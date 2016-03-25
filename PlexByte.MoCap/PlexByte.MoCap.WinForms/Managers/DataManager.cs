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

        public IProject GetProjectById(string pId) { return null; }

        public ITask GetTaskById(string pId) { return null; }

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

        public bool UpsertExpense(Expense pExpense)
        {
            throw new System.NotImplementedException();
        }

        public bool UpsertProject(Project pProject)
        {
            throw new System.NotImplementedException();
        }

        public void UpsertSurvey(Survey pSurvey)
        {
            _backendService.InsertSurvey(pSurvey.Id,
                pSurvey.InteractionId,
                pSurvey.DueDateTime,
                pSurvey.StartDateTime,
                pSurvey.EndDateTime,
                pSurvey.Creator.Id,
                pSurvey.Owner.Id,
                pSurvey.IsActive,
                pSurvey.State.ToString());
        }

        public void UpsertTask(Task pTask)
        {
            _backendService.InsertTask(pTask.Id, pTask.InteractionId, pTask.DueDateTime, pTask.Budget, pTask.Duration,
                pTask.Priority, pTask.Progress, pTask.DurationCurrent, pTask.BudgetUsed, pTask.StartDateTime, pTask.EndDateTime,
                pTask.IsActive, pTask.Text, pTask.Creator.Id, pTask.Owner.Id, pTask.State.ToString(), pTask.ProjectId);
        }

        public bool UpsertTimeslice(Timeslice pTimeslice)
        {
            throw new System.NotImplementedException();
        }

        public void UpsertUser(User pUser)
        {
            _backendService.InsertUser(pUser.Id,pUser.FirstName, pUser.LastName, pUser.MiddleName, pUser.EmailAddress, 
                pUser.Birthdate, pUser.Username, pUser.Password);
        }

        public void UpsertVote(Vote pVote)
        {
            _backendService.InsertVote(pVote.Id,
                pVote.Option.Id,
                pVote.User.Id,
                pVote.CreatedDateTime);
        }

        public void UpsertSurveyOption(SurveyOption pSurveyOption)
        {
            _backendService.InsertSurveyOption(pSurveyOption.Id,
                pSurveyOption.Text,
                pSurveyOption.CreatedDateTime);
        }

        public ISurveyOption GetSurveyOption(string pId)
        {
            return "";
            // _backendService.GeSurveyOptionById()
        }

        public List<SurveyOption> GetSurveyOptions(string pSurveyId)
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
    }
}
