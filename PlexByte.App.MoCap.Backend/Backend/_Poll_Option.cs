namespace MoCap.Backend
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ira._Poll_Option")]
    public partial class _Poll_Option
    {
        public long Id { get; set; }

        public long PollId { get; set; }

        public long OptionId { get; set; }

        public int Votes { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ModifiedDateTime { get; set; }

        public virtual PollOption PollOption { get; set; }

        public virtual Poll Poll { get; set; }
    }
}
