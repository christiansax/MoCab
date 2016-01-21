namespace Backend
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nfo.VersionInfo")]
    public partial class VersionInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VersionInfo()
        {
            VersionDescription = new HashSet<VersionDescription>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ObjectName { get; set; }

        public long TypeId { get; set; }

        public int VersionMajor { get; set; }

        public int VersionMinor { get; set; }

        public int? VersionRevision { get; set; }

        public int? VersionBuild { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ModifiedDateTime { get; set; }

        public virtual Type Type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VersionDescription> VersionDescription { get; set; }
    }
}
