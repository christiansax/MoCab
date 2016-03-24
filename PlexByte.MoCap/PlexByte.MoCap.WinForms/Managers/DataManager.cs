//////////////////////////////////////////////////////////////
//                      Class DataManager
//      Author: Christian B. Sax            Date:   2016/03/14
//      This class manages is used to convert from Object to SQL parsable data and vice versa.
//      The objective is to encapsulate any backend related conversions within this class and 
//      expose objects to calling classes only
using System;
using System.Collections.Generic;
using System.Linq;
using PlexByte.MoCap.Backend;
using PlexByte.MoCap.Interactions;
using PlexByte.MoCap.Security;

namespace PlexByte.MoCap.Managers
{
    public class DataManager:IDisposable
    {
        #region OLD

        private ObjectManager _objectManager = null;
        private BackendService _backendService = null;

        public DataManager()
        {
            _backendService = new BackendService();
            // _objectManager = new ObjectManager(this);
            ProjectList=new List<IProject>();
            TaskList=new List<ITask>();
            SurveyList =new List<ISurvey>();
            ExpenseList=new List<IExpense>();
            TimeSliceList=new List<ITimeslice>();
            UserList=new List<IUser>();
        }
        public void Dispose()
        {
            if (_backendService != null)
                _backendService = null;

            if (_objectManager != null)
                _objectManager.Dispose();
            _objectManager = null;

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
            UserList = null;
        }

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

        public List<IUser> UserList { get; set; }

        public IProject CreateProjectById(string pId)
        {
            IProject tmp = _objectManager.CreateProjects(_backendService.GetProjectById(pId)).First();
            if (!ProjectList.Contains(tmp))
                ProjectList.Add(tmp);
            return tmp;
        }

        public ITask CreateTaskById(string pId)
        {
            ITask tmp = _objectManager.CreateTasks(_backendService.GetTaskById(pId)).First();
            if (!TaskList.Contains(tmp))
                TaskList.Add(tmp);
            return tmp;
        }

        public ISurvey CreateSurveyById(string pId)
        {
            ISurvey tmp = _objectManager.CreateSurveys(_backendService.GetSurveyById(pId)).First();
            if (!SurveyList.Contains(tmp))
                SurveyList.Add(tmp);
            return tmp;
        }

        public IExpense CreateExpenseById(string pId)
        {
            IExpense tmp = _objectManager.CreateExpenses(_backendService.GetExpenseById(pId)).First();
            if (!ExpenseList.Contains(tmp))
                ExpenseList.Add(tmp);
            return tmp;
        }

        public ITimeslice CreateTimesliceById(string pId)
        {
            ITimeslice tmp = _objectManager.CreateTimeslices(_backendService.GetTimesliceById(pId)).First();
            if (!TimeSliceList.Contains(tmp))
                TimeSliceList.Add(tmp);
            return tmp;
        }

        public IUser CreateUserById(string pId)
        {
            IUser tmp=_objectManager.CreateUsers(_backendService.GetUserById(pId)).First();
            if(!UserList.Contains(tmp))
                UserList.Add(tmp);
            return tmp;
        }

        public IUser CreateUserByUserName(string pUserName)
        {
            IUser tmp = _objectManager.CreateUsers(_backendService.GetUserByUserName(pUserName)).First();
            if (!UserList.Contains(tmp))
                UserList.Add(tmp);
            return tmp;
        }

        public IUser AuthenticateUser(string pUserName, string pPassword)
        {
            return _objectManager.CreateUsers(_backendService.AuthenticateUser(pUserName, pPassword)).First();
        }

        public void InsertUser(string pUserId,
            string pFirstName,
            string pLastName,
            string pMiddleName,
            string pEmail,
            DateTime pBirthdate,
            string pUserName,
            string pPassword)
        {
            _backendService.InsertUser(pUserId, pFirstName, pLastName, pMiddleName, pEmail, pBirthdate, pUserName, pPassword);
        }

        public void InsertProject(string pProjectId,
            string pTitle,
            string pDescription,
            DateTime pStartDate,
            DateTime pEndDate,
            string pOwner,
            string pCreator,
            int pEnableBalance,
            int pEnableSurvey,
            int pIsActive,
            string pStateId)
        {
            _backendService.InsertProject(pProjectId, pTitle, pDescription, pStartDate, pEndDate, pOwner, pEnableBalance, pEnableSurvey, pIsActive, pCreator, pStateId);
        }

        public DateTime GetLastUserLogin(string pUserId) { return _backendService.LastUserLogin(pUserId); }
        public void InsertTask() {
           // _backendService.InsertTask()
        }

        #endregion

        #region NEW

        public IProject GetProjectById(string pId)
        {
            throw new System.NotImplementedException();
        }

        public ITask GetTaskById(string pId)
        {
            throw new System.NotImplementedException();
        }

        public ISurvey GetSurveyById(string pId)
        {
            throw new System.NotImplementedException();
        }

        public IExpense GetExpenseById(string pId)
        {
            throw new System.NotImplementedException();
        }

        public ITimeslice GetTimesliceById(string pId)
        {
            throw new System.NotImplementedException();
        }

        public IUser GetUser(string pUserId, bool pIsUserName)
        {
            throw new System.NotImplementedException();
        }

        public bool UpsertExpense(IExpense pExpense)
        {
            throw new System.NotImplementedException();
        }

        public bool UpsertProject(IProject pProject)
        {
            throw new System.NotImplementedException();
        }

        public bool UpsertSurvey(ISurvey pSurvey)
        {
            throw new System.NotImplementedException();
        }

        public virtual bool UpsertTask(ITask pTask)
        {
            throw new System.NotImplementedException();
        }

        public virtual bool UpsertTimeslice(ITimeslice pTimeslice)
        {
            throw new System.NotImplementedException();
        }

        public virtual bool UpsertUser(IUser pUser)
        {
            throw new System.NotImplementedException();
        }

        public virtual ISurveyOption GetSurveyOption(string pId)
        {
            throw new System.NotImplementedException();
        }

        public virtual List<SurveyOption> GetSurveyOptions(string pSurveyId)
        {
            throw new System.NotImplementedException();
        }

        public virtual bool UpsertSurveyOption(ISurveyOption pSurveyOption)
        {
            throw new System.NotImplementedException();
        }

        public virtual IVote GetVoteById(string pId)
        {
            throw new System.NotImplementedException();
        }

        public virtual List<IVote> GetVoteBySurveyId(string pId)
        {
            throw new System.NotImplementedException();
        }

        public virtual bool UpsertVote(IVote pVote)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
