namespace MoCap.Backend
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ira.Poll")]
    public partial class Poll
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Poll()
        {
            C_Poll_Option = new HashSet<_Poll_Option>();
            Interaction_BinaryObject = new HashSet<Interaction_BinaryObject>();
            C_User_Poll_Option = new HashSet<_User_Poll_Option>();
            Timeslice = new HashSet<Timeslice>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Label { get; set; }

        public string Description { get; set; }

        public long? ProjectId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime StartDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime EndDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DueDateTime { get; set; }

        public int VotesPerUser { get; set; }

        public bool VotesChangeable { get; set; }

        public bool AllowCustomOption { get; set; }

        public bool CompleteOnMajority { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ModifiedDateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<_Poll_Option> C_Poll_Option { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Interaction_BinaryObject> Interaction_BinaryObject { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<_User_Poll_Option> C_User_Poll_Option { get; set; }

        public virtual Project Project { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Timeslice> Timeslice { get; set; }
    }
}
