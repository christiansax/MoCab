using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using PlexByte.MoCap.Interactions;
using PlexByte.MoCap.Security;
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

        #endregion

        #region Variables

        private InteractionFactory _interactionFactory = null;
        private ObjectFactory _objectFactory = null;
        private Timer _UpdateTimer = null;

        #endregion

        #region Ctor & Dtor

        public ObjectManager()
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
            _UpdateTimer = new Timer(20000);
            _UpdateTimer.AutoReset = false;
            _UpdateTimer.Elapsed += UpdateTimer_Elapsed;
        }

        public List<T> ProcessResultSet<T>(DataTable pDataTable)
        {
            List<T> tmp = new List<T>();

            if (typeof (Project) == typeof (T))
            {
                // Assemble project interaction from resultset
            }
            else if (typeof (Task) == typeof (T))
            {
                // Assemble task interaction from resultset
            }
            else if (typeof (Survey) == typeof (T))
            {
                // Assemble survey interaction from resultset
            }
            else if (typeof (Expense) == typeof (T))
            {
                // Assemble Expense interaction from resultset
            }
            else if (typeof (Timeslice) == typeof (T))
            {
                // Assemble Timeslice interaction from resultset
            }
            else if (typeof (SurveyOption) == typeof (T))
            {
                // Assemble SurveyOption from resultset
            }
            else if (typeof (Vote) == typeof (T))
            {
                // Assemble vote from recordset
            }
            else if (typeof (User) == typeof (T))
            {
                // Assemble user from recordset
            }
            else
            {
                throw new ArgumentException($"The type provided is not implemented. Cannot assemble type {typeof (T).ToString()}");
            }

            return tmp;
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
        }

        #endregion

        #region Public methods

        /// <summary>
        /// This method populates the project list based on the recordset given
        /// </summary>
        /// <param name="pResultSet">The recordset containing the projects to create</param>
        public void CreateProjects(DataTable pResultSet) { ProjectList = CreateObjectFromDataTable<List<Project>>(pResultSet); }

        /// <summary>
        /// This method populates the task list based on the recordset given
        /// </summary>
        /// <param name="pResultSet">The recordset containing the tasks to create</param>
        public void CreateTasks(DataTable pResultSet) { TaskList = CreateObjectFromDataTable<List<Task>>(pResultSet); }

        /// <summary>
        /// This method populates the survey list based on the recordset given
        /// </summary>
        /// <param name="pResultSet">The recordset containing the surveys to create</param>
        public void CreateSurveys(DataTable pResultSet) { SurveyList = CreateObjectFromDataTable<List<Survey>>(pResultSet); }

        /// <summary>
        /// This method populates the account list based on the recordset given
        /// </summary>
        /// <param name="pResultSet">The recordset containing the accounts to create</param>
        public void CreateAccounts(DataTable pResultSet) { }

        /// <summary>
        /// This method populates the Expense list based on the recordset given
        /// </summary>
        /// <param name="pResultSet">The recordset containing the expenses to create</param>
        public void CreateExpenses(DataTable pResultSet) { ExpenseList = CreateObjectFromDataTable<List<Expense>>(pResultSet); }

        /// <summary>
        /// This method populates the Timeslice list based on the recordset given
        /// </summary>
        /// <param name="pResultSet">The recordset containing the timeslices to create</param>
        public void CreateTimeslices(DataTable pResultSet) { TimeSliceList = CreateObjectFromDataTable<List<Timeslice>>(pResultSet); }

        /// <summary>
        /// This method populates the user list based on the recordset given
        /// </summary>
        /// <param name="pResultSet">The recordset containing the users to create</param>
        public User CreateUsers(DataTable pResultSet) { return CreateObjectFromDataTable<User>(pResultSet); }

        #endregion

        #region Private methods

        /// <summary>
        /// This method creates the object specidied based on the id given. It will lookup the db for the id and context specified and 
        /// creates the object(-s) in question
        /// </summary>
        /// <typeparam name="T">The type of object to create</typeparam>
        /// <param name="pId">The id of the object to lookup</param>
        /// <returns>Object of the type specified</returns>
        private T CreateObjectFromId<T>(string pId)
        {
            T tmp = default(T);
            if (typeof (IProject) == typeof (T))
            {
            }
            else if (typeof (ITask) == typeof (T))
            {
            }
            else if (typeof (ISurvey) == typeof (T))
            {
            }
            else if (typeof (IExpense) == typeof (T))
            {
            }
            else if (typeof (ITimeslice) == typeof (T))
            {
            }
            else if (typeof (ISurveyOption) == typeof (T))
            {
            }
            else if (typeof (IVote) == typeof (T))
            {
            }
            else if (typeof (ITask) == typeof (T))
            {
            }
            else
                throw new ArgumentException($"The generic method does not implement functionality for type {typeof (T).ToString()}");

            return tmp;
        }

        /// <summary>
        /// This method creates the type of object specified based on a fixed column mapping of the data table provided
        /// </summary>
        /// <typeparam name="T">The type of object to create</typeparam>
        /// <param name="pRecordSet">The dataTable which contains the recordset to process</param>
        /// <returns>Object of type specified</returns>
        private T CreateObjectFromDataTable<T>(DataTable pRecordSet)
        {
            T tmp = default(T);
            if (typeof (IProject) == typeof (T))
            {
            }
            else if (typeof (ITask) == typeof (T))
            {
            }
            else if (typeof (ISurvey) == typeof (T))
            {
            }
            else if (typeof (IExpense) == typeof (T))
            {
            }
            else if (typeof (ITimeslice) == typeof (T))
            {
            }
            else if (typeof (ISurveyOption) == typeof (T))
            {
            }
            else if (typeof (IVote) == typeof (T))
            {
            }
            else if (typeof (ITask) == typeof (T))
            {
            }
            else
                throw new ArgumentException($"The generic method does not implement functionality for type {typeof (T).ToString()}");

            return tmp;
        }

        private void UpdateTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e) { throw new NotImplementedException(); }

        #endregion
    }
}