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

    /// <summary>
    /// The worktime of the user
    /// </summary>
    public int Duration { get; private set; }
    /// <summary>
    /// Owner of the time in the timeslice
    /// </summary>
    public IUser User { get; private set; }
    /// <summary>
    /// The unique id of the task
    /// </summary>
    public string Id { get; private set; }
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
    public DateTime CreatedDateTime { get; private set; }
    /// <summary>
    /// The date and time the task was last modified
    /// </summary>
    public DateTime ModifiedDateTime { get; private set; }
    /// <summary>
    /// Flag indicating whether or not the task can be worked on
    /// </summary>
    public bool IsActive { get; private set; }
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
    public IUser Creator { get; private set; }
    /// <summary>
    /// The user currently owning the task
    /// </summary>
    public IUser Owner { get; private set; }
    /// <summary>
    /// The state of the task
    /// </summary>
    public InteractionState State { get; private set; }

    #endregion

    #region Variables
    
    private System.Timers.Timer _stateTimer = new System.Timers.Timer(60 * 1000);

    #endregion

    #region Events
    public event Complete Completed;
    public event Modify Modified;
    public event StateChange StateChanged;
    #endregion

    #region Ctor & Dtor

    /// <summary>
    /// Constructor of the class
    /// </summary>
    /// <param name="pId"></param>
    /// <param name="pUser"></param>
    /// <param name="pDuration"></param>
    public Timeslice(string pId, IUser pUser, int pDuration)
    {
        InitializeProperties(pId, pUser, pDuration);
    }

    /// <summary>
    /// Constructor of the class
    /// </summary>
    /// <param name="pId"></param>
    /// <param name="pUser"></param>
    /// <param name="pStartDT"></param>
    /// <param name="pEndDT"></param>
    public Timeslice(string pId, IUser pUser, DateTime pStartDT, DateTime pEndDT)
    {
        int pDuration = CalculateDuration(pStartDT, pEndDT);
        InitializeProperties(pId, pUser, pDuration);
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

    /// <summary>
    /// Calculates the duration between the start and end of a worksession
    /// </summary>
    /// <param name="pStartDT"></param>
    /// <param name="pEndDT"></param>
    /// <returns></returns>
	public virtual int CalculateDuration(DateTime pStartDT, DateTime pEndDT)
    {
        TimeSpan timespan = pStartDT - pEndDT;
        return int.Parse(timespan.Minutes.ToString());
    }

    /// <summary>
    /// This method changes the owner of the project and raises the modified event if the owner is different
    /// used to create a secound project-admin
    /// </summary>
    /// <param name="pUser"></param>
    public virtual void ChangeOwner(IUser pUser)
    {
        if (Owner != pUser)
        {
            Owner = pUser;
            List<InteractionAttributes> changedAttributes = new List<InteractionAttributes>();
            changedAttributes.Add(InteractionAttributes.Owner);
            OnModify(new InteractionEventArgs($"Survey owner changed [Id={Id}]", DateTime.Now, InteractionType.Account));
        }
    }

    /// <summary>
    /// This method changes the active flag of the object. This can occure if the item expired, finished or was 
    /// cancelled. It will raise the Modified event once changed
    /// </summary>
    /// <param name="pActive"></param>
	public virtual void ChangeIsActive(bool pActive)
    {
        if (IsActive != pActive)
        {
            IsActive = pActive;
            List<InteractionAttributes> changedAttributes = new List<InteractionAttributes>();
            changedAttributes.Add(InteractionAttributes.IsActive);
            OnModify(new InteractionEventArgs($"Survey IsActive changed [Id={Id}]", DateTime.Now, InteractionType.Account));
        }
    }

    /// <summary>
    /// Changes the state of this interaction and thus causes the stateCHanged event to be fired
    /// </summary>
    /// <param name="pState"></param>
	public virtual void ChangeState(InteractionState pState)
    {
        this.State = pState;
        if (State == InteractionState.Finished ||
            State == InteractionState.Cancelled ||
            State == InteractionState.Expired)
            ChangeIsActive(false);
        List<InteractionAttributes> changedAttributes = new List<InteractionAttributes>();
        changedAttributes.Add(InteractionAttributes.State);
        OnStateChanged(new InteractionEventArgs($"Survey state changed [Id={Id}]", DateTime.Now, InteractionType.Account));
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
    private void InitializeProperties(string pId, IUser pUser, int pDuration)
    {
        Id = pId;
        User = pUser;
        Duration = pDuration;
        CreatedDateTime = DateTime.Now;
        ModifiedDateTime = DateTime.Now;
        StartDateTime = DateTime.Now;
        EndDateTime = default(DateTime);
        IsActive = true;
        State = StartDateTime <= DateTime.Now ? InteractionState.Active : InteractionState.Queued;
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
        if (State == InteractionState.Active || State == InteractionState.Queued)
        {
            // Behind schedule?
            if (EndDateTime <= DateTime.Now)
                ChangeState(InteractionState.Expired);
            // Turns active?
            if (StartDateTime <= DateTime.Now && State == InteractionState.Queued)
                ChangeState(InteractionState.Active);
            // Finished if project is closed?
            if (IsActive == false)
                ChangeState(InteractionState.Finished);
        }

        // Still active?
        if (State == InteractionState.Active || State == InteractionState.Queued)
            _stateTimer.Start();
    }

    #endregion
}

