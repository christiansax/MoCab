//////////////////////////////////////////////////////////////
//                      Class ObjectFactory                              
//      Author: Christian B. Sax            Date:   2016/02/24
//              Fabian Ochsner
//      Implements IObjectFactory, creating various objects that do not
//      inherit from the IInteraction interface
using System;
using PlexByte.MoCap.Helpers;
using PlexByte.MoCap.Security;

namespace PlexByte.MoCap.Interactions
{
    public class ObjectFactory : IObjectFactory
    {
        public IVote CreateVote(string pId, IUser pUser, ISurveyOption pOption, string pSurveyId)
        {
            if (string.IsNullOrEmpty(pId))
                pId = GenericHelper.GenerateId();
            return (new Vote(pId, pUser, pOption, pSurveyId));
        }

        public virtual ISurveyOption CreateSurveyOption(string pId, string pText)
        {
            if (string.IsNullOrEmpty(pId))
                pId = GenericHelper.GenerateId();
            return (new SurveyOption(pId, pText));
        }

        public virtual IUser CreateUser(string pId,
            string pFirstName,
            string pLastName,
            string pMiddleName,
            string pEmail,
            DateTime pBirthdate,
            string pUserName,
            string pPassword,
            DateTime pModified,
            DateTime pCreated,
            string pPersonId)
        {
            try
            {
                return new User(pId,
                    pPersonId,
                    pFirstName,
                    pLastName,
                    pMiddleName,
                    pEmail,
                    pBirthdate,
                    pCreated,
                    pModified,
                    pUserName,
                    pPassword);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}