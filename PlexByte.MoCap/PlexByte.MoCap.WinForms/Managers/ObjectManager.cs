using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using PlexByte.MoCap.Interactions;
using PlexByte.MoCap.Security;
using PlexByte.MoCap.WinForms.UserControls;
using Timer = System.Timers.Timer;

namespace PlexByte.MoCap.WinForms.Managers
{
    public class ObjectManager : IDisposable
    {
        #region Delegates and Events

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

        #endregion

        #region Properties

        /// <summary>
        /// The list of Survey available for this user
        /// </summary>
        public List<ISurvey> SurveyList { get; set; }

        /// <summary>
        /// The list of project for this user
        /// </summary>
        public List<IProject> ProjectList { get; set; }

        /// <summary>
        /// The list of tasks for this user
        /// </summary>
        public List<ITask> TaskList { get; set; }

        /// <summary>
        /// The list of Expenses for this user
        /// </summary>
        public List<IExpense> ExpenseList { get; set; }

        /// <summary>
        /// The list of timeslices for this user
        /// </summary>
        public List<ITimeslice> TimeSliceList { get; set; }

        /// <summary>
        /// The list of timeslices for this user
        /// </summary>
        public List<IUser> UserList { get; set; }

        #endregion

        #region Variables

        private IInteractionFactory _interactionFactory = null;
        private IObjectFactory _objectFactory = null;
        private Timer _updateTimer = null;
        private DataManager _dataManager = null;

        #endregion

        #region Ctor & Dtor

