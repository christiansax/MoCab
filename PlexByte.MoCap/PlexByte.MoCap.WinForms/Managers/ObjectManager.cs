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
using PlexByte.MoCap.WinForms.UserControls;
using System.Timers;
using PlexByte.MoCap.WinForms;

namespace PlexByte.MoCap.Managers
{
    public class ObjectManager : IDisposable
    {
        DataManager _dataManager = new DataManager();
        FormManager _formManager = new FormManager();
        IInteractionFactory _interactionFactory = null;
        IObjectFactory _objectFactory = null;
        private frm_MoCapMain _MainUI = null;
        Timer _updateTimer = null;
        
        #region Ctor & Dtor

        public ObjectManager(frm_MoCapMain pMainForm)
        {
            _MainUI = pMainForm;
            // Instanciate factories to create object
            _interactionFactory = new InteractionFactory();
            _objectFactory = new ObjectFactory();

            // Initialize the time which will periodically update the objects
            _updateTimer = new Timer(20000);
            _updateTimer.AutoReset = false;
            _updateTimer.Elapsed += UpdateTimer_Elapsed;

            //_dataManager = pDataManager;
        }

        private void UpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            throw new NotImplementedException();
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

        public List<ITimeslice> TimesliceList
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
            DockContent tmp = null;
            if (pObject.GetType() == typeof (IUser))
            {
                tmp = _formManager.CreateUserFormFromObject((IUser)pObject);
            }
            else
            {
                tmp = _formManager.CreateFormFromObject((IInteraction)pObject);
            }

            return tmp;
        }
    }
}