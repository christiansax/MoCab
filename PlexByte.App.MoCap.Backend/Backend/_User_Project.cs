namespace Backend
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sec._User_Project")]
    public partial class _User_Project
    {
        public long Id { get; set; }

        public long ProjectId { get; set; }

        public long UserId { get; set; }

        public bool IsActive { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ModifiedDateTime { get; set; }

        public virtual Project Project { get; set; }

        public virtual User User { get; set; }
    }
}
