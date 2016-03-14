//////////////////////////////////////////////////////////////
//                      Class DataManager
//      Author: Christian B. Sax            Date:   2016/03/14
//      This class manages is used to convert from Object to SQL parsable data and vice versa.
//      The objective is to encapsulate any backend related conversions within this class and 
//      expose objects to calling classes only
using PlexByte.MoCap.Backend;

namespace MoCap.PlexByte.MoCap.WinForms
{
    public class DataManager
    {
        /// <summary>
        /// The user this datamanager runs under
        /// </summary>
        public string UserId { get; set; }

        private BackendService _backend = new BackendService();

        public DataManager(string pUserId, string pPassword)
        {
            UserId = _backend.AuthenticateUser(pUserId, pPassword);
            
        }

    }
}
