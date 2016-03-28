//////////////////////////////////////////////////////////////
//                      Class InteractionService                              
//      Author: Christian B. Sax            Date:   2016/03/2
//      This class provides backend functionality by reading and writing to the database. The class is not intended 
//      for converting business logic but to return record set to the caller for further business logic process.
//      Also inserting is not intended to convert from business objects into the db. Use Adapter classes, to do this
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Sockets;
using PlexByte.MoCap.Helpers;

namespace PlexByte.MoCap.Backend
{
    public enum ObjectType
    {
        User,
        Project
    }

    // TODO: Update documentation

    public class BackendService:IDisposable
    {
        private const string _DBServer = "198.38.83.33";
        private const string _Password = "MoCap";
        private string _DBUser = CryptoHelper.Decrypt("BjjfgaK9bvsBcQCzh2cA7D0OQnwJ1lrU/36zDXs5bKfbK/mCnQChL74+/wtOu1+6", _Password);
        private string _DBPWD = CryptoHelper.Decrypt("mFntrazoOtZJqDO+T8vCdtnm6aUjkfvf0Lh8kATxrZQkfNE0NiPDC7zXkb2h22MM", _Password);
        private string _connectionString = null;

        public BackendService()
        {
            _connectionString = string.Format("Server={0}; Database=csax2277_MoCap;User Id={1};Password={2};", _DBServer, _DBUser, _DBPWD);
        }

        public void Dispose() { _connectionString = null; }

