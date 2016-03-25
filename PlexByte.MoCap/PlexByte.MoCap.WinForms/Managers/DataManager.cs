//////////////////////////////////////////////////////////////
//                      Class DataManager
//      Author: Christian B. Sax            Date:   2016/03/14
//      This class manages is used to convert from Object to SQL parsable data and vice versa.
//      The objective is to encapsulate any backend related conversions within this class and 
//      expose objects to calling classes only
using System;
using System.Collections.Generic;
using PlexByte.MoCap.Interactions;
using PlexByte.MoCap.Security;
using PlexByte.MoCap.Backend;

namespace PlexByte.MoCap.Managers
{
    public class DataManager:IDisposable
    {
        private BackendService _backendService = null;
        private IInteractionFactory _interactionFactory = null;
        private IObjectFactory _objectFactory = null;

        #region Ctor & Dtor

        public DataManager()
        {
            _backendService = new BackendService();
            _interactionFactory = new InteractionFactory();
            _objectFactory = new ObjectFactory();
        }

        public void Dispose()
        {
            _backendService?.Dispose();
            _backendService = null;

            _interactionFactory = null;
            _objectFactory = null;
        }

        #endregion

        public IProject GetProjectById(string pId)
        {
            
        }

        public ITask GetTaskById(string pId)
        {
            
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

        public bool UpsertTask(ITask pTask)
        {
            throw new System.NotImplementedException();
        }

        public bool UpsertTimeslice(ITimeslice pTimeslice)
        {
            throw new System.NotImplementedException();
        }

        public bool UpsertUser(IUser pUser)
        {
            throw new System.NotImplementedException();
        }

        public ISurveyOption GetSurveyOption(string pId)
        {
            throw new System.NotImplementedException();
        }

        public List<SurveyOption> GetSurveyOptions(string pSurveyId)
        {
            throw new System.NotImplementedException();
        }

        public bool UpsertSurveyOption(ISurveyOption pSurveyOption)
        {
            throw new System.NotImplementedException();
        }

        public IVote GetVoteById(string pId)
        {
            throw new System.NotImplementedException();
        }

        public List<IVote> GetVoteBySurveyId(string pId)
        {
            throw new System.NotImplementedException();
        }

        public bool UpsertVote(IVote pVote)
        {
            throw new System.NotImplementedException();
        }
    }
}
