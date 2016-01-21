namespace Backend
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cfg.Property")]
    public partial class Property
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Property()
        {
            PhoneNumber = new HashSet<PhoneNumber>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public long TypeId { get; set; }

        public long LanguageId { get; set; }

        public string ValueString1 { get; set; }

        public string ValueString2 { get; set; }

        public string ValueString3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueNum1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueNum2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueNum3 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ModifiedDateTime { get; set; }

        public virtual Language Language { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhoneNumber> PhoneNumber { get; set; }

        public virtual Type Type { get; set; }
    }
}
