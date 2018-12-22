namespace shopapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vArticleCustomField")]
    public partial class vArticleCustomField
    {
        [Key]
        [StringLength(300)]
        public string ArticleNo { get; set; }

        public int? Factor { get; set; }

        public int? FactorCalcMethod { get; set; }

        public decimal? NetPrice { get; set; }

        public int? Available { get; set; }

        public int? ContributionCurrentPeriod { get; set; }

        public int? ContributionYear { get; set; }

        public int? ContributionPercent { get; set; }

        public int? ProjectNo { get; set; }

        [StringLength(300)]
        public string CurrencyCode { get; set; }

        public decimal? AgreedPrice { get; set; }

        public int? Discount { get; set; }

        [StringLength(300)]
        public string PriceType { get; set; }

        [StringLength(300)]
        public string FirstDate { get; set; }

        [StringLength(300)]
        public string LastDate { get; set; }

        public int? DiscountI { get; set; }

        public int? DiscountII { get; set; }

        public int? DiscountIII { get; set; }

        public DateTime? Price1FromDate { get; set; }

        public DateTime? SupplPriceFromDate { get; set; }

        public DateTime? FullCostFromDate { get; set; }

        public DateTime? PriceCalcDate { get; set; }

        [StringLength(300)]
        public string InActiveStatus { get; set; }

        public decimal? PriceTimesPurchUnit { get; set; }

        public int? ErrorCode { get; set; }

        public int? UpdateStock { get; set; }

        public DateTime? LastMovementDate { get; set; }

        public int? AutoConsumptionYesNo { get; set; }

        public int? WeightedPurchasePriceYesNo { get; set; }

        public decimal? ExchangePrice { get; set; }

        [StringLength(300)]
        public string CurrencyNo { get; set; }

        [StringLength(300)]
        public string TemplateArticle { get; set; }

        public int? Quantity { get; set; }

        public decimal? ComparableUnitPrice { get; set; }

        [StringLength(300)]
        public string ComparableUnitType { get; set; }

        public int? ContributionInCurrency { get; set; }

        public int? ColorMark { get; set; }

        public bool IsUpdated { get; set; }
    }
}
