namespace Backend
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ira.Timeslice")]
    public partial class Timeslice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        public long UserId { get; set; }

        public long? ProjectId { get; set; }

        public long? TaskId { get; set; }

        public long? ChatId { get; set; }

        public long? PollId { get; set; }

        public long Duration { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ModifiedDateTime { get; set; }

        public virtual Chat Chat { get; set; }

        public virtual Poll Poll { get; set; }

        public virtual Project Project { get; set; }

        public virtual Task Task { get; set; }

        public virtual User User { get; set; }
    }
}
