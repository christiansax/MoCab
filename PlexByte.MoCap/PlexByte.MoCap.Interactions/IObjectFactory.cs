//////////////////////////////////////////////////////////////
//                      Interface IObjectFactory                              
//      Author: Christian B. Sax            Date:   2016/02/24
//              Fabian Ochsner
//      Defines methods to construct object contained in the interaction package
//      but do not inherit from IInteraction
using System;
using PlexByte.MoCap.Security;

namespace PlexByte.MoCap.Interactions
{
    public interface IObjectFactory
    {
        IVote CreateVote(string pId, IUser pUser, ISurveyOption pOption);

        ISurveyOption CreateSurveyOption(string pId, string pText);

        IUser CreateUser(string pId, string pFirstName, string pLastName, string pMiddleName, string pEmail, DateTime pBirthdate,
            string pUserName, string pPassword, DateTime pModified, DateTime pCreated, string pPersonId);
    }
}