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
    class Suppliers
    {
        private const string URL = Utilities.URL + "suppliers";
        private string urlParameters = "";
        public async Task GetSuppliers()
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
                    if (!(json[Supplier.ARRAY_SUPPLIERS] is JArray)) return;
                    var col = (JArray)json[Supplier.ARRAY_SUPPLIERS];
                    foreach (JObject obj in col)
                    {
                        this.AddSupplier(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private void AddSupplier(JObject obj)
        {
            try
            {
                using (Admin.DBLayer.ICONEntities2 DB = new Admin.DBLayer.ICONEntities2())
                {
                    var SupplierNo = Convert.ToInt32(obj[Supplier.SupplierNo]);
                    var oldt = DB.vSuppliers.Where(u => u.SupplierNo == SupplierNo).FirstOrDefault();
                    if (oldt == null)
                    {
                        var t = new Admin.DBLayer.vSupplier();
                        t.SupplierNo = SupplierNo;
                        t.Name = Convert.ToString(obj[Supplier.Name]);
                        t.ContactNo = Convert.ToInt32(obj[Supplier.ContactNo]);
                        t.PostCode = Convert.ToString(obj[Supplier.PostCode]);
                        t.PostOffice = Convert.ToString(obj[Supplier.PostOffice]);
                        t.Telephone = Convert.ToString(obj[Supplier.Telephone]);
                        t.Telefax = Convert.ToString(obj[Supplier.Telefax]);
                        t.EmailAddress = Convert.ToString(obj[Supplier.EmailAddress]);
                        t.FormProfileSuppNo = Convert.ToInt32(obj[Supplier.FormProfileSuppNo]);
                        t.DeliveryMethodsNo = Convert.ToInt32(obj[Supplier.DeliveryMethodsNo]);
                        t.TermsOfDeliveryNo = Convert.ToInt32(obj[Supplier.TermsOfDeliveryNo]);
                        t.SwiftCodeNo = Convert.ToInt32(obj[Supplier.SwiftCodeNo]);
                        t.PostAccount = Convert.ToString(obj[Supplier.PostAccount]);
                        t.BankAccount = Convert.ToString(obj[Supplier.BankAccount]);
                        t.CountryNo = Convert.ToInt32(obj[Supplier.CountryNo]);
                        t.Address1 = Convert.ToString(obj[Supplier.Address1]);
                        t.SortName = Convert.ToString(obj[Supplier.SortName]);
                        t.BuContactNo = Convert.ToInt32(obj[Supplier.BuContactNo]);
                        t.SupplierGrpNo = Convert.ToInt32(obj[Supplier.SupplierGrpNo]);
                        t.BusinessNo = Convert.ToInt32(obj[Supplier.BusinessNo]);
                        t.SupplierProfileNo = Convert.ToInt32(obj[Supplier.SupplierProfileNo]);
                        t.EmployeeNo = Convert.ToInt32(obj[Supplier.EmployeeNo]);
                        t.TermsOfPaySupplNo = Convert.ToInt32(obj[Supplier.TermsOfPaySupplNo]);
                        t.WareHouseNo = Convert.ToInt32(obj[Supplier.WareHouseNo]);
                        t.OurCustomerNo = Convert.ToString(obj[Supplier.OurCustomerNo]);
                        t.CompanyNo = Convert.ToString(obj[Supplier.CompanyNo]);
                        t.DistrictNo = Convert.ToInt32(obj[Supplier.DistrictNo]);
                        t.CurrencyNo = Convert.ToInt32(obj[Supplier.CurrencyNo]);
                        t.CreditLimit = Convert.ToDecimal(obj[Supplier.CreditLimit]);
                        t.GLAccPay = Convert.ToInt32(obj[Supplier.GLAccPay]);
                        t.SupplierTypeNo = Convert.ToInt32(obj[Supplier.SupplierTypeNo]);
                        t.DiscountGrpSupplNo = Convert.ToInt32(obj[Supplier.DiscountGrpSupplNo]);
                        t.LastMovementDate = Convert.ToDateTime(obj[Supplier.LastMovementDate]);
                        t.InActiveYesNo = Convert.ToBoolean(obj[Supplier.InActiveYesNo]);
                        t.RegistrationDate = Convert.ToDateTime(obj[Supplier.RegistrationDate]);
                        t.AccessLevel = Convert.ToInt32(obj[Supplier.AccessLevel]);
                        t.Password = Convert.ToString(obj[Supplier.Password]);
                        t.CustomerNo = Convert.ToInt32(obj[Supplier.CustomerNo]);
                        t.ProjectNo = Convert.ToInt32(obj[Supplier.ProjectNo]);
                        t.ProductNo = Convert.ToInt32(obj[Supplier.ProductNo]);
                        t.DepNo = Convert.ToInt32(obj[Supplier.DepNo]);
                        t.SupplierClassification = Convert.ToInt32(obj[Supplier.SupplierClassification]);
                        t.ChainNo = Convert.ToInt32(obj[Supplier.ChainNo]);
                        t.WWWAddress = Convert.ToString(obj[Supplier.WWWAddress]);
                        t.Address3 = Convert.ToString(obj[Supplier.Address3]);
                        t.Address2 = Convert.ToString(obj[Supplier.Address2]);
                        t.LastUpdate = Convert.ToDateTime(obj[Supplier.LastUpdate]);
                        t.ExtraCostUnitIVNo = Convert.ToInt32(obj[Supplier.ExtraCostUnitIVNo]);
                        t.ExtraCostUnitIIINo = Convert.ToInt32(obj[Supplier.ExtraCostUnitIIINo]);
                        t.ExtraCostUnitIINo = Convert.ToInt32(obj[Supplier.ExtraCostUnitIINo]);
                        t.ExtraCostUnitINo = Convert.ToInt32(obj[Supplier.ExtraCostUnitINo]);
                        t.RemittanceProfileNo = Convert.ToInt32(obj[Supplier.RemittanceProfileNo]);
                        t.LocalGovernmentNo = Convert.ToInt32(obj[Supplier.LocalGovernmentNo]);
                        t.ReminderProfileNo = Convert.ToInt32(obj[Supplier.ReminderProfileNo]);
                        t.NoOfReceivedPrOrder = Convert.ToInt32(obj[Supplier.NoOfReceivedPrOrder]);
                        t.AvgDaysDelayedDelivery = Convert.ToInt32(obj[Supplier.AvgDaysDelayedDelivery]);
                        t.EbusinessType = Convert.ToInt32(obj[Supplier.EbusinessType]);
                        t.OrderConfirmationTime = Convert.ToInt32(obj[Supplier.OrderConfirmationTime]);
                        t.EANLocationNo = Convert.ToString(obj[Supplier.EANLocationNo]);
                        t.VATRegNo = Convert.ToString(obj[Supplier.VATRegNo]);
                       // t.PrefGLAccountNo = Convert.ToInt32(obj[Supplier.PrefGLAccountNo]);
                        t.PLAttResponsible = Convert.ToInt32(obj[Supplier.PLAttResponsible]);
                        t.BankGiro = Convert.ToString(obj[Supplier.BankGiro]);
                        t.RiksBankKod = Convert.ToInt32(obj[Supplier.RiksBankKod]);
                        t.BankName = Convert.ToString(obj[Supplier.BankName]);
                        t.PgKontorUtland = Convert.ToString(obj[Supplier.PgKontorUtland]);
                        t.Telephone2 = Convert.ToString(obj[Supplier.Telephone2]);
                        t.LanguageNo = Convert.ToInt32(obj[Supplier.LanguageNo]);
                        t.BankConNo = Convert.ToInt32(obj[Supplier.BankConNo]);
                       // t.ForeignPaymentYesNo = Convert.ToInt32(obj[Supplier.ForeignPaymentYesNo]);
                        t.CurrencyAccount = Convert.ToInt32(obj[Supplier.CurrencyAccount]);
                        t.UserNumber = Convert.ToString(obj[Supplier.UserNumber]);
                        t.KIDSupplier = Convert.ToInt32(obj[Supplier.KIDSupplier]);
                        t.ForeignBankCode = Convert.ToString(obj[Supplier.ForeignBankCode]);
                        t.CountryCode = Convert.ToString(obj[Supplier.CountryCode]);
                        t.PaymentMethod = Convert.ToInt32(obj[Supplier.PaymentMethod]);
                        t.GLAccPayAlfa = Convert.ToString(obj[Supplier.GLAccPayAlfa]);
                        t.AccountingRuleNo = Convert.ToInt32(obj[Supplier.AccountingRuleNo]);
                        t.EuroFicka = Convert.ToInt32(obj[Supplier.EuroFicka]);
                        t.TransType = Convert.ToInt32(obj[Supplier.TransType]);
                        t.TransTypeText = Convert.ToString(obj[Supplier.TransTypeText]);
                        t.AttestationResponsible = Convert.ToInt32(obj[Supplier.AttestationResponsible]);
                        t.FloatGroupNo = Convert.ToInt32(obj[Supplier.FloatGroupNo]);
                        t.ChartererCompanyNo = Convert.ToInt32(obj[Supplier.ChartererCompanyNo]);
                        t.IBAN = Convert.ToString(obj[Supplier.IBAN]);
                        t.DateLastFinancialStatement = Convert.ToDateTime(obj[Supplier.DateLastFinancialStatement]);
                        t.AnnualSales = Convert.ToInt32(obj[Supplier.AnnualSales]);
                        t.NoOfEmployees = Convert.ToInt32(obj[Supplier.NoOfEmployees]);
                        t.CostTrackingProfileNo = Convert.ToInt32(obj[Supplier.CostTrackingProfileNo]);
                        t.IsUpdated = true;
                        DB.vSuppliers.Add(t);
                        DB.SaveChanges();
                    }
                    else
                    {
                        bool IsUpdated = false;
                        if (oldt.Name != Convert.ToString(obj[Supplier.Name]))
                        {
                            IsUpdated = true;
                            oldt.Name = Convert.ToString(obj[Supplier.Name]);
                        }
                        if (oldt.ContactNo != Convert.ToInt32(obj[Supplier.ContactNo]))
                        {
                            IsUpdated = true;
                            oldt.ContactNo = Convert.ToInt32(obj[Supplier.ContactNo]);
                        }
                        if (oldt.PostCode != Convert.ToString(obj[Supplier.PostCode]))
                        {
                            IsUpdated = true;
                            oldt.PostCode = Convert.ToString(obj[Supplier.PostCode]);
                        }
                        if (oldt.PostOffice != Convert.ToString(obj[Supplier.PostOffice]))
                        {
                            IsUpdated = true;
                            oldt.PostOffice = Convert.ToString(obj[Supplier.PostOffice]);
                        }
                        if (oldt.Telephone != Convert.ToString(obj[Supplier.Telephone]))
                        {
                            IsUpdated = true;
                            oldt.Telephone = Convert.ToString(obj[Supplier.Telephone]);
                        }
                        if (oldt.Telefax != Convert.ToString(obj[Supplier.Telefax]))
                        {
                            IsUpdated = true;
                            oldt.Telefax = Convert.ToString(obj[Supplier.Telefax]);
                        }
                        if (oldt.EmailAddress != Convert.ToString(obj[Supplier.EmailAddress]))
                        {
                            IsUpdated = true;
                            oldt.EmailAddress = Convert.ToString(obj[Supplier.EmailAddress]);
                        }
                        if (oldt.FormProfileSuppNo != Convert.ToInt32(obj[Supplier.FormProfileSuppNo]))
                        {
                            IsUpdated = true;
                            oldt.FormProfileSuppNo = Convert.ToInt32(obj[Supplier.FormProfileSuppNo]);
                        }
                        if (oldt.DeliveryMethodsNo != Convert.ToInt32(obj[Supplier.DeliveryMethodsNo]))
                        {
                            IsUpdated = true;
                            oldt.DeliveryMethodsNo = Convert.ToInt32(obj[Supplier.DeliveryMethodsNo]);
                        }
                        if (oldt.TermsOfDeliveryNo != Convert.ToInt32(obj[Supplier.TermsOfDeliveryNo]))
                        {
                            IsUpdated = true;
                            oldt.TermsOfDeliveryNo = Convert.ToInt32(obj[Supplier.TermsOfDeliveryNo]);
                        }
                        if (oldt.SwiftCodeNo != Convert.ToInt32(obj[Supplier.SwiftCodeNo]))
                        {
                            IsUpdated = true;
                            oldt.SwiftCodeNo = Convert.ToInt32(obj[Supplier.SwiftCodeNo]);
                        }
                        if (oldt.PostAccount != Convert.ToString(obj[Supplier.PostAccount]))
                        {
                            IsUpdated = true;
                            oldt.PostAccount = Convert.ToString(obj[Supplier.PostAccount]);
                        }
                        if (oldt.BankAccount != Convert.ToString(obj[Supplier.BankAccount]))
                        {
                            IsUpdated = true;
                            oldt.BankAccount = Convert.ToString(obj[Supplier.BankAccount]);
                        }
                        if (oldt.CountryNo != Convert.ToInt32(obj[Supplier.CountryNo]))
                        {
                            IsUpdated = true;
                            oldt.CountryNo = Convert.ToInt32(obj[Supplier.CountryNo]);
                        }
                        if (oldt.Address1 != Convert.ToString(obj[Supplier.Address1]))
                        {
                            IsUpdated = true;
                            oldt.Address1 = Convert.ToString(obj[Supplier.Address1]);
                        }
                        if (oldt.SortName != Convert.ToString(obj[Supplier.SortName]))
                        {
                            IsUpdated = true;
                            oldt.SortName = Convert.ToString(obj[Supplier.SortName]);
                        }
                        if (oldt.BuContactNo != Convert.ToInt32(obj[Supplier.BuContactNo]))
                        {
                            IsUpdated = true;
                            oldt.BuContactNo = Convert.ToInt32(obj[Supplier.BuContactNo]);
                        }
                        if (oldt.SupplierGrpNo != Convert.ToInt32(obj[Supplier.SupplierGrpNo]))
                        {
                            IsUpdated = true;
                            oldt.SupplierGrpNo = Convert.ToInt32(obj[Supplier.SupplierGrpNo]);
                        }
                        if (oldt.BusinessNo != Convert.ToInt32(obj[Supplier.BusinessNo]))
                        {
                            IsUpdated = true;
                            oldt.BusinessNo = Convert.ToInt32(obj[Supplier.BusinessNo]);
                        }
                        if (oldt.SupplierProfileNo != Convert.ToInt32(obj[Supplier.SupplierProfileNo]))
                        {
                            IsUpdated = true;
                            oldt.SupplierProfileNo = Convert.ToInt32(obj[Supplier.SupplierProfileNo]);
                        }
                        if (oldt.EmployeeNo != Convert.ToInt32(obj[Supplier.EmployeeNo]))
                        {
                            IsUpdated = true;
                            oldt.EmployeeNo = Convert.ToInt32(obj[Supplier.EmployeeNo]);
                        }
                        if (oldt.TermsOfPaySupplNo != Convert.ToInt32(obj[Supplier.TermsOfPaySupplNo]))
                        {
                            IsUpdated = true;
                            oldt.TermsOfPaySupplNo = Convert.ToInt32(obj[Supplier.TermsOfPaySupplNo]);
                        }
                        if (oldt.WareHouseNo != Convert.ToInt32(obj[Supplier.WareHouseNo]))
                        {
                            IsUpdated = true;
                            oldt.WareHouseNo = Convert.ToInt32(obj[Supplier.WareHouseNo]);
                        }
                        if (oldt.OurCustomerNo != Convert.ToString(obj[Supplier.OurCustomerNo]))
                        {
                            IsUpdated = true;
                            oldt.OurCustomerNo = Convert.ToString(obj[Supplier.OurCustomerNo]);
                        }
                        if (oldt.CompanyNo != Convert.ToString(obj[Supplier.CompanyNo]))
                        {
                            IsUpdated = true;
                            oldt.CompanyNo = Convert.ToString(obj[Supplier.CompanyNo]);
                        }
                        if (oldt.DistrictNo != Convert.ToInt32(obj[Supplier.DistrictNo]))
                        {
                            IsUpdated = true;
                            oldt.DistrictNo = Convert.ToInt32(obj[Supplier.DistrictNo]);
                        }
                        if (oldt.CurrencyNo != Convert.ToInt32(obj[Supplier.CurrencyNo]))
                        {
                            IsUpdated = true;
                            oldt.CurrencyNo = Convert.ToInt32(obj[Supplier.CurrencyNo]);
                        }
                        if (oldt.CreditLimit != Convert.ToDecimal(obj[Supplier.CreditLimit]))
                        {
                            IsUpdated = true;
                            oldt.CreditLimit = Convert.ToDecimal(obj[Supplier.CreditLimit]);
                        }
                        if (oldt.GLAccPay != Convert.ToInt32(obj[Supplier.GLAccPay]))
                        {
                            IsUpdated = true;
                            oldt.GLAccPay = Convert.ToInt32(obj[Supplier.GLAccPay]);
                        }
                        if (oldt.SupplierTypeNo != Convert.ToInt32(obj[Supplier.SupplierTypeNo]))
                        {
                            IsUpdated = true;
                            oldt.SupplierTypeNo = Convert.ToInt32(obj[Supplier.SupplierTypeNo]);
                        }
                        if (oldt.DiscountGrpSupplNo != Convert.ToInt32(obj[Supplier.DiscountGrpSupplNo]))
                        {
                            IsUpdated = true;
                            oldt.DiscountGrpSupplNo = Convert.ToInt32(obj[Supplier.DiscountGrpSupplNo]);
                        }
                        if (oldt.LastMovementDate != Convert.ToDateTime(obj[Supplier.LastMovementDate]))
                        {
                            IsUpdated = true;
                            oldt.LastMovementDate = Convert.ToDateTime(obj[Supplier.LastMovementDate]);
                        }
                        if (oldt.InActiveYesNo != Convert.ToBoolean(obj[Supplier.InActiveYesNo]))
                        {
                            IsUpdated = true;
                            oldt.InActiveYesNo = Convert.ToBoolean(obj[Supplier.InActiveYesNo]);
                        }
                        if (oldt.RegistrationDate != Convert.ToDateTime(obj[Supplier.RegistrationDate]))
                        {
                            IsUpdated = true;
                            oldt.RegistrationDate = Convert.ToDateTime(obj[Supplier.RegistrationDate]);
                        }
                        if (oldt.AccessLevel != Convert.ToInt32(obj[Supplier.AccessLevel]))
                        {
                            IsUpdated = true;
                            oldt.AccessLevel = Convert.ToInt32(obj[Supplier.AccessLevel]);
                        }
                        if (oldt.Password != Convert.ToString(obj[Supplier.Password]))
                        {
                            IsUpdated = true;
                            oldt.Password = Convert.ToString(obj[Supplier.Password]);
                        }
                        if (oldt.CustomerNo != Convert.ToInt32(obj[Supplier.CustomerNo]))
                        {
                            IsUpdated = true;
                            oldt.CustomerNo = Convert.ToInt32(obj[Supplier.CustomerNo]);
                        }
                        if (oldt.ProjectNo != Convert.ToInt32(obj[Supplier.ProjectNo]))
                        {
                            IsUpdated = true;
                            oldt.ProjectNo = Convert.ToInt32(obj[Supplier.ProjectNo]);
                        }
                        if (oldt.DepNo != Convert.ToInt32(obj[Supplier.DepNo]))
                        {
                            IsUpdated = true;
                            oldt.DepNo = Convert.ToInt32(obj[Supplier.DepNo]);
                        }
                        if (oldt.SupplierClassification != Convert.ToInt32(obj[Supplier.SupplierClassification]))
                        {
                            IsUpdated = true;
                            oldt.SupplierClassification = Convert.ToInt32(obj[Supplier.SupplierClassification]);
                        }
                        if (oldt.ChainNo != Convert.ToInt32(obj[Supplier.ChainNo]))
                        {
                            IsUpdated = true;
                            oldt.ChainNo = Convert.ToInt32(obj[Supplier.ChainNo]);
                        }
                        if (oldt.WWWAddress != Convert.ToString(obj[Supplier.WWWAddress]))
                        {
                            IsUpdated = true;
                            oldt.WWWAddress = Convert.ToString(obj[Supplier.WWWAddress]);
                        }
                        if (oldt.Address3 != Convert.ToString(obj[Supplier.Address3]))
                        {
                            IsUpdated = true;
                            oldt.Address3 = Convert.ToString(obj[Supplier.Address3]);
                        }
                        if (oldt.Address2 != Convert.ToString(obj[Supplier.Address2]))
                        {
                            IsUpdated = true;
                            oldt.Address2 = Convert.ToString(obj[Supplier.Address2]);
                        }
                        if (oldt.LastUpdate != Convert.ToDateTime(obj[Supplier.LastUpdate]))
                        {
                            IsUpdated = true;
                            oldt.LastUpdate = Convert.ToDateTime(obj[Supplier.LastUpdate]);
                        }
                        if (oldt.ExtraCostUnitIVNo != Convert.ToInt32(obj[Supplier.ExtraCostUnitIVNo]))
                        {
                            IsUpdated = true;
                            oldt.ExtraCostUnitIVNo = Convert.ToInt32(obj[Supplier.ExtraCostUnitIVNo]);
                        }
                        if (oldt.ExtraCostUnitIIINo != Convert.ToInt32(obj[Supplier.ExtraCostUnitIIINo]))
                        {
                            IsUpdated = true;
                            oldt.ExtraCostUnitIIINo = Convert.ToInt32(obj[Supplier.ExtraCostUnitIIINo]);
                        }
                        if (oldt.ExtraCostUnitIINo != Convert.ToInt32(obj[Supplier.ExtraCostUnitIINo]))
                        {
                            IsUpdated = true;
                            oldt.ExtraCostUnitIINo = Convert.ToInt32(obj[Supplier.ExtraCostUnitIINo]);
                        }
                        if (oldt.ExtraCostUnitINo != Convert.ToInt32(obj[Supplier.ExtraCostUnitINo]))
                        {
                            IsUpdated = true;
                            oldt.ExtraCostUnitINo = Convert.ToInt32(obj[Supplier.ExtraCostUnitINo]);
                        }
                        if (oldt.RemittanceProfileNo != Convert.ToInt32(obj[Supplier.RemittanceProfileNo]))
                        {
                            IsUpdated = true;
                            oldt.RemittanceProfileNo = Convert.ToInt32(obj[Supplier.RemittanceProfileNo]);
                        }
                        if (oldt.LocalGovernmentNo != Convert.ToInt32(obj[Supplier.LocalGovernmentNo]))
                        {
                            IsUpdated = true;
                            oldt.LocalGovernmentNo = Convert.ToInt32(obj[Supplier.LocalGovernmentNo]);
                        }
                        if (oldt.ReminderProfileNo != Convert.ToInt32(obj[Supplier.ReminderProfileNo]))
                        {
                            IsUpdated = true;
                            oldt.ReminderProfileNo = Convert.ToInt32(obj[Supplier.ReminderProfileNo]);
                        }
                        if (oldt.NoOfReceivedPrOrder != Convert.ToInt32(obj[Supplier.NoOfReceivedPrOrder]))
                        {
                            IsUpdated = true;
                            oldt.NoOfReceivedPrOrder = Convert.ToInt32(obj[Supplier.NoOfReceivedPrOrder]);
                        }
                        if (oldt.AvgDaysDelayedDelivery != Convert.ToInt32(obj[Supplier.AvgDaysDelayedDelivery]))
                        {
                            IsUpdated = true;
                            oldt.AvgDaysDelayedDelivery = Convert.ToInt32(obj[Supplier.AvgDaysDelayedDelivery]);
                        }
                        if (oldt.EbusinessType != Convert.ToInt32(obj[Supplier.EbusinessType]))
                        {
                            IsUpdated = true;
                            oldt.EbusinessType = Convert.ToInt32(obj[Supplier.EbusinessType]);
                        }
                        if (oldt.OrderConfirmationTime != Convert.ToInt32(obj[Supplier.OrderConfirmationTime]))
                        {
                            IsUpdated = true;
                            oldt.OrderConfirmationTime = Convert.ToInt32(obj[Supplier.OrderConfirmationTime]);
                        }
                        if (oldt.EANLocationNo != Convert.ToString(obj[Supplier.EANLocationNo]))
                        {
                            IsUpdated = true;
                            oldt.EANLocationNo = Convert.ToString(obj[Supplier.EANLocationNo]);
                        }
                        if (oldt.VATRegNo != Convert.ToString(obj[Supplier.VATRegNo]))
                        {
                            IsUpdated = true;
                            oldt.VATRegNo = Convert.ToString(obj[Supplier.VATRegNo]);
                        }
                        //if (oldt.PrefGLAccountNo != Convert.ToInt32(obj[Supplier.PrefGLAccountNo]))
                        //{
                        //    IsUpdated = true;
                        //    oldt.PrefGLAccountNo = Convert.ToInt32(obj[Supplier.PrefGLAccountNo]);
                        //}
                        if (oldt.PLAttResponsible != Convert.ToInt32(obj[Supplier.PLAttResponsible]))
                        {
                            IsUpdated = true;
                            oldt.PLAttResponsible = Convert.ToInt32(obj[Supplier.PLAttResponsible]);
                        }
                        if (oldt.BankGiro != Convert.ToString(obj[Supplier.BankGiro]))
                        {
                            IsUpdated = true;
                            oldt.BankGiro = Convert.ToString(obj[Supplier.BankGiro]);
                        }
                        if (oldt.RiksBankKod != Convert.ToInt32(obj[Supplier.RiksBankKod]))
                        {
                            IsUpdated = true;
                            oldt.RiksBankKod = Convert.ToInt32(obj[Supplier.RiksBankKod]);
                        }
                        if (oldt.BankName != Convert.ToString(obj[Supplier.BankName]))
                        {
                            IsUpdated = true;
                            oldt.BankName = Convert.ToString(obj[Supplier.BankName]);
                        }
                        if (oldt.PgKontorUtland != Convert.ToString(obj[Supplier.PgKontorUtland]))
                        {
                            IsUpdated = true;
                            oldt.PgKontorUtland = Convert.ToString(obj[Supplier.PgKontorUtland]);
                        }
                        if (oldt.Telephone2 != Convert.ToString(obj[Supplier.Telephone2]))
                        {
                            IsUpdated = true;
                            oldt.Telephone2 = Convert.ToString(obj[Supplier.Telephone2]);
                        }
                        if (oldt.LanguageNo != Convert.ToInt32(obj[Supplier.LanguageNo]))
                        {
                            IsUpdated = true;
                            oldt.LanguageNo = Convert.ToInt32(obj[Supplier.LanguageNo]);
                        }
                        if (oldt.BankConNo != Convert.ToInt32(obj[Supplier.BankConNo]))
                        {
                            IsUpdated = true;
                            oldt.BankConNo = Convert.ToInt32(obj[Supplier.BankConNo]);
                        }
                    
                        if (oldt.CurrencyAccount != Convert.ToInt32(obj[Supplier.CurrencyAccount]))
                        {
                            IsUpdated = true;
                            oldt.CurrencyAccount = Convert.ToInt32(obj[Supplier.CurrencyAccount]);
                        }
                        if (oldt.UserNumber != Convert.ToString(obj[Supplier.UserNumber]))
                        {
                            IsUpdated = true;
                            oldt.UserNumber = Convert.ToString(obj[Supplier.UserNumber]);
                        }
                        if (oldt.KIDSupplier != Convert.ToInt32(obj[Supplier.KIDSupplier]))
                        {
                            IsUpdated = true;
                            oldt.KIDSupplier = Convert.ToInt32(obj[Supplier.KIDSupplier]);
                        }
                        if (oldt.ForeignBankCode != Convert.ToString(obj[Supplier.ForeignBankCode]))
                        {
                            IsUpdated = true;
                            oldt.ForeignBankCode = Convert.ToString(obj[Supplier.ForeignBankCode]);
                        }
                        if (oldt.CountryCode != Convert.ToString(obj[Supplier.CountryCode]))
                        {
                            IsUpdated = true;
                            oldt.CountryCode = Convert.ToString(obj[Supplier.CountryCode]);
                        }
                        if (oldt.PaymentMethod != Convert.ToInt32(obj[Supplier.PaymentMethod]))
                        {
                            IsUpdated = true;
                            oldt.PaymentMethod = Convert.ToInt32(obj[Supplier.PaymentMethod]);
                        }
                        if (oldt.GLAccPayAlfa != Convert.ToString(obj[Supplier.GLAccPayAlfa]))
                        {
                            IsUpdated = true;
                            oldt.GLAccPayAlfa = Convert.ToString(obj[Supplier.GLAccPayAlfa]);
                        }
                        if (oldt.AccountingRuleNo != Convert.ToInt32(obj[Supplier.AccountingRuleNo]))
                        {
                            IsUpdated = true;
                            oldt.AccountingRuleNo = Convert.ToInt32(obj[Supplier.AccountingRuleNo]);
                        }
                        if (oldt.EuroFicka != Convert.ToInt32(obj[Supplier.EuroFicka]))
                        {
                            IsUpdated = true;
                            oldt.EuroFicka = Convert.ToInt32(obj[Supplier.EuroFicka]);
                        }
                        if (oldt.TransType != Convert.ToInt32(obj[Supplier.TransType]))
                        {
                            IsUpdated = true;
                            oldt.TransType = Convert.ToInt32(obj[Supplier.TransType]);
                        }
                        if (oldt.TransTypeText != Convert.ToString(obj[Supplier.TransTypeText]))
                        {
                            IsUpdated = true;
                            oldt.TransTypeText = Convert.ToString(obj[Supplier.TransTypeText]);
                        }
                        if (oldt.AttestationResponsible != Convert.ToInt32(obj[Supplier.AttestationResponsible]))
                        {
                            IsUpdated = true;
                            oldt.AttestationResponsible = Convert.ToInt32(obj[Supplier.AttestationResponsible]);
                        }
                        if (oldt.FloatGroupNo != Convert.ToInt32(obj[Supplier.FloatGroupNo]))
                        {
                            IsUpdated = true;
                            oldt.FloatGroupNo = Convert.ToInt32(obj[Supplier.FloatGroupNo]);
                        }
                        if (oldt.ChartererCompanyNo != Convert.ToInt32(obj[Supplier.ChartererCompanyNo]))
                        {
                            IsUpdated = true;
                            oldt.ChartererCompanyNo = Convert.ToInt32(obj[Supplier.ChartererCompanyNo]);
                        }
                        if (oldt.IBAN != Convert.ToString(obj[Supplier.IBAN]))
                        {
                            IsUpdated = true;
                            oldt.IBAN = Convert.ToString(obj[Supplier.IBAN]);
                        }
                        if (oldt.DateLastFinancialStatement != Convert.ToDateTime(obj[Supplier.DateLastFinancialStatement]))
                        {
                            IsUpdated = true;
                            oldt.DateLastFinancialStatement = Convert.ToDateTime(obj[Supplier.DateLastFinancialStatement]);
                        }
                        if (oldt.AnnualSales != Convert.ToInt32(obj[Supplier.AnnualSales]))
                        {
                            IsUpdated = true;
                            oldt.AnnualSales = Convert.ToInt32(obj[Supplier.AnnualSales]);
                        }
                        if (oldt.NoOfEmployees != Convert.ToInt32(obj[Supplier.NoOfEmployees]))
                        {
                            IsUpdated = true;
                            oldt.NoOfEmployees = Convert.ToInt32(obj[Supplier.NoOfEmployees]);
                        }
                        if (oldt.CostTrackingProfileNo != Convert.ToInt32(obj[Supplier.CostTrackingProfileNo]))
                        {
                            IsUpdated = true;
                            oldt.CostTrackingProfileNo = Convert.ToInt32(obj[Supplier.CostTrackingProfileNo]);
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
        public void UpdateSupplier()
        {
            try
            {
                using (Admin.DBLayer.ICONEntities2 DB = new Admin.DBLayer.ICONEntities2())
                {
                    var vSuppliers = DB.vSuppliers.Where( u => u.IsUpdated==true).ToList();
                    foreach (var v in vSuppliers)
                    {
                        try
                        {
                            var t = DB.tblSuppliers.Where(u => u.SupplierNo  == v.SupplierNo).FirstOrDefault();
                            using (Admin.DBLayer.ICONEntities2 DB2 = new Admin.DBLayer.ICONEntities2())
                            {
                                if (t == null)
                                {
                                    t = new Admin.DBLayer.tblSupplier();
                                    t.Address1 = v.Address1;
                                    t.Address2 = v.Address2;
                                    t.BankAccount = v.BankAccount;
                                    t.BankName = v.BankName;
                                    t.CreateBy = "VISMA";
                                    t.City = v.Address3;
                                    t.Contact = Convert.ToString(v.ContactNo);
                                    t.CountryId = new Guid("2A8B3E38-7D7F-4A43-B38B-1CC19FB2D144");
                                    t.CreationDate = DateTime.Now;
                                    t.CreditLimit = v.CreditLimit;
                                    t.CurrencyId = new Guid("34DD283F-DD4B-4A55-AA26-505245FDB52C");
                                    t.Email = v.EmailAddress;
                                    t.IBAN = v.IBAN;
                                    t.IsVISMA = true;
                                    t.Name = v.Name;
                                    t.Phone = v.Telephone;
                                    t.PostOffice = v.PostOffice;
                                    t.PostAccount = v.PostAccount;
                                    t.StatusId = v.InActiveYesNo == true ? new Guid(Utilities.Status_Active) : new Guid(Utilities.Status_InActive);
                                    t.SwiftCode = Convert.ToString(v.SwiftCodeNo);
                                    t.SupplierId = Guid.NewGuid();
                                    t.SupplierNo = v.SupplierNo;
                                    DB2.tblSuppliers.Add(t);
                                    DB2.SaveChanges();
                                }
                                else
                                {
                                    t.Address1 = v.Address1;
                                    t.Address2 = v.Address2;
                                    t.BankAccount = v.BankAccount;
                                    t.BankName = v.BankName;
                                    t.ModifyBy  = "VISMA";
                                    t.City = v.Address3;
                                    t.Contact = Convert.ToString(v.ContactNo);
                                    t.ModifyDate  = DateTime.Now;
                                    t.CreditLimit = v.CreditLimit;
                                    t.Email = v.EmailAddress;
                                    t.IBAN = v.IBAN;
                                    t.IsVISMA = true;
                                    t.Name = v.Name;
                                    t.Phone = v.Telephone;
                                    t.PostOffice = v.PostOffice;
                                    t.PostAccount = v.PostAccount;
                                    t.StatusId = v.InActiveYesNo == true ? new Guid(Utilities.Status_Active) : new Guid(Utilities.Status_InActive);
                                    t.SwiftCode = Convert.ToString(v.SwiftCodeNo);
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
}
