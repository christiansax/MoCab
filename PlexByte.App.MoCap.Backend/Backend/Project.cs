namespace Backend
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ira.Project")]
    public partial class Project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Project()
        {
            Chat = new HashSet<Chat>();
            Poll = new HashSet<Poll>();
            C_Directory_User = new HashSet<_Directory_User>();
            C_User_Project = new HashSet<_User_Project>();
            Task = new HashSet<Task>();
            Timeslice = new HashSet<Timeslice>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public string Description { get; set; }

        [StringLength(250)]
        public string Category { get; set; }

        public long OwnerId { get; set; }

        public long DeputyId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime StartDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime EndDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DueDateTime { get; set; }

        public int Priority { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Progress { get; set; }

        public bool IsCompleted { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Budget { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ModifiedDateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chat> Chat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Poll> Poll { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<_Directory_User> C_Directory_User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<_User_Project> C_User_Project { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Task> Task { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Timeslice> Timeslice { get; set; }
    }
}
