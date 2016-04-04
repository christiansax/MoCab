//////////////////////////////////////////////////////////////
//                      Class ObjectManager
//      Author: Christian B. Sax            Date:   2016/03/24
//      The object manager controls the form- and dataManager. It is responsible 
//      to maintain, create and convert objects from or to forms and finally updates 
//      the database using BackendService.
//      It also tracks each object instance created and provides access to then through
//      its lists
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using PlexByte.MoCap.Interactions;
using PlexByte.MoCap.Security;
using Timer = System.Timers.Timer;
using WeifenLuo.WinFormsUI.Docking;
using PlexByte.MoCap.WinForms.UserControls;
using System.Timers;
using PlexByte.MoCap.Helpers;
using PlexByte.MoCap.WinForms;
using PlexByte.MoCap.WinForms.CustomForms;

namespace PlexByte.MoCap.Managers
{
    public class ObjectManager : IDisposable
    {
        #region Delegates and Events
        /// <summary>
        /// Delegate for the refresh timer elapsed event
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event params</param>
        public delegate void RefreshTimerElapsesEventHandler(object sender, EventArgs e);
        /// <summary>
        ///  Delegate for the object changed event
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event params</param>
        public delegate void ObjectChangingEventHandler(object sender, EventArgs e);
        /// <summary>
        /// This delegate is used for the log in and out event
        /// </summary>
        /// <param name="sender">The user performing the login / logout</param>
        /// <param name="e">The event args</param>
        public delegate void UserSessionEventHandler(object sender, EventArgs e);

        /// <summary>
        /// The RefreshTimerElapsed event
        /// </summary>
        public event RefreshTimerElapsesEventHandler RefreshTimerElapsed;
        /// <summary>
        /// The Object changed event
        /// </summary>
        public event ObjectChangingEventHandler ObjectChanged;
        /// <summary>
        /// This event is fired whenever a user is logging in
        /// </summary>
        public event UserSessionEventHandler UserLoggedIn;
        /// <summary>
        /// This event is fired whenever a user logs out
        /// </summary>
        public event UserSessionEventHandler UserLoggedOut;

        #endregion

        #region Properties

        /// <summary>
        /// The user being logged into this session
        /// </summary>
        public IUser UserContext { get; private set; } = null;
        
        /// <summary>
        /// The list of projects for this user
        /// </summary>
        public List<IProject> ProjectList { get; private set; }

        /// <summary>
        /// The list of tasks for this user
        /// </summary>
        public List<ITask> TaskList { get; private set; }

        /// <summary>
        /// The list of survey for this user
        /// </summary>
        public List<ISurvey> SurveyList { get; private set; }

        /// <summary>
        /// The list of expenses for this user
        /// </summary>
        public List<IExpense> ExpenseList { get; private set; }

        /// <summary>
        /// The list of timeslices for this user
        /// </summary>
        public List<ITimeslice> TimesliceList { get; private set; }

        /// <summary>
        /// The list of users this user has a relation with
        /// </summary>
        public List<IUser> UserList { get; private set; }

        #endregion

        #region Variables

        DataManager _dataManager = null;
        FormManager _formManager = null;
        IInteractionFactory _interactionFactory = null;
        IObjectFactory _objectFactory = null;
        Timer _updateTimer = null;

        #endregion

        #region Ctor & Dtor

