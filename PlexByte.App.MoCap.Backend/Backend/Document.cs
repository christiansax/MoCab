namespace MoCap.Backend
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nfo.Document")]
    public partial class Document
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Document()
        {
            C_User_Document_Acceptance = new HashSet<_User_Document_Acceptance>();
        }

        public long Id { get; set; }

        public long TypeId { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Required]
        public string Text { get; set; }

        public byte[] Object { get; set; }

        [Required]
        [StringLength(250)]
        public string CreatedBy { get; set; }

        [Required]
        [StringLength(250)]
        public string RevisionedBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ActivationDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ModifiedDateTime { get; set; }

        public virtual Type Type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<_User_Document_Acceptance> C_User_Document_Acceptance { get; set; }
    }
}
