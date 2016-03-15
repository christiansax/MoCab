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
            List<T> tmp=new List<T>();

            if (typeof (Project) == typeof (T))
            {
                // Assemble project interaction from resultset
            }
            else if(typeof(Task) == typeof(T))
            {
                // Assemble task interaction from resultset
            }
            else if (typeof(Survey) == typeof(T))
            {
                // Assemble survey interaction from resultset
            }
            else if (typeof(Expense) == typeof(T))
            {
                // Assemble Expense interaction from resultset
            }
            else if (typeof(Timeslice) == typeof(T))
            {
                // Assemble Timeslice interaction from resultset
            }
            else if (typeof(SurveyOption) == typeof(T))
            {
                // Assemble SurveyOption from resultset
            }
            else if (typeof(Vote) == typeof(T))
            {
                // Assemble vote from recordset
            }
            else if (typeof(User) == typeof(T))
            {
                // Assemble user from recordset
            }
            else
            {
                throw new ArgumentException($"The type provided is not implemented. Cannot assemble type {typeof(T).ToString()}");
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

        //public List<Project> GetProjectsForUser() 

        public T CreateObjectFromDataTable<T>(List<Control> pFormControls, string pId) { throw new NotImplementedException(); }

        public T CreateObjectFromDataTable<T>(List<Control> pFormControls, DataTable pRecordSet) { throw new NotImplementedException(); }

        #endregion

        private void UpdateTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
