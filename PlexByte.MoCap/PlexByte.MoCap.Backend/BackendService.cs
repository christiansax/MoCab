﻿//////////////////////////////////////////////////////////////
//                      Class InteractionService                              
//      Author: Christian B. Sax            Date:   2016/03/2
//      This class provides backend functionality by reading and writing to the database. The class is not intended 
//      for converting business logic but to return record set to the caller for further business logic process.
//      Also inserting is not intended to convert from business objects into the db. Use Adapter classes, to do this

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PlexByte.MoCap.Helpers;

namespace PlexByte.MoCap.Backend
{
    public enum ObjectType
    {
        User,
        Project
    }

    public class BackendService
    {
        private static string _DBServer = "198.38.83.33";
        private static string _Password = "MoCap";
        private static string _DBUser = CryptoHelper.Decrypt("BjjfgaK9bvsBcQCzh2cA7D0OQnwJ1lrU/36zDXs5bKfbK/mCnQChL74+/wtOu1+6", _Password);
        private static string _DBPWD = CryptoHelper.Decrypt("mFntrazoOtZJqDO+T8vCdtnm6aUjkfvf0Lh8kATxrZQkfNE0NiPDC7zXkb2h22MM", _Password);
        private string _connectionString = string.Format("Server={0}; Database=csax2277_MoCap_Prod;User Id={1};Password={2};", _DBServer, _DBUser, _DBPWD);

        /// <summary>
        /// This method authenticates the given user and password against the database. If suceeded the ID of the authenticated user will be returnes
        /// </summary>
        /// <param name="pId">The id of the user to query results for</param>
        /// <returns>The Users Id</returns>
        public string AuthenticateUser(string pUserName, string pPassword)
        {
            DataTable userInfo = new DataTable();
            pPassword = CryptoHelper.Decrypt(pPassword, _Password);

            userInfo = ExecuteQueryString($"select * from View_User where (Username = {pUserName} or EmailAddress = {pUserName}) " +
                                          $"AND Password = {pPassword}  AND IsActive = 1");
            if (userInfo.Rows.Count < 1)
                throw new Exception($"Authentification failed! Username or password is invalid [UserName={pUserName}] [Password={pPassword}]");
            else
            {
                return userInfo.Columns["Id"].ToString();
            }
        }

        /// <summary>
        /// If project is the type, all users being member of the project with the Id specified will be returned.
        /// Otherwise the user with the Id given is returned
        /// </summary>
        /// <param name="pId">The Id to use in the lookup</param>
        /// <param name="pType">The object type to use in the query (either Project or User)</param>
        /// <returns>DataTable containing either all members of a project or the user matching the Id</returns>
        public DataTable GetUserById(string pId, ObjectType pType)
        {
            string sQueryString = string.Empty;
            switch (pType)
            {
                case ObjectType.Project:
                    sQueryString = $"select * from View_ProjectUserMapping where ProjectId = {pId}  AND IsActive = 1";
                    break;
                case ObjectType.User:
                    sQueryString = $"select * from View_User where Id = {pId}  AND IsActive = 1";
                    break;
                default:
                    throw new Exception("Object type is null or unknown!");
            }
            return ExecuteQueryString(sQueryString);
        }

        /// <summary>
        /// This method gets all task for the userId or projectId specified and returns the datatable.
        /// </summary>
        /// <param name="pId">The id of the user or project to query</param>
        /// <param name="pType">The object type to use in the query (either Project or User)</param>
        /// <returns>DataTable containing all tasks for the user or project in question</returns>
        public DataTable GetTasksById(string pId, ObjectType pType)
        {
            string sQueryString = string.Empty;
            switch (pType)
            {
                case ObjectType.Project:
                    sQueryString = $"select * from View_ProjectTaskMapping where ProjectId = {pId}  AND IsActive = 1";
                    break;
                case ObjectType.User:
                    sQueryString = $"select * from View_Task where OwnerId = {pId} or CreatorId = {pId}  AND IsActive = 1";
                    break;
                default:
                    throw new Exception("Object type is null or unknown!");
            }
            
            return ExecuteQueryString(sQueryString);
        }

