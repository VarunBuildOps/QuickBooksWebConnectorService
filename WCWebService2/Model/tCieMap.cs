namespace WCWebService.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tCieMap")]
    public partial class tCieMap
    {
        [Key]
        public short iCieId { get; set; }

        [StringLength(100)]
        public string sCieName { get; set; }
    }
}
