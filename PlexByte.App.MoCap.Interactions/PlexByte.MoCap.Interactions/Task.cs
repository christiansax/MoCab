//////////////////////////////////////////////////////////////
//                      Class Task                              
//      Author: Christian B. Sax            Date:   2016/02/23
//      Implementation of ITask interface, representing a piece of work
using System;
using System.Collections.Generic;
using System.Linq;

public class Task : IInteraction,
    ITask
{
    #region Properties

    /// <summary>
    /// The unique id of the task
    /// </summary>
    public string Id { get { return _id; } }
    /// <summary>
    /// The date and time this task becomes active and can be worked on. As long as this date is not reached the 
    /// state will remain queued and no work can be performed on the task as longs as it is in state queued
    /// </summary>
    public DateTime StartDateTime { get; set; }
    /// <summary>
    /// The date and time this task should be finished. If this date is reached the state will change to expired
    /// </summary>
    public DateTime EndDateTime { get; set; }
    /// <summary>
    /// The date and time the task was created
    /// </summary>
    public DateTime CreatedDateTime { get { return _createdDateTime; } }
    /// <summary>
    /// The date and time the task was last modified
    /// </summary>
    public DateTime ModifiedDateTime { get { return _modifiedDateTime; } }
    /// <summary>
    /// Flag indicating whether or not the task can be worked on
    /// </summary>
    public bool IsActive { get { return _isActive; } }
    /// <summary>
    /// The text of this task (description)
    /// </summary>
    public string Text { get; set; }
    /// <summary>
    /// The type of interaction (will be always task)
    /// </summary>
    public InteractionType Type { get; }
    /// <summary>
    /// The user that created the task
    /// </summary>
    public IUser Creator { get { return _creator; } }
    /// <summary>
    /// The user currently owning the task
    /// </summary>
    public IUser Owner { get { return _owner; } }
    /// <summary>
    /// The state of the task
    /// </summary>
    public InteractionState State { get { return _state; } }
    /// <summary>
    /// The tasks budget
    /// </summary>
    public decimal Budget { get { return _budget; } }
    /// <summary>
    /// The task duration in seconds
    /// </summary>
    public int Duration { get { return _duration; } }
    /// <summary>
    /// The priority of this task
    /// </summary>
    public int Priority { get { return _priority; } }
    /// <summary>
    /// The time currently spent on this task in seconds
    /// </summary>
    public int DurationCurrent { get; }
    /// <summary>
    /// The investment currently made in this task
    /// </summary>
    public decimal BudgetUsed { get; }
    /// <summary>
    /// The list of sub tasks assigned
    /// </summary>
    public List<ITask> SubTasks { get { return _subTasks; } }
    /// <summary>
    /// The progresss of the task
    /// </summary>
    public int Progress { get { return _progress; } }

    #endregion

    #region Variables

    private string _id;
    private DateTime _createdDateTime;
    private DateTime _modifiedDateTime;
    private bool _isActive;
    private IUser _creator;
    private IUser _owner;
    private InteractionState _state;
    private InteractionType _type;
    private decimal _budget;
    private int _duration;
    private int _priority;
    private List<ITask> _subTasks;
    private int _progress = 0;
    private int _durationCurrent = 0;
    private decimal _budgetUsed = new decimal(0.00);

    #endregion

    #region Events

    public event Complete Completed;
    public event Modify Modified;
    public event StateChange StateChanged;

    #endregion

    #region Ctor & Dtor

    public Task(string pId, string pText, IUser pCreator) :
        this(pId,
            pText,
            pCreator,
            DateTime.Now,
            default(DateTime),
            default(DateTime),
            0,
            0,
            1,
            InteractionState.Active,
            null,
            null,
            null,
            0)
    {
    }

    public Task(string pId, string pText, IUser pCreator, DateTime pStartDT, DateTime pEndDT, DateTime pDueDT):
        this(pId,
            pText,
            pCreator,
            pStartDT,
            pEndDT,
            pDueDT,
            0,
            0,
            1,
            InteractionState.Active,
            null,
            null,
            null,
            0)
    { }

    public Task(string pId,
        string pText,
        IUser pCreator,
        DateTime pStartDT,
        DateTime pEndDT,
        DateTime pDueDT,
        decimal pBudget,
        int pDuration,
        int pPriority,
        InteractionState pState,
        List<IExpense> pExpenses, 
        List<ITimeslice> pTime, 
        List<ITask> pSubTask,
        int pProgress)
    {
        InitializeProperties(pId, pText, pCreator, pStartDT, pEndDT, pDueDT, pBudget, pDuration, pPriority, false, 
            InteractionType.Task, pCreator, pState, pExpenses, pTime, pSubTask, pProgress);
    }

    #endregion

    #region Event raising methods

    public virtual void OnComplete(InteractionEventArgs pEventArgs)
    {
        Completed?.Invoke(this, pEventArgs);
    }

    public void OnStateChanged(InteractionEventArgs pEventArgs)
    {
        StateChanged?.Invoke(this, pEventArgs);
    }

    public virtual void OnModify(InteractionEventArgs pEventArgs)
    {
        Modified?.Invoke(this, pEventArgs);
    }

    #endregion

    #region Public methods

    public virtual void ChangeOwner(IUser pUser)
    {
        if (Owner != pUser)
        {
            _owner = pUser;
            List<InteractionAttributes> changedAttrs = new List<InteractionAttributes>();
            changedAttrs.Add(InteractionAttributes.Owner);
            OnModify(new InteractionEventArgs("Owner changed", DateTime.Now, InteractionType.Task, changedAttrs));
        }
    }

    public virtual void ChangeIsActive(bool pActive)
    {
        if (_state == InteractionState.Active || _state == InteractionState.Queued)
        {
            if (IsActive != pActive)
            {
                _isActive = pActive;
                List<InteractionAttributes> changedAttrs = new List<InteractionAttributes>();
                changedAttrs.Add(InteractionAttributes.IsActive);
                OnModify(new InteractionEventArgs("IsActive state changed", DateTime.Now, InteractionType.Task, 
                    changedAttrs));
            }
        }
    }

    public virtual void AddTimeslice(ITimeslice pTimeslice)
    {
        // Update current duration
        _duration += pTimeslice.Duration;
    }

    public virtual void AddExpense(IExpense pExpense) { throw new System.NotImplementedException(); }

    public void ChangeState(InteractionState pState) { throw new NotImplementedException(); }

    #endregion

    #region Private Methods

    private void InitializeProperties(string pId, string pText, IUser pCreator, DateTime pStartDT, DateTime pEndDT, 
        DateTime pDueDT, decimal pBudget, int pDuration, int pPriority, bool pIsActive, InteractionType pType, 
        IUser pOwner, InteractionState pState, List<IExpense> pExpenses, List<ITimeslice> pTime, List<ITask> pSubTask, 
        int pProgress)
    {
        if(pId!=null && pId.Length>0)
            _id = pId;
        else
            _id = Helper.GenerateId();

        StartDateTime = pStartDT;
        EndDateTime = pEndDT;
        _createdDateTime = DateTime.Now;
        _modifiedDateTime = DateTime.Now;
        _isActive = pIsActive;
        Text = pText;
        _type = pType;
        _creator = pCreator;
        _owner = pOwner;
        _state = pState;
        _budget = pBudget;
        _duration = pDuration;
        _priority = pPriority;
        _subTasks = pSubTask ?? new List<ITask>();
        _budgetUsed = pExpenses?.Sum(x => x.Expenditure) ?? 0;
        _durationCurrent = pTime?.Sum(x => x.Duration) ?? 0;
        if (_subTasks.Count > 0)
        {
            int totalProgress= _subTasks.Sum(x => x.Progress);

            // is completed?
            if (_progress >= _subTasks.Count*100)
            {
                _state = InteractionState.Finished;
                _progress = 100;
            }
            else
            {
                _progress = Convert.ToInt32(
                    Convert.ToDouble(totalProgress)/
                    Convert.ToDouble(_subTasks.Count*100)*
                    Convert.ToDouble(100));
            }
        }
        else
            _progress = pProgress;
    }

    public void UdateProgress(int pProgress)
    {
        throw new NotImplementedException();
    }

    #endregion
}