//////////////////////////////////////////////////////////////
//                      Class DataManager
//      Author: Christian B. Sax            Date:   2016/03/14
//      This class manages is used to convert from Object to SQL parsable data and vice versa.
//      The objective is to encapsulate any backend related conversions within this class and 
//      expose objects to calling classes only
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using PlexByte.MoCap.Backend;
using PlexByte.MoCap.Interactions;
using PlexByte.MoCap.Security;
using PlexByte.MoCap.WinForms.Managers;

namespace PlexByte.MoCap.WinForms
{
    public class DataManager
    {
        /// <summary>
        /// Indicates if datamanager is initialized for a user
        /// </summary>
        public bool IsInitialized { get; set; } = false;
        

        private BackendService _backend = new BackendService();
        private ObjectManager _objectManager=new ObjectManager();

        /// <summary>
        /// The default constructor requiring to call initialize datamanger manually
        /// </summary>
        public DataManager() { }

        public DataManager(string pUserId, string pPassword)
        {
            InitializeDataManager(pUserId, pPassword);
            IsInitialized = true;
        }

        public void Login(string pUserName, string pPassword)
        {
            //LoggedInUser = _objectManager.CreateObjectFromDataTable<User>(_backend.AuthenticateUser(pUserName, pPassword));
        }

        public void Logout()
        {
            LoggedInUser = null;
            IsInitialized = false;
           
        }

        public void InitializeDataManager(string pUserId, string pPassword)
        {
            try
            {
                if(IsInitialized)
                    Logout();
                Login(pUserId, pPassword);

                // Get all user specific data
                QueryDataBaseObjects();

                IsInitialized = true;
            }
            catch (Exception exp)
            {
                throw new Exception($"Failed to initialize DataManager! Exception: {exp.Message}");
            }
        }

        private void QueryDataBaseObjects()
        {
            // Get projects, tasks, survey, timeslices, expenses etc this user is involved in
        }
    }
}
