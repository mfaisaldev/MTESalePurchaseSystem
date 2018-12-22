namespace shopapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vArticleGroupMain")]
    public partial class vArticleGroupMain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MainGroupNo { get; set; }

        [StringLength(300)]
        public string Name { get; set; }

        public int? StockControlYesNo { get; set; }

        public int? RemainderOrderYesNo { get; set; }

        public int? RemainderPurchasingYesNo { get; set; }

        public int? AutoConsumptionYesNo { get; set; }

        public int? AutoPriceVarianceYesNo { get; set; }

        public int? ParentMainGroupNo { get; set; }

        public int? FIFOYesNo { get; set; }

        public int? InActiveYesNo { get; set; }

        public DateTime? LastUpdate { get; set; }

        public int? LastUpdatedBy { get; set; }

        public DateTime? Created { get; set; }

        public int? CreatedBy { get; set; }

        public int? ShowInShoppingCart { get; set; }

        public bool IsUpdated { get; set; }
    }
}
