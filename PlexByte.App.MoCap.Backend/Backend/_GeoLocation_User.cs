namespace MoCap.Backend
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sec._GeoLocation_User")]
    public partial class _GeoLocation_User
    {
        public long Id { get; set; }

        public long GeoLocationId { get; set; }

        public long UserId { get; set; }

        [Column(TypeName = "date")]
        public DateTime TrackingDate { get; set; }

        public TimeSpan TrackingTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ModifiedDateTime { get; set; }

        public virtual GeoLocation GeoLocation { get; set; }

        public virtual User User { get; set; }
    }
}
