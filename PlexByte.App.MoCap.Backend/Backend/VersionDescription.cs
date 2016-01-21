namespace Backend
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nfo.VersionDescription")]
    public partial class VersionDescription
    {
        public int Id { get; set; }

        public int ObjectId { get; set; }

        [Required]
        public string Description { get; set; }

        public string ReleaseNotes { get; set; }

        [Required]
        [StringLength(250)]
        public string SupervisionedBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ModifiedDateTime { get; set; }

        public virtual VersionInfo VersionInfo { get; set; }
    }
}
