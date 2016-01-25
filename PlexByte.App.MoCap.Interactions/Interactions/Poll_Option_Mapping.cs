using System.Collections.Generic;

namespace MoCap.Interactions
{
    public class Poll_Option_Mapping
    {
        public long ID { get; }
        public List<KeyValuePair<long, long>> Poll_Option_List { get; set; }

    }
}
