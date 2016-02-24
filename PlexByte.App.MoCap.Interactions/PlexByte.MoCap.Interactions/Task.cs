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
    public string Id => _id;

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
    public DateTime CreatedDateTime => _createdDateTime;

    /// <summary>
    /// The date and time the task was last modified
    /// </summary>
    public DateTime ModifiedDateTime => _modifiedDateTime;

    /// <summary>
    /// Flag indicating whether or not the task can be worked on
    /// </summary>
    public bool IsActive => _isActive;

    /// <summary>
    /// The text of this task (description)
    /// </summary>
    public string Text { get; set; }
    /// <summary>
    /// The type of interaction (will be always task)
    /// </summary>
    public InteractionType Type { get; } = InteractionType.Task;
    /// <summary>
    /// The user that created the task
    /// </summary>
    public IUser Creator => _creator;

    /// <summary>
    /// The user currently owning the task
    /// </summary>
    public IUser Owner => _owner;

    /// <summary>
    /// The state of the task
    /// </summary>
    public InteractionState State => _state;

    /// <summary>
    /// The tasks budget
    /// </summary>
    public decimal Budget => _budget;

    /// <summary>
    /// The task duration in seconds
    /// </summary>
    public int Duration => _duration;

    /// <summary>
    /// The priority of this task
    /// </summary>
    public int Priority => _priority;

    /// <summary>
    /// The time currently spent on this task in seconds
    /// </summary>
    public int DurationCurrent { get; } = 0;

    /// <summary>
    /// The investment currently made in this task
    /// </summary>
    public decimal BudgetUsed { get; } = 0;
    /// <summary>
    /// The list of sub tasks assigned
    /// </summary>
    public List<ITask> SubTasks => _subTasks;

    /// <summary>
    /// The progresss of the task
    /// </summary>
    public int Progress => _progress;

    public DateTime DueDateTime => _dueDateTime;

    #endregion

    #region Variables

    private string _id;
    private DateTime _createdDateTime;
    private DateTime _modifiedDateTime;
    private DateTime _dueDateTime;
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
    private System.Timers.Timer _stateTimer = new System.Timers.Timer(60 * 1000);

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
            new decimal(0.00),
            0,
            null,
            0)
    {
    }

    public Task(string pId, string pText, IUser pCreator, DateTime pStartDt, DateTime pEndDt, DateTime pDueDt):
        this(pId,
            pText,
            pCreator,
            pStartDt,
            pEndDt,
            pDueDt,
            0,
            0,
            1,
            InteractionState.Active,
            new decimal(0.00),
            0,
            null,
            0)
    { }

    public Task(string pId,string pText,IUser pCreator,DateTime pStartDt,DateTime pEndDt,DateTime pDueDt,decimal pBudget,int pDuration,int pPriority,InteractionState pState,decimal pBudgetUsed, int pTimeUsed, List<ITask> pSubTask,int pProgress)
    {
        InitializeProperties(pId, pText, pCreator, pStartDt, pEndDt, pDueDt, pBudget, pDuration, pPriority, false, 
            InteractionType.Task, pCreator, pState, pBudgetUsed, pTimeUsed, pSubTask, pProgress);
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
            List<InteractionAttributes> changedAttrs = new List<InteractionAttributes> {InteractionAttributes.Owner};
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
                List<InteractionAttributes> changedAttrs = new List<InteractionAttributes> {InteractionAttributes.IsActive};
                OnModify(new InteractionEventArgs("IsActive state changed", DateTime.Now, InteractionType.Task, 
                    changedAttrs));
            }
        }
    }

    public virtual void AddTimeslice(int pDuration)
    {
        // Update current duration
        _duration += pDuration;
        List<InteractionAttributes> changedAttrs = new List<InteractionAttributes> {InteractionAttributes.UsedDuration};
        OnModify(new InteractionEventArgs("Time used changed", DateTime.Now, InteractionType.Task,
            changedAttrs));
    }

    public virtual void AddExpense(decimal pExpenseValue)
    {
        // Update budget used
        _budgetUsed += pExpenseValue;
        List<InteractionAttributes> changedAttrs = new List<InteractionAttributes> {InteractionAttributes.UsedBudget};
        OnModify(new InteractionEventArgs("Budget used changed", DateTime.Now, InteractionType.Task,
            changedAttrs));
    }

    public void ChangeState(InteractionState pState)
    {
        this._state = pState;
        switch (pState)
        {
            case InteractionState.Finished:
                ChangeIsActive(false);
                break;
            case InteractionState.Cancelled:
                ChangeIsActive(false);
                break;
            case InteractionState.Queued:
                ChangeIsActive(false);
                break;
            default:
                ChangeIsActive(true);
                break;
        }

        List<InteractionAttributes> changedAttributes = new List<InteractionAttributes> {InteractionAttributes.State, InteractionAttributes.IsActive};
        OnStateChanged(new InteractionEventArgs($"Survey state changed [Id={Id}]", DateTime.Now, InteractionType.Task));
    }

    public void AddSubTask(ITask pTask) { }

    public void UdateProgress(int pProgress)
    {
        if (pProgress > 0)
        {
            _progress = ((pProgress + _progress) >= 100) ? 100 :
            _progress + pProgress;

            if (_progress + pProgress == 100)
            {
                ChangeState(InteractionState.Finished);
                ChangeIsActive(false);
            }
            else
            {
                List<InteractionAttributes> changedAttributes = new List<InteractionAttributes> { InteractionAttributes.Progress };
                OnModify(new InteractionEventArgs($"Progress changed [NewValue={_progress}] [TaskId={_id}]", DateTime.Now,
                    InteractionType.Task, changedAttributes));
            }

        }
    }

    #endregion

    #region Private Methods

    private void InitializeProperties(string pId, string pText, IUser pCreator, DateTime pStartDt, DateTime pEndDt, 
        DateTime pDueDt, decimal pBudget, int pDuration, int pPriority, bool pIsActive, InteractionType pType, 
        IUser pOwner, InteractionState pState, decimal pBudgetUsed,
        int pTimeUsed, List<ITask> pSubTask, 
        int pProgress)
    {
        if(!string.IsNullOrEmpty(pId))
            _id = pId;
        else
            _id = Helper.GenerateId();
        _dueDateTime = pDueDt;
        StartDateTime = pStartDt;
        EndDateTime = pEndDt;
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
        _budgetUsed = pBudgetUsed;
        _durationCurrent = pTimeUsed;
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

        _stateTimer.Elapsed += OnTimerElapsed;
        _stateTimer.AutoReset = false;
        _stateTimer.Start();
    }

    private void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        if (_state == InteractionState.Active || _state == InteractionState.Queued)
        {
            // Expired?
            if (DueDateTime <= DateTime.Now)
                ChangeState(InteractionState.Expired);
            // Turns active?
            if (StartDateTime <= DateTime.Now && _state == InteractionState.Queued)
                ChangeState(InteractionState.Active);
            // Finished, as progress >=100
            if (Progress>=100)
                ChangeState(InteractionState.Finished);
        }

        // Still active?
        if (_state == InteractionState.Active || _state == InteractionState.Queued)
            _stateTimer.Start();
    }

    #endregion
}