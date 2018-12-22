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
    class POs
    {
        private const string URL = Utilities.URL + "SupplierOrders";
        private string urlParameters = "";
        public async Task GetPOes()
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
                    if (!(json[PO.ARRAY_ORDERS] is JArray)) return;
                    var col = (JArray)json[PO.ARRAY_ORDERS];
                    foreach (JObject obj in col)
                    {
                        this.AddPO(obj);
                        if(obj[Lines.ARRAY_LINES] is JArray)
                        {
                            var colLines = (JArray)obj[Lines.ARRAY_LINES];
                            foreach(JObject objLine in colLines)
                            {
                                this.AddLine(objLine);
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
        private void AddPO(JObject obj)
        {
            try
            {
                using (Admin.DBLayer.ICONEntities2 DB = new Admin.DBLayer.ICONEntities2())
                {
                        var t = new Admin.DBLayer.vPO();
                        t.SupplierOrderNo = Convert.ToString(obj[PO.SupplierOrderNo]);
                        t.SupplierName = Convert.ToString(obj[PO.SupplierName]);
                        t.SupplierOrderDate = Convert.ToDateTime(obj[PO.SupplierOrderDate]);
                        t.DeliveryDate = Convert.ToDateTime(obj[PO.DeliveryDate]);
                        t.TotalAmount = Convert.ToInt32(obj[PO.TotalAmount]);
                        t.OurRef = Convert.ToString(obj[PO.OurRef]);
                        t.ContactNo = Convert.ToInt32(obj[PO.ContactNo]);
                        t.NameContactNo = Convert.ToString(obj[PO.NameContactNo]);
                        t.SupplierNo = Convert.ToInt32(obj[PO.SupplierNo]);
                        t.TermsOfPaySupplNo = Convert.ToInt32(obj[PO.TermsOfPaySupplNo]);
                        t.WareHouseNo = Convert.ToInt32(obj[PO.WareHouseNo]);
                        t.ProductNo = Convert.ToInt32(obj[PO.ProductNo]);
                        t.DepNo = Convert.ToInt32(obj[PO.DepNo]);
                        t.ProjectNo = Convert.ToInt32(obj[PO.ProjectNo]);
                        t.VATCode = Convert.ToInt32(obj[PO.VATCode]);
                        t.TaxClassNo = Convert.ToInt32(obj[PO.TaxClassNo]);
                        t.CurrencyNo = Convert.ToInt32(obj[PO.CurrencyNo]);
                        t.Telephone = Convert.ToString(obj[PO.Telephone]);
                        t.DeliveredYesNo = Convert.ToInt32(obj[PO.DeliveredYesNo]);
                        t.Address1 = Convert.ToString(obj[PO.Address1]);
                        t.PostOffice = Convert.ToString(obj[PO.PostOffice]);
                        t.PostCode = Convert.ToString(obj[PO.PostCode]);
                        t.CountryNo = Convert.ToInt32(obj[PO.CountryNo]);
                        t.EmployeeNo = Convert.ToInt32(obj[PO.EmployeeNo]);
                        t.DeliveryMethodsNo = Convert.ToInt32(obj[PO.DeliveryMethodsNo]);
                        t.TermsOfDeliveryNo = Convert.ToInt32(obj[PO.TermsOfDeliveryNo]);
                        t.TotalDelivery = Convert.ToInt32(obj[PO.TotalDelivery]);
                        t.InvoiceFee = Convert.ToInt32(obj[PO.InvoiceFee]);
                        t.HandlingCharge = Convert.ToInt32(obj[PO.HandlingCharge]);
                        t.Postage = Convert.ToInt32(obj[PO.Postage]);
                        t.PurchaseDiscount = Convert.ToInt32(obj[PO.PurchaseDiscount]);
                        t.PurchaseDiscountTaxFree = Convert.ToInt32(obj[PO.PurchaseDiscountTaxFree]);
                        t.PostageTaxFree = Convert.ToInt32(obj[PO.PostageTaxFree]);
                        t.CashDiscount = Convert.ToInt32(obj[PO.CashDiscount]);
                        t.CashDiscountTaxFree = Convert.ToInt32(obj[PO.CashDiscountTaxFree]);
                        t.DueDate = Convert.ToDateTime(obj[PO.DueDate]);
                        t.ExchangeAmount = Convert.ToInt32(obj[PO.ExchangeAmount]);
                        t.ExchangeRate = Convert.ToInt32(obj[PO.ExchangeRate]);
                        t.CompanyNo = Convert.ToString(obj[PO.CompanyNo]);
                        t.TotalVAT = Convert.ToInt32(obj[PO.TotalVAT]);
                        t.VoucherDate = Convert.ToDateTime(obj[PO.VoucherDate]);
                        t.DeliveryAddressNo = Convert.ToInt32(obj[PO.DeliveryAddressNo]);
                        t.DeliveryCountryNo = Convert.ToInt32(obj[PO.DeliveryCountryNo]);
                        t.DeliveryPostOffice = Convert.ToString(obj[PO.DeliveryPostOffice]);
                        t.DeliveryAddress1 = Convert.ToString(obj[PO.DeliveryAddress1]);
                        t.DeliveryPostCode = Convert.ToString(obj[PO.DeliveryPostCode]);
                        t.DeliveryAddress2 = Convert.ToString(obj[PO.DeliveryAddress2]);
                        t.Address2 = Convert.ToString(obj[PO.Address2]);
                        t.OrderConfirmationDate = Convert.ToDateTime(obj[PO.OrderConfirmationDate]);
                        t.SuppliersOrderNoRef = Convert.ToString(obj[PO.SuppliersOrderNoRef]);
                        t.TotalAmountFromInvoice = Convert.ToInt32(obj[PO.TotalAmountFromInvoice]);
                        t.OrderStatus = Convert.ToInt32(obj[PO.OrderStatus]);
                        t.RemainderOrderYesNo = Convert.ToInt32(obj[PO.RemainderOrderYesNo]);
                        t.FreightCost = Convert.ToInt32(obj[PO.FreightCost]);
                        t.OrderType = Convert.ToInt32(obj[PO.OrderType]);
                        t.IsUpdated = true;
                        DB.vPOes.Add(t);
                        DB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void AddLine(JObject obj)
        {
            try
            {
                using (Admin.DBLayer.ICONEntities2 DB = new Admin.DBLayer.ICONEntities2())
                {
                    var t = new Admin.DBLayer.vPOLine();
                    t.AltArtNo = Convert.ToString(obj[Lines.AltArtNo]);
                    t.Amount = Convert.ToInt32(obj[Lines.Amount]);
                    t.ArticleNo = Convert.ToString(obj[Lines.ArticleNo]);
                    t.CurrencyNo = Convert.ToInt32(obj[Lines.CurrencyNo]);
                    t.DeliveryDate = Convert.ToDateTime(obj[Lines.DeliveryDate]);
                    t.DepNo = Convert.ToInt32(obj[Lines.DepNo]);
                    t.Description = Convert.ToString(obj[Lines.Description]);
                    t.DiscountGrpArtNo = Convert.ToInt32(obj[Lines.DiscountGrpArtNo]);
                    t.DiscountI = Convert.ToInt32(obj[Lines.DiscountI]);
                    t.EANNo = Convert.ToString(obj[Lines.EANNo]);
                    t.EmployeeNo = Convert.ToInt32(obj[Lines.EmployeeNo]);
                    t.ExchangeAmount = Convert.ToInt32(obj[Lines.ExchangeAmount]);
                    t.ExchangePurchasePrice = Convert.ToInt32(obj[Lines.ExchangePurchasePrice]);
                    t.ExchangeRate = Convert.ToInt32(obj[Lines.ExchangeRate]);
                    t.ExpiryDate = Convert.ToDateTime(obj[Lines.ExpiryDate]);
                    t.FullCost = Convert.ToInt32(obj[Lines.FullCost]);
                    t.Invoiced = Convert.ToInt32(obj[Lines.Invoiced]);
                    t.InvoicePrice = Convert.ToInt32(obj[Lines.InvoicePrice]);
                    t.Name = Convert.ToString(obj[Lines.Name]);
                    t.NetDeliveryAmount = Convert.ToInt32(obj[Lines.NetDeliveryAmount]);
                    t.NetRemainderAmount = Convert.ToInt32(obj[Lines.NetRemainderAmount]);
                    t.OrderDate = Convert.ToDateTime(obj[Lines.OrderDate]);
                    t.OrderStatus = Convert.ToInt32(obj[Lines.OrderStatus]);
                    t.OrderType = Convert.ToInt32(obj[Lines.OrderType]);
                    t.OriginalLineNo = Convert.ToInt32(obj[Lines.OriginalLineNo]);
                    t.OriginalPrice = Convert.ToInt32(obj[Lines.OriginalPrice]);
                    t.OriginalQuantity = Convert.ToInt32(obj[Lines.OriginalQuantity]);
                    t.PartReceived = Convert.ToInt32(obj[Lines.PartReceived]);
                    t.PostingTemplateNo = Convert.ToInt32(obj[Lines.PostingTemplateNo]);
                    t.PriceCalculationNo = Convert.ToInt32(obj[Lines.PriceCalculationNo]);
                    t.ProductNo = Convert.ToInt32(obj[Lines.ProductNo]);
                    t.ProjectNo = Convert.ToInt32(obj[Lines.ProjectNo]);
                    t.Quantity = Convert.ToInt32(obj[Lines.Quantity]);
                    t.Remainder = Convert.ToInt32(obj[Lines.Remainder]);
                    t.StockProfileNo = Convert.ToInt32(obj[Lines.StockProfileNo]);
                    t.SupplierNo = Convert.ToInt32(obj[Lines.SupplierNo]);
                    t.SupplierOrderNo = Convert.ToString(obj[Lines.SupplierOrderNo]);
                    t.TaxClassNo = Convert.ToInt32(obj[Lines.TaxClassNo]);
                    t.VATCode = Convert.ToInt32(obj[Lines.VATCode]);
                    t.WareHouseNo = Convert.ToInt32(obj[Lines.WareHouseNo]);
                    t.Weight = Convert.ToInt32(obj[Lines.Weight]);
                    t.SuppliersOrderLineNo = Convert.ToInt32(obj[Lines.SuppliersOrderLineNo]);
                    t.TotalInvoiced = Convert.ToInt32(obj[Lines.TotalInvoiced]);
                    t.UniqueId = Convert.ToInt32(obj[Lines.UniqueId]);
                    t.UnitHeight = Convert.ToInt32(obj[Lines.UnitHeight]);
                    t.UnitWidth = Convert.ToInt32(obj[Lines.UnitWidth]);
                    t.UnitLength = Convert.ToInt32(obj[Lines.UnitLength]);
                    t.UnitTypeNo = Convert.ToInt32(obj[Lines.UnitTypeNo]);
                    t.IsUpdated = true;
                    t.POLineId = Guid.NewGuid();
                    DB.vPOLines.Add(t);
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
