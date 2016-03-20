//////////////////////////////////////////////////////////////
//                      Class Interaction
//      Author: Christian B. Sax            Date:   2016/03/14
//      Implements the IInteraction interface and serves as a dummy
using System;
using PlexByte.MoCap.Security;

namespace PlexByte.MoCap.Interactions
{
    public class Interaction:IInteraction
    {
        private string _id;
        private DateTime _startDateTime;
        private DateTime _endDateTime;
        private DateTime _createdDateTime;
        private DateTime _modifiedDateTime;
        private bool _isActive;
        private string _text;
        private InteractionType _type;
        private IUser _creator;
        private IUser _owner;
        private InteractionState _state;

        #region Implementation of IInteraction

        public event Complete Completed;
        public event Modify Modified;
        public event StateChange StateChanged;
        public string Id { get { return _id; } }

        public DateTime StartDateTime { get { return _startDateTime; } set { _startDateTime = value; } }

        public DateTime EndDateTime { get { return _endDateTime; } set { _endDateTime = value; } }

        public DateTime CreatedDateTime { get { return _createdDateTime; } }

        public DateTime ModifiedDateTime { get { return _modifiedDateTime; } }

        public bool IsActive { get { return _isActive; } }

        public string Text { get { return _text; } set { _text = value; } }

        public InteractionType Type { get { return _type; } }

        public IUser Creator { get { return _creator; } }

        public IUser Owner { get { return _owner; } }

        public InteractionState State { get { return _state; } }

        public void OnComplete(InteractionEventArgs pEventArgs) { throw new NotImplementedException(); }

        public void ChangeOwner(IUser pUser) { throw new NotImplementedException(); }

        public void ChangeIsActive(bool pActive) { throw new NotImplementedException(); }

        public void OnModify(InteractionEventArgs pEventArgs) { throw new NotImplementedException(); }

        public void OnStateChanged(InteractionEventArgs pEventArgs) { throw new NotImplementedException(); }

        public void ChangeState(InteractionState pState) { throw new NotImplementedException(); }

        public Interaction(string pId,
            DateTime pstartDateTime,
            DateTime pendDateTime,
            DateTime pcreatedDateTime,
            DateTime pDateTimemodified,
            bool pisActive,
            string ptext,
            InteractionType ptype,
            IUser pcreator,
            IUser powner,
            InteractionState pstate)
        {
            _id = pId;
            StartDateTime = pstartDateTime;
            EndDateTime = pendDateTime;
            _createdDateTime= pcreatedDateTime;
            _modifiedDateTime = pDateTimemodified;
            _isActive = pisActive;
            Text = ptext;
            _type = ptype;
            _creator = pcreator;
            _owner = powner;
            _state = pstate;
        }

        #endregion
    }
}
