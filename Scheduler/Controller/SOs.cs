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

namespace Scheduler.Controller
{
    class SOs
    {
        private const string URL = Utilities.URL + "SalesOrders";
        private string urlParameters = "";
        public async Task GetSOes()
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
                    if (!(json[SO.ARRAY_ORDERS] is JArray)) return;
                    var col = (JArray)json[SO.ARRAY_ORDERS];
                    foreach (JObject obj in col)
                    {
                        this.AddSO(obj);
                        if (obj[Lines.ARRAY_LINES] is JArray)
                        {
                            var colLines = (JArray)obj[Lines.ARRAY_LINES];
                            foreach (JObject objLine in colLines)
                            {
                                this.AddLine(objLine, obj[SO.OrderNo]);
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
        private void AddSO(JObject obj)
        {
            try
            {
                using (Admin.DBLayer.ICONEntities2 DB = new Admin.DBLayer.ICONEntities2())
                {
                    var t = new Admin.DBLayer.vSO();
                    t.OrderNo = Convert.ToString(obj[SO.OrderNo]);
                    t.CustomerName = Convert.ToString(obj[SO.CustomerName]);
                    t.ContactNoInvoice = Convert.ToInt32(obj[SO.ContactNoInvoice]);
                    t.OrderDate = Convert.ToDateTime(obj[SO.OrderDate]);
                    t.DeliveryDate = Convert.ToDateTime(obj[SO.DeliveryDate]);
                    t.TotalAmount = Convert.ToInt32(obj[SO.TotalAmount]);
                    t.OurRef = Convert.ToString(obj[SO.OurRef]);
                    t.CustomerGrpNo = Convert.ToInt32(obj[SO.CustomerGrpNo]);
                    t.DepNo = Convert.ToInt32(obj[SO.DepNo]);
                    t.ProjectNo = Convert.ToInt32(obj[SO.ProjectNo]);
                    t.VATCode = Convert.ToInt32(obj[SO.VATCode]);
                    t.CurrencyNo = Convert.ToInt32(obj[SO.CurrencyNo]);
                    t.InvoicePostOffice = Convert.ToString(obj[SO.InvoicePostOffice]);
                    t.InvoiceAddress1 = Convert.ToString(obj[SO.InvoiceAddress1]);
                    t.DeliveryPostOffice = Convert.ToString(obj[SO.DeliveryPostOffice]);
                    t.InvoicePostCode = Convert.ToString(obj[SO.InvoicePostCode]);
                    t.CustomerNo = Convert.ToInt32(obj[SO.CustomerNo]);
                    t.DeliveryCountryNo = Convert.ToInt32(obj[SO.DeliveryCountryNo]);
                    t.EmployeeNo = Convert.ToInt32(obj[SO.EmployeeNo]);
                    t.DeliveryAddress1 = Convert.ToString(obj[SO.DeliveryAddress1]);
                    t.DueDate = Convert.ToDateTime(obj[SO.DueDate]);
                    t.OrderStatus = Convert.ToInt32(obj[SO.OrderStatus]);
                    t.CompanyNo = Convert.ToString(obj[SO.CompanyNo]);
                    t.TotalWeight = Convert.ToInt32(obj[SO.TotalWeight]);
                    t.TotalVAT = Convert.ToInt32(obj[SO.TotalVAT]);
                    t.DeliveryPostCode = Convert.ToString(obj[SO.DeliveryPostCode]);
                    t.ExchangeAmount = Convert.ToInt32(obj[SO.ExchangeAmount]);
                    t.ExchangeRate = Convert.ToInt32(obj[SO.ExchangeRate]);
                    t.PurchaseNo = Convert.ToInt32(obj[SO.PurchaseNo]);
                    t.ProductNo = Convert.ToInt32(obj[SO.ProductNo]);
                    t.ContactNoDelivery = Convert.ToInt32(obj[SO.ContactNoDelivery]);
                    t.InvoiceAddress2 = Convert.ToString(obj[SO.InvoiceAddress2]);
                    t.DeliveryAddress2 = Convert.ToString(obj[SO.DeliveryAddress2]);
                    t.FactNo = Convert.ToInt32(obj[SO.FactNo]);
                    t.TotalWeightDelivered = Convert.ToInt32(obj[SO.TotalWeightDelivered]);
                    t.FactCustomerNo = Convert.ToString(obj[SO.FactCustomerNo]);
                    t.OriginalOrderNo = Convert.ToString(obj[SO.OriginalOrderNo]);
                    t.AgreedAmount = Convert.ToInt32(obj[SO.AgreedAmount]);
                    t.TermsOfDeliveryNo = Convert.ToInt32(obj[SO.TermsOfDeliveryNo]);
                    t.PaymentTypeNo = Convert.ToInt32(obj[SO.PaymentTypeNo]);
                    t.TermsOfPayCustNo = Convert.ToInt32(obj[SO.TermsOfPayCustNo]);
                    t.CashPaymentYesNo = Convert.ToBoolean(obj[SO.CashPaymentYesNo]);
                    t.InvoiceEmailAddress = Convert.ToString(obj[SO.InvoiceEmailAddress]);
                    t.YourReference = Convert.ToString(obj[SO.YourReference]);
                    t.HandlingCharge = Convert.ToInt32(obj[SO.HandlingCharge]);
                    t.Postage = Convert.ToInt32(obj[SO.Postage]);
                    t.FreightcostPer = Convert.ToInt32(obj[SO.FreightcostPer]);
                    t.DeliveryMethodsNo = Convert.ToInt32(obj[SO.DeliveryMethodsNo]);
                    t.OrderType = Convert.ToInt32(obj[SO.OrderType]);
                    t.IsUpdated = true;
                    DB.vSOes.Add(t);
                    DB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void AddLine(JObject obj, JToken OrderNo)
        {
            try
            {
                using (Admin.DBLayer.ICONEntities2 DB = new Admin.DBLayer.ICONEntities2())
                {
                    var t = new Admin.DBLayer.vSOLine();
                    t.OrderNo = Convert.ToString(OrderNo);
                    t.AltArtNo = Convert.ToString(obj[SOLines.AltArtNo]);
                    t.OrderStatus = Convert.ToInt32(obj[SOLines.OrderStatus]);
                    t.DepNo = Convert.ToInt32(obj[SOLines.DepNo]);
                    t.EANNo = Convert.ToString(obj[SOLines.EANNo]);
                    t.OrderDate = Convert.ToDateTime(obj[SOLines.OrderDate]);
                    t.PLUNo = Convert.ToString(obj[SOLines.PLUNo]);
                    t.PostingTemplateNo = Convert.ToInt32(obj[SOLines.PostingTemplateNo]);
                    t.PurchasePrice = Convert.ToInt32(obj[SOLines.PurchasePrice]);
                    t.TotalDelivered = Convert.ToInt32(obj[SOLines.TotalDelivered]);
                    t.Amount = Convert.ToInt32(obj[SOLines.Amount]);
                    t.ArticleNo = Convert.ToString(obj[SOLines.ArticleNo]);
                    t.CurrencyNo = Convert.ToInt32(obj[SOLines.CurrencyNo]);
                    t.DeliveryDate = Convert.ToDateTime(obj[SOLines.DeliveryDate]);
                    t.DiscountI = Convert.ToInt32(obj[SOLines.DiscountI]);
                    t.DiscountII = Convert.ToInt32(obj[SOLines.DiscountII]);
                    t.DistributionFormulaNo = Convert.ToInt32(obj[SOLines.DistributionFormulaNo]);
                    t.EmployeeNo = Convert.ToInt32(obj[SOLines.EmployeeNo]);
                    t.ExchangeAmount = Convert.ToInt32(obj[SOLines.ExchangeAmount]);
                    t.ExchangeRate = Convert.ToInt32(obj[SOLines.ExchangeRate]);
                    t.ExchangeSalesPrice = Convert.ToInt32(obj[SOLines.ExchangeSalesPrice]);
                    t.FullCost = Convert.ToInt32(obj[SOLines.FullCost]);
                    t.GLSalesAccountNo = Convert.ToInt32(obj[SOLines.GLSalesAccountNo]);
                    t.GrossPrice = Convert.ToInt32(obj[SOLines.GrossPrice]);
                    t.IntermediateGroupNo = Convert.ToInt32(obj[SOLines.IntermediateGroupNo]);
                    t.Invoiced = Convert.ToInt32(obj[SOLines.Invoiced]);
                    t.MainGroupNo = Convert.ToInt32(obj[SOLines.MainGroupNo]);
                    t.Name = Convert.ToString(obj[SOLines.Name]);
                    t.NetDeliveryAmount = Convert.ToInt32(obj[SOLines.NetDeliveryAmount]);
                    t.NetPrice = Convert.ToInt32(obj[SOLines.NetPrice]);
                    t.ProductNo = Convert.ToInt32(obj[SOLines.ProductNo]);
                    t.ProjectNo = Convert.ToInt32(obj[SOLines.ProjectNo]);
                    t.Quantity = Convert.ToInt32(obj[SOLines.Quantity]);
                    t.Remainder = Convert.ToInt32(obj[SOLines.Remainder]);
                    t.SubGroupNo = Convert.ToInt32(obj[SOLines.SubGroupNo]);
                    t.TaxClassNo = Convert.ToInt32(obj[SOLines.TaxClassNo]);
                    t.VATCode = Convert.ToInt32(obj[SOLines.VATCode]);
                    t.WareHouseNo = Convert.ToInt32(obj[SOLines.WareHouseNo]);
                    t.Weight = Convert.ToInt32(obj[SOLines.Weight]);
                    t.UniqueId = Convert.ToInt32(obj[SOLines.UniqueId]);
                    t.PartDelivered = Convert.ToInt32(obj[SOLines.PartDelivered]);
                    t.UnitHeight = Convert.ToInt32(obj[SOLines.UnitHeight]);
                    t.UnitWidth = Convert.ToInt32(obj[SOLines.UnitWidth]);
                    t.UnitLength = Convert.ToInt32(obj[SOLines.UnitLength]);
                    t.UnitTypeNo = Convert.ToInt32(obj[SOLines.UnitTypeNo]);
                    t.IsUpdated = true;
                    t.SOLineId = Guid.NewGuid();
                    DB.vSOLines.Add(t);
                    DB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
