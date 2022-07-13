namespace WCWebService.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public enum ProductType
        {
            Service = 0,
            Inventory
        }

        public int id { get; set; }

        [StringLength(50)]
        public string sProdCatCode { get; set; }

        [StringLength(75)]
        public string sProdCatName { get; set; }

        [StringLength(50)]
        public string sSubProdCatCode { get; set; }

        [StringLength(75)]
        public string sSubProdCatName { get; set; }

        [Required]
        [StringLength(50)]
        public string sSkuCode { get; set; }

        [StringLength(75)]
        public string sSkuName { get; set; }

        public short? iUnitCnt { get; set; }

        public double? fHeight { get; set; }

        public double? fLenght { get; set; }

        [StringLength(50)]
        public string sColorCode { get; set; }

        public double? fWeight { get; set; }

        [Column(TypeName = "money")]
        public decimal? fCost { get; set; }

        [Column(TypeName = "money")]
        public decimal? fPrice { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dLaunch { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        public int iCieId { get; set; }
    }
}
