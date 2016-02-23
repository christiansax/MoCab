//////////////////////////////////////////////////////////////
//                      Class Survey                              
//      Author: Christian B. Sax            Date:   2016/02/13
using System;
using System.Collections.Generic;
using System.Linq;

public class Survey : ISurvey,
    IInteraction
{
    #region Properties

    public List<ISurveyOption> OptionList { get; set; }
    public List<IVote> VoteList => _voteList;
    public string Id => _id;
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public DateTime CreatedDateTime => _createdDateTime;
    public DateTime ModifiedDateTime => _modifiedDateTime;
    public bool IsActive => _isActive;
    public string Text { get; set; }
    public InteractionType Type { get; set; }
    public IUser Creator => _creator;
    public IUser Owner => _owner;
    public DateTime DueDateTime { get; set; }
    public InteractionState State => _state;
    public int MaxVotesPerUser { get; set; }
    public List<IUser> UserList { get; set; }

    #endregion

    #region Variables

    private IUser _owner;
    private IUser _creator;
    private DateTime _modifiedDateTime;
    private DateTime _createdDateTime;
    private List<IVote> _voteList;
    private InteractionState _state;
    private System.Timers.Timer _stateTimer = new System.Timers.Timer(60*1000);
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
    /// <param name="pId">The id of the interaction</param>
    /// <param name="pText">The text of the survey</param>
    /// <param name="pOptions">The options available</param>
    /// <param name="pCreator">The creator of this survey</param>
    public Survey(string pId, string pText, List<ISurveyOption> pOptions, IUser pCreator) { InitializeProperties(pId, pText, pOptions, pCreator); }

    /// <summary>
    /// Constructor of the class
    /// </summary>
    /// <param name="pId">The id of the interaction</param>
    /// <param name="pText">The text of the survey</param>
    /// <param name="pOptions">The options available as strngs</param>
    /// <param name="pCreator">The creator of this survey</param>
    public Survey(string pId, string pText, List<string> pOptions, IUser pCreator)
    {
        List<ISurveyOption> options = new List<ISurveyOption>();
        foreach (string option in pOptions)
        {
            options.Add(new SurveyOption(new Guid().ToString(), option));
        }
        InitializeProperties(pId, pText, options, pCreator);
    }

    #endregion

    #region Event raising methods

    /// <summary>
    /// This method raises the corresponding event in case subscribers are registered
    /// </summary>
    /// <param name="pEventArgs">The event args to pass along</param>
    public virtual void OnComplete(InteractionEventArgs pEventArgs) { Completed?.Invoke(this, pEventArgs); }

    /// <summary>
    /// This method raises the corresponding event in case subscribers are registered
    /// </summary>
    /// <param name="pEventArgs">The event args to pass along</param>
    public virtual void OnModify(InteractionEventArgs pEventArgs) { Modified?.Invoke(this, pEventArgs); }

    /// <summary>
    /// This method raises the stateChanged event, in case subscribers are registeres
    /// </summary>
    /// <param name="pEventArgs">The event args to pass along</param>
    public virtual void OnStateChanged(InteractionEventArgs pEventArgs) { StateChanged?.Invoke(this, pEventArgs); }

    #endregion

    #region Public methods

    /// <summary>
    /// This method changes the owner of the survey and raises the modified event if the owner is different
    /// </summary>
    /// <param name="pUser">The new user to mark as owner</param>
    public virtual void ChangeOwner(IUser pUser)
    {
        if (_owner != pUser)
        {
            _owner = pUser;
            List<InteractionAttributes> changedAttributes = new List<InteractionAttributes> {InteractionAttributes.Owner};
            OnModify(new InteractionEventArgs($"Survey owner changed [Id={Id}]", DateTime.Now, InteractionType.Survey));
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
            List<InteractionAttributes> changedAttributes = new List<InteractionAttributes> {InteractionAttributes.IsActive};
            OnModify(new InteractionEventArgs($"Survey IsActive changed [Id={Id}]", DateTime.Now, InteractionType.Survey));
        }
    }

    /// <summary>
    /// This method adds a vote to this survey and verifies if all votes were made. If this is the case a statChanged
    /// event with state finished will be fired. It will also check if the user still has open votes
    /// </summary>
    /// <param name="pVote">The vote to ass</param>
    public virtual void AddVote(IVote pVote)
    {
        if (_voteList.Count(x => x.User == pVote.User) < MaxVotesPerUser)
        {
            _voteList.Add(pVote);
            List<InteractionAttributes> changedAttributes = new List<InteractionAttributes> {InteractionAttributes.VoteList};
            OnModify(new InteractionEventArgs($"Survey votes changed [Id={Id}]", DateTime.Now, InteractionType.Survey));
        }

        // Is completed?
        if (_voteList.Count >= (MaxVotesPerUser*UserList.Count))
        {
            _isActive = false;
            ChangeState(InteractionState.Finished);
        }
    }

    /// <summary>
    /// This method will add options to a survey. In case a new option is added the Modified event is raised
    /// </summary>
    /// <param name="pOption">The survey option to add</param>
    public virtual void AddOption(ISurveyOption pOption)
    {
        if (!OptionList.Contains(pOption))
        {
            OptionList.Add(pOption);
            List<InteractionAttributes> changedAttributes = new List<InteractionAttributes> {InteractionAttributes.OptionList};
            OnModify(new InteractionEventArgs($"Survey Option list changed [Id={Id}]", DateTime.Now, InteractionType.Survey));
        }
    }

    /// <summary>
    /// Adds a new user to the list of eligible users
    /// </summary>
    /// <param name="pUser">The user to add</param>
    public void AddUser(IUser pUser)
    {
        if (!UserList.Contains(pUser))
        {
            UserList.Add(pUser);
            List<InteractionAttributes> changedAttributes = new List<InteractionAttributes> {InteractionAttributes.UserList};
            OnModify(new InteractionEventArgs($"Survey user list changed [Id={Id}]", DateTime.Now, InteractionType.Survey));
        }
    }

    /// <summary>
    /// Removed a user from the list of eligible users
    /// </summary>
    /// <param name="pUser">The user to remove</param>
    public void RemoveUser(IUser pUser)
    {
        if (UserList.Contains(pUser))
        {
            UserList.Remove(pUser);
            List<InteractionAttributes> changedAttributes = new List<InteractionAttributes> {InteractionAttributes.UserList};
            OnModify(new InteractionEventArgs($"Survey user list changed [Id={Id}]", DateTime.Now, InteractionType.Survey));
        }
    }

    /// <summary>
    /// Changes the state of this interaction and thus causes the stateCHanged event to be fired
    /// </summary>
    /// <param name="pState">The new state to set</param>
    public void ChangeState(InteractionState pState)
    {
        this._state = pState;
        if (_state == InteractionState.Finished ||
            _state == InteractionState.Cancelled ||
            _state == InteractionState.Expired)
            ChangeIsActive(false);
        List<InteractionAttributes> changedAttributes = new List<InteractionAttributes> {InteractionAttributes.State, InteractionAttributes.IsActive};
        OnStateChanged(new InteractionEventArgs($"Survey state changed [Id={Id}]", DateTime.Now, InteractionType.Survey));
    }

    #endregion

    #region Private methods

    /// <summary>
    /// Initializes all attributes and started the state timer, which validates the interaction's state every 60
    /// seconds.
    /// </summary>
    /// <param name="pId">The Id of the object</param>
    /// <param name="pText">The text of the survey</param>
    /// <param name="pOptions">The options on can select</param>
    /// <param name="pCreator">The creator of this survey</param>
    private void InitializeProperties(string pId, string pText, List<ISurveyOption> pOptions, IUser pCreator)
    {
        _id = pId;
        _creator = pCreator;
        Text = pText;
        OptionList = pOptions;
        _createdDateTime = DateTime.Now;
        _modifiedDateTime = DateTime.Now;
        StartDateTime = DateTime.Now;
        EndDateTime = default(DateTime);
        DueDateTime = default(DateTime);
        _isActive = true;
        Type = InteractionType.Survey;
        _voteList = new List<IVote>();
        OptionList = new List<ISurveyOption>();
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
            if (_voteList.Count >= UserList.Count*MaxVotesPerUser)
                ChangeState(InteractionState.Finished);
        }

        // Still active?
        if (_state == InteractionState.Active || _state == InteractionState.Queued)
            _stateTimer.Start();
    }

    #endregion
}