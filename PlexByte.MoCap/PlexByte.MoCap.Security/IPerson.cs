//////////////////////////////////////////////////////////////
//                      Interface Person
//      Author: Christian B. Sax            Date:   2016/02/16
//      This interface defines the the properties of a person, 
//      which is an unregistered user
using System;

namespace PlexByte.MoCap.Security
{
    public interface IPerson
    {
        string Id { get; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string MiddleName { get; set; }
        string EmailAddress { get; set; }
        DateTime Birthdate { get; set; }
        DateTime CreatedDateTime { get; }
        DateTime ModifiedDateTime { get; }
    }
}
