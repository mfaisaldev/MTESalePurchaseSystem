namespace shopapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vArticleUnitType")]
    public partial class vArticleUnitType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UnitTypeNo { get; set; }

        [StringLength(300)]
        public string ArticleNo { get; set; }

        public int? WareHouseNo { get; set; }

        [StringLength(300)]
        public string Name { get; set; }

        [StringLength(300)]
        public string UnitNamePurchase { get; set; }

        public int? Factor { get; set; }

        public DateTime? LastUpdate { get; set; }

        public int? LastUpdatedBy { get; set; }

        [StringLength(300)]
        public string ISOCode { get; set; }

        public int? Height { get; set; }

        public bool? VariableQtyYesNo { get; set; }

        public int? Width { get; set; }

        public int? Length { get; set; }

        public int? Volume { get; set; }

        public int? Rounding { get; set; }

        public int? PriceListNo { get; set; }

        [StringLength(300)]
        public string Comment { get; set; }

        public int? UnitInPurchase { get; set; }

        public int? SplitPurchaseYesNo { get; set; }

        public int? UnitInSales { get; set; }

        public bool? SplitSalesYesNo { get; set; }

        public int? FactorCalcMethod { get; set; }

        public int? Weight { get; set; }

        public int? UnitNo { get; set; }

        [StringLength(300)]
        public string PackingType { get; set; }

        public bool? ComparableUnitYesNo { get; set; }

        [StringLength(300)]
        public string Location { get; set; }

        public int? UnitInStockControl { get; set; }

        public bool IsUpdated { get; set; }
    }
}
