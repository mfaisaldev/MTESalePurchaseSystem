using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scheduler.Model;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Admin;
using System.IO;

namespace Scheduler.Controller
{
    class Articles
    {
        private const string URL = Utilities.URL + "articles";
        private string urlParameters = "";

        public async Task GetArticleFromFile()
        {
            try
            {
                string text;
                var fileStream = new FileStream(@"c:\USB\products.txt", FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    text = streamReader.ReadToEnd();
                    var json = JObject.Parse(text);
                    if (!(json[Article.ARRAY_ARTICLES] is JArray)) return;
                    var col = (JArray)json[Article.ARRAY_ARTICLES];
                    foreach (JObject obj in col)
                    {
                        this.AddArticle(obj);
                    }
                }
               
               
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public async Task GetArticles()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(urlParameters).Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsAsync<JObject>();
                    if (!(json[Article.ARRAY_ARTICLES] is JArray)) return;
                    var col = (JArray)json[Article.ARRAY_ARTICLES];
                    foreach (JObject obj in col)
                    {
                        this.AddArticle(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private void AddArticle(JObject obj)
        {
            try
            {
                using (Admin.DBLayer.ICONEntities2 DB = new Admin.DBLayer.ICONEntities2())
                {
                    var ArticleNo = obj[Article.ARTICLENO].ToString();
                    var oldt = DB.vArticles.Where(u => u.ArticleNo  == ArticleNo).FirstOrDefault();
                    if (oldt == null)
                    {
                        var t = new Admin.DBLayer.vArticle();
                        t.ArticleNo = ArticleNo;
                        t.Name = obj[Article.NAME].ToString();
                        t.Price1 = Convert.ToDecimal(obj[Article.PRICE1]);
                        t.PriceCalcMethodsNo = Convert.ToInt32(obj[Article.PRICECALCMETHODSNO]);
                        t.QuantityPerUnitPurchase = Convert.ToInt32(obj[Article.QUANTITYPERUNITPURCHASE]);
                        t.QuantityPerUnitSale = Convert.ToInt32(obj[Article.QUANTITYPERUNITSALE]);
                        t.StockProfileNo = Convert.ToInt32(obj[Article.STOCKPROFILENO]);
                        t.RegistrationDate = Convert.ToDateTime(obj[Article.REGISTRATIONDATE]);
                        t.StopDateOfferPrice = Convert.ToDateTime(obj[Article.STOPDATEOFFERPRICE]);
                        t.ValidTo = Convert.ToDateTime(obj[Article.VALIDTO]);
                        t.WarehouseNo = Convert.ToInt32(obj[Article.WAREHOUSENO]); 
                        t.PostingTemplateNo = Convert.ToInt32(obj[Article.POSTINGTEMPLATENO]);
                        t.AgreedPrice = Convert.ToInt32(obj[Article.AGREEDPRICE]);
                        t.NetPrice = Convert.ToDecimal(obj[Article.NETPRICE]);
                        t.DiscountI = Convert.ToDecimal(obj[Article.DISCOUNTI]);
                        t.DiscountII = Convert.ToDecimal(obj[Article.DISCOUNTII]);
                        t.MainGroupNo = Convert.ToInt32(obj[Article.MAINGROUPNO]);
                        t.IntermediateGroupNo = Convert.ToInt32(obj[Article.INTERMEDIATEGROUPNO]);
                        t.SubGroupNo = Convert.ToInt32(obj[Article.SUBGROUPNO]);
                        t.LastUpdate = Convert.ToDateTime(obj[Article.LASTUPDATE]);
                        t.LastUpdatedBy = Convert.ToInt32(obj[Article.LASTUPDATEDBY]);
                        t.InActiveYesNo = Convert.ToBoolean(obj[Article.INACTIVEYESNO]);
                        t.WebshopLastAvailableInStock = Convert.ToInt32(obj[Article.WEBSHOPLASTAVAILABLEINSTOCK]);
                        t.WebshopArticleYesNo = Convert.ToBoolean(obj[Article.WEBSHOPARTICLEYESNO]);
                        t.ShowOnWebYesNo = Convert.ToBoolean(obj[Article.SHOWONWEBYESNO]);
                        t.MainStructureArtYesNo = Convert.ToBoolean(obj[Article.MAINSTRUCTUREARTYESNO]);
                        t.CountedYesNo = Convert.ToBoolean(obj[Article.COUNTEDYESNO]);
                        t.PicturePath = obj[Article.PICTUREPATH].ToString();
                        t.MemoFilePath = obj[Article.MEMOFILEPATH].ToString();
                        t.POSArticleInfo = obj[Article.POSARTICLEINFO].ToString();
                        t.EUFiguresNo = Convert.ToInt32(obj[Article.EUFIGURESNO]);
                        t.CountryOfOriginNo = Convert.ToInt32(obj[Article.COUNTRYOFORIGINNO]);
                        t.IsUpdated = true;
                        DB.vArticles.Add(t);
                        DB.SaveChanges();
                    }
                    else
                    {
                        bool IsUpdated = false;
                        if (oldt.Name != obj[Article.NAME].ToString())
                        {
                            IsUpdated = true;
                            oldt.Name = obj[Article.NAME].ToString();
                        }
                        if (oldt.Price1 != Convert.ToInt32(obj[Article.PRICE1]))
                        {
                            IsUpdated = true;
                            oldt.Price1 = Convert.ToInt32(obj[Article.PRICE1]);
                        }
                        if (oldt.PriceCalcMethodsNo != Convert.ToInt32(obj[Article.PRICECALCMETHODSNO]))
                        {
                            IsUpdated = true;
                            oldt.PriceCalcMethodsNo = Convert.ToInt32(obj[Article.PRICECALCMETHODSNO]);
                        }
                        if (oldt.QuantityPerUnitPurchase != Convert.ToInt32(obj[Article.QUANTITYPERUNITPURCHASE]))
                        {
                            IsUpdated = true;
                            oldt.QuantityPerUnitPurchase = Convert.ToInt32(obj[Article.QUANTITYPERUNITPURCHASE]);
                        }
                        if (oldt.QuantityPerUnitSale != Convert.ToInt32(obj[Article.QUANTITYPERUNITSALE]))
                        {
                            IsUpdated = true;
                            oldt.QuantityPerUnitSale = Convert.ToInt32(obj[Article.QUANTITYPERUNITSALE]);
                        }
                        if (oldt.StockProfileNo != Convert.ToInt32(obj[Article.STOCKPROFILENO]))
                        {
                            IsUpdated = true;
                            oldt.StockProfileNo = Convert.ToInt32(obj[Article.STOCKPROFILENO]);
                        }
                        if (oldt.RegistrationDate != Convert.ToDateTime(obj[Article.REGISTRATIONDATE]))
                        {
                            IsUpdated = true;
                            oldt.RegistrationDate = Convert.ToDateTime(obj[Article.REGISTRATIONDATE]);
                        }
                        if (oldt.StopDateOfferPrice != Convert.ToDateTime(obj[Article.STOPDATEOFFERPRICE]))
                        {
                            IsUpdated = true;
                            oldt.StopDateOfferPrice = Convert.ToDateTime(obj[Article.STOPDATEOFFERPRICE]);
                        }
                        if (oldt.ValidTo != Convert.ToDateTime(obj[Article.VALIDTO]))
                        {
                            IsUpdated = true;
                            oldt.ValidTo = Convert.ToDateTime(obj[Article.VALIDTO]);
                        }
                        if (oldt.WarehouseNo != Convert.ToInt32(obj[Article.WAREHOUSENO]))
                        {
                            IsUpdated = true;
                            oldt.WarehouseNo = Convert.ToInt32(obj[Article.WAREHOUSENO]);
                        }
                        if (oldt.PostingTemplateNo != Convert.ToInt32(obj[Article.POSTINGTEMPLATENO]))
                        {
                            IsUpdated = true;
                            oldt.PostingTemplateNo = Convert.ToInt32(obj[Article.POSTINGTEMPLATENO]);
                        }
                        if (oldt.AgreedPrice != Convert.ToInt32(obj[Article.AGREEDPRICE]))
                        {
                            IsUpdated = true;
                            oldt.AgreedPrice = Convert.ToInt32(obj[Article.AGREEDPRICE]);
                        }
                        if (oldt.NetPrice != Convert.ToInt32(obj[Article.NETPRICE]))
                        {
                            IsUpdated = true;
                            oldt.NetPrice = Convert.ToInt32(obj[Article.NETPRICE]);
                        }
                        if (oldt.DiscountI != Convert.ToInt32(obj[Article.DISCOUNTI]))
                        {
                            IsUpdated = true;
                            oldt.DiscountI = Convert.ToInt32(obj[Article.DISCOUNTI]);
                        }
                        if (oldt.DiscountII != Convert.ToInt32(obj[Article.DISCOUNTII]))
                        {
                            IsUpdated = true;
                            oldt.DiscountII = Convert.ToInt32(obj[Article.DISCOUNTII]);
                        }
                        if (oldt.MainGroupNo != Convert.ToInt32(obj[Article.MAINGROUPNO]))
                        {
                            IsUpdated = true;
                            oldt.MainGroupNo = Convert.ToInt32(obj[Article.MAINGROUPNO]);
                        }
                        if (oldt.IntermediateGroupNo != Convert.ToInt32(obj[Article.INTERMEDIATEGROUPNO]))
                        {
                            IsUpdated = true;
                            oldt.IntermediateGroupNo = Convert.ToInt32(obj[Article.INTERMEDIATEGROUPNO]);
                        }
                        if (oldt.SubGroupNo != Convert.ToInt32(obj[Article.SUBGROUPNO]))
                        {
                            IsUpdated = true;
                            oldt.SubGroupNo = Convert.ToInt32(obj[Article.SUBGROUPNO]);
                        }
                        if (oldt.LastUpdate != Convert.ToDateTime(obj[Article.LASTUPDATE]))
                        {
                            IsUpdated = true;
                            oldt.LastUpdate = Convert.ToDateTime(obj[Article.LASTUPDATE]);
                        }
                        if (oldt.LastUpdatedBy != Convert.ToInt32(obj[Article.LASTUPDATEDBY]))
                        {
                            IsUpdated = true;
                            oldt.LastUpdatedBy = Convert.ToInt32(obj[Article.LASTUPDATEDBY]);
                        }
                        if (oldt.InActiveYesNo != Convert.ToBoolean(obj[Article.INACTIVEYESNO]))
                        {
                            IsUpdated = true;
                            oldt.InActiveYesNo = Convert.ToBoolean(obj[Article.INACTIVEYESNO]);
                        }
                        if (oldt.WebshopLastAvailableInStock != Convert.ToInt32(obj[Article.WEBSHOPLASTAVAILABLEINSTOCK]))
                        {
                            IsUpdated = true;
                            oldt.WebshopLastAvailableInStock = Convert.ToInt32(obj[Article.WEBSHOPLASTAVAILABLEINSTOCK]);
                        }
                        if (oldt.WebshopArticleYesNo != Convert.ToBoolean(obj[Article.WEBSHOPARTICLEYESNO]))
                        {
                            IsUpdated = true;
                            oldt.WebshopArticleYesNo = Convert.ToBoolean(obj[Article.WEBSHOPARTICLEYESNO]);
                        }
                        if (oldt.ShowOnWebYesNo != Convert.ToBoolean(obj[Article.SHOWONWEBYESNO]))
                        {
                            IsUpdated = true;
                            oldt.ShowOnWebYesNo = Convert.ToBoolean(obj[Article.SHOWONWEBYESNO]);
                        }
                        if (oldt.MainStructureArtYesNo != Convert.ToBoolean(obj[Article.MAINSTRUCTUREARTYESNO]))
                        {
                            IsUpdated = true;
                            oldt.MainStructureArtYesNo = Convert.ToBoolean(obj[Article.MAINSTRUCTUREARTYESNO]);
                        }
                        if (oldt.CountedYesNo != Convert.ToBoolean(obj[Article.COUNTEDYESNO]))
                        {
                            IsUpdated = true;
                            oldt.CountedYesNo = Convert.ToBoolean(obj[Article.COUNTEDYESNO]);
                        }
                        if (oldt.PicturePath != Convert.ToString(obj[Article.PICTUREPATH]))
                        {
                            IsUpdated = true;
                            oldt.PicturePath = Convert.ToString(obj[Article.PICTUREPATH]);
                        }
                        if (oldt.MemoFilePath != Convert.ToString(obj[Article.MEMOFILEPATH]))
                        {
                            IsUpdated = true;
                            oldt.MemoFilePath = Convert.ToString(obj[Article.MEMOFILEPATH]);
                        }
                        if (oldt.POSArticleInfo != Convert.ToString(obj[Article.POSARTICLEINFO]))
                        {
                            IsUpdated = true;
                            oldt.POSArticleInfo = Convert.ToString(obj[Article.POSARTICLEINFO]);
                        }
                        if (oldt.EUFiguresNo != Convert.ToInt32(obj[Article.EUFIGURESNO]))
                        {
                            IsUpdated = true;
                            oldt.EUFiguresNo = Convert.ToInt32(obj[Article.EUFIGURESNO]);
                        }
                        if (oldt.CountryOfOriginNo != Convert.ToInt32(obj[Article.COUNTRYOFORIGINNO]))
                        {
                            IsUpdated = true;
                            oldt.CountryOfOriginNo = Convert.ToInt32(obj[Article.COUNTRYOFORIGINNO]);
                        }
                        if (IsUpdated)
                        {
                            oldt.IsUpdated = IsUpdated;
                            DB.SaveChanges();
                        }
                    }
                   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void UpdateArticle()
        {
            try
            {
                using (Admin.DBLayer.ICONEntities2 DB = new Admin.DBLayer.ICONEntities2())
                {

                    var vArticles = (from a in DB.vArticles
                                     join cf in DB.vArticleCustomFields on a.ArticleNo equals cf.ArticleNo 
                                     join si in DB.vArticleStockInfoes on a.ArticleNo equals si.ArticleNo 
                                     where  a.ArticleNo != "" && a.IsUpdated == true  && a.LastUpdate > new DateTime(2015,4,18)
                                     select new {a.ArticleNo, a.Name, a.Price1, a.PriceCalcMethodsNo, a.QuantityPerUnitPurchase,
 a.QuantityPerUnitSale, a.StockProfileNo, a.RegistrationDate, a.StopDateOfferPrice, a.ValidTo, a.WarehouseNo, a.PostingTemplateNo,
 a.AgreedPrice, a.NetPrice, a.DiscountI, a.DiscountII, a.MainGroupNo, a.IntermediateGroupNo, a.SubGroupNo, a.LastUpdate, a.LastUpdatedBy,
 a.InActiveYesNo, a.WebshopLastAvailableInStock, a.WebshopArticleYesNo, a.ShowOnWebYesNo, a.MainStructureArtYesNo, a.CountedYesNo,
 a.PicturePath, a.MemoFilePath, a.POSArticleInfo, a.EUFiguresNo, a.CountryOfOriginNo, a.IsUpdated, cf.Factor, cf.FactorCalcMethod,
 cfNetPrice =cf.NetPrice, cf.Available, cf.ContributionCurrentPeriod, cf.ContributionYear, cf.ContributionPercent, cf.ProjectNo,
 cf.CurrencyCode,cfAgreedPrice= cf.AgreedPrice, cf.Discount, cf.PriceType, cf.FirstDate, cf.LastDate, cfDiscountI= cf.DiscountI,
 cfDiscountII =cf.DiscountII, cf.DiscountIII, cf.Price1FromDate, cf.SupplPriceFromDate, cf.FullCostFromDate, cf.PriceCalcDate,
 cf.InActiveStatus, cf.PriceTimesPurchUnit, cf.ErrorCode, cf.UpdateStock, cf.LastMovementDate, cf.AutoConsumptionYesNo,
 cf.WeightedPurchasePriceYesNo, cf.ExchangePrice, cf.CurrencyNo, cf.TemplateArticle, cf.Quantity, cf.ComparableUnitPrice,
 cf.ComparableUnitType, cf.ContributionInCurrency, cf.ColorMark, cfIsUpdated =cf.IsUpdated, si.UnitOnPurchase,
 si.MaxStock, si.MinStock, si.UnitInStock, si.UnitOnOrder, si.UnitOnReminder, si.UnitPacked, si.QtyManualReserved, si.QtyReserved
                                     }).ToList();

                    foreach (var v in vArticles)
                    {
                        try
                        {
                            var t = DB.tblProducts.Where(u => u.ArticleNo  == v.ArticleNo).FirstOrDefault();
                            using (Admin.DBLayer.ICONEntities2 DB2 = new Admin.DBLayer.ICONEntities2())
                            {
                                if (t == null)
                                {
                                    t = new Admin.DBLayer.tblProduct();
                                    t.ArticleNo = v.ArticleNo;
                                    t.UPC_code = v.ArticleNo; 
                                    t.CreateBy = "VISMA";
                                    t.CreationDate = DateTime.Now;
                                    t.CurrencyId = new Guid("34DD283F-DD4B-4A55-AA26-505245FDB52C");
                                    t.FullDescription = v.TemplateArticle;
                                    t.Price = v.Price1;
                                    t.ProductId = Guid.NewGuid();
                                    t.ProductStock = v.UnitInStock;
                                    t.Price_customs_NOK = v.cfAgreedPrice;
                                    t.ShortDescription = v.Name;
                                    t.Name = v.Name;
                                    t.StatusId = new Guid(Utilities.Status_Active);
                                    t.IsVISMA = true;
                                    t.PublishDate = v.RegistrationDate;
                                    t.Purchase_Price_NOK = v.NetPrice;
                                    t.Name = v.Name;
                                    if (v.MainGroupNo > 0)
                                    {
                                        try
                                        {
                                            t.MainGroupId = DB.tblMainGroups.Where(u => u.MainGroupNo == v.MainGroupNo).FirstOrDefault().MainGroupId;
                                        }
                                        catch (Exception ex)
                                        {
                                            t.MainGroupId = null;
                                            //Console.WriteLine(ex);
                                        }
                                    }
                                    if (v.IntermediateGroupNo > 0)
                                    {
                                        try
                                        {
                                            t.IntermediateGroupId = DB.tblIntermediateGroups.Where(u => u.IntermediateGroupNo == v.IntermediateGroupNo).FirstOrDefault().IntermediateGroupId;
                                        }
                                        catch (Exception ex)
                                        {
                                            t.IntermediateGroupId = null;
                                            //Console.WriteLine(ex);
                                        }
                                    }

                                    if (v.SubGroupNo > 0)
                                    {
                                        try
                                        {
                                            t.SubGroupId = DB.tblSubGroups.Where(u => u.SubGroupNo == v.SubGroupNo).FirstOrDefault().SubGroupId;
                                        }
                                        catch (Exception ex)
                                        {
                                            t.SubGroupId = null;
                                            //Console.WriteLine(ex);
                                        }
                                    }
                                    t.WareHouseNo = v.WarehouseNo;
                                    t.UnitOnPurchase = v.UnitOnPurchase;
                                    t.MaxStock = v.MaxStock;
                                    t.MinStock = v.MinStock;
                                    t.UnitInStock = v.UnitInStock;
                                    t.UnitOnOrder = v.UnitOnOrder;
                                    t.UnitOnReminder = v.UnitOnReminder;
                                    t.UnitPacked = v.UnitPacked;
                                    t.QtyManualReserved = v.QtyManualReserved;
                                    t.QtyReserved = v.QtyReserved;
                                    t.ProductStock = v.UnitInStock;
                                    t.FileId = new Guid("D7253A72-9B86-426E-8716-85028AC3582C"); 
                                    DB2.tblProducts.Add(t);
                                    DB2.SaveChanges();
                                }
                                else
                                {
                                    t.CurrencyId = new Guid("34DD283F-DD4B-4A55-AA26-505245FDB52C");
                                    t.FullDescription = v.TemplateArticle;
                                    t.Price = v.Price1;
                                    t.UPC_code = v.ArticleNo;
                                    t.Price_customs_NOK = v.cfAgreedPrice;
                                    t.ShortDescription = v.Name;
                                    t.Name = v.Name;
                                    t.IsVISMA = true;
                                    t.PublishDate = v.RegistrationDate;
                                    t.Purchase_Price_NOK = v.NetPrice;
                                    t.Name = v.Name;
                                    t.ModifyBy = "VISMA";
                                    t.ModifyDate = DateTime.Now;
                                    if (v.MainGroupNo > 0)
                                    {
                                        try
                                        {
                                            t.MainGroupId = DB.tblMainGroups.Where(u => u.MainGroupNo == v.MainGroupNo).FirstOrDefault().MainGroupId;
                                        }
                                        catch (Exception ex)
                                        {
                                            t.MainGroupId = null;
                                            //Console.WriteLine(ex);
                                        }
                                    }
                                    if (v.IntermediateGroupNo > 0)
                                    {
                                        try
                                        {
                                            t.IntermediateGroupId = DB.tblIntermediateGroups.Where(u => u.IntermediateGroupNo == v.IntermediateGroupNo).FirstOrDefault().IntermediateGroupId;
                                        }
                                        catch (Exception ex)
                                        {
                                            t.IntermediateGroupId = null;
                                            //Console.WriteLine(ex);
                                        }
                                    }
                                   
                                    if (v.SubGroupNo > 0)
                                    {
                                        try
                                        {
                                            t.SubGroupId = DB.tblSubGroups.Where(u => u.SubGroupNo == v.SubGroupNo).FirstOrDefault().SubGroupId;
                                        }
                                        catch (Exception ex)
                                        {
                                            t.SubGroupId = null;
                                            //Console.WriteLine(ex);
                                        }
                                    }
                                    t.WareHouseNo = v.WarehouseNo;
                                    t.UnitOnPurchase = v.UnitOnPurchase;
                                    t.MaxStock = v.MaxStock;
                                    t.MinStock = v.MinStock;
                                    t.UnitInStock = v.UnitInStock;
                                    t.UnitOnOrder = v.UnitOnOrder;
                                    t.UnitOnReminder = v.UnitOnReminder;
                                    t.UnitPacked = v.UnitPacked;
                                    t.QtyManualReserved = v.QtyManualReserved;
                                    t.QtyReserved = v.QtyReserved;
                                    t.ProductStock = v.UnitInStock;
                                    DB2.SaveChanges();
                                }
                            }
                            var a = DB.vArticles.Where(u => u.ArticleNo == v.ArticleNo).FirstOrDefault(); 
                            a.IsUpdated = false;
                            DB.SaveChanges();
                            var acf = DB.vArticleCustomFields.Where(u => u.ArticleNo == v.ArticleNo).FirstOrDefault();
                            acf.IsUpdated = false;
                            DB.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

      
        public void UpdateArticleMainGroup()
        {
            try
            {
                using (Admin.DBLayer.ICONEntities2 DB = new Admin.DBLayer.ICONEntities2())
                {
                    var vArticleGroupMains = DB.vArticleGroupMains.Where(u => u.IsUpdated == true).ToList();
                    foreach (var v in vArticleGroupMains)
                    {
                        try
                        {
                            var t = DB.tblMainGroups.Where(u => u.MainGroupNo == v.MainGroupNo).FirstOrDefault();
                            using (Admin.DBLayer.ICONEntities2 DB2 = new Admin.DBLayer.ICONEntities2())
                            {
                                if (t == null)
                                {
                                    t = new Admin.DBLayer.tblMainGroup();
                                    t.MainGroupId  = Guid.NewGuid();
                                    t.CreateBy = "VISMA";
                                    t.CreationDate = DateTime.Now;
                                    t.DisplayOrder = v.MainGroupNo;
                                    t.IsVISMA = true;
                                    t.MainGroupNo = v.MainGroupNo;
                                    t.Name = v.Name;
                                    t.StatusId = new Guid(Utilities.Status_Active);
                                    DB2.tblMainGroups.Add(t);
                                    DB2.SaveChanges();
                                }
                                else
                                {
                                    t.DisplayOrder = v.MainGroupNo;
                                    t.IsVISMA = true;
                                    t.MainGroupNo = v.MainGroupNo;
                                    t.Name = v.Name;
                                    t.ModifyBy = "VISMA";
                                    t.ModifyDate = DateTime.Now;
                                    DB2.SaveChanges();
                                }
                            }
                            v.IsUpdated = false;
                            DB.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void UpdateArticleIntermediateGroup()
        {
            try
            {
                using (Admin.DBLayer.ICONEntities2 DB = new Admin.DBLayer.ICONEntities2())
                {
                    var vArticleIntermediateGroups = DB.vArticleIntermediateGroups.Where(u => u.IsUpdated == true).ToList();
                    foreach (var v in vArticleIntermediateGroups)
                    {
                        try
                        {
                            var t = DB.tblIntermediateGroups.Where(u => u.IntermediateGroupNo  == v.IntermediateGroupNo).FirstOrDefault();
                            using (Admin.DBLayer.ICONEntities2 DB2 = new Admin.DBLayer.ICONEntities2())
                            {
                                if (t == null)
                                {
                                    t = new Admin.DBLayer.tblIntermediateGroup();
                                    t.IntermediateGroupId  = Guid.NewGuid();
                                    t.IntermediateGroupNo = v.IntermediateGroupNo;
                                    t.MainGroupNo = v.MainGroupNo;
                                    if (v.MainGroupNo>0)
                                        t.MainGroupId = DB.tblMainGroups.Where(u => u.MainGroupNo == v.MainGroupNo).FirstOrDefault().MainGroupId;      
                                    t.CreateBy = "VISMA";
                                    t.CreationDate = DateTime.Now;
                                    t.DisplayOrder = v.IntermediateGroupNo;
                                    t.IsVISMA = true;
                                    t.Name = v.Name;
                                    t.StatusId = new Guid(Utilities.Status_Active);
                                    DB2.tblIntermediateGroups.Add(t);
                                    DB2.SaveChanges();
                                }
                                else
                                {
                                    t.DisplayOrder = v.IntermediateGroupNo;
                                    t.IsVISMA = true;
                                    t.IntermediateGroupNo = v.IntermediateGroupNo;
                                    t.MainGroupNo = v.MainGroupNo;
                                    if (v.MainGroupNo > 0)
                                        t.MainGroupId = DB.tblMainGroups.Where(u => u.MainGroupNo == v.MainGroupNo).FirstOrDefault().MainGroupId;
                                    t.Name = v.Name;
                                    t.ModifyBy = "VISMA";
                                    t.ModifyDate = DateTime.Now;
                                    DB2.SaveChanges();
                                }
                            }
                            v.IsUpdated = false;
                            DB.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void UpdateArticleSubGroup()
        {
            try
            {
                using (Admin.DBLayer.ICONEntities2 DB = new Admin.DBLayer.ICONEntities2())
                {
                    var vArticleSubGroups = DB.vArticleSubGroups.Where(u => u.IsUpdated == true).ToList();
                    foreach (var v in vArticleSubGroups)
                    {
                        try
                        {
                            var t = DB.tblSubGroups.Where(u => u.SubGroupNo == v.SubGroupNo).FirstOrDefault();
                            using (Admin.DBLayer.ICONEntities2 DB2 = new Admin.DBLayer.ICONEntities2())
                            {
                                if (t == null)
                                {
                                    t = new Admin.DBLayer.tblSubGroup();
                                    t.SubGroupId = Guid.NewGuid();
                                    t.IntermediateGroupNo = v.IntermediateGroupNo;
                                    t.SubGroupNo = v.SubGroupNo;
                                    if (v.IntermediateGroupNo > 0)
                                        t.IntermediateGroupId = DB.tblIntermediateGroups.Where(u => u.IntermediateGroupNo == v.IntermediateGroupNo).FirstOrDefault().MainGroupId;
                                    t.CreateBy = "VISMA";
                                    t.CreationDate = DateTime.Now;
                                    t.DisplayOrder = v.IntermediateGroupNo;
                                    t.IsVISMA = true;
                                    t.Name = v.Name;
                                    t.StatusId = new Guid(Utilities.Status_Active);
                                    DB2.tblSubGroups.Add(t);
                                    DB2.SaveChanges();
                                }
                                else
                                {
                                    t.DisplayOrder = v.IntermediateGroupNo;
                                    t.IsVISMA = true;
                                    t.IntermediateGroupNo = v.IntermediateGroupNo;
                                    t.SubGroupNo = v.SubGroupNo;
                                    if (v.IntermediateGroupNo > 0)
                                        t.IntermediateGroupId = DB.tblIntermediateGroups.Where(u => u.IntermediateGroupNo == v.IntermediateGroupNo).FirstOrDefault().MainGroupId;
                                    t.Name = v.Name;
                                    t.ModifyBy = "VISMA";
                                    t.ModifyDate = DateTime.Now;
                                    DB2.SaveChanges();
                                }
                            }
                            v.IsUpdated = false;
                            DB.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }


    class ArticleGroups
    {
        private const string URL = Utilities.URL + "articlegroups/main";
        private string urlParameters = "";
        public async Task GetArticleGroups()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(urlParameters).Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsAsync<JObject>();
                    if (!(json[ArticleGroup.ARRAY_ARTICLES_GROUP] is JArray)) return;
                    var col = (JArray)json[ArticleGroup.ARRAY_ARTICLES_GROUP];
                    foreach (JObject obj in col)
                    {
                        this.AddArticleGroup(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private void AddArticleGroup(JObject obj)
        {
            try
            {
                using (Admin.DBLayer.ICONEntities2 DB = new Admin.DBLayer.ICONEntities2())
                {
                    var MainGroupNo = Convert.ToInt32(obj[ArticleGroup.MainGroupNo]);
                    var oldt = DB.vArticleGroupMains.Where(u => u.MainGroupNo == MainGroupNo).FirstOrDefault();
                    if (oldt == null)
                    {
                        var t = new Admin.DBLayer.vArticleGroupMain();
                        t.MainGroupNo = MainGroupNo;
                        t.Name = Convert.ToString(obj[ArticleGroup.Name]);
                        t.StockControlYesNo = Convert.ToInt32(obj[ArticleGroup.StockControlYesNo]);
                        t.RemainderOrderYesNo = Convert.ToInt32(obj[ArticleGroup.RemainderOrderYesNo]);
                        t.RemainderPurchasingYesNo = Convert.ToInt32(obj[ArticleGroup.RemainderPurchasingYesNo]);
                        t.AutoConsumptionYesNo = Convert.ToInt32(obj[ArticleGroup.AutoConsumptionYesNo]);
                        t.AutoPriceVarianceYesNo = Convert.ToInt32(obj[ArticleGroup.AutoPriceVarianceYesNo]);
                        t.ParentMainGroupNo = Convert.ToInt32(obj[ArticleGroup.ParentMainGroupNo]);
                        t.FIFOYesNo = Convert.ToInt32(obj[ArticleGroup.FIFOYesNo]);
                        t.InActiveYesNo = Convert.ToInt32(obj[ArticleGroup.InActiveYesNo]);
                        t.LastUpdate = Convert.ToDateTime(obj[ArticleGroup.LastUpdate]);
                        t.LastUpdatedBy = Convert.ToInt32(obj[ArticleGroup.LastUpdatedBy]);
                        t.Created = Convert.ToDateTime(obj[ArticleGroup.Created]);
                        t.CreatedBy = Convert.ToInt32(obj[ArticleGroup.CreatedBy]);
                        t.ShowInShoppingCart = Convert.ToInt32(obj[ArticleGroup.ShowInShoppingCart]);
                        t.IsUpdated = true;
                        DB.vArticleGroupMains.Add(t);
                        DB.SaveChanges();
                    }
                    else
                    {
                        bool IsUpdated = false;
                        if (oldt.Name != obj[ArticleGroup.Name].ToString())
                        {
                            IsUpdated = true;
                            oldt.Name = obj[ArticleGroup.Name].ToString();
                        }
                        if (oldt.StockControlYesNo != Convert.ToInt32(obj[ArticleGroup.StockControlYesNo]))
                        {
                            IsUpdated = true;
                            oldt.StockControlYesNo = Convert.ToInt32(obj[ArticleGroup.StockControlYesNo]);
                        }
                        if (oldt.RemainderOrderYesNo != Convert.ToInt32(obj[ArticleGroup.RemainderOrderYesNo]))
                        {
                            IsUpdated = true;
                            oldt.RemainderOrderYesNo = Convert.ToInt32(obj[ArticleGroup.RemainderOrderYesNo]);
                        }
                        if (oldt.RemainderPurchasingYesNo != Convert.ToInt32(obj[ArticleGroup.RemainderPurchasingYesNo]))
                        {
                            IsUpdated = true;
                            oldt.RemainderPurchasingYesNo = Convert.ToInt32(obj[ArticleGroup.RemainderPurchasingYesNo]);
                        }
                        if (oldt.AutoConsumptionYesNo != Convert.ToInt32(obj[ArticleGroup.AutoConsumptionYesNo]))
                        {
                            IsUpdated = true;
                            oldt.AutoConsumptionYesNo = Convert.ToInt32(obj[ArticleGroup.AutoConsumptionYesNo]);
                        }
                        if (oldt.AutoPriceVarianceYesNo != Convert.ToInt32(obj[ArticleGroup.AutoPriceVarianceYesNo]))
                        {
                            IsUpdated = true;
                            oldt.AutoPriceVarianceYesNo = Convert.ToInt32(obj[ArticleGroup.AutoPriceVarianceYesNo]);
                        }
                        if (oldt.ParentMainGroupNo != Convert.ToInt32(obj[ArticleGroup.ParentMainGroupNo]))
                        {
                            IsUpdated = true;
                            oldt.ParentMainGroupNo = Convert.ToInt32(obj[ArticleGroup.ParentMainGroupNo]);
                        }
                        if (oldt.FIFOYesNo != Convert.ToInt32(obj[ArticleGroup.FIFOYesNo]))
                        {
                            IsUpdated = true;
                            oldt.FIFOYesNo = Convert.ToInt32(obj[ArticleGroup.FIFOYesNo]);
                        }
                        if (oldt.InActiveYesNo != Convert.ToInt32(obj[ArticleGroup.InActiveYesNo]))
                        {
                            IsUpdated = true;
                            oldt.InActiveYesNo = Convert.ToInt32(obj[ArticleGroup.InActiveYesNo]);
                        }
                        if (oldt.LastUpdate != Convert.ToDateTime(obj[ArticleGroup.LastUpdate]))
                        {
                            IsUpdated = true;
                            oldt.LastUpdate = Convert.ToDateTime(obj[ArticleGroup.LastUpdate]);
                        }
                        if (oldt.LastUpdatedBy != Convert.ToInt32(obj[ArticleGroup.LastUpdatedBy]))
                        {
                            IsUpdated = true;
                            oldt.LastUpdatedBy = Convert.ToInt32(obj[ArticleGroup.LastUpdatedBy]);
                        }
                        if (oldt.Created != Convert.ToDateTime(obj[ArticleGroup.Created]))
                        {
                            IsUpdated = true;
                            oldt.Created = Convert.ToDateTime(obj[ArticleGroup.Created]);
                        }
                        if (oldt.CreatedBy != Convert.ToInt32(obj[ArticleGroup.CreatedBy]))
                        {
                            IsUpdated = true;
                            oldt.CreatedBy = Convert.ToInt32(obj[ArticleGroup.CreatedBy]);
                        }
                        if (oldt.ShowInShoppingCart != Convert.ToInt32(obj[ArticleGroup.ShowInShoppingCart]))
                        {
                            IsUpdated = true;
                            oldt.ShowInShoppingCart = Convert.ToInt32(obj[ArticleGroup.ShowInShoppingCart]);
                        }
                        if (IsUpdated)
                        {
                            oldt.IsUpdated = IsUpdated;
                            DB.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }

    class ArticleSubGroups
    {
        private const string URL = Utilities.URL + "articlegroups/sub";
        private string urlParameters = "";
        public async Task GetArticleSubGroups()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(urlParameters).Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsAsync<JObject>();
                    if (!(json[ArticleSubGroup.ARRAY_ARTICLES_SUB_GROUP] is JArray)) return;
                    var col = (JArray)json[ArticleSubGroup.ARRAY_ARTICLES_SUB_GROUP];
                    foreach (JObject obj in col)
                    {
                        this.AddArticleSubGroup(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private void AddArticleSubGroup(JObject obj)
        {
            try
            {
                using (Admin.DBLayer.ICONEntities2 DB = new Admin.DBLayer.ICONEntities2())
                {
                    var SubGroupNo = Convert.ToInt32(obj[ArticleSubGroup.SubGroupNo]);
                    var oldt = DB.vArticleSubGroups.Where(u => u.SubGroupNo == SubGroupNo).FirstOrDefault();
                    if (oldt == null)
                    {
                        var t = new Admin.DBLayer.vArticleSubGroup();
                        t.SubGroupNo = SubGroupNo;
                        t.Name = Convert.ToString(obj[ArticleSubGroup.Name]);
                        t.IntermediateGroupNo = Convert.ToInt32(obj[ArticleSubGroup.IntermediateGroupNo]);
                        t.SortName = Convert.ToString(obj[ArticleSubGroup.SortName]);
                        t.InActiveYesNo = Convert.ToInt32(obj[ArticleSubGroup.InActiveYesNo]);
                        t.LastUpdate = Convert.ToDateTime(obj[ArticleSubGroup.LastUpdate]);
                        t.LastUpdatedBy = Convert.ToInt32(obj[ArticleSubGroup.LastUpdatedBy]);
                        t.Created = Convert.ToDateTime(obj[ArticleSubGroup.Created]);
                        t.CreatedBy = Convert.ToInt32(obj[ArticleSubGroup.CreatedBy]);
                        t.IsUpdated = true;
                        DB.vArticleSubGroups.Add(t);
                        DB.SaveChanges();
                    }
                    else
                    {
                        bool IsUpdated = false;
                        if (oldt.Name != obj[ArticleSubGroup.Name].ToString())
                        {
                            IsUpdated = true;
                            oldt.Name = obj[ArticleSubGroup.Name].ToString();
                        }
                        if (oldt.IntermediateGroupNo != Convert.ToInt32(obj[ArticleSubGroup.IntermediateGroupNo]))
                        {
                            IsUpdated = true;
                            oldt.IntermediateGroupNo = Convert.ToInt32(obj[ArticleSubGroup.IntermediateGroupNo]);
                        }
                        if (oldt.SortName != obj[ArticleSubGroup.SortName].ToString())
                        {
                            IsUpdated = true;
                            oldt.SortName = obj[ArticleSubGroup.SortName].ToString();
                        }
                        if (oldt.InActiveYesNo != Convert.ToInt32(obj[ArticleSubGroup.InActiveYesNo]))
                        {
                            IsUpdated = true;
                            oldt.InActiveYesNo = Convert.ToInt32(obj[ArticleSubGroup.InActiveYesNo]);
                        }
                        if (oldt.LastUpdate != Convert.ToDateTime(obj[ArticleSubGroup.LastUpdate]))
                        {
                            IsUpdated = true;
                            oldt.LastUpdate = Convert.ToDateTime(obj[ArticleSubGroup.LastUpdate]);
                        }
                        if (oldt.LastUpdatedBy != Convert.ToInt32(obj[ArticleSubGroup.LastUpdatedBy]))
                        {
                            IsUpdated = true;
                            oldt.LastUpdatedBy = Convert.ToInt32(obj[ArticleSubGroup.LastUpdatedBy]);
                        }
                        if (oldt.Created != Convert.ToDateTime(obj[ArticleSubGroup.Created]))
                        {
                            IsUpdated = true;
                            oldt.Created = Convert.ToDateTime(obj[ArticleSubGroup.Created]);
                        }
                        if (oldt.CreatedBy != Convert.ToInt32(obj[ArticleSubGroup.CreatedBy]))
                        {
                            IsUpdated = true;
                            oldt.CreatedBy = Convert.ToInt32(obj[ArticleSubGroup.CreatedBy]);
                        }
                        if (IsUpdated)
                        {
                            oldt.IsUpdated = IsUpdated;
                            DB.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }

    class ArticleIntermediateGroups
    {
        private const string URL = Utilities.URL + "articlegroups/middle";
        private string urlParameters = "";
        public async Task GetArticleIntermediateGroups()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(urlParameters).Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsAsync<JObject>();
                    if (!(json[ArticleIntermediateGroup.ARRAY_ARTICLES_SUB_GROUP] is JArray)) return;
                    var col = (JArray)json[ArticleIntermediateGroup.ARRAY_ARTICLES_SUB_GROUP];
                    foreach (JObject obj in col)
                    {
                        this.AddArticleIntermediateGroup(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private void AddArticleIntermediateGroup(JObject obj)
        {
            try
            {
                using (Admin.DBLayer.ICONEntities2 DB = new Admin.DBLayer.ICONEntities2())
                {
                    var IntermediateGroupNo = Convert.ToInt32(obj[ArticleIntermediateGroup.IntermediateGroupNo]);
                    var oldt = DB.vArticleIntermediateGroups.Where(u => u.IntermediateGroupNo == IntermediateGroupNo).FirstOrDefault();
                    if (oldt == null)
                    {
                        var t = new Admin.DBLayer.vArticleIntermediateGroup();
                        t.IntermediateGroupNo = IntermediateGroupNo;
                        t.Name = Convert.ToString(obj[ArticleIntermediateGroup.Name]);
                        t.MainGroupNo = Convert.ToInt32(obj[ArticleIntermediateGroup.MainGroupNo]);
                        t.SortName = Convert.ToString(obj[ArticleIntermediateGroup.SortName]);
                        t.InActiveYesNo = Convert.ToInt32(obj[ArticleIntermediateGroup.InActiveYesNo]);
                        t.LastUpdate = Convert.ToDateTime(obj[ArticleIntermediateGroup.LastUpdate]);
                        t.LastUpdatedBy = Convert.ToInt32(obj[ArticleIntermediateGroup.LastUpdatedBy]);
                        t.Created = Convert.ToDateTime(obj[ArticleIntermediateGroup.Created]);
                        t.CreatedBy = Convert.ToInt32(obj[ArticleIntermediateGroup.CreatedBy]);
                        t.IsUpdated = true;
                        DB.vArticleIntermediateGroups.Add(t);
                        DB.SaveChanges();
                    }
                    else
                    {
                        bool IsUpdated = false;
                        if (oldt.Name != obj[ArticleIntermediateGroup.Name].ToString())
                        {
                            IsUpdated = true;
                            oldt.Name = obj[ArticleIntermediateGroup.Name].ToString();
                        }
                        if (oldt.MainGroupNo != Convert.ToInt32(obj[ArticleIntermediateGroup.MainGroupNo]))
                        {
                            IsUpdated = true;
                            oldt.MainGroupNo = Convert.ToInt32(obj[ArticleIntermediateGroup.MainGroupNo]);
                        }
                        if (oldt.SortName != obj[ArticleIntermediateGroup.SortName].ToString())
                        {
                            IsUpdated = true;
                            oldt.SortName = obj[ArticleIntermediateGroup.SortName].ToString();
                        }
                        if (oldt.InActiveYesNo != Convert.ToInt32(obj[ArticleIntermediateGroup.InActiveYesNo]))
                        {
                            IsUpdated = true;
                            oldt.InActiveYesNo = Convert.ToInt32(obj[ArticleIntermediateGroup.InActiveYesNo]);
                        }
                        if (oldt.LastUpdate != Convert.ToDateTime(obj[ArticleIntermediateGroup.LastUpdate]))
                        {
                            IsUpdated = true;
                            oldt.LastUpdate = Convert.ToDateTime(obj[ArticleIntermediateGroup.LastUpdate]);
                        }
                        if (oldt.LastUpdatedBy != Convert.ToInt32(obj[ArticleIntermediateGroup.LastUpdatedBy]))
                        {
                            IsUpdated = true;
                            oldt.LastUpdatedBy = Convert.ToInt32(obj[ArticleIntermediateGroup.LastUpdatedBy]);
                        }
                        if (oldt.Created != Convert.ToDateTime(obj[ArticleIntermediateGroup.Created]))
                        {
                            IsUpdated = true;
                            oldt.Created = Convert.ToDateTime(obj[ArticleIntermediateGroup.Created]);
                        }
                        if (oldt.CreatedBy != Convert.ToInt32(obj[ArticleIntermediateGroup.CreatedBy]))
                        {
                            IsUpdated = true;
                            oldt.CreatedBy = Convert.ToInt32(obj[ArticleIntermediateGroup.CreatedBy]);
                        }
                        if (IsUpdated)
                        {
                            oldt.IsUpdated = IsUpdated;
                            DB.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
    public class ArticlesUnitTypes
    {
        private string urlParameters = "";
        public async Task GetArticlesUnitTypes()
        {
            try
            {
                using (Admin.DBLayer.ICONEntities2 DB = new Admin.DBLayer.ICONEntities2())
                {
                    var articles = DB.vArticles.ToList();
                    foreach (var article in articles)
                    {
                        if (!String.IsNullOrWhiteSpace(article.ArticleNo))
                        {
                            HttpClient client = new HttpClient();
                            var URL = Utilities.URL + "articles/" + article.ArticleNo + "/unittypes";
                            client.BaseAddress = new Uri(URL);
                            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                            HttpResponseMessage response = client.GetAsync(urlParameters).Result;
                            if (response.IsSuccessStatusCode)
                            {
                                var json = await response.Content.ReadAsAsync<JObject>();
                                if (json[ArticleUnitType.ARRAY_ARTICLES_UNITTYPES] is JArray)
                                {
                                    var col = (JArray)json[ArticleUnitType.ARRAY_ARTICLES_UNITTYPES];
                                    foreach (JObject obj in col)
                                        this.AddArticleUnitType(obj, article.ArticleNo);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void AddArticleUnitType(JObject obj, string ArticleNo)
        {
            try
            {
                using (Admin.DBLayer.ICONEntities2 DB = new Admin.DBLayer.ICONEntities2())
                {
                    var UnitTypeNo = Convert.ToInt32(obj[ArticleUnitType.UnitTypeNo]);
                    var oldt = DB.vArticleUnitTypes.Where(u => u.UnitTypeNo == UnitTypeNo).FirstOrDefault();
                    if (oldt == null)
                    {
                        var t = new Admin.DBLayer.vArticleUnitType();
                        t.ArticleNo = ArticleNo;
                        t.UnitTypeNo = UnitTypeNo;
                        t.Name = obj[ArticleUnitType.Name].ToString();
                        t.WareHouseNo = Convert.ToInt32(obj[ArticleUnitType.WareHouseNo]);
                        t.UnitNamePurchase = Convert.ToString(obj[ArticleUnitType.UnitNamePurchase]);
                        t.Factor = Convert.ToInt32(obj[ArticleUnitType.Factor]);
                        t.LastUpdate = Convert.ToDateTime(obj[ArticleUnitType.LastUpdate]);
                        t.LastUpdatedBy = Convert.ToInt32(obj[ArticleUnitType.LastUpdatedBy]);
                        t.ISOCode = Convert.ToString(obj[ArticleUnitType.ISOCode]);
                        t.Height = Convert.ToInt32(obj[ArticleUnitType.Height]);
                        t.VariableQtyYesNo = Convert.ToBoolean(obj[ArticleUnitType.VariableQtyYesNo]);
                        t.Width = Convert.ToInt32(obj[ArticleUnitType.Width]);
                        t.Length = Convert.ToInt32(obj[ArticleUnitType.Length]);
                        t.Volume = Convert.ToInt32(obj[ArticleUnitType.Volume]);
                        t.Rounding = Convert.ToInt32(obj[ArticleUnitType.Rounding]);
                        t.PriceListNo = Convert.ToInt32(obj[ArticleUnitType.PriceListNo]);
                        t.Comment = Convert.ToString(obj[ArticleUnitType.Comment]);
                        t.UnitInPurchase = Convert.ToInt32(obj[ArticleUnitType.UnitInPurchase]);
                        t.SplitPurchaseYesNo = Convert.ToInt32(obj[ArticleUnitType.SplitPurchaseYesNo]);
                        t.UnitInSales = Convert.ToInt32(obj[ArticleUnitType.UnitInSales]);
                        t.SplitSalesYesNo = Convert.ToBoolean(obj[ArticleUnitType.SplitSalesYesNo]);
                        t.FactorCalcMethod = Convert.ToInt32(obj[ArticleUnitType.FactorCalcMethod]);
                        t.Weight = Convert.ToInt32(obj[ArticleUnitType.Weight]);
                        t.UnitNo = Convert.ToInt32(obj[ArticleUnitType.UnitNo]);
                        t.PackingType = Convert.ToString(obj[ArticleUnitType.PackingType]);
                        t.ComparableUnitYesNo = Convert.ToBoolean(obj[ArticleUnitType.ComparableUnitYesNo]);
                        t.Location = Convert.ToString(obj[ArticleUnitType.Location]);
                        t.UnitInStockControl = Convert.ToInt32(obj[ArticleUnitType.UnitInStockControl]);
                        t.IsUpdated = true;
                        DB.vArticleUnitTypes.Add(t);
                        DB.SaveChanges();
                    }
                    else
                    {
                        bool IsUpdated = false;
                        if (oldt.Name != obj[ArticleUnitType.Name].ToString())
                        {
                            IsUpdated = true;
                            oldt.Name = obj[ArticleUnitType.Name].ToString();
                        }
                        if (oldt.WareHouseNo != Convert.ToInt32(obj[ArticleUnitType.WareHouseNo]))
                        {
                            IsUpdated = true;
                            oldt.WareHouseNo = Convert.ToInt32(obj[ArticleUnitType.WareHouseNo]);
                        }
                        if (oldt.UnitNamePurchase != Convert.ToString(obj[ArticleUnitType.UnitNamePurchase]))
                        {
                            IsUpdated = true;
                            oldt.UnitNamePurchase = Convert.ToString(obj[ArticleUnitType.UnitNamePurchase]);
                        }
                        if (oldt.Factor != Convert.ToInt32(obj[ArticleUnitType.Factor]))
                        {
                            IsUpdated = true;
                            oldt.Factor = Convert.ToInt32(obj[ArticleUnitType.Factor]);
                        }
                        if (oldt.LastUpdate != Convert.ToDateTime(obj[ArticleUnitType.LastUpdate]))
                        {
                            IsUpdated = true;
                            oldt.LastUpdate = Convert.ToDateTime(obj[ArticleUnitType.LastUpdate]);
                        }
                        if (oldt.LastUpdatedBy != Convert.ToInt32(obj[ArticleUnitType.LastUpdatedBy]))
                        {
                            IsUpdated = true;
                            oldt.LastUpdatedBy = Convert.ToInt32(obj[ArticleUnitType.LastUpdatedBy]);
                        }
                        if (oldt.ISOCode != Convert.ToString(obj[ArticleUnitType.ISOCode]))
                        {
                            IsUpdated = true;
                            oldt.ISOCode = Convert.ToString(obj[ArticleUnitType.ISOCode]);
                        }
                        if (oldt.Height != Convert.ToInt32(obj[ArticleUnitType.Height]))
                        {
                            IsUpdated = true;
                            oldt.Height = Convert.ToInt32(obj[ArticleUnitType.Height]);
                        }
                        if (oldt.VariableQtyYesNo != Convert.ToBoolean(obj[ArticleUnitType.VariableQtyYesNo]))
                        {
                            IsUpdated = true;
                            oldt.VariableQtyYesNo = Convert.ToBoolean(obj[ArticleUnitType.VariableQtyYesNo]);
                        }
                        if (oldt.Width != Convert.ToInt32(obj[ArticleUnitType.Width]))
                        {
                            IsUpdated = true;
                            oldt.Width = Convert.ToInt32(obj[ArticleUnitType.Width]);
                        }
                        if (oldt.Length != Convert.ToInt32(obj[ArticleUnitType.Length]))
                        {
                            IsUpdated = true;
                            oldt.Length = Convert.ToInt32(obj[ArticleUnitType.Length]);
                        }
                        if (oldt.Volume != Convert.ToInt32(obj[ArticleUnitType.Volume]))
                        {
                            IsUpdated = true;
                            oldt.Volume = Convert.ToInt32(obj[ArticleUnitType.Volume]);
                        }
                        if (oldt.Rounding != Convert.ToInt32(obj[ArticleUnitType.Rounding]))
                        {
                            IsUpdated = true;
                            oldt.Rounding = Convert.ToInt32(obj[ArticleUnitType.Rounding]);
                        }
                        if (oldt.PriceListNo != Convert.ToInt32(obj[ArticleUnitType.PriceListNo]))
                        {
                            IsUpdated = true;
                            oldt.PriceListNo = Convert.ToInt32(obj[ArticleUnitType.PriceListNo]);
                        }
                        if (oldt.Comment != Convert.ToString(obj[ArticleUnitType.Comment]))
                        {
                            IsUpdated = true;
                            oldt.Comment = Convert.ToString(obj[ArticleUnitType.Comment]);
                        }
                        if (oldt.UnitInPurchase != Convert.ToInt32(obj[ArticleUnitType.UnitInPurchase]))
                        {
                            IsUpdated = true;
                            oldt.UnitInPurchase = Convert.ToInt32(obj[ArticleUnitType.UnitInPurchase]);
                        }
                        if (oldt.SplitPurchaseYesNo != Convert.ToInt32(obj[ArticleUnitType.SplitPurchaseYesNo]))
                        {
                            IsUpdated = true;
                            oldt.SplitPurchaseYesNo = Convert.ToInt32(obj[ArticleUnitType.SplitPurchaseYesNo]);
                        }
                        if (oldt.UnitInSales != Convert.ToInt32(obj[ArticleUnitType.UnitInSales]))
                        {
                            IsUpdated = true;
                            oldt.UnitInSales = Convert.ToInt32(obj[ArticleUnitType.UnitInSales]);
                        }
                        if (oldt.SplitSalesYesNo != Convert.ToBoolean(obj[ArticleUnitType.SplitSalesYesNo]))
                        {
                            IsUpdated = true;
                            oldt.SplitSalesYesNo = Convert.ToBoolean(obj[ArticleUnitType.SplitSalesYesNo]);
                        }
                        if (oldt.FactorCalcMethod != Convert.ToInt32(obj[ArticleUnitType.FactorCalcMethod]))
                        {
                            IsUpdated = true;
                            oldt.FactorCalcMethod = Convert.ToInt32(obj[ArticleUnitType.FactorCalcMethod]);
                        }
                        if (oldt.Weight != Convert.ToInt32(obj[ArticleUnitType.Weight]))
                        {
                            IsUpdated = true;
                            oldt.Weight = Convert.ToInt32(obj[ArticleUnitType.Weight]);
                        }
                        if (oldt.UnitNo != Convert.ToInt32(obj[ArticleUnitType.UnitNo]))
                        {
                            IsUpdated = true;
                            oldt.UnitNo = Convert.ToInt32(obj[ArticleUnitType.UnitNo]);
                        }
                        if (oldt.PackingType != Convert.ToString(obj[ArticleUnitType.PackingType]))
                        {
                            IsUpdated = true;
                            oldt.PackingType = Convert.ToString(obj[ArticleUnitType.PackingType]);
                        }
                        if (oldt.ComparableUnitYesNo != Convert.ToBoolean(obj[ArticleUnitType.ComparableUnitYesNo]))
                        {
                            IsUpdated = true;
                            oldt.ComparableUnitYesNo = Convert.ToBoolean(obj[ArticleUnitType.ComparableUnitYesNo]);
                        }
                        if (oldt.Location != Convert.ToString(obj[ArticleUnitType.Location]))
                        {
                            IsUpdated = true;
                            oldt.Location = Convert.ToString(obj[ArticleUnitType.Location]);
                        }
                        if (oldt.UnitInStockControl != Convert.ToInt32(obj[ArticleUnitType.UnitInStockControl]))
                        {
                            IsUpdated = true;
                            oldt.UnitInStockControl = Convert.ToInt32(obj[ArticleUnitType.UnitInStockControl]);
                        }
                        if (IsUpdated)
                        {
                            oldt.IsUpdated = IsUpdated;
                            DB.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }

    public class ArticleCustomFields
    {
        private string urlParameters = "";
        public async Task GetArticlesCustomFields()
        {
            try
            {
                using (Admin.DBLayer.ICONEntities2 DB = new Admin.DBLayer.ICONEntities2())
                {
                    var articles = DB.vArticles.Where(u => u.LastUpdate > new DateTime(2015, 4, 18)).ToList();
                    foreach (var article in articles)
                    {
                        if (!String.IsNullOrWhiteSpace(article.ArticleNo))
                        {
                            HttpClient client = new HttpClient();
                            var URL = Utilities.URL + "articles/" + article.ArticleNo + "/customfields";
                            client.BaseAddress = new Uri(URL);
                            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                            HttpResponseMessage response = client.GetAsync(urlParameters).Result;
                            if (response.IsSuccessStatusCode)
                            {
                                var json = await response.Content.ReadAsAsync<JObject>();
                                if (json[ArticleCustomField.ARRAY_ARTICLES_CUSTOMFIELD] is JObject)
                                {
                                    var obj = (JObject)json[ArticleCustomField.ARRAY_ARTICLES_CUSTOMFIELD];
                                    this.AddArticleCustomField(obj, article.ArticleNo);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void AddArticleCustomField(JObject obj, string ArticleNo)
        {
            try
            {
                using (Admin.DBLayer.ICONEntities2 DB = new Admin.DBLayer.ICONEntities2())
                {
                    var oldt = DB.vArticleCustomFields.Where(u => u.ArticleNo == ArticleNo).FirstOrDefault();
                    if (oldt == null)
                    {
                        var t = new Admin.DBLayer.vArticleCustomField();
                        t.ArticleNo = ArticleNo;
                        t.Factor = Convert.ToInt32(obj[ArticleCustomField.Factor]);
                        t.FactorCalcMethod = Convert.ToInt32(obj[ArticleCustomField.FactorCalcMethod]);
                        t.NetPrice = Convert.ToDecimal(obj[ArticleCustomField.NetPrice]);
                        t.Available = Convert.ToInt32(obj[ArticleCustomField.Available]);
                        t.ContributionCurrentPeriod = Convert.ToInt32(obj[ArticleCustomField.ContributionCurrentPeriod]);
                        t.ContributionYear = Convert.ToInt32(obj[ArticleCustomField.ContributionYear]);
                        t.ContributionPercent = Convert.ToInt32(obj[ArticleCustomField.ContributionPercent]);
                        t.ProjectNo = Convert.ToInt32(obj[ArticleCustomField.ProjectNo]);
                        t.CurrencyCode = Convert.ToString(obj[ArticleCustomField.CurrencyCode]);
                        t.AgreedPrice = Convert.ToDecimal(obj[ArticleCustomField.AgreedPrice]);
                        t.Discount = Convert.ToInt32(obj[ArticleCustomField.Discount]);
                        t.PriceType = Convert.ToString(obj[ArticleCustomField.PriceType]);
                        t.FirstDate = Convert.ToString(obj[ArticleCustomField.FirstDate]);
                        t.LastDate = Convert.ToString(obj[ArticleCustomField.LastDate]);
                        t.DiscountI = Convert.ToInt32(obj[ArticleCustomField.DiscountI]);
                        t.DiscountII = Convert.ToInt32(obj[ArticleCustomField.DiscountII]);
                        t.DiscountIII = Convert.ToInt32(obj[ArticleCustomField.DiscountIII]);
                        t.Price1FromDate = Convert.ToDateTime(obj[ArticleCustomField.Price1FromDate]);
                        t.SupplPriceFromDate = Convert.ToDateTime(obj[ArticleCustomField.SupplPriceFromDate]);
                        t.FullCostFromDate = Convert.ToDateTime(obj[ArticleCustomField.FullCostFromDate]);
                        t.PriceCalcDate = Convert.ToDateTime(obj[ArticleCustomField.PriceCalcDate]);
                        t.InActiveStatus = Convert.ToString(obj[ArticleCustomField.InActiveStatus]);
                        t.PriceTimesPurchUnit = Convert.ToDecimal(obj[ArticleCustomField.PriceTimesPurchUnit]);
                        t.ErrorCode = Convert.ToInt32(obj[ArticleCustomField.ErrorCode]);
                        t.UpdateStock = Convert.ToInt32(obj[ArticleCustomField.UpdateStock]);
                        t.LastMovementDate = Convert.ToDateTime(obj[ArticleCustomField.LastMovementDate]);
                        t.AutoConsumptionYesNo = Convert.ToInt32(obj[ArticleCustomField.AutoConsumptionYesNo]);
                        t.WeightedPurchasePriceYesNo = Convert.ToInt32(obj[ArticleCustomField.WeightedPurchasePriceYesNo]);
                        t.ExchangePrice = Convert.ToDecimal(obj[ArticleCustomField.ExchangePrice]);
                        t.CurrencyNo = Convert.ToString(obj[ArticleCustomField.CurrencyNo]);
                        t.TemplateArticle = Convert.ToString(obj[ArticleCustomField.TemplateArticle]);
                        t.Quantity = Convert.ToInt32(obj[ArticleCustomField.Quantity]);
                        t.ComparableUnitPrice = Convert.ToDecimal(obj[ArticleCustomField.ComparableUnitPrice]);
                        t.ComparableUnitType = Convert.ToString(obj[ArticleCustomField.ComparableUnitType]);
                        t.ContributionInCurrency = Convert.ToInt32(obj[ArticleCustomField.ContributionInCurrency]);
                        t.ColorMark = Convert.ToInt32(obj[ArticleCustomField.ColorMark]);
                        t.IsUpdated = true;
                        DB.vArticleCustomFields.Add(t);
                        DB.SaveChanges();
                    }
                    else
                    {
                        bool IsUpdated = false;
                        if (oldt.Factor != Convert.ToInt32(obj[ArticleCustomField.Factor]))
                        {
                            IsUpdated = true;
                            oldt.Factor = Convert.ToInt32(obj[ArticleCustomField.Factor]);
                        }
                        if (oldt.FactorCalcMethod != Convert.ToInt32(obj[ArticleCustomField.FactorCalcMethod]))
                        {
                            IsUpdated = true;
                            oldt.FactorCalcMethod = Convert.ToInt32(obj[ArticleCustomField.FactorCalcMethod]);
                        }
                        if (oldt.NetPrice != Convert.ToDecimal(obj[ArticleCustomField.NetPrice]))
                        {
                            IsUpdated = true;
                            oldt.NetPrice = Convert.ToDecimal(obj[ArticleCustomField.NetPrice]);
                        }
                        if (oldt.Available != Convert.ToInt32(obj[ArticleCustomField.Available]))
                        {
                            IsUpdated = true;
                            oldt.Available = Convert.ToInt32(obj[ArticleCustomField.Available]);
                        }
                        if (oldt.ContributionCurrentPeriod != Convert.ToInt32(obj[ArticleCustomField.ContributionCurrentPeriod]))
                        {
                            IsUpdated = true;
                            oldt.ContributionCurrentPeriod = Convert.ToInt32(obj[ArticleCustomField.ContributionCurrentPeriod]);
                        }
                        if (oldt.ContributionYear != Convert.ToInt32(obj[ArticleCustomField.ContributionYear]))
                        {
                            IsUpdated = true;
                            oldt.ContributionYear = Convert.ToInt32(obj[ArticleCustomField.ContributionYear]);
                        }
                        if (oldt.ContributionPercent != Convert.ToInt32(obj[ArticleCustomField.ContributionPercent]))
                        {
                            IsUpdated = true;
                            oldt.ContributionPercent = Convert.ToInt32(obj[ArticleCustomField.ContributionPercent]);
                        }
                        if (oldt.ProjectNo != Convert.ToInt32(obj[ArticleCustomField.ProjectNo]))
                        {
                            IsUpdated = true;
                            oldt.ProjectNo = Convert.ToInt32(obj[ArticleCustomField.ProjectNo]);
                        }
                        if (oldt.CurrencyCode != Convert.ToString(obj[ArticleCustomField.CurrencyCode]))
                        {
                            IsUpdated = true;
                            oldt.CurrencyCode = Convert.ToString(obj[ArticleCustomField.CurrencyCode]);
                        }
                        if (oldt.AgreedPrice != Convert.ToDecimal(obj[ArticleCustomField.AgreedPrice]))
                        {
                            IsUpdated = true;
                            oldt.AgreedPrice = Convert.ToDecimal(obj[ArticleCustomField.AgreedPrice]);
                        }
                        if (oldt.Discount != Convert.ToInt32(obj[ArticleCustomField.Discount]))
                        {
                            IsUpdated = true;
                            oldt.Discount = Convert.ToInt32(obj[ArticleCustomField.Discount]);
                        }
                        if (oldt.PriceType != Convert.ToString(obj[ArticleCustomField.PriceType]))
                        {
                            IsUpdated = true;
                            oldt.PriceType = Convert.ToString(obj[ArticleCustomField.PriceType]);
                        }
                        if (oldt.FirstDate != Convert.ToString(obj[ArticleCustomField.FirstDate]))
                        {
                            IsUpdated = true;
                            oldt.FirstDate = Convert.ToString(obj[ArticleCustomField.FirstDate]);
                        }
                        if (oldt.LastDate != Convert.ToString(obj[ArticleCustomField.LastDate]))
                        {
                            IsUpdated = true;
                            oldt.LastDate = Convert.ToString(obj[ArticleCustomField.LastDate]);
                        }
                        if (oldt.DiscountI != Convert.ToInt32(obj[ArticleCustomField.DiscountI]))
                        {
                            IsUpdated = true;
                            oldt.DiscountI = Convert.ToInt32(obj[ArticleCustomField.DiscountI]);
                        }
                        if (oldt.DiscountII != Convert.ToInt32(obj[ArticleCustomField.DiscountII]))
                        {
                            IsUpdated = true;
                            oldt.DiscountII = Convert.ToInt32(obj[ArticleCustomField.DiscountII]);
                        }
                        if (oldt.DiscountIII != Convert.ToInt32(obj[ArticleCustomField.DiscountIII]))
                        {
                            IsUpdated = true;
                            oldt.DiscountIII = Convert.ToInt32(obj[ArticleCustomField.DiscountIII]);
                        }
                        if (oldt.Price1FromDate != Convert.ToDateTime(obj[ArticleCustomField.Price1FromDate]))
                        {
                            IsUpdated = true;
                            oldt.Price1FromDate = Convert.ToDateTime(obj[ArticleCustomField.Price1FromDate]);
                        }
                        if (oldt.SupplPriceFromDate != Convert.ToDateTime(obj[ArticleCustomField.SupplPriceFromDate]))
                        {
                            IsUpdated = true;
                            oldt.SupplPriceFromDate = Convert.ToDateTime(obj[ArticleCustomField.SupplPriceFromDate]);
                        }
                        if (oldt.FullCostFromDate != Convert.ToDateTime(obj[ArticleCustomField.FullCostFromDate]))
                        {
                            IsUpdated = true;
                            oldt.FullCostFromDate = Convert.ToDateTime(obj[ArticleCustomField.FullCostFromDate]);
                        }
                        if (oldt.PriceCalcDate != Convert.ToDateTime(obj[ArticleCustomField.PriceCalcDate]))
                        {
                            IsUpdated = true;
                            oldt.PriceCalcDate = Convert.ToDateTime(obj[ArticleCustomField.PriceCalcDate]);
                        }
                        if (oldt.InActiveStatus != Convert.ToString(obj[ArticleCustomField.InActiveStatus]))
                        {
                            IsUpdated = true;
                            oldt.InActiveStatus = Convert.ToString(obj[ArticleCustomField.InActiveStatus]);
                        }
                        if (oldt.PriceTimesPurchUnit != Convert.ToDecimal(obj[ArticleCustomField.PriceTimesPurchUnit]))
                        {
                            IsUpdated = true;
                            oldt.PriceTimesPurchUnit = Convert.ToDecimal(obj[ArticleCustomField.PriceTimesPurchUnit]);
                        }
                        if (oldt.ErrorCode != Convert.ToInt32(obj[ArticleCustomField.ErrorCode]))
                        {
                            IsUpdated = true;
                            oldt.ErrorCode = Convert.ToInt32(obj[ArticleCustomField.ErrorCode]);
                        }
                        if (oldt.UpdateStock != Convert.ToInt32(obj[ArticleCustomField.UpdateStock]))
                        {
                            IsUpdated = true;
                            oldt.UpdateStock = Convert.ToInt32(obj[ArticleCustomField.UpdateStock]);
                        }
                        if (oldt.LastMovementDate != Convert.ToDateTime(obj[ArticleCustomField.LastMovementDate]))
                        {
                            IsUpdated = true;
                            oldt.LastMovementDate = Convert.ToDateTime(obj[ArticleCustomField.LastMovementDate]);
                        }
                        if (oldt.AutoConsumptionYesNo != Convert.ToInt32(obj[ArticleCustomField.AutoConsumptionYesNo]))
                        {
                            IsUpdated = true;
                            oldt.AutoConsumptionYesNo = Convert.ToInt32(obj[ArticleCustomField.AutoConsumptionYesNo]);
                        }
                        if (oldt.WeightedPurchasePriceYesNo != Convert.ToInt32(obj[ArticleCustomField.WeightedPurchasePriceYesNo]))
                        {
                            IsUpdated = true;
                            oldt.WeightedPurchasePriceYesNo = Convert.ToInt32(obj[ArticleCustomField.WeightedPurchasePriceYesNo]);
                        }
                        if (oldt.ExchangePrice != Convert.ToInt32(obj[ArticleCustomField.ExchangePrice]))
                        {
                            IsUpdated = true;
                            oldt.ExchangePrice = Convert.ToInt32(obj[ArticleCustomField.ExchangePrice]);
                        }
                        if (oldt.CurrencyNo != Convert.ToString(obj[ArticleCustomField.CurrencyNo]))
                        {
                            IsUpdated = true;
                            oldt.CurrencyNo = Convert.ToString(obj[ArticleCustomField.CurrencyNo]);
                        }
                        if (oldt.TemplateArticle != Convert.ToString(obj[ArticleCustomField.TemplateArticle]))
                        {
                            IsUpdated = true;
                            oldt.TemplateArticle = Convert.ToString(obj[ArticleCustomField.TemplateArticle]);
                        }
                        if (oldt.Quantity != Convert.ToInt32(obj[ArticleCustomField.Quantity]))
                        {
                            IsUpdated = true;
                            oldt.Quantity = Convert.ToInt32(obj[ArticleCustomField.Quantity]);
                        }
                        if (oldt.ComparableUnitPrice != Convert.ToDecimal(obj[ArticleCustomField.ComparableUnitPrice]))
                        {
                            IsUpdated = true;
                            oldt.ComparableUnitPrice = Convert.ToDecimal(obj[ArticleCustomField.ComparableUnitPrice]);
                        }
                        if (oldt.ComparableUnitType != Convert.ToString(obj[ArticleCustomField.ComparableUnitType]))
                        {
                            IsUpdated = true;
                            oldt.ComparableUnitType = Convert.ToString(obj[ArticleCustomField.ComparableUnitType]);
                        }
                        if (oldt.ContributionInCurrency != Convert.ToInt32(obj[ArticleCustomField.ContributionInCurrency]))
                        {
                            IsUpdated = true;
                            oldt.ContributionInCurrency = Convert.ToInt32(obj[ArticleCustomField.ContributionInCurrency]);
                        }
                        if (oldt.ColorMark != Convert.ToInt32(obj[ArticleCustomField.ColorMark]))
                        {
                            IsUpdated = true;
                            oldt.ColorMark = Convert.ToInt32(obj[ArticleCustomField.ColorMark]);
                        }
                        if (IsUpdated)
                        {
                            oldt.IsUpdated = IsUpdated;
                            DB.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }

    public class ArticleStockInfoes
    {
        private string urlParameters = "";
        public async Task GetArticlesStockInfo()
        {
            try
            {
                using (Admin.DBLayer.ICONEntities2 DB = new Admin.DBLayer.ICONEntities2())
                {
                    var articles = DB.vArticles.Where(u => u.LastUpdate > new DateTime(2015,4,18)).ToList();
                    foreach (var article in articles)
                    {
                        if (!String.IsNullOrWhiteSpace(article.ArticleNo))
                        {
                            HttpClient client = new HttpClient();
                            var URL = Utilities.URL + "articles/" + article.ArticleNo + "/stockinfo";
                            client.BaseAddress = new Uri(URL);
                            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                            HttpResponseMessage response = client.GetAsync(urlParameters).Result;
                            if (response.IsSuccessStatusCode)
                            {
                                JObject json = await response.Content.ReadAsAsync<JObject>();
                                if (json != null)
                                {
                                    this.AddArticleStockInfo(json, article.ArticleNo);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void AddArticleStockInfo(JObject obj, string ArticleNo)
        {
            try
            {
                using (Admin.DBLayer.ICONEntities2 DB = new Admin.DBLayer.ICONEntities2())
                {
                    var oldt = DB.vArticleStockInfoes.Where(u => u.ArticleNo == ArticleNo).FirstOrDefault();
                    if (oldt == null)
                    {
                        var t = new Admin.DBLayer.vArticleStockInfo();
                        t.ArticleNo = ArticleNo;
                        t.WareHouseNo = Convert.ToInt32(obj[ArticleStockInfo.WareHouseNo]);
                        t.ArticleNo= Convert.ToString(obj[ArticleStockInfo.               ArticleNo]);
                        t.Location= Convert.ToString(obj[ArticleStockInfo.                Location]);
                        t.CountedUnit= Convert.ToInt32(obj[ArticleStockInfo.              CountedUnit]);
                        t.LotNo= Convert.ToInt32(obj[ArticleStockInfo.                    LotNo]);
                        t.UnitOnPurchase= Convert.ToInt32(obj[ArticleStockInfo.           UnitOnPurchase]);
                        t.MaxStock= Convert.ToInt32(obj[ArticleStockInfo.                 MaxStock]);
                        t.MinStock= Convert.ToInt32(obj[ArticleStockInfo.                 MinStock]);
                        t.UnitInStock= Convert.ToInt32(obj[ArticleStockInfo.              UnitInStock]);
                        t.UnitOnOrder= Convert.ToInt32(obj[ArticleStockInfo.              UnitOnOrder]);
                        t.UnitOnReminder= Convert.ToInt32(obj[ArticleStockInfo.           UnitOnReminder]);
                        t.LastMovementDate= Convert.ToDateTime(obj[ArticleStockInfo.      LastMovementDate]);
                        t.UnitPacked= Convert.ToInt32(obj[ArticleStockInfo.               UnitPacked]);
                        t.CountedYesNo= Convert.ToInt32(obj[ArticleStockInfo.             CountedYesNo]);
                        t.UnitOnLoan= Convert.ToInt32(obj[ArticleStockInfo.               UnitOnLoan]);
                        t.LastUpdate= Convert.ToDateTime(obj[ArticleStockInfo.            LastUpdate]);
                        t.LastUpdatedBy= Convert.ToInt32(obj[ArticleStockInfo.            LastUpdatedBy]);
                        t.QtyManualReserved= Convert.ToInt32(obj[ArticleStockInfo.        QtyManualReserved]);
                        t.QtyReserved= Convert.ToInt32(obj[ArticleStockInfo.              QtyReserved]);
                        t.LastStockCountDate= Convert.ToDateTime(obj[ArticleStockInfo.LastStockCountDate]);

                        t.IsUpdated = true;
                        DB.vArticleStockInfoes.Add(t);
                        DB.SaveChanges();
                    }
                    else
                    {
                        bool IsUpdated = false;
                        if (oldt.WareHouseNo != Convert.ToInt32(obj[ArticleStockInfo.WareHouseNo]))
                        {
                            IsUpdated = true;
                            oldt.WareHouseNo = Convert.ToInt32(obj[ArticleStockInfo.WareHouseNo]);
                        }
                        if (oldt.Location != Convert.ToString(obj[ArticleStockInfo.Location]))
                        {
                            IsUpdated = true;
                            oldt.Location = Convert.ToString(obj[ArticleStockInfo.Location]);
                        }
                        if (oldt.CountedUnit != Convert.ToInt32(obj[ArticleStockInfo.CountedUnit]))
                        {
                            IsUpdated = true;
                            oldt.CountedUnit = Convert.ToInt32(obj[ArticleStockInfo.CountedUnit]);
                        }
                        if (oldt.LotNo != Convert.ToInt32(obj[ArticleStockInfo.LotNo]))
                        {
                            IsUpdated = true;
                            oldt.LotNo = Convert.ToInt32(obj[ArticleStockInfo.LotNo]);
                        }
                        if (oldt.UnitOnPurchase != Convert.ToInt32(obj[ArticleStockInfo.UnitOnPurchase]))
                        {
                            IsUpdated = true;
                            oldt.UnitOnPurchase = Convert.ToInt32(obj[ArticleStockInfo.UnitOnPurchase]);
                        }
                        if (oldt.MaxStock != Convert.ToInt32(obj[ArticleStockInfo.MaxStock]))
                        {
                            IsUpdated = true;
                            oldt.MaxStock = Convert.ToInt32(obj[ArticleStockInfo.MaxStock]);
                        }
                        if (oldt.MinStock != Convert.ToInt32(obj[ArticleStockInfo.MinStock]))
                        {
                            IsUpdated = true;
                            oldt.MinStock = Convert.ToInt32(obj[ArticleStockInfo.MinStock]);
                        }
                        if (oldt.UnitInStock != Convert.ToInt32(obj[ArticleStockInfo.UnitInStock]))
                        {
                            IsUpdated = true;
                            oldt.UnitInStock = Convert.ToInt32(obj[ArticleStockInfo.UnitInStock]);
                        }
                        if (oldt.UnitOnOrder != Convert.ToInt32(obj[ArticleStockInfo.UnitOnOrder]))
                        {
                            IsUpdated = true;
                            oldt.UnitOnOrder = Convert.ToInt32(obj[ArticleStockInfo.UnitOnOrder]);
                        }
                        if (oldt.UnitOnReminder != Convert.ToInt32(obj[ArticleStockInfo.UnitOnReminder]))
                        {
                            IsUpdated = true;
                            oldt.UnitOnReminder = Convert.ToInt32(obj[ArticleStockInfo.UnitOnReminder]);
                        }
                        if (oldt.LastMovementDate != Convert.ToDateTime(obj[ArticleStockInfo.LastMovementDate]))
                        {
                            IsUpdated = true;
                            oldt.LastMovementDate = Convert.ToDateTime(obj[ArticleStockInfo.LastMovementDate]);
                        }
                        if (oldt.UnitPacked != Convert.ToInt32(obj[ArticleStockInfo.UnitPacked]))
                        {
                            IsUpdated = true;
                            oldt.UnitPacked = Convert.ToInt32(obj[ArticleStockInfo.UnitPacked]);
                        }
                        if (oldt.CountedYesNo != Convert.ToInt32(obj[ArticleStockInfo.CountedYesNo]))
                        {
                            IsUpdated = true;
                            oldt.CountedYesNo = Convert.ToInt32(obj[ArticleStockInfo.CountedYesNo]);
                        }
                        if (oldt.UnitOnLoan != Convert.ToInt32(obj[ArticleStockInfo.UnitOnLoan]))
                        {
                            IsUpdated = true;
                            oldt.UnitOnLoan = Convert.ToInt32(obj[ArticleStockInfo.UnitOnLoan]);
                        }
                        if (oldt.LastUpdate != Convert.ToDateTime(obj[ArticleStockInfo.LastUpdate]))
                        {
                            IsUpdated = true;
                            oldt.LastUpdate = Convert.ToDateTime(obj[ArticleStockInfo.LastUpdate]);
                        }
                        if (oldt.LastUpdatedBy != Convert.ToInt32(obj[ArticleStockInfo.LastUpdatedBy]))
                        {
                            IsUpdated = true;
                            oldt.LastUpdatedBy = Convert.ToInt32(obj[ArticleStockInfo.LastUpdatedBy]);
                        }
                        if (oldt.QtyManualReserved != Convert.ToInt32(obj[ArticleStockInfo.QtyManualReserved]))
                        {
                            IsUpdated = true;
                            oldt.QtyManualReserved = Convert.ToInt32(obj[ArticleStockInfo.QtyManualReserved]);
                        }
                        if (oldt.QtyReserved != Convert.ToInt32(obj[ArticleStockInfo.QtyReserved]))
                        {
                            IsUpdated = true;
                            oldt.QtyReserved = Convert.ToInt32(obj[ArticleStockInfo.QtyReserved]);
                        }
                        if (oldt.LastStockCountDate != Convert.ToDateTime(obj[ArticleStockInfo.LastStockCountDate]))
                        {
                            IsUpdated = true;
                            oldt.LastStockCountDate = Convert.ToDateTime(obj[ArticleStockInfo.LastStockCountDate]);
                        }
                        if (IsUpdated)
                        {
                            oldt.IsUpdated = IsUpdated;
                            DB.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
