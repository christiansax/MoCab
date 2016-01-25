using System;
using System.Collections.Generic;
using System.Linq;

namespace MoCap.Interactions.Mapping
{
    public class MAP_UserProject
    {
        public long ID { get; set; }
        public long UserID { get; set; }
        public long ProjectID { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public MAP_UserProject(long pID, long pUserID, long pProjectID, DateTime pCreated, DateTime pModified)
        {
            ID = pID;
            UserID = pUserID;
            ProjectID = pProjectID;
            Created = pCreated;
            Modified = pModified;
        }

        public List<long> GetProjectIDs(long pUserID)
        {
            return 
        }
    }
}
