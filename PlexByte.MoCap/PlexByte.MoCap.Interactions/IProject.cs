//////////////////////////////////////////////////////////////
//                      Interface Project                              
//      Author: Fabian Ochsner            Date:   2016/02/19
using System.Collections.Generic;
using PlexByte.MoCap.Security;

namespace PlexByte.MoCap.Interactions
{

    public delegate void UserInvite(object sender, InteractionEventArgs e);
    public delegate void UserAdd(object sender, InteractionEventArgs e);
    public delegate void UserBan(object sender, InteractionEventArgs e);
    public delegate void Leave(object sender, InteractionEventArgs e);
    public delegate void TaskAdd(object sender, InteractionEventArgs e);
    public delegate void SurveyAdd(object sender, InteractionEventArgs e);

    public interface IProject
    {

        event UserInvite UserInvited;
        event UserAdd UserAdded;
        event UserBan UserBanned;
        event Leave Left;
        event TaskAdd TaskAdded;
        event SurveyAdd SurveyAdded;


        string Id { get; }

        bool EnableBalance { get; }

        bool EnableSurvey { get; }

        List<IUser> InvitationList { get; }

        IAccount ProjectAccount { get; set; }

        List<ITask> TaskList { get; }

        List<ISurvey> SurveyList { get; }

        List<IUser> MemberList { get; }

        void AddTask(ITask pTask);

        void AddSurvey(ISurvey pSurvey);

        void Invite(IUser pUser);

        void Accept(IUser pUser);

        void Leave(IUser pUser);

        void KickUser(IUser pUser);

    }

}