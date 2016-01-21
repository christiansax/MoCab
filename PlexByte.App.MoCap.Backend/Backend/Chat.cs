namespace Backend
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ira.Chat")]
    public partial class Chat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Chat()
        {
            C_User_Chat = new HashSet<_User_Chat>();
            Interaction_BinaryObject = new HashSet<Interaction_BinaryObject>();
            Timeslice = new HashSet<Timeslice>();
        }

        public long Id { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        public long? ProjectId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime StartDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime EndDateTime { get; set; }

        public int Priority { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ModifedDateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<_User_Chat> C_User_Chat { get; set; }

        public virtual Project Project { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Interaction_BinaryObject> Interaction_BinaryObject { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Timeslice> Timeslice { get; set; }
    }
}
