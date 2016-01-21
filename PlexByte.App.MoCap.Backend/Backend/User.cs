namespace MoCap.Backend
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sec.User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            C_PhoneNumber_Object = new HashSet<_PhoneNumber_Object>();
            Settings = new HashSet<Settings>();
            Message = new HashSet<Message>();
            Project = new HashSet<Project>();
            Project1 = new HashSet<Project>();
            Task = new HashSet<Task>();
            Task1 = new HashSet<Task>();
            Timeslice = new HashSet<Timeslice>();
            C_User_Document_Acceptance = new HashSet<_User_Document_Acceptance>();
            C_Directory_User = new HashSet<_Directory_User>();
            C_GeoLocation_User = new HashSet<_GeoLocation_User>();
            C_User_Chat = new HashSet<_User_Chat>();
            C_User_Contact = new HashSet<_User_Contact>();
            C_User_Message = new HashSet<_User_Message>();
            C_User_Poll_Option = new HashSet<_User_Poll_Option>();
            C_User_Project = new HashSet<_User_Project>();
            C_User_User = new HashSet<_User_User>();
            C_User_User1 = new HashSet<_User_User>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(500)]
        public string UserId { get; set; }

        [Required]
        [StringLength(250)]
        public string FirstName { get; set; }

        [StringLength(250)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(250)]
        public string LastName { get; set; }

        public bool IsActive { get; set; }

        [StringLength(1000)]
        public string EmailWork { get; set; }

        [StringLength(1000)]
        public string EmailPersonally { get; set; }

        public long HomeAddressId { get; set; }

        public long? OfficeAddressId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Birthdate { get; set; }

        public long? JobId { get; set; }

        public long? CompanyId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Salary { get; set; }

        public long? WorkingSchemeId { get; set; }

        [StringLength(20)]
        public string PagerNumber { get; set; }

        [Required]
        [StringLength(20)]
        public string Gender { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ModifiedDateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<_PhoneNumber_Object> C_PhoneNumber_Object { get; set; }

        public virtual Address Address { get; set; }

        public virtual Address Address1 { get; set; }

        public virtual Company Company { get; set; }

        public virtual Job Job { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Settings> Settings { get; set; }

        public virtual WorkingScheme WorkingScheme { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Message { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Project> Project { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Project> Project1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Task> Task { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Task> Task1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Timeslice> Timeslice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<_User_Document_Acceptance> C_User_Document_Acceptance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<_Directory_User> C_Directory_User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<_GeoLocation_User> C_GeoLocation_User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<_User_Chat> C_User_Chat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<_User_Contact> C_User_Contact { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<_User_Message> C_User_Message { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<_User_Poll_Option> C_User_Poll_Option { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<_User_Project> C_User_Project { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<_User_User> C_User_User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<_User_User> C_User_User1 { get; set; }
    }
}
