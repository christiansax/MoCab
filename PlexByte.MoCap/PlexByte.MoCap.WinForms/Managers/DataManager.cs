//////////////////////////////////////////////////////////////
//                      Class DataManager
//      Author: Christian B. Sax            Date:   2016/03/14
//      This class manages is used to convert from Object to SQL parsable data and vice versa.
//      The objective is to encapsulate any backend related conversions within this class and 
//      expose objects to calling classes only
using System;
using System.Linq;
using PlexByte.MoCap.Backend;
using PlexByte.MoCap.Interactions;
using PlexByte.MoCap.Security;
using PlexByte.MoCap.WinForms.Managers;
using System.Windows.Forms;

namespace PlexByte.MoCap.WinForms
{
    public class DataManager:IDisposable
    {
        private ObjectManager _objectManager = null;
        private BackendService _backendService = null;

        public DataManager()
        {
            _backendService = new BackendService();
            _objectManager = new ObjectManager(this);
        }
        public void Dispose()
        {
            if (_backendService != null)
                _backendService = null;

            if (_objectManager != null)
                _objectManager.Dispose();
            _objectManager = null;
        }

        public IProject CreateProjectById(string pId)
        {
            return (_objectManager.CreateProjects(_backendService.GetProjectById(pId)).First());
        }

        public ITask CreateTaskById(string pId)
        {
            return (_objectManager.CreateTasks(_backendService.GetProjectById(pId)).First());
        }

        public ISurvey CreateSurveyById(string pId)
        {
            return (_objectManager.CreateSurveys(_backendService.GetProjectById(pId)).First());
        }

        public IExpense CreateExpenseById(string pId)
        {
            return (_objectManager.CreateExpenses(_backendService.GetProjectById(pId)).First());
        }

        public ITimeslice CreateTimesliceById(string pId)
        {
            return (_objectManager.CreateTimeslices(_backendService.GetProjectById(pId)).First());
        }

        public IUser CreateUserById(string pId)
        {
            return (_objectManager.CreateUsers(_backendService.GetProjectById(pId)).First());
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
            CheckState pEnableBalance,
            CheckState pEnableSurvey,
            CheckState pIsActive,
            string pStateId)
        {
            //bool _EnableBalance = Convert.ToBoolean(pEnableBalance);
            //bool _EnableSurvey = Convert.ToBoolean(pEnableSurvey);
            int _EnableBalance = Convert.ToInt32(pEnableBalance);
            int _EnableSurvey = Convert.ToInt32(pEnableSurvey);
            int _IsActive = Convert.ToInt32(pIsActive);

            _backendService.InsertProject(pProjectId, pTitle, pDescription, pStartDate, pEndDate, pOwner, _EnableBalance, _EnableSurvey, _IsActive, pOwner, pStateId);
        }
    }
}
