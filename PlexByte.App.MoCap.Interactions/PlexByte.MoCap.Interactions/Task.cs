﻿//////////////////////////////////////////////////////////////
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

    public string Id { get { return _id; } }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public DateTime CreatedDateTime { get { return _createdDateTime; } }
    public DateTime ModifiedDateTime { get { return _modifiedDateTime; } }
    public bool IsActive { get { return _isActive; } }
    public string Text { get; set; }
    public InteractionType Type { get; set; }
    public IUser Creator { get { return _creator; } }
    public IUser Owner { get { return _owner; } }
    public InteractionState State { get { return _state; } }
    public decimal Budget { get { return _budget; } }
    public int Duration { get { return _duration; } }
    public int Priority { get { return _priority; } }
    public int DurationCurrent { get; set; }
    public decimal BudgetUsed { get; set; }
    public List<ITimeslice> TimesliceList { get { return _timesliceList; } }
    public List<IExpense> ExpenseList { get { return _expenseList; } }
    public List<ITask> SubTasks { get { return _subTasks; } }
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
    private decimal _budget;
    private int _duration;
    private int _priority;
    private List<ITimeslice> _timesliceList;
    private List<IExpense> _expenseList;
    private List<ITask> _subTasks;
    private int _progress = 0;

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
        _id = pId;
        StartDateTime = pStartDT;
        EndDateTime = pEndDT;
        _createdDateTime = DateTime.Now;
        _modifiedDateTime = DateTime.Now;
        _isActive = pIsActive;
        Text = pText;
        Type = pType;
        _creator = pCreator;
        _owner = pOwner;
        _state = pState;
        _budget = pBudget;
        _duration = pDuration;
        _priority = pPriority;
        DurationCurrent = 0;
        BudgetUsed = 0;
        _expenseList = (pExpenses != null) ? pExpenses : new List<IExpense>();
        _timesliceList = (pExpenses != null) ? pTime : new List<ITimeslice>();
        _subTasks = (pSubTask != null) ? pSubTask : new List<ITask>();
        DurationCurrent = _timesliceList.Sum(x => x.Duration);
        BudgetUsed = _expenseList.Sum(x => x.Value);
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