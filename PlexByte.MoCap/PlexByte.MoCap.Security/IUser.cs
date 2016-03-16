//////////////////////////////////////////////////////////////
//                      Interface IUSer
//      Author: Christian B. Sax            Date:   2016/02/16
//      This interface defines the the properties of a user, 
//      which is a registered user
using System;

namespace PlexByte.MoCap.Security
{
    public interface IUser
    {
        string Id { get; }
        string PersonId { get; }
        string Username { get; set; }
        string Password { get; set; }
    }
}
