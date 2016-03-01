//////////////////////////////////////////////////////////////
//                      Class InteractionEventArgs                              
//      Author: Christian B. Sax            Date:   2016/02/13
//      Implements attributes to be submitted in case of an interaction event
using System;
using System.Collections.Generic;

namespace PlexByte.MoCap.Interactions
{
    public class InteractionEventArgs
    {
        public virtual InteractionType Type { get; set; }

        public virtual DateTime EventDateTime { get; set; }

        public virtual string Message { get; set; }

        public virtual List<InteractionAttributes> ChangedAttributeList { get; set; }

        public InteractionEventArgs(string pMessage, DateTime pEventDateTime, InteractionType pType) :
            this(pMessage, pEventDateTime, pType, new List<InteractionAttributes>())
        {
        }

        public InteractionEventArgs(string pMessage,
            DateTime pEventDateTime,
            InteractionType pType,
            List<InteractionAttributes> pChangedAttributes)
        {
            this.Type = pType;
            EventDateTime = pEventDateTime;
            Message = pMessage;
            ChangedAttributeList = pChangedAttributes;
        }
    }
}