//////////////////////////////////////////////////////////////
//                      Class DataManager
//      Author: Christian B. Sax            Date:   2016/03/14
//      This class manages is used to convert from Object to SQL parsable data and vice versa.
//      The objective is to encapsulate any backend related conversions within this class and 
//      expose objects to calling classes only
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using PlexByte.MoCap.Interactions;
using PlexByte.MoCap.Security;
using PlexByte.MoCap.Backend;

namespace PlexByte.MoCap.Managers
{
    public class DataManager : IDisposable
    {
        #region Properties

        #endregion

        #region Variables

        private BackendService _backendService = null;
        private IInteractionFactory _interactionFactory = null;
        private IObjectFactory _objectFactory = null;
        private ObjectManager _objectManager = null;

        #endregion

        #region Ctor & Dtor

        public DataManager(ObjectManager pInstance)
        {
            _backendService = new BackendService();
            _interactionFactory = new InteractionFactory();
            _objectFactory = new ObjectFactory();
            _objectManager = pInstance;
        }

        public void Dispose()
        {
            _backendService?.Dispose();
            _backendService = null;

            _interactionFactory = null;
            _objectFactory = null;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// This method get a project based on the id specified from the database
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        public IProject GetProjectById(string pId)
        {
            DataTable record = _backendService.GetProjectById(pId);
            if (record.Rows.Count > 0)
            {
                IProject project = _interactionFactory.CreateProject(record.Rows[0]["Id"].ToString(),
                    record.Rows[0]["ProjectDescription"].ToString(),
                    Convert.ToBoolean(record.Rows[0]["EnableBalance"].ToString()),
                    Convert.ToBoolean(record.Rows[0]["EnableSurvey"].ToString()),
                    DateTime.Parse(record.Rows[0]["StartDateTime"].ToString()),
                    DateTime.Parse(record.Rows[0]["EndDateTime"].ToString()),
                    GetUser(record.Rows[0]["CreatorId"].ToString(), false),
                    GetUser(record.Rows[0]["OwnerId"].ToString(), false),
                    null,
                    null,
                    null,
                    null,
                    record.Rows[0]["Name"].ToString());
                ((Project) project).Name = record.Rows[0]["Name"].ToString();
                record = null;
                return project;
            }
            else
                return null;
        }

        /// <summary>
        /// This method get a task based on the id specified from the database
        /// </summary>
        /// <param name="pId">The id of the task to lookup</param>
        /// <returns>ITask matching the id specified</returns>
        public ITask GetTaskById(string pId)
        {
            DataTable record = _backendService.GetTaskById(pId);
            if (record.Rows.Count > 0)
            {
                ITask task = _interactionFactory.CreateTask(record.Rows[0]["Id"].ToString(),
                    record.Rows[0]["TaskDescription"].ToString(),
                    record.Rows[0]["Title"].ToString(),
                    GetUser(record.Rows[0]["CreatorId"].ToString(), false),
                    DateTime.Parse(record.Rows[0]["StartDateTime"].ToString()),
                    DateTime.Parse(record.Rows[0]["EndDateTime"].ToString()),
                    DateTime.Parse(record.Rows[0]["DueDateTime"].ToString()),
                    Convert.ToDecimal(record.Rows[0]["Budget"].ToString()),
                    Convert.ToInt32(record.Rows[0]["Duration"].ToString()),
                    Convert.ToInt32(record.Rows[0]["Priority"].ToString()),
                    (InteractionState) Enum.Parse(typeof (InteractionState), record.Rows[0]["StateName"].ToString()),
                    Convert.ToDecimal(record.Rows[0]["BudgetUsed"].ToString()),
                    Convert.ToInt32(record.Rows[0]["DurationUsed"].ToString()),
                    null,
                    Convert.ToInt32(record.Rows[0]["Progress"].ToString()));
                record = null;
                return task;
            }
            else
                return null;
        }

        /// <summary>
        /// This method get a survey based on the id provided from the database
        /// </summary>
        /// <param name="pId">The Id of the survey to lookup</param>
        /// <returns>ISurvey object that was created and mathes the Id</returns>
        public ISurvey GetSurveyById(string pId)
        {
            DataTable record = _backendService.GetSurveyById(pId);
            List<ISurveyOption> surveyOptions = GetSurveyOptions(pId);
            List<IVote> votes = (from DataRow row
                in _backendService.GetVoteById(record.Rows[0]["Id"].ToString(), true).Rows
                select _objectFactory.CreateVote(row["Id"].ToString(),
                    GetUser(row["UserId"].ToString(), false),
                    GetSurveyOption(row["OptionId"].ToString()))).ToList();
            ISurvey survey = _interactionFactory.CreateSurvey(record.Rows[0]["Id"].ToString(),
                record.Rows[0]["Text"].ToString(),
                surveyOptions ?? new List<ISurveyOption>(),
                GetUser(record.Rows[0]["Creator"].ToString(), false),
                DateTime.Parse(record.Rows[0]["StartDateTime"].ToString()),
                DateTime.Parse(record.Rows[0]["EndDateTime"].ToString()),
                DateTime.Parse(record.Rows[0]["DueDateTime"].ToString()),
                Convert.ToInt32(record.Rows[0]["MaxVotePerUser"].ToString()),
                record.Rows[0]["Title"].ToString(),
                (InteractionState)Enum.Parse(typeof(InteractionState), record.Rows[0]["StateName"].ToString()),
                votes);
            survey.ProjectId = record.Rows[0]["ProjectId"].ToString();
            record = null;
            surveyOptions = null;
            votes = null;
            return survey;
        }

        public IExpense GetExpenseById(string pId)
        {
            DataTable record = _backendService.GetExpenseById(pId);
            IInteraction tmp = null;
            if (record.Rows[0]["ProjectId"].ToString().Length > 0)
                tmp = (IInteraction)GetProjectById(record.Rows[0]["ProjectId"].ToString());
            else if(record.Rows[0]["TaskId"].ToString().Length > 0)
                tmp = (IInteraction)GetTaskById(record.Rows[0]["TaskId"].ToString());

            IExpense expense = _interactionFactory.CreateExpense(record.Rows[0]["Id"].ToString(),
                "",
                GetUser(record.Rows[0]["CreatorId"].ToString(), false),
                tmp);
            record = null;
            return expense;
        }

        public ITimeslice GetTimesliceById(string pId)
        {
            DataTable record = _backendService.GetTimesliceById(pId);
            IInteraction tmp = null;
            if (record.Rows[0]["ProjectId"].ToString().Length > 0)
                tmp = (IInteraction)GetProjectById(record.Rows[0]["ProjectId"].ToString());
            else if (record.Rows[0]["TaskId"].ToString().Length > 0)
                tmp = (IInteraction)GetTaskById(record.Rows[0]["TaskId"].ToString());

            ITimeslice timeslice = _interactionFactory.CreateTimeslice(record.Rows[0]["Id"].ToString(),
                GetUser(record.Rows[0]["CreatorId"].ToString(), false),
                Convert.ToInt32(record.Rows[0]["CreatorId"].ToString()),
                tmp);
            record = null;
            return timeslice;
        }

        /// <summary>
        /// This method gets a survey option from the database
        /// </summary>
        /// <param name="pId">The Id of the survey option</param>
        /// <returns>ISurveyOption mathing the Id provided</returns>
        public ISurveyOption GetSurveyOption(string pId)
        {
            DataTable record = _backendService.GeSurveyOptionById(pId);
            if (record.Rows.Count > 0)
            {
                return _objectFactory.CreateSurveyOption(record.Rows[0]["Id"].ToString(),
                    record.Rows[0]["Text"].ToString());
            }
            else
                return null;
        }

        /// <summary>
        /// This method gets the survey options of a survey from the database
        /// </summary>
        /// <param name="pSurveyId">The survey Id to get the options from</param>
        /// <returns>List of ISurveyOptions matching the id of the survey given</returns>
        public List<ISurveyOption> GetSurveyOptions(string pSurveyId)
        {
            List<ISurveyOption> options = null;
            DataTable records = _backendService.GetSurveyOptions(pSurveyId);
            if (records.Rows.Count > 0)
            {
                foreach (DataRow row in records.Rows)
                {
                    if (options == null) options = new List<ISurveyOption>();
                    options.Add(_objectFactory.CreateSurveyOption(row["Id"].ToString(),
                        row["Text"].ToString()));
                }
            }
            return options;
        }

        /// <summary>
        /// This method gets a vote based on the id provieded from the database
        /// </summary>
        /// <param name="pId">The id of the vote to lookup</param>
        /// <returns>IVote matching the id provided</returns>
        public IVote GetVoteById(string pId)
        {
            DataTable record = _backendService.GetVoteById(pId, false);
            if (record.Rows.Count > 0)
            {
                return (_objectFactory.CreateVote(record.Rows[0]["Id"].ToString(),
                    GetUser(record.Rows[0]["UserId"].ToString(), true),
                    GetSurveyOption(record.Rows[0]["SurveyOptionId"].ToString())));
            }
            else
                return null;
        }

        /// <summary>
        /// This method returns a list of votes left for a survey
        /// </summary>
        /// <param name="pId">The survey id</param>
        /// <returns>List of IVote for the survey provided</returns>
        public List<IVote> GetVoteBySurveyId(string pId)
        {
            List<IVote> votes = null;
            DataTable records = _backendService.GetVoteById(pId, true);
            foreach (DataRow row in records.Rows)
            {
                if (votes == null) votes = new List<IVote>();
                votes.Add(_objectFactory.CreateVote(row["Id"].ToString(),
                    GetUser(row["UserId"].ToString(), true),
                    GetSurveyOption(row["SurveyOptionId"].ToString())));
            }
            return votes;
        }

        /// <summary>
        /// This method get a used either based on Id or username
        /// </summary>
        /// <param name="pUserId">Either userId or userName to lookup</param>
        /// <param name="pIsUserName">Set true if Id contains a userName</param>
        /// <returns>IUser matching either Id or userName provided</returns>
        public IUser GetUser(string pUserId, bool pIsUserName)
        {
            IUser user = null;
            if (!pIsUserName)
            {
                if (!Regex.IsMatch(pUserId, @"^\d+$"))
                    pIsUserName = true;
            }
            DataTable dt = (pIsUserName)
                ? _backendService.GetUserByUserName(pUserId)
                : _backendService.GetUserById(pUserId);
            if (dt.Rows.Count > 0)
            {
                user = _objectFactory.CreateUser(dt.Rows[0]["Id"].ToString(),
                    dt.Rows[0]["FirstName"].ToString(),
                    dt.Rows[0]["LastName"].ToString(),
                    dt.Rows[0]["MiddleName"].ToString(),
                    dt.Rows[0]["EmailAddress"].ToString(),
                    DateTime.Parse(dt.Rows[0]["Birthdate"].ToString()),
                    dt.Rows[0]["Username"].ToString(),
                    dt.Rows[0]["Password"].ToString(),
                    DateTime.Parse(dt.Rows[0]["ModifiedDateTime"].ToString()),
                    DateTime.Parse(dt.Rows[0]["CreatedDateTime"].ToString()),
                    dt.Rows[0]["PersonId"].ToString());
            }
            return user;
        }

        /// <summary>
        /// This method returns a list of interaction based on the user given and type specified
        /// </summary>
        /// <param name="pUserId">The user id to use in the search</param>
        /// <returns>List of Interactions for this user</returns>
        public List<T> GetAllInteractions<T>(string pUserId)
        {
            List<T> interactions = new List<T>();
            if (typeof (T) == typeof (IProject))
            {
                interactions.AddRange(
                    from DataRow row in _backendService.GetProjectsByUser(pUserId).Rows
                    select (T) GetProjectById(row["Id"].ToString()));
            }
            else if (typeof (T) == typeof (ITask))
            {
                foreach (DataRow project in _backendService.GetProjectsByUser(pUserId).Rows)
                {
                    interactions.AddRange(
                        from DataRow row in _backendService.GetTaskByProjectId(project["Id"].ToString()).Rows
                        select (T) GetTaskById(row["Id"].ToString()));
                }
            }
            else if (typeof (T) == typeof (ISurvey))
            {
                foreach (DataRow project in _backendService.GetProjectsByUser(pUserId).Rows)
                {
                    interactions.AddRange(
                        from DataRow row in _backendService.GetSurveyByProjectId(project["Id"].ToString(),
                            ObjectType.Project).Rows
                        select (T) GetSurveyById(row["Id"].ToString()));
                }
            }
            else if (typeof (T) == typeof (IExpense))
            {
                foreach (DataRow project in _backendService.GetProjectsByUser(pUserId).Rows)
                {
                    interactions.AddRange(
                        from DataRow row in _backendService.GetExpenseByProjectId(project["Id"].ToString()).Rows
                        select (T)GetExpenseById(row["Id"].ToString()));
                }
            }
            else if (typeof (T) == typeof (ITimeslice))
            {
                foreach (DataRow project in _backendService.GetProjectsByUser(pUserId).Rows)
                {
                    interactions.AddRange(
                        from DataRow row in _backendService.GetTimeSliceByProjectId(project["Id"].ToString()).Rows
                        select (T)GetTimesliceById(row["Id"].ToString()));
                }
            }
            else
            {
                throw new InvalidCastException($"The type {typeof (T).ToString()} is not implemented");
            }
            return interactions;
        }

        public void UpsertExpense(Expense pExpense) { throw new System.NotImplementedException(); }

        /// <summary>
        /// This method inserts or updated a project in the database
        /// </summary>
        /// <param name="pProject"></param>
        public void UpsertProject(Project pProject)
        {
            _backendService.InsertProject(pProject.Id,
                pProject.Name,
                pProject.Text,
                pProject.StartDateTime,
                pProject.EndDateTime,
                pProject.Owner.Id,
                pProject.EnableBalance,
                pProject.EnableSurvey,
                pProject.IsActive,
                pProject.Creator.Id,
                pProject.State);
        }

        /// <summary>
        /// This method inserts or updated a survey in the database
        /// </summary>
        /// <param name="pSurvey">The survey to update or insert</param>
        public void UpsertSurvey(Survey pSurvey)
        {
            _backendService.InsertSurvey(pSurvey.Id,
                pSurvey.InteractionId,
                pSurvey.MaxVotesPerUser,
                pSurvey.DueDateTime,
                pSurvey.StartDateTime,
                pSurvey.EndDateTime,
                pSurvey.Creator.Id,
                pSurvey.Owner.Id,
                pSurvey.IsActive,
                pSurvey.State,
                pSurvey.ProjectId,
                pSurvey.Text,
                pSurvey.Title);
            if (pSurvey.OptionList.Count > 0)
            {
                foreach (var option in pSurvey.OptionList)
                {
                    _backendService.InsertSurveyOption(option.Id, option.Text, pSurvey.Id);
                }
            }
        }

        /// <summary>
        /// This method inserts or updates a task in the database
        /// </summary>
        /// <param name="pTask">The task to insert or update</param>
        public void UpsertTask(Task pTask)
        {
            _backendService.InsertTask(pTask.Id,
                pTask.InteractionId,
                pTask.DueDateTime,
                pTask.Budget,
                pTask.Duration,
                pTask.Priority,
                pTask.Progress,
                pTask.DurationCurrent,
                pTask.BudgetUsed,
                pTask.StartDateTime,
                pTask.EndDateTime,
                pTask.IsActive,
                pTask.Text,
                pTask.Creator.Id,
                pTask.Owner.Id,
                pTask.State.ToString(),
                pTask.ProjectId);
        }

        /// <summary>
        /// This method inserts or updates a timeslice in the database
        /// </summary>
        /// <param name="pTimeslice">The timeslice to insert or update</param>
        public void UpsertTimeslice(Timeslice pTimeslice)
        {
            _backendService.InsertTimeslice(pTimeslice.Id,
                pTimeslice.Duration,
                pTimeslice.Target.Id,
                pTimeslice.Description,
                pTimeslice.Target.Type.ToString(),
                pTimeslice.CreatedDateTime);
        }

        /// <summary>
        /// This method inserts or updates a user in the database
        /// </summary>
        /// <param name="pUser">The user to insert or update</param>
        public void UpsertUser(User pUser)
        {
            _backendService.InsertUser(pUser.Id,
                pUser.FirstName,
                pUser.LastName,
                pUser.MiddleName,
                pUser.EmailAddress,
                pUser.Birthdate,
                pUser.Username,
                pUser.Password);
        }

        /// <summary>
        /// This method inserts or updates a vote in the database
        /// </summary>
        /// <param name="pVote">The vote to insert or update</param>
        public void UpsertVote(Vote pVote)
        {
            _backendService.InsertVote(pVote.Id,
                pVote.Option.Id,
                pVote.User.Id,
                pVote.CreatedDateTime);
        }

        /// <summary>
        /// This method inserts or updates a SurveyOption in the database
        /// </summary>
        /// <param name="pSurveyOption">The survey option to insert or update</param>
        public void UpsertSurveyOption(SurveyOption pSurveyOption, string pSurveyId)
        {
            _backendService.InsertSurveyOption(pSurveyOption.Id,
                pSurveyOption.Text,
                pSurveyId);
        }

        #endregion
    }
}
