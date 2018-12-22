using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Model
{
    class Article
    {
        public const string ARRAY_ARTICLES = "Articles";

        public const string ARTICLENO = "ArticleNo";
        public const string NAME = "Name";
        public const string PRICE1 = "Price1";
        public const string PRICECALCMETHODSNO = "PriceCalcMethodsNo";
        public const string QUANTITYPERUNITPURCHASE = "QuantityPerUnitPurchase";
        public const string QUANTITYPERUNITSALE = "QuantityPerUnitSale";
        public const string STOCKPROFILENO = "StockProfileNo";
        public const string REGISTRATIONDATE = "RegistrationDate";
        public const string STOPDATEOFFERPRICE = "StopDateOfferPrice";
        public const string VALIDTO = "ValidTo";
        public const string WAREHOUSENO = "WarehouseNo";
        public const string POSTINGTEMPLATENO = "PostingTemplateNo";
        public const string AGREEDPRICE = "AgreedPrice";
        public const string NETPRICE = "NetPrice";
        public const string DISCOUNTI = "DiscountI";
        public const string DISCOUNTII = "DiscountII";
        public const string MAINGROUPNO = "MainGroupNo";
        public const string INTERMEDIATEGROUPNO = "IntermediateGroupNo";
        public const string SUBGROUPNO = "SubGroupNo";
        public const string LASTUPDATE = "LastUpdate";
        public const string LASTUPDATEDBY = "LastUpdatedBy";
        public const string INACTIVEYESNO = "InActiveYesNo";
        public const string WEBSHOPLASTAVAILABLEINSTOCK = "WebshopLastAvailableInStock";
        public const string WEBSHOPARTICLEYESNO = "WebshopArticleYesNo";
        public const string SHOWONWEBYESNO = "ShowOnWebYesNo";
        public const string MAINSTRUCTUREARTYESNO = "MainStructureArtYesNo";
        public const string COUNTEDYESNO = "CountedYesNo";
        public const string PICTUREPATH = "PicturePath";
        public const string MEMOFILEPATH = "MemoFilePath";
        public const string POSARTICLEINFO = "POSArticleInfo";
        public const string EUFIGURESNO = "EUFiguresNo";
        public const string COUNTRYOFORIGINNO = "CountryOfOriginNo";

        public const string CustomFields = "CustomFields";
    }

    class ArticleGroup
    {
        public const string ARRAY_ARTICLES_GROUP = "Groups";
        public const string MainGroupNo = "MainGroupNo";
        public const string Name = "Name";
        public const string StockControlYesNo = "StockControlYesNo";
        public const string RemainderOrderYesNo = "RemainderOrderYesNo";
        public const string RemainderPurchasingYesNo = "RemainderPurchasingYesNo";
        public const string AutoConsumptionYesNo = "AutoConsumptionYesNo";
        public const string AutoPriceVarianceYesNo = "AutoPriceVarianceYesNo";
        public const string ParentMainGroupNo = "ParentMainGroupNo";
        public const string FIFOYesNo = "FIFOYesNo";
        public const string InActiveYesNo = "InActiveYesNo";
        public const string LastUpdate = "LastUpdate";
        public const string LastUpdatedBy = "LastUpdatedBy";
        public const string Created = "Created";
        public const string CreatedBy = "CreatedBy";
        public const string ShowInShoppingCart = "ShowInShoppingCart";
    }

    class ArticleIntermediateGroup
    {
        public const string ARRAY_ARTICLES_SUB_GROUP = "Groups";
        public const string IntermediateGroupNo = "IntermediateGroupNo";
        public const string Name = "Name";
        public const string MainGroupNo = "MainGroupNo";
        public const string SortName = "SortName";
        public const string LastUpdate = "LastUpdate";
        public const string LastUpdatedBy = "LastUpdatedBy";
        public const string Created = "Created";
        public const string CreatedBy = "CreatedBy";
        public const string InActiveYesNo = "InActiveYesNo";
    }

    class ArticleSubGroup
    {
        public const string ARRAY_ARTICLES_SUB_GROUP = "Groups";
        public const string SubGroupNo = "SubGroupNo";
        public const string IntermediateGroupNo = "IntermediateGroupNo";
        public const string Name = "Name";
        public const string SortName = "SortName";
        public const string LastUpdate = "LastUpdate";
        public const string LastUpdatedBy = "LastUpdatedBy";
        public const string Created = "Created";
        public const string CreatedBy = "CreatedBy";
        public const string InActiveYesNo = "InActiveYesNo";
    }

    class ArticleUnitType
    {
        public const string ARRAY_ARTICLES_UNITTYPES = "UnitTypes";

        public const string UnitTypeNo = "UnitTypeNo";
        public const string ArticleNo = "ArticleNo";
        public const string WareHouseNo = "WareHouseNo";
        public const string Name = "Name";
        public const string UnitNamePurchase = "UnitNamePurchase";
        public const string Factor = "Factor";
        public const string LastUpdate = "LastUpdate";
        public const string LastUpdatedBy = "LastUpdatedBy";
        public const string ISOCode = "ISOCode";
        public const string Height = "Height";
        public const string VariableQtyYesNo = "VariableQtyYesNo";
        public const string Width = "Width";
        public const string Length = "Length";
        public const string Volume = "Volume";
        public const string Rounding = "Rounding";
        public const string PriceListNo = "PriceListNo";
        public const string Comment = "Comment";
        public const string UnitInPurchase = "UnitInPurchase";
        public const string SplitPurchaseYesNo = "SplitPurchaseYesNo";
        public const string UnitInSales = "UnitInSales";
        public const string SplitSalesYesNo = "SplitSalesYesNo";
        public const string FactorCalcMethod = "FactorCalcMethod";
        public const string Weight = "Weight";
        public const string UnitNo = "UnitNo";
        public const string PackingType = "PackingType";
        public const string ComparableUnitYesNo = "ComparableUnitYesNo";
        public const string Location = "Location";
        public const string UnitInStockControl = "UnitInStockControl";
    }
    class ArticleCustomField
    {
        public const string ARRAY_ARTICLES_CUSTOMFIELD = "CustomFields";

        public const string Factor = "4151 - Factor";
        public const string FactorCalcMethod = "7505 - FactorCalcMethod";
        public const string NetPrice = "20230 - NetPrice";
        public const string Available = "20245 - Available";
        public const string ContributionCurrentPeriod = "20279 - ContributionCurrentPeriod";
        public const string ContributionYear = "20280 - ContributionYear";
        public const string ContributionPercent = "20392 - ContributionPercent";
        public const string ArticleNo = "20472 - ArticleNo";
        public const string ProjectNo = "20651 - ProjectNo";
        public const string CurrencyCode = "20685 - CurrencyCode";
        public const string AgreedPrice = "20792 - AgreedPrice";
        public const string Discount = "20907 - Discount";
        public const string PriceType = "20909 - PriceType";
        public const string FirstDate = "20954 - FirstDate";
        public const string LastDate = "20955 - LastDate";
        public const string DiscountI = "21101 - DiscountI";
        public const string DiscountII = "21102 - DiscountII";
        public const string DiscountIII = "21103 - DiscountIII";
        public const string Price1FromDate = "21150 - Price1FromDate";
        public const string SupplPriceFromDate = "21151 - SupplPriceFromDate";
        public const string FullCostFromDate = "21156 - FullCostFromDate";
        public const string PriceCalcDate = "21175 - PriceCalcDate";
        public const string InActiveStatus = "21219 - InActiveStatus";
        public const string PriceTimesPurchUnit = "21232 - PriceTimesPurchUnit";
        public const string ErrorCode = "21234 - ErrorCode";
        public const string UpdateStock = "21244 - UpdateStock";
        public const string LastMovementDate = "21307 - LastMovementDate";
        public const string AutoConsumptionYesNo = "21399 - AutoConsumptionYesNo";
        public const string WeightedPurchasePriceYesNo = "21400 - WeightedPurchasePriceYesNo";
        public const string ExchangePrice = "21419 - ExchangePrice";
        public const string CurrencyNo = "21602 - CurrencyNo";
        public const string TemplateArticle = "21627 - TemplateArticle";
        public const string Quantity = "21752 - Quantity";
        public const string ComparableUnitPrice = "21766 - ComparableUnitPrice";
        public const string ComparableUnitType = "21767 - ComparableUnitType";
        public const string ContributionInCurrency = "22001 - ContributionInCurrency";
        public const string ColorMark = "29569 - ColorMark";
    }

    public class ArticleStockInfo
    {
        public const string WareHouseNo = "WareHouseNo";
        public const string ArticleNo = "ArticleNo";
        public const string Location = "Location";
        public const string CountedUnit = "CountedUnit";
        public const string LotNo = "LotNo";
        public const string UnitOnPurchase = "UnitOnPurchase";
        public const string MaxStock = "MaxStock";
        public const string MinStock = "MinStock";
        public const string UnitInStock = "UnitInStock";
        public const string UnitOnOrder = "UnitOnOrder";
        public const string UnitOnReminder = "UnitOnReminder";
        public const string LastMovementDate = "LastMovementDate";
        public const string UnitPacked = "UnitPacked";
        public const string CountedYesNo = "CountedYesNo";
        public const string UnitOnLoan = "UnitOnLoan";
        public const string LastUpdate = "LastUpdate";
        public const string LastUpdatedBy = "LastUpdatedBy";
        public const string QtyManualReserved = "QtyManualReserved";
        public const string QtyReserved = "QtyReserved";
        public const string LastStockCountDate = "LastStockCountDate";
    }
}
