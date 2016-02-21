//////////////////////////////////////////////////////////////
//                      Class Project                              
//      Author: Fabian Ochsner            Date:   2016/02/19
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Project : IProject, IInteraction
{
    #region Properties
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
    public bool EnableBalance { get; set; }
    public bool EnableSurvey { get; set; }
    public IAccount ProjectAccount { get; set; }
    public List<IUser> InvitationList { get; set; }
    public List<ITask> TaskList { get; set; }
    public List<ISurvey> SurveyList { get; set; }
    public List<IUser> MemberList { get; set; }


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
    /// <param name="pText"></param>
    /// <param name="pCreator"></param>
    public Project(string pId, string pText,bool pEnableBalance, bool pEnableSurvey, IUser pCreator)
    {
        List<IUser> pMemberList = new List<IUser>();
        List<IUser> pInvitationList = new List<IUser>();
        List<ITask> pTaskList = new List<ITask>();
        List<ISurvey> pSurveyList = new List<ISurvey>();

        InitializeProperties(pId, pText, pEnableBalance, pEnableSurvey, pMemberList, pInvitationList, pTaskList, pSurveyList, pCreator);
    }

    /// <summary>
    /// Constructor of the class
    /// </summary>
    /// <param name="pId"></param>
    /// <param name="pText"></param>
    /// <param name="pEnableBalance"></param>
    /// <param name="pEnableSurvey"></param>
    /// <param name="pCreator"></param>
    /// <param name="pMemberList"></param>
    /// <param name="pInvitationList"></param>
    public Project(string pId, string pText, bool pEnableBalance, bool pEnableSurvey, List<IUser> pMemberList, List<IUser> pInvitationList, List<ITask> pTaskList, List<ISurvey> pSurveyList, IUser pCreator)
    {
        InitializeProperties(pId, pText, pEnableBalance, pEnableSurvey, pMemberList, pInvitationList, pTaskList, pSurveyList, pCreator);
    }
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
    /// This method changes the owner of the project and raises the modified event if the owner is different
    /// used to create a secound project-admin
    /// </summary>
    /// <param name="pUser"></param>
    public virtual void ChangeOwner(IUser pUser)
    {
        if (_owner != pUser)
        {
            _owner = pUser;
            List<InteractionAttributes> changedAttributes = new List<InteractionAttributes>();
            changedAttributes.Add(InteractionAttributes.Owner);
            OnModify(new InteractionEventArgs($"Survey owner changed [Id={Id}]", DateTime.Now, InteractionType.Project));
        }
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
            OnModify(new InteractionEventArgs($"Survey IsActive changed [Id={Id}]", DateTime.Now, InteractionType.Project));
        }
    }
    /// <summary>
    /// This method adds a Task to the list of tasks from the project
    /// </summary>
    /// <param name="pTask"></param>
	public virtual void AddTask(ITask pTask)
	{
        TaskList.Add(pTask);
        List<InteractionAttributes> changedAttributes = new List<InteractionAttributes>();
        changedAttributes.Add(InteractionAttributes.TaskList);
        OnModify(new InteractionEventArgs($"Survey IsActive changed [Id={Id}]", DateTime.Now, InteractionType.Project));
    }

    /// <summary>
    /// This method adds a Survey to the list of surveys from the project
    /// </summary>
    /// <param name="pSurvey"></param>
	public virtual void AddSurvey(ISurvey pSurvey)
    {
        SurveyList.Add(pSurvey);
        List<InteractionAttributes> changedAttributes = new List<InteractionAttributes>();
        changedAttributes.Add(InteractionAttributes.SurveyList);
        OnModify(new InteractionEventArgs($"Survey IsActive changed [Id={Id}]", DateTime.Now, InteractionType.Project));
    }

    /// <summary>
    /// To invite a user to a projec, it adds the user to the invitations list
    /// </summary>
    /// <param name="pUser"></param>
	public virtual void Invite(IUser pUser)
	{
        if (!MemberList.Contains(pUser)&& !InvitationList.Contains(pUser))
        {
            InvitationList.Add(pUser);
            List<InteractionAttributes> changedAttributes = new List<InteractionAttributes>();
            changedAttributes.Add(InteractionAttributes.InvitationList);
            OnModify(new InteractionEventArgs($"Survey user list changed [Id={Id}]", DateTime.Now, InteractionType.Project));
        }
    }

    /// <summary>
    /// After a user is invited to a project this method removes the user from the invitation list and adds the same to the member list
    /// </summary>
    /// <param name="pUser"></param>
	public virtual void Accept(IUser pUser)
    {
        if (InvitationList.Contains(pUser))
        {
            InvitationList.Remove(pUser);
            MemberList.Add(pUser);
            List<InteractionAttributes> changedAttributes = new List<InteractionAttributes>();
            changedAttributes.Add(InteractionAttributes.InvitationList);
            OnModify(new InteractionEventArgs($"Survey user list changed [Id={Id}]", DateTime.Now, InteractionType.Project));
        }
    }
    /// <summary>
    /// Remove oneself from the memberlist of the project
    /// </summary>
	public virtual void Leave()
	{
		throw new System.NotImplementedException();
	}

    /// <summary>
    /// Kicks a user from the project. It removes a user from the memberlist
    /// </summary>
    /// <param name="pUser"></param>
	public virtual void KickUser(IUser pUser)
	{
        if (MemberList.Contains(pUser))
        {
            MemberList.Remove(pUser);
            List<InteractionAttributes> changedAttributes = new List<InteractionAttributes>();
            changedAttributes.Add(InteractionAttributes.MemberList);
            OnModify(new InteractionEventArgs($"Survey user list changed [Id={Id}]", DateTime.Now, InteractionType.Project));
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
        OnStateChanged(new InteractionEventArgs($"Survey state changed [Id={Id}]", DateTime.Now, InteractionType.Project));
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
    private void InitializeProperties(string pId, string pText, bool pEnableBalance, bool pEnableSurvey, List<IUser> pMemberList, List<IUser> pInvitationList, List<ITask> pTaskList, List<ISurvey> pSurveyList, IUser pCreator)
    {
        
        _id = pId;
        EnableBalance = pEnableBalance;
        EnableSurvey = pEnableSurvey;
        MemberList = pMemberList;
        InvitationList = pInvitationList;
        TaskList = pTaskList;
        SurveyList = pSurveyList;
        _creator = pCreator;
        Text = pText;
        MemberList = pMemberList;
        InvitationList = pInvitationList;
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
            // Behind schedule?
            if (EndDateTime <= DateTime.Now)
                ChangeState(InteractionState.Behind);
            // Turns active?
            if (StartDateTime <= DateTime.Now && _state == InteractionState.Queued)
                ChangeState(InteractionState.Active);
            // Finished if project is closed?
            if (IsActive==false)
                ChangeState(InteractionState.Finished);
        }

        // Still active?
        if (_state == InteractionState.Active || _state == InteractionState.Queued)
            _stateTimer.Start();
    }
    #endregion
}