        public ObjectManager(DataManager pDataManager)
        {
            // Instanciate factories to create object
            _interactionFactory = new InteractionFactory();
            _objectFactory = new ObjectFactory();

            // Instanciate the interaction lists
            TaskList = new List<Task>();
            SurveyList = new List<Survey>();
            ExpenseList = new List<Expense>();
            TimeSliceList = new List<Timeslice>();

            // Initialize the time which will periodically update the objects
            _updateTimer = new Timer(20000);
            _updateTimer.AutoReset = false;
            _updateTimer.Elapsed += UpdateTimer_Elapsed;

            _dataManager = pDataManager;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
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
            _objectFactory = null;
            _interactionFactory = null;
            if (_updateTimer != null && _updateTimer.Enabled)
            {
                _updateTimer.Stop();
                _updateTimer.Enabled = false;
            }
            _updateTimer = null;

            _dataManager = null;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// This method populates the project list based on the recordset given
        /// </summary>
        /// <param name="pResultSet">The recordset containing the projects to create</param>
        public List<IProject> CreateProjects(DataTable pResultSet)
        {
            List<IProject> tmp = CreateProjectsFromData(pResultSet);
            foreach (IProject project in tmp)
            {
                ProjectList.Add(project);
            }
            return tmp;
        }

        /// <summary>
        /// This method populates the task list based on the recordset given
        /// </summary>
        /// <param name="pResultSet">The recordset containing the tasks to create</param>
        public List<ITask> CreateTasks(DataTable pResultSet)
        {
            List<ITask> tmp = CreateTasksFromData(pResultSet);
            foreach (ITask task in tmp)
            {
                if (!TaskList.Contains(task))
                    TaskList.Add(task);
            }
            return tmp;
        }

        /// <summary>
        /// This method populates the survey list based on the recordset given
        /// </summary>
        /// <param name="pResultSet">The recordset containing the surveys to create</param>
        public List<ISurvey> CreateSurveys(DataTable pResultSet)
        {
            List<ISurvey> tmp = CreateSurveysFromData(pResultSet);
            foreach (ISurvey survey in tmp)
            {
                if(!SurveyList.Contains(survey))
                    SurveyList.Add(survey);
            }
            return tmp;
        }

        /// <summary>
        /// This method populates the account list based on the recordset given
        /// </summary>
        /// <param name="pResultSet">The recordset containing the accounts to create</param>
        public List<IAccount> CreateAccounts(DataTable pResultSet) { throw new NotImplementedException(); }

        /// <summary>
        /// This method populates the Expense list based on the recordset given
        /// </summary>
        /// <param name="pResultSet">The recordset containing the expenses to create</param>
        public List<IExpense> CreateExpenses(DataTable pResultSet)
        {
            List<IExpense> tmp = CreateExpensesFromData(pResultSet);
            foreach (IExpense expense in tmp)
            {
                if (!ExpenseList.Contains(expense))
                    ExpenseList.Add(expense);
            }
            return tmp;
        }

        /// <summary>
        /// This method populates the Timeslice list based on the recordset given
        /// </summary>
        /// <param name="pResultSet">The recordset containing the timeslices to create</param>
        public List<ITimeslice> CreateTimeslices(DataTable pResultSet)
        {
            List<ITimeslice> tmp = CreateTimeslicesFromData(pResultSet);
            foreach (ITimeslice timeslice in tmp)
            {
                if (!TimeSliceList.Contains(timeslice))
                    TimeSliceList.Add(timeslice);
            }
            return tmp;
        }

        /// <summary>
        /// This method populates the user list based on the recordset given
        /// </summary>
        /// <param name="pResultSet">The recordset containing the users to create</param>
        public List<IUser> CreateUsers(DataTable pResultSet)
        {
            List<IUser> tmp = CreateUsers(pResultSet);
            foreach (IUser user in tmp)
            {
                if (!UserList.Contains(user))
                    UserList.Add(user);
            }
            return tmp;
        }

        #endregion

        #region Private methods

        private List<IProject> CreateProjectsFromData(DataTable pRecordSet)
        {
            List<IProject> result = new List<IProject>();
            foreach (DataRow row in pRecordSet.Rows)
            {
                result.Add(_interactionFactory.CreateProject(row["Id"].ToString(),
                    row["Text"].ToString(),
                    Convert.ToBoolean(row["EnableBalance"].ToString()),
                    Convert.ToBoolean(row["EnableSurvey"].ToString()),
                    DateTime.ParseExact(row["StartDateTime"].ToString(), "yyyy-mm-dd HH:mm:ss.fff", CultureInfo.InvariantCulture),
                    DateTime.ParseExact(row["EndDateTime"].ToString(), "yyyy-mm-dd HH:mm:ss.fff", CultureInfo.InvariantCulture),
                    _dataManager.CreateUserById(row["Creator"].ToString())));
            }
            return (result.Count > 0) ? result : null;
        }
        private List<ITask> CreateTasksFromData(DataTable pRecordSet) { throw new NotImplementedException(); }
        private List<ISurvey> CreateSurveysFromData(DataTable pRecordSet) { throw new NotImplementedException(); }
        private List<IExpense> CreateExpensesFromData(DataTable pRecordSet) { throw new NotImplementedException(); }
        private List<ITimeslice> CreateTimeslicesFromData(DataTable pRecordSet) { throw new NotImplementedException(); }

        /// <summary>
        /// This method creates a list of user objects from the dataTable provided
        /// </summary>
        /// <param name="pRecordSet">The dataTable containing user data</param>
        /// <returns>The list of Users created</returns>
        public List<IUser> CreateUserFromData(DataTable pRecordSet)
        {
            List<IUser> result = new List<IUser>();
            foreach (DataRow curRow in pRecordSet.Rows)
            {
                result.Add(_objectFactory.CreateUser(curRow["Id"].ToString(),
                    curRow["FirstName"].ToString(),
                    curRow["LastName"].ToString(),
                    curRow["MiddleName"].ToString(),
                    curRow["EmailAddress"].ToString(),
                    DateTime.Parse(curRow["Birthdate"].ToString()),
                    curRow["Username"].ToString(),
                    curRow["Password"].ToString(),
                    DateTime.Parse(curRow["ModifiedDateTime"].ToString()),
                    DateTime.Parse(curRow["CreatedDateTime"].ToString()),
                    curRow["PersonId"].ToString()));
            }
            return (result.Count > 0) ? result : null;
        }

        private void UpdateTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e) { throw new NotImplementedException(); }

        #endregion
    }
}