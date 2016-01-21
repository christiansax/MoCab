namespace MoCap.Backend
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cfg.AddressAppendix")]
    public partial class AddressAppendix
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AddressAppendix()
        {
            Address = new HashSet<Address>();
        }

        public long Id { get; set; }

        [StringLength(250)]
        public string HouseName { get; set; }

        [StringLength(250)]
        public string County { get; set; }

        [StringLength(50)]
        public string POBox { get; set; }

        [StringLength(250)]
        public string CustomString1 { get; set; }

        [StringLength(250)]
        public string CustomString2 { get; set; }

        [StringLength(250)]
        public string CustomString3 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ModifiedDateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Address> Address { get; set; }
    }
}
