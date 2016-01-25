using System;
using System.Collections.Generic;
using System.Linq;
namespace MoCap.Interactions
{
    public class PollOption
    {
        public long ID { get; }
        public string Text { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; }
        public DateTime Modified { get; }

        private DateTime modified = new DateTime(1970, 1, 30);

        public PollOption(long pID, string pText, string pDescription, bool pIsActive, DateTime pCreated, 
            DateTime pModified)
        {
            ID = pID;
            Text = pText;
            Description = pDescription;
            IsActive = pIsActive;
            Created = pCreated;
            Modified = pModified;
        }

        public PollOption(long pID, string pText, DateTime pCreated) : this(pID, pText, "", true, pCreated, 
            DateTime.Now)
        {
        }
    }
}