        /// <summary>
        /// This method authenticates the given user and password against the database. If suceeded the ID of the authenticated user will be returnes
        /// </summary>
        /// <param name="pId">The id of the user to query results for</param>
        /// <returns>The Users Id</returns>
        public DataTable AuthenticateUser(string pUserName, string pPassword)
        {
            DataTable userInfo = new DataTable();
            pPassword = CryptoHelper.Encrypt(pPassword, _Password);
            userInfo = ExecuteQueryString($"select * from View_User where (Username = '{pUserName}' or EmailAddress = '{pUserName}') AND [Password] = '{pPassword}'");
            if (userInfo.Rows.Count < 1)
                throw new Exception($"Authentification failed! Username or password is invalid [UserName={pUserName}] [Password={pPassword}]");
            else
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    // Create the command and set its properties.
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "SPROC_AddUserLog";
                    command.CommandType = CommandType.StoredProcedure;

                    // Add the input parameter and set its properties.
                    SqlParameter parameter = new SqlParameter("@UserId", SqlDbType.BigInt)
                    {
                        Direction = ParameterDirection.Input,
                        Value = Convert.ToInt64(userInfo.Rows[0]["Id"])
                    };
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter("@ResultMsg", SqlDbType.VarChar)
                    {
                        Direction = ParameterDirection.Output,
                        Value = string.Empty
                    };
                    command.Parameters.Add(parameter);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0}: {1:C}", reader[0], reader[1]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    reader.Close();
                    return userInfo;
                }
            }
        }

        public DateTime LastUserLogin(string pUserId)
        {
            return DateTime.Parse(ExecuteQueryString($"select MAX([LogDateTime] from [View_UserLog] where UserId = '{pUserId}'").
                Rows[0]["LogDateTime"].ToString());
        }

        public DataTable GetProjectById(string pId)
        {
            return ExecuteQueryString($"select * from View_Project where Id = '{pId}'");
        }

        public DataTable GetTaskById(string pId)
        {
            return ExecuteQueryString($"select * from View_Task where Id = '{pId}'");
        }

        public DataTable GetSurveyById(string pId)
        {
            return ExecuteQueryString($"select * from View_Survey where Id = '{pId}'");
        }

        public DataTable GetExpenseById(string pId)
        {
            return ExecuteQueryString($"select * from View_Expense where Id = '{pId}'");
        }

        public DataTable GetTimesliceById(string pId)
        {
            return ExecuteQueryString($"select * from View_Timeslice where Id = '{pId}'");
        }

        public DataTable GeSurveyOptionById(string pId)
        {
            return ExecuteQueryString($"select * from View_SurveyOption where Id = '{pId}'");
        }

        /// <summary>
        /// This method returns either a single vote by its Id or a set of votes connected to a survey
        /// </summary>
        /// <param name="pId">The id to use in the lookup</param>
        /// <param name="pIsSurveyId">True if the id was a surveyId</param>
        /// <returns>DataTable containing either a single vote or a list of votes left for a survey</returns>
        public DataTable GetVoteById(string pId, bool pIsSurveyId)
        {
            DataTable resultSet = null;
            switch (pIsSurveyId)
            {
                case true:
                    return resultSet = ExecuteQueryString($"select * from View_Vote where SurveyId = '{pId}'");
                case false:
                    return resultSet = ExecuteQueryString($"select * from View_Vote where Id = '{pId}'");
                default:
                    return null;
            }
        }

        public DataTable GetUserById(string pId)
        {
            return ExecuteQueryString($"select * from View_User where Id = '{pId}'");
        }

        public DataTable GetUserByUserName(string pUserName)
        {
            return ExecuteQueryString($"select * from View_User where Username = '{pUserName}'");
        }

        /// <summary>
        /// If project is the type, all users being member of the project with the Id specified will be returned.
        /// Otherwise the user with the Id given is returned
        /// </summary>
        /// <param name="pId">The Id to use in the lookup</param>
        /// <param name="pType">The object type to use in the query (either Project or User)</param>
        /// <returns>DataTable containing either all members of a project or the user matching the Id</returns>
        public DataTable GetUserByProjectId(string pId)
        {
            return ExecuteQueryString($"select * from View_ProjectUserMapping where ProjectId = '{pId}' AND IsActive = 1");
        }

        /// <summary>
        /// This method gets all task for the userId or projectId specified and returns the datatable.
        /// </summary>
        /// <param name="pId">The id of the user or project to query</param>
        /// <param name="pType">The object type to use in the query (either Project or User)</param>
        /// <returns>DataTable containing all tasks for the user or project in question</returns>
        public DataTable GetTaskByProjectId(string pId)
        {
            return ExecuteQueryString($"select * from View_ProjectTaskMapping where ProjectId = '{pId}' AND IsActive = 1");
        }

        /// <summary>
        /// This method gets all Surveys a user can participate in or were assigned to the projectId.
        /// </summary>
        /// <param name="pId">The id of the user or project to query</param>
        /// <param name="pType">The object type to use in the query (either Project or User)</param>
        /// <returns>DataTable containing all Survey for the user or project in question</returns>
        public DataTable GetSurveyByProjectId(string pId, ObjectType pType)
        {
            return ExecuteQueryString($"select * from View_ProjectSurveyMapping where ProjectId = '{pId}' AND IsActive = 1");
        }

        /// <summary>
        /// This method gets all survey options that are available for the survey specified. It uses the SQL view_surveyoptions
        /// </summary>
        /// <param name="pSurveyId">The id of the survey to query</param>
        /// <returns>DataTable containing all Survey Options for the Survey in question</returns>
        public DataTable GetSurveyOptions(string pSurveyId)
        {
            return ExecuteQueryString($"select * from View_SurveyOptions where SurveyId = {pSurveyId}");
        }

        /// <summary>
        /// This method returns a recordset containing a grouped list of votes given for the survey id specified. It uses the 
        /// SQL view_votecount and has the following structure featuring a group by rollup
        /*  SurveyId	        Survey	                        OptionId	        SurveyOption	    UserId	Username	    Total
            20160225225053154	Which option would you go for?	20160225225057154	Choose option one	1       christian.sax	2
            20160225225053154	Which option would you go for?	20160225225057154	Choose option one	1       NULL	        2
            20160225225053154	Which option would you go for?	20160225225057154	Choose option one   NULL    NULL	        2
            20160225225053154	Which option would you go for?	20160225225057154	NULL                NULL    NULL	        2
            20160225225053154	Which option would you go for?	NULL                NULL                NULL    NULL            2
            20160225225053154	NULL                            NULL                NULL                NULL    NULL            2
            20160225225053190	What animal do you like most	20160225225057158	Jump on option three 1      christian.sax	1
            20160225225053190	What animal do you like most	20160225225057158	Jump on option three 1      NULL	        1
            20160225225053190	What animal do you like most	20160225225057158	Jump on option three NULL   NULL	        1
            20160225225053190	What animal do you like most	20160225225057158	NULL                NULL    NULL	        1
            20160225225053190	What animal do you like most    NULL                NULL                NULL    NULL            1
            20160225225053190	NULL                            NULL                NULL                NULL    NULL            1
            NULL                NULL                            NULL                NULL                NULL    NULL            3
        */
        /// </summary>
        /// <param name="pSurveyId"></param>
        /// <returns></returns>
        public DataTable GetVoteCount(string pSurveyId)
        {
            return ExecuteQueryString($"select * from View_VoteCount where SurveyId = {pSurveyId}");
        }

        /// <summary>
        /// Returns all projects a user created, owns or is a member of
        /// </summary>
        /// <param name="pUserId">The user Id to use in the query</param>
        /// <returns>DataSet containing all projects for this user</returns>
        public DataTable GetProjectsByUser(string pUserId)
        {
            return ExecuteQueryString($"select * from View_Project where Id in (select ProjectId from View_ProjectUserMapping where " +
                                      $"UserId = {pUserId}) AND ([OwnerId] = {pUserId} OR [CreatorId] = {pUserId})  AND IsActive = 1" +
                                      $" order by [Name]");
        }

        public DataTable GetAllReferencedUsers(string pUserId)
        {
            DataTable users = new DataTable();
            // Get all projects for this user
            foreach (DataRow row  in GetProjectsByUser(pUserId).Rows)
            {
                // Loop through all projects and check the usermapping
                foreach (DataRow row2 in GetUserByProjectId(row["Id"].ToString()).Rows)
                {
                    foreach (DataRow userRow in GetUserById(row2["Id"].ToString()).Rows)
                    {
                        if(!users.Rows.Contains(userRow))
                            users.Rows.Add(userRow);
                    }
                }
            }
            return users;
        }

        /// <summary>
        /// This method returns all expenses for the user or projectId specified
        /// </summary>
        /// <param name="pId">The id to use in the query</param>
        /// <param name="pType">The object type to use in the query (either Project or User)</param>
        /// <returns>DataTable containing all expenses</returns>
        public DataTable GetExpenseByProjectId(string pId)
        {
            return ExecuteQueryString($"select ProjectId, ExpenseId, TaskId, ExpUserName, ExpDescription, Value, CreatedDateTime " +
                                   $"from View_Accounting where [ProjectId] = '{pId}') and ExpenseId is not null AND IsActive = 1 order by ProjectId");
        }

        //public DataTable GetChangedInteractionsForUser()

        /// <summary>
        /// This method returns all timeslices for the user or projectId specified
        /// </summary>
        /// <param name="pId">The id to use in the query</param>
        /// <param name="pType">The object type to use in the query (either Project or User)</param>
        /// <returns>DataTable containing all timeslices</returns>
        /// <returns></returns>
        public DataTable GetTimeSliceByProjectId(string pId)
        {
            return ExecuteQueryString($"select ProjectId, TimesliceId, TaskId, TsUserName, TsDescription, Duration, CreatedDateTime " +
                                   $"from View_Accounting where [ProjectId] = '{pId}') and TimesliceId is not null AND IsActive = 1 order by ProjectId");
        }

        /// <summary>
        /// This method opens an SQL connection to the server as configured in the connection string given, executes the 
        /// command text found in the parameter and finally returns the datatable from the reader executed
        /// </summary>
        /// <param name="pSQLQuery">The sql query string to use for this query</param>
        /// <returns>DataTable containing the result set of this query</returns>
        private DataTable ExecuteQueryString(string pSQLQuery)
        {
            DataTable tbl = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(pSQLQuery))
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    tbl = new DataTable();
                    tbl.Load(reader);

                    connection.Close();
                }
            }
            return tbl;
        }

        /// <summary>
        /// This method inserts a record based on the parameters specified in the insertQuery and the values provided in the 
        /// stringValueList. The insertQuery should have a similar structure: INSERT into TableName (Column1Name, Column2Name, ...) VALUES (@ParamName1ListPos1Val, @ParamName2ListPos2Val)
        /// </summary>
        /// <param name="pInsertQuery">The insert query statement to execute</param>
        /// <param name="pStringValueList">The parameter value list. Note tha the position corresponds to the variable name order</param>
        /// <returns>Returns the number of records that were affected with this query</returns>
        private int ExecuteInsertString(string pInsertQuery, List<string> pStringValueList)
        {
            int affectedRecords = 0;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(pInsertQuery))
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    // Find values section
                    string valuesSection = string.Empty;
                    if (pInsertQuery.ToLower().IndexOf("values") > 0)
                    {
                        // We found values, lets extract the string
                        valuesSection = pInsertQuery.Substring(pInsertQuery.ToLower().IndexOf("values"));

                        // Format the string for parsing
                        valuesSection = valuesSection.ToLower().Replace("values", "");
                        valuesSection = valuesSection.ToLower().Replace("(", "");
                        valuesSection = valuesSection.ToLower().Replace(")", "");

                        // What's left are the variables... lets split into list
                        string[] valueVarList = valuesSection.Split(',');
                        valuesSection = null;
                        for (int i = 0; i < valueVarList.Length; i++)
                        {
                            // Set the parameters according to parameter list...
                            command.Parameters.AddWithValue(valueVarList[i], pStringValueList[i]);
                        }
                        valueVarList = null;
                    }
                    connection.Open();

                    affectedRecords = command.ExecuteNonQuery();

                    connection.Close();
                }
            }
            return affectedRecords;
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
            string execString = string.Empty;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Create the command and set its properties.
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Sproc_UserAddUpdate";
                command.CommandType = CommandType.StoredProcedure;

                // Add the input parameter and set its properties.
                SqlParameter parameter = new SqlParameter("@UserId", SqlDbType.BigInt)
                {
                    Direction = ParameterDirection.Input,
                    Value = Convert.ToInt64(pUserId)
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@FirstName", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = pFirstName
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@LastName", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = pLastName
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@MiddleName", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = pMiddleName
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@EmailAddress", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = pEmail
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@BirthDate", SqlDbType.DateTime)
                {
                    Direction = ParameterDirection.Input,
                    Value = pBirthdate
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@UserName", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = pUserName
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@Password", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = pPassword
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@ResultMsg", SqlDbType.VarChar)
                {
                    Direction = ParameterDirection.Output,
                    Value = string.Empty
                };
                command.Parameters.Add(parameter);

                // Open the connection and execute the reader.
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}: {1:C}", reader[0], reader[1]);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
            }
        }

        public void InsertProject(string pProjectId,
            string pTitle,
            string pDescription,
            DateTime pStartDate,
            DateTime pEndDate,
            string pOwner,
            bool pEnableBalance,
            bool pEnableSurvey,
            bool pIsActive,
            string pCreator,
            Enum pStateId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Create the command and set its properties.
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Sproc_ProjectAddUpdate";
                command.CommandType = CommandType.StoredProcedure;

                // Add the input parameter and set its properties.
                SqlParameter parameter = new SqlParameter("@ProjectId", SqlDbType.BigInt)
                {
                    Direction = ParameterDirection.Input,
                    Value = Convert.ToInt64(pProjectId)
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@Name", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = pTitle
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@Description", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = pDescription
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@EnableBalance", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Input,
                    Value = pEnableBalance
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@EnableSurvey", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Input,
                    Value = pEnableSurvey
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@StartDateTime", SqlDbType.DateTime)
                {
                    Direction = ParameterDirection.Input,
                    Value = pStartDate
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@EndDateTime", SqlDbType.DateTime)
                {
                    Direction = ParameterDirection.Input,
                    Value = pEndDate
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@IsActive", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Input,
                    Value = pIsActive
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@CreatorId", SqlDbType.BigInt)
                {
                    Direction = ParameterDirection.Input,
                    Value = Convert.ToInt64(pCreator)
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@OwnerId", SqlDbType.BigInt)
                {
                    Direction = ParameterDirection.Input,
                    Value = Convert.ToInt64(pOwner)
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@StateId", SqlDbType.BigInt)
                {
                    Direction = ParameterDirection.Input,
                    Value = pStateId
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@ResultMsg", SqlDbType.VarChar)
                {
                    Direction = ParameterDirection.Output,
                    Value = string.Empty
                };
                command.Parameters.Add(parameter);

                // Open the connection and execute the reader.
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}: {1:C}", reader[0], reader[1]);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
            }
        }

        public void InsertTask(string TaskId,
            string InteractionId,
            DateTime DueDateTime,
            decimal Budget,
            int Duration,
            int Priority,
            int Progress,
            int DurationUsed,
            decimal BudgetUsed,
            DateTime StartDateTime,
            DateTime EndDateTime,
            bool IsActive,
            string Text,
            string CreatorId,
            string OwnerId,
            string StateId,
            string ProjectId)
        {
            string execString = string.Empty;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Create the command and set its properties.
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Sproc_TaskAddUpdate";
                command.CommandType = CommandType.StoredProcedure;

                // Add the input parameter and set its properties.
                SqlParameter parameter = new SqlParameter("@TaskId", SqlDbType.BigInt)
                {
                    Direction = ParameterDirection.Input,
                    Value = Convert.ToInt64(TaskId)
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@InteractionId", SqlDbType.BigInt)
                {
                    Direction = ParameterDirection.Input,
                    Value = Convert.ToInt64(InteractionId)
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@DueDateTime", SqlDbType.Date)
                {
                    Direction = ParameterDirection.Input,
                    Value = DueDateTime
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@Budget", SqlDbType.Decimal)
                {
                    Direction = ParameterDirection.Input,
                    Value = Budget
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@Duration", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = Duration
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@Priority", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = Priority
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@Progress", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = Progress
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@DurationUsed", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = DurationUsed
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@BudgetUsed", SqlDbType.Decimal)
                {
                    Direction = ParameterDirection.Input,
                    Value = BudgetUsed
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@StartDateTime", SqlDbType.Date)
                {
                    Direction = ParameterDirection.Input,
                    Value = StartDateTime
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@EndDateTime", SqlDbType.Date)
                {
                    Direction = ParameterDirection.Input,
                    Value = EndDateTime
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@IsActive", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Input,
                    Value = IsActive
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@Text", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = Text
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@CreatorId", SqlDbType.BigInt)
                {
                    Direction = ParameterDirection.Input,
                    Value = CreatorId
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@OwnerId", SqlDbType.BigInt)
                {
                    Direction = ParameterDirection.Input,
                    Value = OwnerId
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@StateId", SqlDbType.BigInt)
                {
                    Direction = ParameterDirection.Input,
                    Value = StateId
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@ProjectId", SqlDbType.BigInt)
                {
                    Direction = ParameterDirection.Input,
                    Value = ProjectId
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@ResultMsg", SqlDbType.VarChar)
                {
                    Direction = ParameterDirection.Output,
                    Value = string.Empty
                };
                command.Parameters.Add(parameter);

                // Open the connection and execute the reader.
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}: {1:C}", reader[0], reader[1]);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
            }
        }

        public void InsertVote(string pId, string pOptionId, string pUserId, DateTime pCreated) { throw new NotImplementedException(); }

        public void InsertSurvey(string pId,
            string pInteractionId,
            DateTime pDueDateTime,
            DateTime pStartDateTime,
            DateTime pEndDateTime,
            string pCreatorId,
            string pOwnerId,
            bool pIsActive,
            string pStateString)
        {
            throw new NotImplementedException();
        }

        public void InsertSurveyOption(string pId, string pText, DateTime pCreatedDateTime) { throw new NotImplementedException(); }

        public void InsertTimeslice(string pId,
            int pDuration,
            string pTargetId,
            string pDescription,
            string pTargetType,
            DateTime pCreatedDateTime)
        {
            string execString = string.Empty;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Create the command and set its properties.
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Sproc_TimesliceAddUpdate";
                command.CommandType = CommandType.StoredProcedure;

                // Add the input parameter and set its properties.
                SqlParameter parameter = new SqlParameter("@Id", SqlDbType.BigInt)
                {
                    Direction = ParameterDirection.Input,
                    Value = Convert.ToInt64(pId)
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@Duration", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = Convert.ToInt32(pDuration)
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@Description", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = pDescription
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@ResultMsg", SqlDbType.VarChar)
                {
                    Direction = ParameterDirection.Output,
                    Value = string.Empty
                };
                command.Parameters.Add(parameter);

                // Open the connection and execute the reader.
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}: {1:C}", reader[0], reader[1]);
                    }
                }
                else
                {
                   Console.WriteLine("No rows found.");
                }

                // Insert mapping record
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Sproc_AccountAddMapping";
                command.CommandType = CommandType.StoredProcedure;

                // Add the input parameter and set its properties.
                parameter = new SqlParameter("@ProjectId", SqlDbType.BigInt)
                {
                    Direction = ParameterDirection.Input,
                };
                if (pTargetType.ToLower() == "project")
                    parameter.Value = Convert.ToInt64(pTargetId);
                else
                    parameter.Value = DBNull.Value;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@ObjectId", SqlDbType.BigInt)
                {
                    Direction = ParameterDirection.Input,
                    Value = Convert.ToInt64(pId)
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@ObjectType", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = 2
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@TaskId", SqlDbType.BigInt)
                {
                    Direction = ParameterDirection.Input,
                };
                if (pTargetType.ToLower() == "task")
                    parameter.Value = Convert.ToInt64(pTargetId);
                else
                    parameter.Value = DBNull.Value;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@ResultMsg", SqlDbType.VarChar)
                {
                    Direction = ParameterDirection.Output,
                    Value = string.Empty
                };
                command.Parameters.Add(parameter);

                // Open the connection and execute the reader.
                connection.Open();
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}: {1:C}", reader[0], reader[1]);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
            }
        }
    }
}
