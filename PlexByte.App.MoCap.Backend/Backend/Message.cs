namespace Backend
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ira.Message")]
    public partial class Message
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Message()
        {
            Interaction_BinaryObject = new HashSet<Interaction_BinaryObject>();
            C_User_Message = new HashSet<_User_Message>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Label { get; set; }

        public string Text { get; set; }

        public long SenderId { get; set; }

        public bool ReadReceipt { get; set; }

        public int TimeToLive { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateTimeOfDeath { get; set; }

        public bool IsActive { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? SentDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ModifedDateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Interaction_BinaryObject> Interaction_BinaryObject { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<_User_Message> C_User_Message { get; set; }

        public virtual User User { get; set; }
    }
}
