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
    public IEnumerable<ITimeslice> TimesliceList { get; set; }
    public IEnumerable<IExpense> ExpenseList { get; set; }
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
    public virtual void ChangeOwner(IUser pUser)
	{
		throw new System.NotImplementedException();
	}

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

	public virtual void ProjectView(IProject pProject)
	{
		throw new System.NotImplementedException();
	}

	public virtual void UserView(IProject pProject, IUser pUser)
	{
		throw new System.NotImplementedException();
	}

    /// <summary>
    /// 
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
        OnStateChanged(new InteractionEventArgs($"Survey state changed [Id={Id}]", DateTime.Now, InteractionType.Survey));
    }
    #endregion

    #region Private methods
    /// <summary>
    /// 
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
            // Expired?
            if (DueDateTime <= DateTime.Now)
                ChangeState(InteractionState.Expired);
            // Turns active?
            if (StartDateTime <= DateTime.Now && _state == InteractionState.Queued)
                ChangeState(InteractionState.Active);
            // Finished, as all votes were made?
            if (_voteList.Count >= UserList.Count * MaxVotesPerUser)
                ChangeState(InteractionState.Finished);
        }

        // Still active?
        if (_state == InteractionState.Active || _state == InteractionState.Queued)
            _stateTimer.Start();
    }
    #endregion
}

