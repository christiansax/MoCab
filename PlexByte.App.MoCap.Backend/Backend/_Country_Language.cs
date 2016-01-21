namespace Backend
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cfg._Country_Language")]
    public partial class _Country_Language
    {
        public long Id { get; set; }

        public long CountryId { get; set; }

        public long LanguageId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ModifiedDateTime { get; set; }

        public virtual Country Country { get; set; }

        public virtual Language Language { get; set; }
    }
}
