//////////////////////////////////////////////////////////////
//                      Class Vote                              
//      Author: Christian B. Sax            Date:   2016/02/13
using System;
using PlexByte.MoCap.Security;

namespace PlexByte.MoCap.Interactions
{
    /// <summary>
    /// This class holds information about a users choice, containing 
    /// the user and his choice selected
    /// </summary>
    public class Vote : IVote
    {
        /// <summary>
        /// The constructor of the class
        /// </summary>
        /// <param name="pId">The unique id of this object</param>
        /// <param name="pUser">The user who made the choice</param>
        /// <param name="pOption">The choice that was selected</param>
        public Vote(string pId, IUser pUser, ISurveyOption pOption)
        {
            Id = pId;
            User = pUser;
            Option = pOption;
        }

        /// <summary>
        /// The date and time this vote was left
        /// </summary>
        public DateTime CreatedDateTime { get; }

        /// <summary>
        /// The unique id of this object
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// The survey option chosen by the user
        /// </summary>
        public ISurveyOption Option { get; }

        /// <summary>
        /// The user who votes
        /// </summary>
        public IUser User { get; }
    }
}