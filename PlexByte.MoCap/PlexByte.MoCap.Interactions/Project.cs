//////////////////////////////////////////////////////////////
//                      Class Project                              
//      Author: Fabian Ochsner            Date:   2016/02/19
//      Implementation of IProject interface, a connection between all components
using System;
using System.Collections.Generic;
using PlexByte.MoCap.Security;

namespace PlexByte.MoCap.Interactions
{
    public class Project : IProject, IInteraction
    {
        #region Properties

        /// <summary>
        /// The unique id of the project
        /// </summary>
        public string Id { get; private set; }
        /// <summary>
        /// The date and time this project becomes active and can be worked on. As long as this date is not reached the 
        /// state will remain queued and no work can be performed on the project as longs as it is in state queued
        /// </summary>
        public DateTime StartDateTime { get; set; }
        /// <summary>
        /// The date and time this project should be finished. If this date is reached the state will change to expired
        /// </summary>
        public DateTime EndDateTime { get; set; }
        /// <summary>
        /// The date and time the project was created
        /// </summary>
        public DateTime CreatedDateTime { get; private set; }
        /// <summary>
        /// The date and time the project was last modified
        /// </summary>
        public DateTime ModifiedDateTime { get; private set; }
        /// <summary>
        /// Flag indicating whether or not the project can be worked on
        /// </summary>
        public bool IsActive { get; private set; }
        /// <summary>
        /// The text of this project (description)
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// The type of interaction (will be always project)
        /// </summary>
        public InteractionType Type { get; }
        /// <summary>
        /// The user that created the project
        /// </summary>
        public IUser Creator { get; private set; }
        /// <summary>
        /// The user currently owning the project
        /// </summary>
        public IUser Owner { get; private set; }
        /// <summary>
        /// The state of the project
        /// </summary>
        public InteractionState State { get; private set; }
        /// <summary>
        /// A bool to set, if it is possible to set a balance to a project
        /// if disabled it is not possible to book spended time or effort in a project
        /// </summary>
        public bool EnableBalance { get; private set; }
        /// <summary>
        /// A bool to set, if it is possible to set up a survey to a project
        /// if disabled it is not possible to create one
        /// </summary>
        public bool EnableSurvey { get; private set; }
        /// <summary>
        /// The account which is conectet do the project
        /// </summary>
        public IAccount ProjectAccount { get; set; }
        /// <summary>
        /// In this list are all members which have to answer an invitation
        /// </summary>
        public List<IUser> InvitationList { get; private set; }
        /// <summary>
        /// A list of all tasks in a project
        /// </summary>
        public List<ITask> TaskList { get; private set; }
        /// <summary>
        /// A list of all surveys in a project
        /// </summary>
        public List<ISurvey> SurveyList { get; private set; }
        /// <summary>
        /// In this list are all members of a project
        /// </summary>
        public List<IUser> MemberList { get; private set; }

        public string Name { get; private set; }

        public DateTime CreatedDateTIme
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public DateTime ModifiedDateTIme
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Variables

        private System.Timers.Timer _stateTimer = new System.Timers.Timer(60 * 1000);

        #endregion

        #region Events

        public event Complete Completed;
        public event Modify Modified;
        public event StateChange StateChanged;
        public event UserAdd UserAdded;
        public event UserBan UserBanned;
        public event Leave Left;
        public event UserInvite UserInvited;
        public event TaskAdd TaskAdded;
        public event SurveyAdd SurveyAdded;

        #endregion

        #region Ctor & Dtor

        /// <summary>
        /// Constructor of the class
        /// </summary>
        /// <param name="pId"></param>
        /// <param name="pText"></param>
        /// <param name="pEnableBalance"></param>
        /// <param name="pEnableSurvey"></param>
        /// <param name="pCreator"></param>
        public Project(string pId, string pText, bool pEnableBalance, bool pEnableSurvey, DateTime pStartDt, DateTime pEndDt, IUser pCreator)
        {
            List<IUser> pMemberList = new List<IUser>();
            List<IUser> pInvitationList = new List<IUser>();
            List<ITask> pTaskList = new List<ITask>();
            List<ISurvey> pSurveyList = new List<ISurvey>();
            IUser pOwner = pCreator;

            InitializeProperties(pId, pText.Remove(pText.IndexOf(@";") + 0), pText.Substring(pText.IndexOf(@";") + 1), pEnableBalance, pEnableSurvey, pMemberList, pInvitationList, pTaskList, pSurveyList, pStartDt, pEndDt, pCreator, pOwner);
        }

