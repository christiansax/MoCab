//////////////////////////////////////////////////////////////
//                      Class Account                              
//      Author: Fabian Ochsner            Date:   2016/02/19
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Account : IAccount, IInteraction
{
    #region Properties
    public List<IExpense> ExpenseList { get; set; }
    public List<ITimeslice> TimesliceList { get; set; }
    public IEnumerable<ITask> TaskList { get; set; }
    public string Id { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime ModifiedDateTime { get; set; }
    public bool IsActive { get; set; }
    public string Text { get; set; }
    public InteractionType Type { get; set; }
    public IUser Creator { get; set; }
    public IUser Owner { get; set; }
    public InteractionState State { get; set; }


    #endregion

    #region Variables
    private IUser _creator;
    private DateTime _modifiedDateTime;
    private DateTime _createdDateTime;
    private System.Timers.Timer _stateTimer = new System.Timers.Timer(60 * 1000);
    private InteractionState _state;
    private bool _isActive;
    private string _id;

    #endregion

    #region Events
    public event Complete Completed;
    public event Modify Modified;
    public event StateChange StateChanged;
    #endregion

    #region Ctor & Dtor

    #endregion

    #region Event raising methods
    public virtual void OnComplete(InteractionEventArgs pEventArgs)
	{
		throw new System.NotImplementedException();
	}
    public virtual void OnModify(InteractionEventArgs pEventArgs)
    {
        throw new System.NotImplementedException();
    }

    public virtual void OnStateChanged(InteractionEventArgs pEventArgs)
    {
        throw new System.NotImplementedException();
    }
    #endregion

    #region Public methods

    /// <summary>
    /// A method not needed
    /// </summary>
    /// <param name="pUser"></param>
    public virtual void ChangeOwner(IUser pUser)
	{
		throw new System.NotImplementedException();
	}

    /// <summary>
    /// This method changes the active flag of the object. This can occure if the item expired, finished or was 
    /// cancelled. It will raise the Modified event once changed
    /// </summary>
    /// <param name="pActive"></param>
	public virtual void ChangeIsActive(bool pActive)
	{
        if (_isActive != pActive)
        {
            _isActive = pActive;
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
        this._state = pState;
        if (_state == InteractionState.Finished ||
            _state == InteractionState.Cancelled ||
            _state == InteractionState.Expired)
            ChangeIsActive(false);
        List<InteractionAttributes> changedAttributes = new List<InteractionAttributes>();
        changedAttributes.Add(InteractionAttributes.State);
        OnStateChanged(new InteractionEventArgs($"Survey state changed [Id={Id}]", DateTime.Now, InteractionType.Account));
    }

    /// <summary>
    /// Adds a "expense" to the expenselist
    /// </summary>
    /// <param name="pExpense"></param>
    public void AddExpense(IExpense pExpense)
    {
        ExpenseList.Add(pExpense);
        List<InteractionAttributes> changedAttributes = new List<InteractionAttributes>();
        changedAttributes.Add(InteractionAttributes.ExpenseList);
        OnModify(new InteractionEventArgs($"Survey IsActive changed [Id={Id}]", DateTime.Now, InteractionType.Account));
    }

    /// <summary>
    /// Adds a "timeslice" to the timeslicelist
    /// </summary>
    /// <param name="pTimeslice"></param>
    public void AddTimeslice(ITimeslice pTimeslice)
    {
        TimesliceList.Add(pTimeslice);
        List<InteractionAttributes> changedAttributes = new List<InteractionAttributes>();
        changedAttributes.Add(InteractionAttributes.TimesliceList);
        OnModify(new InteractionEventArgs($"Survey IsActive changed [Id={Id}]", DateTime.Now, InteractionType.Account));
    }

    public void EditExpense(IExpense pExpense)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Deletes a "expense" object if it exists in the expenselist
    /// </summary>
    /// <param name="pExpense"></param>
    public void DeleteExpense(IExpense pExpense)
    {
        if (ExpenseList.Contains(pExpense))
        {
            ExpenseList.Remove(pExpense);
            List<InteractionAttributes> changedAttributes = new List<InteractionAttributes>();
            changedAttributes.Add(InteractionAttributes.ExpenseList);
            OnModify(new InteractionEventArgs($"Survey user list changed [Id={Id}]", DateTime.Now, InteractionType.Account));
        }
    }

    public void EditTimeslice(ITimeslice PTimeslice)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Deletes a "timeslice" object if it exists in the timeslicelist
    /// </summary>
    /// <param name="pTimeslice"></param>
    public void DeleteTimeslice(ITimeslice pTimeslice)
    {
        if (TimesliceList.Contains(pTimeslice))
        {
            TimesliceList.Remove(pTimeslice);
            List<InteractionAttributes> changedAttributes = new List<InteractionAttributes>();
            changedAttributes.Add(InteractionAttributes.TimesliceList);
            OnModify(new InteractionEventArgs($"Survey user list changed [Id={Id}]", DateTime.Now, InteractionType.Account));
        }
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
    private void InitializeProperties(string pId, string pText, List<IUser> pMemberList, List<IUser> pInvitationList, IUser pCreator)
    {
        _id = pId;
        _creator = pCreator;
        Text = pText;
        _createdDateTime = DateTime.Now;
        _modifiedDateTime = DateTime.Now;
        StartDateTime = DateTime.Now;
        EndDateTime = default(DateTime);
        _isActive = true;
        Type = InteractionType.Project;
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
            //// Expired?
            //if (DueDateTime <= DateTime.Now)
            //    ChangeState(InteractionState.Expired);
            //// Turns active?
            //if (StartDateTime <= DateTime.Now && _state == InteractionState.Queued)
            //    ChangeState(InteractionState.Active);
            //// Finished, as all votes were made?
            //if (_voteList.Count >= UserList.Count * MaxVotesPerUser)
            //    ChangeState(InteractionState.Finished);
        }

        // Still active?
        if (_state == InteractionState.Active || _state == InteractionState.Queued)
            _stateTimer.Start();
    }

    #endregion
}

