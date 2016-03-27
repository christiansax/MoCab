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
using System.Security.Authentication;
using PlexByte.MoCap.Interactions;
using PlexByte.MoCap.Security;
using Timer = System.Timers.Timer;
using WeifenLuo.WinFormsUI.Docking;
using PlexByte.MoCap.WinForms.UserControls;
using System.Timers;
using PlexByte.MoCap.Helpers;
using PlexByte.MoCap.WinForms;

namespace PlexByte.MoCap.Managers
{
    public class ObjectManager : IDisposable
    {
        #region Delegates and Events

        public delegate void RefreshTimerElapsesEventHandler(object sender, EventArgs e);
        public delegate void ObjectChangingEventHandler(object sender, EventArgs e);

        public event RefreshTimerElapsesEventHandler RefreshTimerElapsed;
        public event RefreshTimerElapsesEventHandler ObjectChanged;

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

        public void LoginUser(string pId, string pPassword)
        {
            IUser user = _dataManager.GetUser(pId, true);
            if (user != null)
            {
                if (user.Password == CryptoHelper.Encrypt(pPassword, "MoCap"))
                {
                    UserContext = user;
                    InitializeObjects();
                }
                else
                    throw new InvalidCredentialException($"The password provided does not match password for user {pId}");
            }
            else
                throw new InvalidCredentialException($"The user {pId} was not found");
        }

        public void LogoutUser() { UserContext = null; }

        public T CreateObjectFromForm<T>(DockContent pForm)
        {
            if (pForm.GetType() == typeof (uc_Project))
            {
                IProject tmp = _formManager.CreateObjectFromForm<IProject>(pForm);
                ProjectList.Add(tmp);
                _dataManager.UpsertProject((Project) tmp);
                return (T) tmp;
            }
            else if (pForm.GetType() == typeof (uc_User))
            {
                IUser tmp = _formManager.CreateObjectFromForm<IUser>(pForm);
                UserList.Add(tmp);
                _dataManager.UpsertUser((User) tmp);
                return (T) tmp;
            }
            else if (pForm.GetType() == typeof (uc_Task))
            {
                ITask tmp = _formManager.CreateObjectFromForm<ITask>(pForm);
                TaskList.Add(tmp);
                _dataManager.UpsertTask((Task) tmp);
                return (T) tmp;
            }
            else if (pForm.GetType() == typeof (uc_Survey))
            {
                ISurvey tmp = _formManager.CreateObjectFromForm<ISurvey>(pForm);
                SurveyList.Add(tmp);
                _dataManager.UpsertSurvey((Survey) tmp);
                return (T) tmp;
            }
            else if (pForm.GetType() == typeof (uc_Expense))
            {
                IExpense tmp = _formManager.CreateObjectFromForm<IExpense>(pForm);
                ExpenseList.Add(tmp);
                _dataManager.UpsertExpense((Expense) tmp);
                return (T) tmp;
            }
            else if (pForm.GetType() == typeof (uc_Timeslice))
            {
                ITimeslice tmp = _formManager.CreateObjectFromForm<ITimeslice>(pForm);
                TimesliceList.Add(tmp);
                _dataManager.UpsertTimeslice((Timeslice) tmp);
                return (T) tmp;
            }
            else
            {
                throw new InvalidCastException($"The type {pForm.GetType().ToString()} cannot be created as was never defined");
            }
        }

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

        #endregion

        #region Private Methods

        private void InitializeObjects() { }

        private void RefreshObjects()
        {
            InitializeObjects();
            OnRefreshTimerElapsed(new EventArgs());
        }

        private void UpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            RefreshObjects();
            _updateTimer.Start();
        }

        public virtual void OnRefreshTimerElapsed(EventArgs e)
        {
            if (RefreshTimerElapsed != null)
            {
                RefreshTimerElapsed(this, e);
            }
        }

        public virtual void OnObjectChanged(object changedObject, EventArgs e)
        {
            if (ObjectChanged != null)
            {
                ObjectChanged(changedObject, e);
            }
        }

        #endregion
    }
}