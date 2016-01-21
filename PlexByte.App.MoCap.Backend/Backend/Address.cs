namespace Backend
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cfg.Address")]
    public partial class Address
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Address()
        {
            Company = new HashSet<Company>();
            User = new HashSet<User>();
            User1 = new HashSet<User>();
        }

        public long Id { get; set; }

        public long AddressTypeId { get; set; }

        public long StreetId { get; set; }

        public long StreetNumberId { get; set; }

        public long? AddressAppendixId { get; set; }

        public long? StateId { get; set; }

        public long CityId { get; set; }

        public long CountryId { get; set; }

        public long? GeoLocationId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ModifiedDateTime { get; set; }

        public virtual AddressAppendix AddressAppendix { get; set; }

        public virtual City City { get; set; }

        public virtual Country Country { get; set; }

        public virtual GeoLocation GeoLocation { get; set; }

        public virtual Type Type { get; set; }

        public virtual State State { get; set; }

        public virtual Street Street { get; set; }

        public virtual StreetNumber StreetNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Company> Company { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> User1 { get; set; }
    }
}
