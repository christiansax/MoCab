using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoCap.Interactions
{
    // TODO: <MoCap.Interactions.Project> Start implementing this class
    public class Project : IInteraction
    {
        public long ID { get; }
        public string Title { get; set; }
        public string Text { get; set; }
        public long CreatorID { get; }
        public long OwnerID { get; set; }
        public long ProjectID { get; set; } = -1;
        public bool IsCompleted { get; }
        public DateTime Created { get; }
        public DateTime Modified { get; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime Due { get; set; }

        public void Send()
        {

        }
    }
}
