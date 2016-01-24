using System;
using MoCap;

namespace MoCap.Interactions
{
    [Serializable]
    public class Task : IInteraction
    {
        public long ID { get; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Priority { get; set; }
        public decimal Duration { get; set; }
        public long CreatorID { get; set; }
        public long OwnerID { get; set; }
        public bool IsCompleted { get; }
        public bool IsPersonal { get; }
        public DateTime Created { get; }
        public DateTime Modified { get; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime Due { get; set; }

        Task(string pText, DateTime pStart, DateTime pEnd, long pOwnerID, long pCreatorID, decimal pDuration)
        {
            Text = pText;
            Start = pStart;
            End = pEnd;
            OwnerID = pOwnerID;
            CreatorID = pCreatorID;
            if (CreatorID == OwnerID)
                IsPersonal = true;
            else
                IsPersonal = false;
            Priority = 50;
            Duration = pDuration;
            Created = DateTime.Now;
            Modified = DateTime.Now;
        }

        public void Send()
        {
            throw new NotImplementedException();
        }
    }
}
