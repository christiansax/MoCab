namespace MoCap.Backend
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nfo._User_Document_Acceptance")]
    public partial class _User_Document_Acceptance
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public long DocumentId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime AcceptanceDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ModifiedDateTime { get; set; }

        public virtual Document Document { get; set; }

        public virtual User User { get; set; }
    }
}
