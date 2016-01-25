using System;
using System.Collections.Generic;
using System.Linq;

namespace MoCap.Interactions
{
    [Serializable]
    public class Task : IInteraction
    {
        #region Delegates

        public delegate void ProgressUpdateEventHandler(object sender, TaskEventArgs e);
        public delegate void CompleteEventHandler(object sender, TaskEventArgs e);
        public delegate void ExceedBudgetEventHandler(object sender, TaskEventArgs e);
        public delegate void GoOverdueEventHandler(object sender, TaskEventArgs e);
        public delegate void StartEventHandler(object sender, TaskEventArgs e);
        public delegate void EndEventHandler(object sender, TaskEventArgs e);
        public delegate void AddExpenseEventHandler(object sender, TaskEventArgs e);

        #endregion

        #region Events

        public event ProgressUpdateEventHandler ProgressUpdated;
        public event CompleteEventHandler Completed;
        public event ExceedBudgetEventHandler ExceededBudget;
        public event GoOverdueEventHandler GotOverdue;
        public event AddExpenseEventHandler AddedExpense;
        public event StartEventHandler Started;
        public event EndEventHandler Ended;

        #endregion

        #region Properties

        public long ID { get; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Priority { get; set; }
        public decimal Duration { get; }
        public decimal DurationUsed { get { return durationUsed; } }
        public decimal Budget { get; }
        public decimal BudgetUsed { get; set; }
        public long CreatorID { get; }
        public long OwnerID { get; set; }
        public long ProjectID { get; set; }
        public bool IsCompleted { get { return isCompleted; } }
        public decimal CompletedRate { get { return completedRate; } }
        public bool IsPersonal { get { return isPersonal; } }
        public List<long> SubTaskIDs { get; set; }
        public List<long> ExpenseIDs { get; set; }
        public DateTime Created { get; }
        public DateTime Modified { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime Due { get; set; }

        #endregion

        #region Variables

        decimal completedRate = 0.00m;
        decimal durationUsed = 0.00m;
        bool isCompleted = false;
        bool isPersonal = false;

        #endregion

        #region Ctor & Dtor

        Task(long pID, string pText, DateTime pStart, DateTime pEnd, long pOwnerID, long pCreatorID, decimal pDuration, 
            long pProjectId, bool pIsCompleted, List<long> pSubTaskIds, List<long> pExpenseIds, DateTime pCreate, 
            DateTime pDue, decimal pBudget = 0.00m)
        {
            ID = pID;
            Text = pText;
            Start = pStart;
            End = pEnd;
            OwnerID = pOwnerID;
            CreatorID = pCreatorID;
            ProjectID = pProjectId;
            SubTaskIDs = pSubTaskIds;
            ExpenseIDs = pExpenseIds;
            if (CreatorID == OwnerID)
                isPersonal = true;
            else
                isPersonal = false;
            Priority = 50;
            Duration = pDuration;
            Budget = pBudget;
            Created = pCreate;
            Due = pDue;
            Modified = DateTime.Now;
        }

        #endregion

        #region Methods

        public void AddSubTask(long pTaskID)
        {
            if (SubTaskIDs == null) { SubTaskIDs = new List<long>(); }
            SubTaskIDs.Add(pTaskID);
            Modified = DateTime.Now;
        }

        public void RemoveSubTask(long pTaskID)
        {
            if (SubTaskIDs != null)
            {
                if (SubTaskIDs.Contains(pTaskID))
                    SubTaskIDs.Remove(pTaskID);
            }
            Modified = DateTime.Now;
        }

        //TODO: <MoCap.Interactions.Task> Implement this method to get a task by id from the InteractionManager
        // in the MoCap.Manager solution. For now we return null
        public Task GetSubTask(long pTaskId)
        {
            Task tmp = null;

            return tmp;
        }

        //TODO: <MoCap.Interactions.Task> Implement send method
        public void Send()
        {
            Modified = DateTime.Now;
        }

        public void UpdateProgress(decimal pMinutes, bool pIsCompleted)
        {
            if (!IsCompleted)
            {
                durationUsed += pMinutes;
                isCompleted = pIsCompleted;
                if (Duration > 0.00m)
                {
                    if (durationUsed / Duration <= 1)
                        completedRate = (durationUsed / Duration) * 100;
                    else
                        OnExceededBudget(new TaskEventArgs(this, "Time spent is over budget"));
                }
                if (IsCompleted)
                {
                    OnProgressUpdated(new TaskEventArgs(this, String.Format(@"Task has completed [TotalMinutes={0}] 
                        [IsCompleted={1}]", durationUsed, pIsCompleted)));
                }
                else
                {
                    OnProgressUpdated(new TaskEventArgs(this, String.Format(@"Progress was updated [Minutes={0}] 
                        [IsCompleted={1}]", pMinutes, pIsCompleted)));
                    if (Due > new DateTime(1970, 1, 30))
                    {
                        // overdue?
                        if (Due < DateTime.Now)
                            OnGotOverdue(new TaskEventArgs(this, String.Format(@"Task is overdue! [DueDate={0}] 
                            [DateNow={1}]", Due, DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss.fff"))));
                    }
                }
            }
            else
                throw new Exception("Task is already completed. No more changes allowed");
            Modified = DateTime.Now;
        }

        public void UpdateProgress(int pMinutes, int pCompletedPercent, bool pIsCompleted)
        {
            if (!IsCompleted)
            {
                durationUsed += pMinutes;
                isCompleted = pIsCompleted;
                completedRate = pCompletedPercent;
                if (Duration > 0.00m)
                {
                    if (durationUsed / Duration > 1)
                        OnExceededBudget(new TaskEventArgs(this, "Time spent is over budget"));

                }
                if (IsCompleted)
                {
                    OnProgressUpdated(new TaskEventArgs(this, String.Format(@"Task has completed [TotalMinutes={0}] 
                        [IsCompleted={1}]", durationUsed, pIsCompleted)));
                }
                else
                {
                    OnProgressUpdated(new TaskEventArgs(this, String.Format(@"Progress was updated [Minutes={0}] 
                        [IsCompleted={1}] [CompletedPercent={2}]", pMinutes, pIsCompleted, pCompletedPercent)));
                }
            }
            else
                throw new Exception("Task is already completed. No more changes allowed");
            Modified = DateTime.Now;
        }

        //TODO: <MoCap.Interactions.Task> Implement AddExpense method
        public void AddExpense()
        {

            Modified = DateTime.Now;
        }

        #endregion

        #region Event handlers

        protected virtual void OnProgressUpdated(TaskEventArgs e)
        {
            if (ProgressUpdated != null)
                ProgressUpdated(this, e);
        }

        protected virtual void OnCompleted(TaskEventArgs e)
        {
            if (Completed != null)
                Completed(this, e);
        }

        protected virtual void OnExceededBudget(TaskEventArgs e)
        {
            if (ExceededBudget != null)
                ExceededBudget(this, e);
        }

        protected virtual void OnGotOverdue(TaskEventArgs e)
        {
            if (GotOverdue != null)
                GotOverdue(this, e);
        }

        protected virtual void OnAddedExpense(TaskEventArgs e)
        {
            if (AddedExpense != null)
                AddedExpense(this, e);
        }

        protected virtual void OnStarted(TaskEventArgs e)
        {
            if (Started != null)
                Started(this, e);
        }

        protected virtual void OnEnded(TaskEventArgs e)
        {
            if (Ended != null)
                Ended(this, e);
        }

        #endregion
    }

    // TODO: <MoCap.Interactions.Task> Remove this class once the final Expense class is completed
    public class Expense
    { }
}
