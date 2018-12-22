using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.Models
{
    public class Article
    {
        public string ArticleNo { get; set; }
        public string Name { get; set; }
        public int Price1 { get; set; }
        public int PriceCalcMethodsNo { get; set; }
        public int QuantityPerUnitPurchase { get; set; }
        public int QuantityPerUnitSale { get; set; }
        public int StockProfileNo { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime StopDateOfferPrice { get; set; }
        public DateTime ValidTo { get; set; }
        public int WarehouseNo { get; set; }
        public int PostingTemplateNo { get; set; }
        public int MainGroupNo { get; set; }
        public int IntermediateGroupNo { get; set; }
        public int SubGroupNo { get; set; }
        public bool InActiveYesNo { get; set; }
        public int WebshopLastAvailableInStock { get; set; }
        public bool WebshopArticleYesNo { get; set; }
        public bool ShowOnWebYesNo { get; set; }
        public bool MainStructureArtYesNo { get; set; }
        public bool CountedYesNo { get; set; }
        public string PicturePath { get; set; }
        public string MemoFilePath { get; set; }
        public string POSArticleInfo { get; set; }
        public int CountryOfOriginNo { get; set; }
        public int EUFiguresNo { get; set; }
    }
}