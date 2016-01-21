namespace MoCap.Backend
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sec._User_User")]
    public partial class _User_User
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public long DirectoryUserId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ModifiedDateTime { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
