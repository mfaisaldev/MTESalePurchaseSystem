namespace shopapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vArticle")]
    public partial class vArticle
    {
        [Key]
        [StringLength(300)]
        public string ArticleNo { get; set; }

        [StringLength(300)]
        public string Name { get; set; }

        public decimal? Price1 { get; set; }

        public int? PriceCalcMethodsNo { get; set; }

        public int? QuantityPerUnitPurchase { get; set; }

        public int? QuantityPerUnitSale { get; set; }

        public int? StockProfileNo { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public DateTime? StopDateOfferPrice { get; set; }

        public DateTime? ValidTo { get; set; }

        public int? WarehouseNo { get; set; }

        public int? PostingTemplateNo { get; set; }

        public decimal? AgreedPrice { get; set; }

        public decimal? NetPrice { get; set; }

        public decimal? DiscountI { get; set; }

        public decimal? DiscountII { get; set; }

        public int? MainGroupNo { get; set; }

        public int? IntermediateGroupNo { get; set; }

        public int? SubGroupNo { get; set; }

        public DateTime? LastUpdate { get; set; }

        public int? LastUpdatedBy { get; set; }

        public bool? InActiveYesNo { get; set; }

        public int? WebshopLastAvailableInStock { get; set; }

        public bool? WebshopArticleYesNo { get; set; }

        public bool? ShowOnWebYesNo { get; set; }

        public bool? MainStructureArtYesNo { get; set; }

        public bool? CountedYesNo { get; set; }

        [StringLength(300)]
        public string PicturePath { get; set; }

        [StringLength(300)]
        public string MemoFilePath { get; set; }

        [StringLength(300)]
        public string POSArticleInfo { get; set; }

        public int? EUFiguresNo { get; set; }

        public int? CountryOfOriginNo { get; set; }

        public bool IsUpdated { get; set; }
    }
}
