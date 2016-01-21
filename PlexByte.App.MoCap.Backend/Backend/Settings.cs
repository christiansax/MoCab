namespace MoCap.Backend
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cfg.Settings")]
    public partial class Settings
    {
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; }

        public long UserId { get; set; }

        [StringLength(50)]
        public string StringValue { get; set; }

        public int? IntegerValue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? NumericValue { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateTimeValue { get; set; }

        public bool? BooleanValue { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ModifiedDateTime { get; set; }

        public virtual User User { get; set; }
    }
}
