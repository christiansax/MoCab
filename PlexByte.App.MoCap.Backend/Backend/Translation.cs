namespace Backend
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cfg.Translation")]
    public partial class Translation
    {
        public int Id { get; set; }

        public long TypeId { get; set; }

        public long LanguageId { get; set; }

        [Required]
        public string StringValue { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ModifiedDateTime { get; set; }

        public virtual Language Language { get; set; }

        public virtual Type Type { get; set; }
    }
}
