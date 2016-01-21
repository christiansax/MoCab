namespace Backend
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ira.Task")]
    public partial class Task
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Task()
        {
            C_Task_Task = new HashSet<_Task_Task>();
            C_Task_Task1 = new HashSet<_Task_Task>();
            Interaction_BinaryObject = new HashSet<Interaction_BinaryObject>();
            Timeslice = new HashSet<Timeslice>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Title { get; set; }

        public string Description { get; set; }

        public long? ProjectId { get; set; }

        public long CreatorId { get; set; }

        public long OwnerId { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsPersonal { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime StartDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime EndDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DueDateTime { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Duration { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Budget { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TotalCosts { get; set; }

        public int Priority { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Progress { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ModifiedDateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<_Task_Task> C_Task_Task { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<_Task_Task> C_Task_Task1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Interaction_BinaryObject> Interaction_BinaryObject { get; set; }

        public virtual Project Project { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Timeslice> Timeslice { get; set; }
    }
}