        /// <summary>
        /// Constructor of the class
        /// </summary>
        /// <param name="pId"></param>
        /// <param name="pText"></param>
        /// <param name="pEnableBalance"></param>
        /// <param name="pEnableSurvey"></param>
        /// <param name="pMemberList"></param>
        /// <param name="pInvitationList"></param>
        /// <param name="pTaskList"></param>
        /// <param name="pSurveyList"></param>
        /// <param name="pCreator"></param>
        /// <param name="pOwner"></param>
        public Project(string pId, string pName, string pText, bool pEnableBalance, bool pEnableSurvey, DateTime pStartDt, DateTime pEndDt, IUser pCreator, IUser pOwner, List<IUser> pMemberList, List<IUser> pInvitationList, List<ITask> pTaskList, List<ISurvey> pSurveyList)
        {
            InitializeProperties(pId, pName, pText, pEnableBalance, pEnableSurvey, pMemberList, pInvitationList, pTaskList, pSurveyList, pStartDt, pEndDt, pCreator, pOwner);
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

        /// <summary>
        /// This method raises the corresponding event in case subscribers are registered
        /// </summary>
        /// <param name="pEventArgs"></param>
        public virtual void OnUserAdd(InteractionEventArgs pEventArgs)
        {
            UserAdded?.Invoke(this, pEventArgs);
        }

        /// <summary>
        /// This method raises the corresponding event in case subscribers are registered
        /// </summary>
        /// <param name="pEventArgs"></param>
        public virtual void OnUserBan(InteractionEventArgs pEventArgs)
        {
            UserBanned?.Invoke(this, pEventArgs);
        }

        /// <summary>
        /// This method raises the corresponding event in case subscribers are registered
        /// </summary>
        /// <param name="pEventArgs"></param>
        public virtual void OnLeave(InteractionEventArgs pEventArgs)
        {
            Left?.Invoke(this, pEventArgs);
        }

        /// <summary>
        /// This method raises the corresponding event in case subscribers are registered
        /// </summary>
        /// <param name="pEventArgs"></param>
        public virtual void OnUserInvite(InteractionEventArgs pEventArgs)
        {
            UserInvited?.Invoke(this, pEventArgs);
        }

        /// <summary>
        /// This method raises the corresponding event in case subscribers are registered
        /// </summary>
        /// <param name="pEventArgs"></param>
        public virtual void OnTaskAdd(InteractionEventArgs pEventArgs)
        {
            TaskAdded?.Invoke(this, pEventArgs);
        }

        /// <summary>
        /// This method raises the corresponding event in case subscribers are registered
        /// </summary>
        /// <param name="pEventArgs"></param>
        public virtual void OnSurveyAdd(InteractionEventArgs pEventArgs)
        {
            SurveyAdded?.Invoke(this, pEventArgs);
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
            if (Owner != pUser)
            {
                Owner = pUser;
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
            if (IsActive != pActive)
            {
                IsActive = pActive;
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
            if (!MemberList.Contains(pUser) && !InvitationList.Contains(pUser))
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
        /// Removes oneself from the memberlist of the project
        /// </summary>
        /// <param name="pUser"></param>
        public virtual void Leave(IUser pUser)
        {
            MemberList.Remove(pUser);
            List<InteractionAttributes> changedAttributes = new List<InteractionAttributes>();
            changedAttributes.Add(InteractionAttributes.MemberList);
            OnModify(new InteractionEventArgs($"Survey user list changed [Id={Id}]", DateTime.Now, InteractionType.Project));
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
        /// Changes the state of this interaction and thus causes the stateChanged event to be fired
        /// </summary>
        /// <param name="pState"></param>
        public virtual void ChangeState(InteractionState pState)
        {

            this.State = pState;
            if (State == InteractionState.Finished ||
                State == InteractionState.Cancelled)
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
        /// <param name="pEnableBalance"></param>
        /// <param name="pEnableSurvey"></param>
        /// <param name="pMemberList"></param>
        /// <param name="pInvitationList"></param>
        /// <param name="pTaskList"></param>
        /// <param name="pSurveyList"></param>
        /// <param name="pCreator"></param>
        /// <param name="pOwner"></param>
        private void InitializeProperties(string pId, string pName, string pText, bool pEnableBalance, bool pEnableSurvey, List<IUser> pMemberList, List<IUser> pInvitationList, List<ITask> pTaskList, List<ISurvey> pSurveyList, DateTime pStartDt, DateTime pEndDt, IUser pCreator, IUser pOwner)
        {

            Id = pId;
            EnableBalance = pEnableBalance;
            EnableSurvey = pEnableSurvey;
            MemberList = pMemberList;
            InvitationList = pInvitationList;
            TaskList = pTaskList;
            SurveyList = pSurveyList;
            Creator = pCreator;
            Owner = pOwner;
            Text = pText;
            CreatedDateTime = DateTime.Now;
            ModifiedDateTime = DateTime.Now;
            StartDateTime = DateTime.Now;
            EndDateTime = default(DateTime);
            IsActive = true;
            State = StartDateTime <= DateTime.Now ? InteractionState.Active : InteractionState.Queued;
            _stateTimer.Elapsed += OnTimerElapsed;
            _stateTimer.AutoReset = false;
            _stateTimer.Start();
            Name = pName;
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

}