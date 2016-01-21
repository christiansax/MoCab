namespace Backend
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cfg.Country")]
    public partial class Country
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Country()
        {
            C_Country_Language = new HashSet<_Country_Language>();
            Address = new HashSet<Address>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Required]
        [StringLength(2)]
        public string ISOCodeA2 { get; set; }

        [StringLength(3)]
        public string ISOCodeA3 { get; set; }

        public int? ISOCodeNumber { get; set; }

        [Required]
        [StringLength(5)]
        public string InternationalDialingCode { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ModifiedDateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<_Country_Language> C_Country_Language { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Address> Address { get; set; }
    }
}
