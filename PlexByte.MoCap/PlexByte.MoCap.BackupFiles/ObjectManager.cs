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
using PlexByte.MoCap.Interactions;
using PlexByte.MoCap.Security;
using Timer = System.Timers.Timer;
using WeifenLuo.WinFormsUI.Docking;
using System.Timers;
using PlexByte.MoCap.OLD;
using PlexByte.MoCap.WinForms.UserControls;

namespace PlexByte.MoCap.Managers.OLD
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

        #endregion

        #region Variables
        
        DataManager _dataManager = new DataManager();
        FormManager _formManager = new FormManager();
        private Timer _updateTimer = null;
        //  private DataManager _dataManager = null;

        #endregion
        
        #region Ctor & Dtor

        public ObjectManager(DataManager pDataManager)
        {
            // Initialize the time which will periodically update the objects
            _updateTimer = new Timer(20000);
            _updateTimer.AutoReset = false;
            _updateTimer.Elapsed += UpdateTimer_Elapsed;

            //_dataManager = pDataManager;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (_updateTimer != null && _updateTimer.Enabled)
            {
                _updateTimer.Stop();
                _updateTimer.Enabled = false;
            }
            _updateTimer = null;

            if(_dataManager!=null)
                _dataManager.Dispose();
            _dataManager = null;

            if (_formManager != null)
                _formManager.Dispose();
            _formManager = null;
        }

        #endregion

        public List<IProject> ProjectList
        {
            get;
            private set;
        }

        public List<ITask> TaskList
        {
            get;
            private set;
        }

        public List<ISurvey> SurveyList
        {
            get;
            private set;
        }

        public List<IExpense> ExpenseList
        {
            get;
            private set;
        }

        public List<Timeslice> TimesliceList
        {
            get;
            private set;
        }

        public List<IUser> UserList
        {
            get;
            private set;
        }

        private void GetAllProjectUsers(string pProjectId)
        {
            throw new System.NotImplementedException();
        }

        private void GetAllTasks(string pId, bool pIsProjectId)
        {
            throw new System.NotImplementedException();
        }

        private void GetAllSurveys(string pId, bool pIsProjectId)
        {
            throw new System.NotImplementedException();
        }

        private void GetAllTimeslices(string pId, bool pIsProjectId)
        {
            throw new System.NotImplementedException();
        }

        private void GetAllExpenses(string pId, bool pIsProjectId)
        {
            throw new System.NotImplementedException();
        }

        public void InitializeDBObjects(string pUserId)
        {
            throw new System.NotImplementedException();
        }

        public T GetObjectById<T>(string pId)
        {
            throw new System.NotImplementedException();
        }

        public void LoginUser(string pId)
        {
            throw new System.NotImplementedException();
        }

        public void LogoutUser()
        {
            throw new System.NotImplementedException();
        }

        public T CreateObjectFromForm<T>(DockContent pForm)
        {
            if (pForm.GetType() == typeof(uc_Project))
            {
                return (T)(_formManager.CreateObjectFromForm<IProject>(pForm));
            }
            else if (pForm.GetType() == typeof(uc_User))
            {
                return (T)(_formManager.CreateObjectFromForm<IUser>(pForm));
            }
            else if (pForm.GetType() == typeof(uc_Task))
            {
                return (T)(_formManager.CreateObjectFromForm<ITask>(pForm));
            }
            else if (pForm.GetType() == typeof(uc_Survey))
            {
                return (T)(_formManager.CreateObjectFromForm<ISurvey>(pForm));
            }
            else if (pForm.GetType() == typeof(uc_Expense))
            {
                return (T)(_formManager.CreateObjectFromForm<IExpense>(pForm));
            }
            else if (pForm.GetType() == typeof(uc_Timeslice))
            {
                return (T)(_formManager.CreateObjectFromForm<ITimeslice>(pForm));
            }
            else
            {
                throw new InvalidCastException($"The type {pForm.GetType().ToString()} cannot be created as was never defined");
            }
        }

        public DockContent CreateFormFromObject<T>(T pObject)
        {
            throw new System.NotImplementedException();
        }

        private void UpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}