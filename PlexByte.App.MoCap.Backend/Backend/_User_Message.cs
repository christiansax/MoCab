namespace MoCap.Backend
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sec._User_Message")]
    public partial class _User_Message
    {
        public long Id { get; set; }

        public long MessageId { get; set; }

        public long UserId { get; set; }

        public bool IsReceived { get; set; }

        public bool IsRead { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ReceivedDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ReadDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ModifiedDateTime { get; set; }

        public virtual Message Message { get; set; }

        public virtual User User { get; set; }
    }
}
