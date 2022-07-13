namespace WCWebService.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(50)]
        public string sClientCode { get; set; }

        [StringLength(100)]
        public string sClientName { get; set; }

        [StringLength(50)]
        public string sClientGrpCode { get; set; }

        [StringLength(100)]
        public string sClientGrpName { get; set; }

        [StringLength(50)]
        public string sRepCode { get; set; }

        [StringLength(25)]
        public string sClassification { get; set; }

        [StringLength(500)]
        public string sAddress { get; set; }

        [StringLength(20)]
        public string sPostCode { get; set; }

        [StringLength(50)]
        public string sCity { get; set; }

        [StringLength(30)]
        public string sCountry { get; set; }

        [StringLength(50)]
        public string sEmail { get; set; }

        [StringLength(50)]
        public string sDistrictName { get; set; }

        [StringLength(50)]
        public string sProv { get; set; }

        [StringLength(50)]
        public string sTerrName { get; set; }

        [StringLength(50)]
        public string sControlType { get; set; }

        [StringLength(50)]
        public string sBannerName { get; set; }

        public short? iAge { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dDateOfBirth { get; set; }

        [StringLength(15)]
        public string Sex { get; set; }

        [StringLength(100)]
        public string sSegment { get; set; }

        [StringLength(100)]
        public string sMarket { get; set; }

        public int iCieId { get; set; }
    }
}
