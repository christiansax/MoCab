//////////////////////////////////////////////////////////////
//                      Class Timeslice                              
//      Author: Fabian Ochsner            Date:   2016/02/23
//      Implementation of ITimeslice interface, handles the time spent on a Task or Project
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Timeslice : ITimeslice, IInteraction
{
    #region Properties
    public int Duration { get; set; }

    public IUser User { get { return _user; } }
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

    #endregion

    #region Variables

    private IUser _owner;
    private IUser _creator;
    private DateTime _modifiedDateTime;
    private DateTime _createdDateTime;
    private System.Timers.Timer _stateTimer = new System.Timers.Timer(60 * 1000);
    private InteractionState _state;
    private bool _isActive;
    private string _id;
    private List<IExpense> _expenseList;
    private List<ITimeslice> _timesliceList;
    private IUser _user;
    private DateTime _startDT;
    private DateTime _endDT;

    #endregion

    #region Events
    public event Complete Completed;
    public event Modify Modified;
    public event StateChange StateChanged;
    #endregion

    #region Ctor & Dtor


    public Timeslice(string pId, IUser pUser, int pDuration)
    {
        DateTime pStartDT = new DateTime();
        DateTime pEndDT = new DateTime();

        InitializeProperties(pId, pUser, pStartDT, pEndDT);

    }

    public Timeslice(string pId, IUser pUser, DateTime pStartDT, DateTime pEndDT)
    {
        InitializeProperties(pId, pUser, pStartDT, pEndDT);

    }

    #endregion

    #region Event raising methods
    /// <summary>
    /// This method raises the corresponding event in case subscribers are registered
    /// </summary>
    /// <param name="pEventArgs"></param>
    public virtual void OnComplete(InteractionEventArgs pEventArgs)
    {
        Completed?.Invoke(this, pEventArgs);
    }

    /// <summary>
    /// This method raises the corresponding event in case subscribers are registered
    /// </summary>
    /// <param name="pEventArgs"></param>
    public virtual void OnModify(InteractionEventArgs pEventArgs)
    {
        Modified?.Invoke(this, pEventArgs);
    }

    /// <summary>
    /// This method raises the corresponding event in case subscribers are registered
    /// </summary>
    /// <param name="pEventArgs"></param>
    public virtual void OnStateChanged(InteractionEventArgs pEventArgs)
    {
        StateChanged?.Invoke(this, pEventArgs);
    }
    #endregion


    #region Public methods

	public virtual int CalculateDuration(DateTime pStartDT, DateTime pEndDT)
	{
		throw new System.NotImplementedException();
	}

    public void ChangeState(InteractionState pState)
    {
        throw new NotImplementedException();
    }

    public void ChangeOwner(IUser pUser)
    {
        throw new NotImplementedException();
    }

    public void ChangeIsActive(bool pActive)
    {
        throw new NotImplementedException();
    }

#endregion

    #region Private methods
    /// <summary>
    /// Initializes all attributes and started the state timer, which validates the interaction's state every 60
    /// </summary>
    /// <param name="pId"></param>
    /// <param name="pText"></param>
    /// <param name="pMemberList"></param>
    /// <param name="pInvitationList"></param>
    /// <param name="pCreator"></param>
    private void InitializeProperties(string pId, IUser pUser, DateTime pStartDT, DateTime pEndDT)
    {
        _id = pId;
        _user = pUser;
        _startDT = pStartDT;
        _endDT = pEndDT;
        _createdDateTime = DateTime.Now;
        _modifiedDateTime = DateTime.Now;
        StartDateTime = DateTime.Now;
        EndDateTime = default(DateTime);
        _isActive = true;
        _state = StartDateTime <= DateTime.Now ? InteractionState.Active : InteractionState.Queued;
        _stateTimer.Elapsed += OnTimerElapsed;
        _stateTimer.AutoReset = false;
        _stateTimer.Start();
    }

    /// <summary>
    /// This method validates the object state and chages if required. Once the interaction is either 
    /// cancelled, finished or expired the state check will suspend
    /// </summary>
    /// <param name="sender">The object calling this method (timer)</param>
    /// <param name="e">The event parameters passed</param>
    private void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        if (_state == InteractionState.Active || _state == InteractionState.Queued)
        {
            // Behind schedule?
            if (EndDateTime <= DateTime.Now)
                ChangeState(InteractionState.Expired);
            // Turns active?
            if (StartDateTime <= DateTime.Now && _state == InteractionState.Queued)
                ChangeState(InteractionState.Active);
            // Finished if project is closed?
            if (IsActive == false)
                ChangeState(InteractionState.Finished);
        }

        // Still active?
        if (_state == InteractionState.Active || _state == InteractionState.Queued)
            _stateTimer.Start();
    }


    #endregion
}

