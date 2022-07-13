namespace WCWebService.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("xferLog")]
    public partial class xferLog
    {
        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dProcess { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dStart { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dEnd { get; set; }

        public bool? bSuccess { get; set; }

        [StringLength(100)]
        public string sNote { get; set; }

        public int iCieId { get; set; }
    }
}
