//////////////////////////////////////////////////////////////
//                      Interface IInteraction                             
//      Author: Christian B. Sax            Date:   2016/02/02
//      Defines Interaction properties, event and methods
using System;
using PlexByte.MoCap.Security;


namespace PlexByte.MoCap.Interactions
{

    public delegate void Complete(object sender, InteractionEventArgs e);

    public delegate void Modify(object sender, InteractionEventArgs e);

    public delegate void StateChange(object sender, InteractionEventArgs e);

    public interface IInteraction
    {
        event Complete Completed;
        event Modify Modified;
        event StateChange StateChanged;

        string Id { get; }

        DateTime StartDateTime { get; set; }

        DateTime EndDateTime { get; set; }

        DateTime CreatedDateTime { get; }

        DateTime ModifiedDateTime { get; }

        bool IsActive { get; }

        string Text { get; set; }

        InteractionType Type { get; }

        IUser Creator { get; }

        IUser Owner { get; }

        InteractionState State { get; }

        void OnComplete(InteractionEventArgs pEventArgs);

        void ChangeOwner(IUser pUser);

        void ChangeIsActive(bool pActive);

        void OnModify(InteractionEventArgs pEventArgs);

        void OnStateChanged(InteractionEventArgs pEventArgs);

        void ChangeState(InteractionState pState);
    }
}