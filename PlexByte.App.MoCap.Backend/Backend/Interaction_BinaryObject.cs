namespace Backend
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ira.Interaction_BinaryObject")]
    public partial class Interaction_BinaryObject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        public long? ChatId { get; set; }

        public long? MessageId { get; set; }

        public long? TaskId { get; set; }

        public long? PollId { get; set; }

        public long? VoteId { get; set; }

        public long BinaryId { get; set; }

        public bool IsActive { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ModifiedDateTime { get; set; }

        public virtual BinaryObject BinaryObject { get; set; }

        public virtual Chat Chat { get; set; }

        public virtual Message Message { get; set; }

        public virtual Poll Poll { get; set; }

        public virtual Task Task { get; set; }

        public virtual _User_Poll_Option C_User_Poll_Option { get; set; }
    }
}
