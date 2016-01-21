namespace MoCap.Backend
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sec._User_Chat")]
    public partial class _User_Chat
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public long ChatId { get; set; }

        public bool IsActive { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ModifedDateTime { get; set; }

        public virtual Chat Chat { get; set; }

        public virtual User User { get; set; }
    }
}
