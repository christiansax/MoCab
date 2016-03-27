//////////////////////////////////////////////////////////////
//                      Class User
//      Author: Christian B. Sax            Date:   2016/02/16
//      This class implements the IUser and IPerson interface. 
//      The difference between the two is that a user is registered
//      and hence can execute functions, where a person cannot

using System;

namespace PlexByte.MoCap.Security
{
    public class User : IUser,
        IPerson
    {
        public string Id => _id;
        string IPerson.Id => _personId;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime CreatedDateTime => _createdDateTime;
        public DateTime ModifiedDateTime { get; set; }
        public string PersonId => _personId;
        public string Username { get; set; }
        public string Password { get; set; }

        private readonly string _id;
        private readonly string _personId;
        private readonly DateTime _createdDateTime;

        public User() { _createdDateTime = ModifiedDateTime = DateTime.Now; }

        public User(string pId,
            string pPersonId,
            string pFirstName,
            string pLastName,
            string pMiddleName,
            string pEmailAddress,
            DateTime pBirthDate,
            DateTime pCreatedDateTime,
            DateTime pModifiedDateTime,
            string pUserName,
            string pPassword)
        {
            _id = pId;
            _personId = pPersonId;
            FirstName = pFirstName;
            LastName = pLastName;
            MiddleName = pMiddleName;
            EmailAddress = pEmailAddress;
            Birthdate = pBirthDate;
            _createdDateTime= pCreatedDateTime;
            ModifiedDateTime = pModifiedDateTime;
            Username = pUserName;
            Password= pPassword;
        }
    }
}