        /// <summary>
        /// This method gets all Surveys a user can participate in or were assigned to the projectId.
        /// </summary>
        /// <param name="pId">The id of the user or project to query</param>
        /// <param name="pType">The object type to use in the query (either Project or User)</param>
        /// <returns>DataTable containing all Survey for the user or project in question</returns>
        public DataTable GetSurveysById(string pId, ObjectType pType)
        {
            string sQueryString = string.Empty;
            switch (pType)
            {
                case ObjectType.Project:
                    sQueryString = $"select * from View_ProjectSurveyMapping where ProjectId = {pId}  AND IsActive = 1";
                    break;
                case ObjectType.User:
                    sQueryString = $"select * from View_SurveyUserMapping where UserId = {pId}  AND IsActive = 1";
                    break;
                default:
                    throw new Exception("Object type is null or unknown!");
            }
            return ExecuteQueryString(sQueryString);
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

        /// <summary>
        /// This method returns all expenses for the user or projectId specified
        /// </summary>
        /// <param name="pId">The id to use in the query</param>
        /// <param name="pType">The object type to use in the query (either Project or User)</param>
        /// <returns>DataTable containing all expenses</returns>
        public DataTable GetExpensesById(string pId, ObjectType pType)
        {
            // TODO: Need to revise the sql statement, it should lookup expense table in the end
            string sQueryString = string.Empty;
            switch (pType)
            {
                case ObjectType.Project:
                    sQueryString = $"select ProjectId, ExpenseId, TaskId, ExpUserName, ExpDescription, Value, CreatedDateTime " +
                                   $"from View_Accounting where [ProjectId] = {pId}) and ExpenseId is not null AND IsActive = 1 order by ProjectId";
                    break;
                case ObjectType.User:
                    sQueryString = $"select ProjectId, ExpenseId, TaskId, ExpUserName, ExpDescription, Value, CreatedDateTime " +
                                   $"from View_Accounting where [ExpUserName] = '(select Username from View_User where Id = {pId})'" +
                                   $" and ExpenseId is not null AND IsActive = 1 order by ProjectId";
                    break;
                default:
                    throw new Exception("Object type is null or unknown!");
            }
            return ExecuteQueryString(sQueryString);
        }

        /// <summary>
        /// This method returns all timeslices for the user or projectId specified
        /// </summary>
        /// <param name="pId">The id to use in the query</param>
        /// <param name="pType">The object type to use in the query (either Project or User)</param>
        /// <returns>DataTable containing all timeslices</returns>
        /// <returns></returns>
        public DataTable GetTimeSliceById(string pId, ObjectType pType)
        {
            // TODO: Need to revise the sql statement, it should lookup timeslice table in the end
            string sQueryString = string.Empty;
            switch (pType)
            {
                case ObjectType.Project:
                    sQueryString = $"select ProjectId, TimesliceId, TaskId, TsUserName, TsDescription, Duration, CreatedDateTime " +
                                   $"from View_Accounting where [ProjectId] = {pId}) and TimesliceId is not null AND IsActive = 1 order by ProjectId";
                    break;
                case ObjectType.User:
                    sQueryString = $"select ProjectId, TimesliceId, TaskId, TsUserName, TsDescription, Duration, CreatedDateTime " +
                                   $"from View_Accounting where [ExpUserName] = '(select Username from View_User where Id = {pId})'" +
                                   $" and TimesliceId is not null AND IsActive = 1 order by ProjectId";
                    break;
                default:
                    throw new Exception("Object type is null or unknown!");
            }
            return ExecuteQueryString(sQueryString);
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
                        for(int i=0;i<valueVarList.Length;i++)
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
    }
}
