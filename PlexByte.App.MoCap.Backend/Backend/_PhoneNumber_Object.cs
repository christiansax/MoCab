namespace MoCap.Backend
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cfg._PhoneNumber_Object")]
    public partial class _PhoneNumber_Object
    {
        public long Id { get; set; }

        public long? UserId { get; set; }

        public long? ContactId { get; set; }

        public long? CompanyId { get; set; }

        public long PhoneNumberId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ModifiedDateTime { get; set; }

        public virtual Company Company { get; set; }

        public virtual Contact Contact { get; set; }

        public virtual PhoneNumber PhoneNumber { get; set; }

        public virtual User User { get; set; }
    }
}
