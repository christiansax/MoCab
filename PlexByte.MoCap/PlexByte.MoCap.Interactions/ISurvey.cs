//////////////////////////////////////////////////////////////
//                      Interface ISurvey                              
//      Author: Christian B. Sax            Date:   2016/02/13
//      Implemented in class Survey
using System;
using System.Collections.Generic;
using PlexByte.MoCap.Security;

namespace PlexByte.MoCap.Interactions
{
    public interface ISurvey
    {
        DateTime DueDateTime { get; set; }
        List<ISurveyOption> OptionList { get; set; }

        List<IVote> VoteList { get; }

        int MaxVotesPerUser { get; set; }
        List<IUser> UserList { get; set; }

        void AddVote(IVote pVote);

        void AddOption(ISurveyOption pOption);

        void AddUser(IUser pUser);

        void RemoveUser(IUser pUser);
    }
}