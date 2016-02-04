﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoCap.Interactions
{
    // TODO: <MoCap.Interactions.Project> Start implementing this class
    public class Project : IInteraction
    {

        #region Properties
        public long ID { get; }
        public string Title { get; set; }
        public string Text { get; set; }
        public long CreatorID { get; }
        public long OwnerID { get; set; }           //probably not needed
        public long ProjectID { get; set; } = -1;   //<--- what is this for?
        public bool IsCompleted { get; }
        public DateTime Created { get; }
        public DateTime Modified { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime Due { get; set; }


        public List<long> MemberID { get; set; }
        public List<long> TaskID { get; set; }
        #endregion


        #region Ctor & Dtor
        Project(long pID, string pTitle, string pText, long pCreatorID, long pOwnerID, long pProjectID,
            bool pIsCompleted, DateTime pCreated, DateTime pModified, DateTime pStart, DateTime pEnd, DateTime pDue,
            List<long> pMemberID, List<long> pTaskID)
        {
            ID = pID;
            Title = pTitle;
            Text = pText;
            CreatorID = pCreatorID;
            OwnerID = pOwnerID;
            ProjectID = pProjectID;
            IsCompleted = pIsCompleted;
            Created = pCreated;
            Modified = pModified;
            Start = pStart;
            End = pEnd;
            Due = pDue;
            MemberID = pMemberID;
            TaskID = pTaskID;
        }

        #endregion

        #region Methods
        public void Send()
        {
            Modified = DateTime.Now;
        }

        #endregion
    }
}