        /// <summary>
        /// Constructor of the class
        /// </summary>
        public ObjectManager()
        {
            // Instanciate factories to create object
            _interactionFactory = new InteractionFactory();
            _objectFactory = new ObjectFactory();
            ProjectList=new List<IProject>();
            TaskList=new List<ITask>();
            SurveyList=new List<ISurvey>();
            ExpenseList=new List<IExpense>();
            TimesliceList=new List<ITimeslice>();
            UserList=new List<IUser>();

            // Initialize the time which will periodically update the objects
            _updateTimer = new Timer(20000);
            _updateTimer.AutoReset = false;
            _updateTimer.Elapsed += UpdateTimer_Elapsed;
            _formManager = new FormManager(this);
            _dataManager = new DataManager(this);

            //_dataManager = pDataManager;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _objectFactory = null;
            _interactionFactory = null;
            if (_updateTimer != null && _updateTimer.Enabled)
            {
                _updateTimer.Stop();
                _updateTimer.Enabled = false;
            }
            _updateTimer = null;

            ProjectList.Clear();
            TaskList.Clear();
            SurveyList.Clear();
            ExpenseList.Clear();
            TimesliceList.Clear();
            UserList.Clear();
            UserContext = null;
            ProjectList = null;
            TaskList = null;
            SurveyList = null;
            ExpenseList = null;
            TimesliceList = null;

            _dataManager?.Dispose();
            _dataManager = null;

            _formManager?.Dispose();
            _formManager = null;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// This method get an object bi its Id from the database
        /// </summary>
        /// <typeparam name="T">The type of object to create (Interaction)</typeparam>
        /// <param name="pId">The id of the object to lookup</param>
        /// <returns>An object of the type specified matching the id</returns>
        public T GetObjectById<T>(string pId)
        {
            T tmp = default(T);
            if (typeof (T) == typeof (IProject))
            {
                tmp = (T) _dataManager.GetProjectById(pId);
                if (tmp != null)
                {
                    if (!ProjectList.Contains((IProject) tmp))
                    {
                        ProjectList.Add((IProject) tmp);
                        OnObjectChanged(tmp, new EventArgs());
                    }
                }
            }
            else if (typeof (T) == typeof (ITask))
            {
                tmp = (T) _dataManager.GetTaskById(pId);
                if (tmp != null)
                {
                    if (!TaskList.Contains((ITask) tmp))
                    {
                        TaskList.Add((ITask) tmp);
                        OnObjectChanged(tmp, new EventArgs());
                    }
                }
            }
            else if (typeof (T) == typeof (ISurvey))
            {
                tmp = (T) _dataManager.GetSurveyById(pId);
                if (tmp != null)
                {
                    if (!SurveyList.Contains((ISurvey) tmp))
                    {
                        SurveyList.Add((ISurvey) tmp);
                        OnObjectChanged(tmp, new EventArgs());
                    }
                }
            }
            else if (typeof (T) == typeof (IExpense))
            {
                tmp = (T) _dataManager.GetExpenseById(pId);
                if (tmp != null)
                {
                    if (!ExpenseList.Contains((IExpense) tmp))
                    {
                        ExpenseList.Add((IExpense) tmp);
                        OnObjectChanged(tmp, new EventArgs());
                    }
                }
            }
            else if (typeof (T) == typeof (ITimeslice))
            {
                tmp = (T) _dataManager.GetTimesliceById(pId);
                if (tmp != null)
                {
                    if (!TimesliceList.Contains((ITimeslice) tmp))
                    {
                        TimesliceList.Add((ITimeslice) tmp);
                        OnObjectChanged(tmp, new EventArgs());
                    }
                }
            }
            else if (typeof (T) == typeof (IUser))
            {
                tmp = (_dataManager.GetUser(pId, false) == null)
                    ? (T) _dataManager.GetUser(pId, true)
                    : (T) _dataManager.GetUser(pId, false);
                if (tmp != null)
                {
                    if (!UserList.Contains((IUser) tmp))
                    {
                        UserList.Add((IUser) tmp);
                        OnObjectChanged(tmp, new EventArgs());
                    }
                }
            }
            else
            {
                throw new InvalidCastException($"The type {typeof(T).ToString()} was not implemented");
            }
            return tmp;
        }

        /// <summary>
        /// This method creates a form from an object passed
        /// </summary>
        /// <typeparam name="T">The type of object from which a form is contructed</typeparam>
        /// <param name="pObject">The object that hold the values and are mathed to the forms input</param>
        /// <returns>A dockContent form that holds the objects values</returns>
        public DockContent CreateFormFromObject<T>(T pObject)
        {
            DockContent tmp = null;
            if (pObject.GetType() == typeof (IUser))
            {
                tmp = _formManager.CreateUserFormFromObject((IUser) pObject);
            }
            else
            {
                tmp = _formManager.CreateFormFromObject((IInteraction) pObject);
            }

            return tmp;
        }

        /// <summary>
        /// This method attempts to login the given user with the password specified
        /// </summary>
        /// <param name="pId">The user id</param>
        /// <param name="pPassword">The users password</param>
        public void LoginUser(string pId, string pPassword)
        {
            IUser user = _dataManager.GetUser(pId, true);
            if (user != null)
            {
                if (user.Password == CryptoHelper.Encrypt(pPassword, "MoCap"))
                {
                    UserContext = user;
                    OnUserLoggedIn(new EventArgs());
                }
                else
                    throw new InvalidCredentialException($"The password provided does not match password for user {pId}");
            }
            else
                throw new InvalidCredentialException($"The user {pId} was not found");
        }

        /// <summary>
        /// This method clears the current userContext and hence logs out a user
        /// </summary>
        public void LogoutUser()
        {
            OnUserLoggedOut((User)UserContext, new EventArgs());
            UserContext = null;
        }

        /// <summary>
        /// This method updates or insert a user object created from the form in the DB
        /// </summary>
        /// <param name="pForm">The form containing the user values</param>
        public void UpsertUserFromForm(uc_User pForm)
        {
            User tmp = (User)CreateObjectFromForm<IUser>(pForm);

            // Is user in list?
            if (UserList.Any(x => String.Equals(x.Username,
                tmp.Username,
                StringComparison.CurrentCultureIgnoreCase)))
            {
                UserList[UserList.FindIndex(x => x.Id == tmp.Id)] = tmp;
                _dataManager.UpsertUser(tmp);
                UserContext = tmp;
            }
            else
            {
                UserList.Add(tmp);
                _dataManager.UpsertUser(tmp);
            }
        }
        
        /// <summary>
        ///  This method updates or insert a project object created from the form in the DB
        /// </summary>
        /// <param name="pForm"></param>
        public IProject UpsertProjectFromForm(uc_Project pForm)
        {
            Project tmp = (Project)CreateObjectFromForm<IProject>(pForm);

            // Is user in list?
            if (ProjectList.Any(x => String.Equals(x.Id,
                tmp.Id,
                StringComparison.CurrentCultureIgnoreCase)))
            {
                ProjectList[ProjectList.FindIndex(x => x.Id == tmp.Id)] = tmp;
                _dataManager.UpsertProject(tmp);
            }
            else
            {
                ProjectList.Add(tmp);
                _dataManager.UpsertProject(tmp);
            }

            return tmp;
        }

        /// <summary>
        /// This method updated or insert a task object created from the form in the DB
        /// </summary>
        /// <param name="pForm">The form containing the task values</param>
        public ITask UpsertTaskFromForm(uc_Task pForm)
        {
            Task tmp = (Task)CreateObjectFromForm<ITask>(pForm);
            pForm.TabText = $"Task Details ({tmp.Title})";

            // Is user in list?
            if (TaskList.Any(x => String.Equals(x.Id,
                tmp.Id,
                StringComparison.CurrentCultureIgnoreCase)))
            {
                TaskList[TaskList.FindIndex(x => x.Id == tmp.Id)] = tmp;
                _dataManager.UpsertTask(tmp);
            }
            else
            {
                TaskList.Add(tmp);
                _dataManager.UpsertTask(tmp);
            }

            return tmp;
        }

        /// <summary>
        /// This method updated or insert a survey object created from the form in the DB
        /// </summary>
        /// <param name="pForm">The form containing the survey values</param>
        public ISurvey UpsertSurveyFromForm(uc_Survey pForm)
        {
            Survey tmp = (Survey)CreateObjectFromForm<ISurvey>(pForm);
            pForm.TabText = $"Survey Details ({tmp.Title})";

            // Is user in list?
            if (SurveyList.Any(x => String.Equals(x.Id,
                tmp.Id,
                StringComparison.CurrentCultureIgnoreCase)))
            {
                SurveyList[SurveyList.FindIndex(x => x.Id == tmp.Id)] = tmp;
                _dataManager.UpsertSurvey(tmp);
            }
            else
            {
                SurveyList.Add(tmp);
                _dataManager.UpsertSurvey(tmp);
            }
            return tmp;
        }

        /// <summary>
        /// This method updated or insert a vote object created from the form in the DB
        /// </summary>
        /// <param name="pForm">The form containing the vote values</param>
        public void UpsertVoteFromForm(uc_Survey pForm)
        {
            if (SurveyList.Any(x => x.Id == pForm.Id))
            {
                try
                {
                    ISurvey survey = SurveyList.First(x => x.Id == pForm.Id);
                    Vote tmp = (Vote) _formManager.CreateObjectFromForm<IVote>(pForm);
                    if (tmp != null)
                    {
                        survey.AddVote(tmp);
                        _dataManager.UpsertVote(tmp);
                    }
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
            else
            {
                throw new Exception("The vote does not exists (yet)");
            }
        }

        /// <summary>
        /// This method updated or insert a expense object created from the form in the DB
        /// </summary>
        /// <param name="pForm"></param>
        /// <returns></returns>
        public IExpense UpsertExpenseFromForm(frm_TaskUpdateProgress pForm)
        {
            //Expense tmp = (Expense)CreateObjectFromForm<IExpense>(pForm);

            //// Is user in list?
            //if (ExpenseList.Any(x => String.Equals(x.Id,
            //    tmp.Id,
            //    StringComparison.CurrentCultureIgnoreCase)))
            //{
            //    ExpenseList[ExpenseList.FindIndex(x => x.Id == tmp.Id)] = tmp;
            //    _dataManager.UpsertExpense(tmp);
            //}
            //else
            //{
            //    ExpenseList.Add(tmp);
            //    _dataManager.UpsertExpense(tmp);
            //}
            return default(IExpense);
        }

        /// <summary>
        /// This method updated or insert a timeslice object created from the form in the DB
        /// </summary>
        /// <param name="pForm"></param>
        /// <returns></returns>
        public ITimeslice UpsertTimesliceFromForm(frm_TaskUpdateProgress pForm)
        {
            //Timeslice tmp = (Timeslice)CreateObjectFromForm<ITimeslice>(pForm);

            //// Is user in list?
            //if (TimesliceList.Any(x => String.Equals(x.Id,
            //    tmp.Id,
            //    StringComparison.CurrentCultureIgnoreCase)))
            //{
            //    TimesliceList[TimesliceList.FindIndex(x => x.Id == tmp.Id)] = tmp;
            //    _dataManager.UpsertTimeslice(tmp);
            //}
            //else
            //{
            //    TimesliceList.Add(tmp);
            //    _dataManager.UpsertTimeslice(tmp);
            //}
                return default(ITimeslice);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pProject"></param>
        /// <param name="pObjectId"></param>
        /// <param name="pObjectType"></param>
        public void UpsertProjectMapping<T>(IProject pProject, string pObjectId, T pObjectType)
        {
            if (pObjectType.GetType() == typeof(User))
            {
                _dataManager.UpsertProjectMapping(pProject.Id, pObjectId, 1);
            }
            else if (pObjectType.GetType() == typeof(Task))
            {
                _dataManager.UpsertProjectMapping(pProject.Id, pObjectId, 2);
            }
            else if (pObjectType.GetType() == typeof(Survey))
            {
                _dataManager.UpsertProjectMapping(pProject.Id, pObjectId, 3);
            }
            else
            {
                throw new InvalidCastException($"The type {typeof(T).ToString()} was not implemented");
            }
        }

        /// <summary>
        /// The event handler for the Refresh event. This event fires whenever the updateTimer elapses
        /// </summary>
        /// <param name="e">The eventarguments</param>
        public virtual void OnRefreshTimerElapsed(EventArgs e) { RefreshTimerElapsed?.Invoke(this, e); }

        /// <summary>
        /// The event handler for the object changed event. This fires whenever an object in the collection changes
        /// </summary>
        /// <param name="changedObject">The changed object raising this event</param>
        /// <param name="e">The event arguments</param>
        public virtual void OnObjectChanged(object changedObject, EventArgs e) { ObjectChanged?.Invoke(changedObject, e); }

        /// <summary>
        /// The event handler for the user login event. This fires whenever a user logs in
        /// </summary>
        /// <param name="e">The event arguments</param>
        public virtual void OnUserLoggedIn(EventArgs e) { UserLoggedIn?.Invoke(UserContext, e); }

        /// <summary>
        /// The event handler for the user logout event. This fires whenever a user logs off
        /// </summary>
        /// <param name="sender">The user logging off</param>
        /// <param name="e">The event arguments</param>
        public virtual void OnUserLoggedOut(User sender, EventArgs e) { UserLoggedOut?.Invoke(sender, e); }

        public void CreateUserOverview()
        {
            if(UserContext!=null)
                InitializeObjects();
        }

        /// <summary>
        /// This method returns the state comparing the dateTime values given
        /// </summary>
        /// <param name="pReference">The dateTime which denotes the reference to compare against</param>
        /// <param name="pStart">The dateTime this interaction starts</param>
        /// <param name="pEnd">The dateTime this interaction ends</param>
        /// <param name="pDue">The dateTIme this interaction is due</param>
        /// <returns>The interactionState computed for this item</returns>
        public InteractionState ComputeState(DateTime pReference, DateTime pStart, DateTime pEnd, DateTime pDue)
        {
            InteractionState tmp = InteractionState.Active;
            if(pStart>pReference)
                tmp=InteractionState.Queued;
            else if(pDue<=pReference)
                tmp=InteractionState.Expired;
            else if(pReference<pDue&&pReference<=pEnd)
                tmp=InteractionState.Finished;
            return tmp;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// This method creates an object from a form. It uses the fors input values to construct the object
        /// of the type specified
        /// </summary>
        /// <typeparam name="T">The object type to use (IInteraction)</typeparam>
        /// <param name="pForm">The form containing the input field to use constructing the object</param>
        /// <returns>An object of the type specified that was constructed from the form inputs</returns>
        private T CreateObjectFromForm<T>(DockContent pForm)
        {
            if (pForm.GetType() == typeof(uc_Project))
            {
                IProject tmp = _formManager.CreateObjectFromForm<IProject>(pForm);
                ProjectList.Add(tmp);
                _dataManager.UpsertProject((Project)tmp);
                UpsertProjectMapping(tmp, tmp.Creator.Id, tmp.Creator);
                return (T)tmp;
            }
            else if (pForm.GetType() == typeof(uc_User))
            {
                IUser tmp = _formManager.CreateUserObjectFromForm((uc_User)pForm);
                if (!UserList.Contains(tmp))
                    UserList.Add(tmp);
                _dataManager.UpsertUser((User)tmp);
                return (T)tmp;
            }
            else if (pForm.GetType() == typeof(uc_Task))
            {
                ITask tmp = _formManager.CreateObjectFromForm<ITask>(pForm);
                TaskList.Add(tmp);
                _dataManager.UpsertTask((Task)tmp);
                return (T)tmp;
            }
            else if (pForm.GetType() == typeof(uc_Survey))
            {
                ISurvey tmp = _formManager.CreateObjectFromForm<ISurvey>(pForm);
                SurveyList.Add(tmp);
                _dataManager.UpsertSurvey((Survey)tmp);
                foreach (ISurveyOption option in tmp.OptionList)
                    _dataManager.UpsertSurveyOption((SurveyOption)option, tmp.Id);
                tmp.VoteList = _dataManager.GetVoteBySurveyId(tmp.Id);
                return (T)tmp;
            }
            else if (pForm.GetType() == typeof(uc_Expense))
            {
                IExpense tmp = _formManager.CreateObjectFromForm<IExpense>(pForm);
                ExpenseList.Add(tmp);
                _dataManager.UpsertExpense((Expense)tmp);
                return (T)tmp;
            }
            else if (pForm.GetType() == typeof(uc_Timeslice))
            {
                ITimeslice tmp = _formManager.CreateObjectFromForm<ITimeslice>(pForm);
                TimesliceList.Add(tmp);
                _dataManager.UpsertTimeslice((Timeslice)tmp);
                return (T)tmp;
            }
            else
            {
                throw new InvalidCastException($"The type {pForm.GetType().ToString()} cannot be created as was never defined");
            }
        }

        /// <summary>
        /// This method initializes all objects this user has a relation to and updates the corresponding list
        /// </summary>
        private void InitializeObjects()
        {
            // Read the objects for this user from the db and add them to the list collection

            // Project
            foreach (var project in _dataManager.GetAllInteractions<IProject>(UserContext.Id))
            {
                if (project != null)
                {
                    if (ProjectList.All(x => x.Id != project.Id))
                    {
                        ProjectList.Add(project);
                        OnObjectChanged(project, new EventArgs());

                        foreach (var member in project.MemberList)
                        {
                            if (UserList.All(x => x.Id != member.Id))
                                UserList.Add(member);
                        }
                    }
                }
            }

            // Task
            foreach (var task in _dataManager.GetAllInteractions<ITask>(UserContext.Id).
                Where(task => task != null).Where(task => TaskList.All(x => x.Id != task.Id)))
            {
                TaskList.Add(task);
                OnObjectChanged(task, new EventArgs());
            }

            // Survey
            foreach (var survey in _dataManager.GetAllInteractions<ISurvey>(UserContext.Id).
                Where(survey => survey != null).Where(survey => SurveyList.All(x => x.Id != survey.Id)))
            {
                SurveyList.Add(survey);
                OnObjectChanged(survey, new EventArgs());
            }

            // Expenses
            foreach (var expenses in _dataManager.GetAllInteractions<IExpense>(UserContext.Id).
                Where(expenses => expenses != null))
            {
                ExpenseList.Add(expenses);
                OnObjectChanged(expenses, new EventArgs());
            }

            // Timeslices
            foreach (var timeslice in _dataManager.GetAllInteractions<ITimeslice>(UserContext.Id).
                Where(timeslice => timeslice != null))
            {
                TimesliceList.Add(timeslice);
                OnObjectChanged(timeslice, new EventArgs());
            }

        }

        /// <summary>
        /// This method is fired everytime the refreshtimer has elapsed, causing the interaction collection to update
        /// </summary>
        private void RefreshObjects()
        {
            if (UserContext != null)
            {
                InitializeObjects();
                OnRefreshTimerElapsed(new EventArgs());
            }
        }

        /// <summary>
        /// This method fires once the updateTimer has elapsed
        /// </summary>
        /// <param name="sender">The timer firing the eventhandler</param>
        /// <param name="e">The event arguments</param>
        private void UpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            RefreshObjects();
            _updateTimer.Start();
        }

        #endregion
    }
}