namespace MoCap.Backend
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sec._User_Poll_Option")]
    public partial class _User_Poll_Option
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public _User_Poll_Option()
        {
            Interaction_BinaryObject = new HashSet<Interaction_BinaryObject>();
        }

        public long Id { get; set; }

        public long UserId { get; set; }

        public long PollId { get; set; }

        public long OptionId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ModifiedDateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Interaction_BinaryObject> Interaction_BinaryObject { get; set; }

        public virtual Poll Poll { get; set; }

        public virtual PollOption PollOption { get; set; }

        public virtual User User { get; set; }
    }
}
