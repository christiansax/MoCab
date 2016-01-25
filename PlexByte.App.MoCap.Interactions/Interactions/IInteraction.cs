using System;

namespace MoCap.Interactions
{
    public interface IInteraction
    {
        long ID { get; }
        string Title { get; set; }
        string Text { get; set; }
        long CreatorID { get; }
        long OwnerID { get; set; }
        long ProjectID { get; set; }
        bool IsCompleted { get; }
        DateTime Created { get; }
        DateTime Modified { get; }
        DateTime Start { get; set; }
        DateTime End { get; set; }
        DateTime Due { get; set; }

        void Send();
    }
}
