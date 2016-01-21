namespace Backend
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("__RefactorLog")]
    public partial class __RefactorLog
    {
        [Key]
        public Guid OperationKey { get; set; }
    }
}
