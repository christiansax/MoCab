//////////////////////////////////////////////////////////////
//                      Class DataManager
//      Author: Christian B. Sax            Date:   2016/03/14
//      This class manages is used to convert from Object to SQL parsable data and vice versa.
//      The objective is to encapsulate any backend related conversions within this class and 
//      expose objects to calling classes only
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using PlexByte.MoCap.Backend;
using PlexByte.MoCap.Interactions;
using PlexByte.MoCap.Security;

namespace PlexByte.MoCap.WinForms
{
    public class DataManager
    {
        /// <summary>
        /// Delegate used when InteractionsChanged event is raised
        /// </summary>
        /// <param name="pInteraction">The list of interactions changed</param>
        /// <param name="e">The event arguments passed</param>
        public delegate void InteractionsChangeEventHandler(List<IInteraction> pInteraction, EventArgs e);
        /// <summary>
        /// Delegate used when InteractionsAdded event is raised
        /// </summary>
        /// <param name="pInteraction"></param>
        /// <param name="e"></param>
        public delegate void InteractionsAddedEventHandler(List<IInteraction> pInteraction, EventArgs e);
        /// <summary>
        /// Delegate used when InteractionsRemoved event is raised
        /// </summary>
        /// <param name="pInteraction"></param>
        /// <param name="e"></param>
        public delegate void InteractionsRemovedEventHandler(List<IInteraction> pInteraction, EventArgs e);

        /// <summary>
        /// The event that is raised when interaction items in the collection have changed
        /// </summary>
        public event InteractionsChangeEventHandler InteractionsChanged;
        /// <summary>
        /// The event that is raised when interaction items were added to the collection
        /// </summary>
        public event InteractionsAddedEventHandler InteractionsAdded;
        /// <summary>
        /// The event that is raised when interaction items were removed from the collection (e.g. they are no longer active)
        /// </summary>
        public event InteractionsRemovedEventHandler InteractionsRemoved;

        /// <summary>
        /// The user this datamanager runs under
        /// </summary>
        public User LoggedInUser { get; set; }

        /// <summary>
        /// Indicates if datamanager is initialized for a user
        /// </summary>
        public bool IsInitialized { get; set; } = false;
        /// <summary>
        /// The list of Survey available for this user
        /// </summary>
        public List<Survey> SurveyList { get; set; }
        /// <summary>
        /// The list of project for this user
        /// </summary>
        public List<Project> ProjectList { get; set; }
        /// <summary>
        /// The list of tasks for this user
        /// </summary>
        public List<Task> TaskList { get; set; }
        /// <summary>
        /// The list of Expenses for this user
        /// </summary>
        public List<Expense> ExpenseList { get; set; }
        /// <summary>
        /// The list of timeslices for this user
        /// </summary>
        public List<Timeslice> TimeSliceList { get; set; }

        private BackendService _backend = new BackendService();
        private InteractionFactory _interactionFactory = null;
        private ObjectFactory _objectFactory = null;

        /// <summary>
        /// The default constructor requiring to call initialize datamanger manually
        /// </summary>
        public DataManager() { }

        public DataManager(string pUserId, string pPassword)
        {
            InitializeDataManager(pUserId, pPassword);
            IsInitialized = true;
            _interactionFactory = new InteractionFactory();
            _objectFactory = new ObjectFactory();
        }

        public void Login(string pUserName, string pPassword)
        {
            LoggedInUser = CreateObjectFromDB<User>(_backend.AuthenticateUser(pUserName, pPassword));
            //= _backend.AuthenticateUser(pUserName, pPassword);
            ProjectList =new List<Project>();
            TaskList=new List<Task>();
            SurveyList=new List<Survey>();
            ExpenseList=new List<Expense>();
            TimeSliceList=new List<Timeslice>();
        }

        public void Logout()
        {
            LoggedInUser = null;
            IsInitialized = false;
            ProjectList.Clear();
            ProjectList = null;
            TaskList.Clear();
            TaskList = null;
            SurveyList.Clear();
            SurveyList = null;
            ExpenseList.Clear();
            ExpenseList = null;
            TimeSliceList.Clear();
            TimeSliceList = null;
        }

        public void InitializeDataManager(string pUserId, string pPassword)
        {
            try
            {
                if(IsInitialized)
                    Logout();
                Login(pUserId, pPassword);

                // Get all user specific data
                QueryDataBaseObjects();

                IsInitialized = true;
            }
            catch (Exception exp)
            {
                throw new Exception($"Failed to initialize DataManager! Exception: {exp.Message}");
            }
        }

        private void QueryDataBaseObjects()
        {
            // Get projects, tasks, survey, timeslices, expenses etc this user is involved in
        }

        private T CreateObjectFromDB<T>(string pId) { throw new NotImplementedException(); }
        private T CreateObjectFromDB<T>(DataTable pRecordSet) { throw new NotImplementedException(); }
    }
}
