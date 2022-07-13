namespace WCWebService.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sale
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(50)]
        public string sRepCode { get; set; }

        [StringLength(75)]
        public string sRepName { get; set; }

        [StringLength(50)]
        public string sRepGrpCode { get; set; }

        [StringLength(75)]
        public string sRepGrpName { get; set; }

        [StringLength(50)]
        public string sRepSubGrpCode { get; set; }

        [StringLength(75)]
        public string sRepSubGrpName { get; set; }

        [StringLength(50)]
        public string sClientCode { get; set; }

        [StringLength(100)]
        public string sClientName { get; set; }

        [StringLength(50)]
        public string sClientGrpCode { get; set; }

        [StringLength(100)]
        public string sClientGrpName { get; set; }

        [StringLength(50)]
        public string sProdCatCode { get; set; }

        [StringLength(75)]
        public string sProdCatName { get; set; }

        [StringLength(50)]
        public string sSubProdCatCode { get; set; }

        [StringLength(75)]
        public string sSubProdCatName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dTransactDate { get; set; }

        [StringLength(50)]
        public string dTransactId { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal? fNetSales { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal? fNetCost { get; set; }

        public decimal? iQty { get; set; }

        [StringLength(50)]
        public string sTypeVente { get; set; }

        public int? iCieId { get; set; }
    }
}
