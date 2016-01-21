namespace Backend
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cfg.PhoneNumber")]
    public partial class PhoneNumber
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhoneNumber()
        {
            C_PhoneNumber_Object = new HashSet<_PhoneNumber_Object>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Value { get; set; }

        public long PhoneTypeId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ModifiedDateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<_PhoneNumber_Object> C_PhoneNumber_Object { get; set; }

        public virtual Property Property { get; set; }
    }
}
