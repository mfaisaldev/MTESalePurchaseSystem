using System;
using System.Linq;
using System.Threading.Tasks;
using Scheduler.Model;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Admin;
using Admin.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Scheduler.Controller
{
    public class Customers
    {
        private const string URL = Utilities.URL + "customers";
        private string urlParameters = "";
        private ApplicationUserManager _userManager;
        public async Task GetCustomers()
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
                    if (!(json[Model.Customer.ARRAY_CUSTOMERS] is JArray)) return;
                    var col = (JArray)json[Model.Customer.ARRAY_CUSTOMERS];
                    foreach (JObject obj in col)
                    {
                        this.AddCusotmer(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void AddCusotmer(JObject obj)
        {
            try
            {
                using (Admin.DBLayer.ICONEntities2 DB = new Admin.DBLayer.ICONEntities2())
                {
                    var CustomerNo = Convert.ToInt32(obj[Model.Customer.CUSTOMERNO]);
                    var oldt = DB.vCustomers.Where(u => u.CustomerNo == CustomerNo).FirstOrDefault();
                    if (oldt == null)
                    {
                        var t = new Admin.DBLayer.vCustomer();
                        t.CustomerNo = Convert.ToInt32(obj[Model.Customer.CUSTOMERNO]);
                        t.Name = obj[Model.Customer.NAME].ToString();
                        t.Address1 = obj[Model.Customer.ADDRESS1].ToString();
                        t.EmailAddress = obj[Model.Customer.EMAILADDRESS].ToString();
                        t.Address2 = obj[Model.Customer.ADDRESS2].ToString();
                        t.PostCode = obj[Model.Customer.POSTCODE].ToString();
                        t.PostOffice = obj[Model.Customer.POSTOFFICE].ToString();
                        t.CountryNo = Convert.ToInt32(obj[Model.Customer.COUNTRYNO]);
                        t.Phone = obj[Model.Customer.PHONE].ToString();
                        t.InActiveYesNo = Convert.ToBoolean(obj[Model.Customer.INACTIVEYESNO]);
                        t.Balance = Convert.ToInt32(obj[Model.Customer.BALANCE]);
                        t.FormProfileCustNo = Convert.ToInt32(obj[Model.Customer.FORMPROFILECUSTNO]);
                        t.DeliveryMethodsNo = Convert.ToInt32(obj[Model.Customer.DELIVERYMETHODSNO]);
                        t.BusinessNo = Convert.ToInt32(obj[Model.Customer.BUSINESSNO]);
                        t.CustomerProfileNo = Convert.ToInt32(obj[Model.Customer.CUSTOMERPROFILENO]);
                        t.EmployeeNo = Convert.ToInt32(obj[Model.Customer.EMPLOYEENO]);
                        t.TermsOfPayCustNo = Convert.ToInt32(obj[Model.Customer.TERMSOFPAYCUSTNO]);
                        t.CustomerGrpNo = Convert.ToInt32(obj[Model.Customer.CUSTOMERGRPNO]);
                        t.DistrictNo = Convert.ToInt32(obj[Model.Customer.DISTRICTNO]);
                        t.PriceCode = Convert.ToInt32(obj[Model.Customer.PRICECODE]);
                        t.CurrencyNo = Convert.ToInt32(obj[Model.Customer.CURRENCYNO]);
                        t.CreditLimit = Convert.ToDecimal(obj[Model.Customer.CREDITLIMIT]);
                        t.CompanyNo = obj[Model.Customer.COMPANYNO].ToString();
                        t.BankAccount = obj[Model.Customer.BANKACCOUNT].ToString();
                        t.OurSupplNo = Convert.ToInt32(obj[Model.Customer.OURSUPPLNO]);
                        t.CustomerTypeNo = Convert.ToInt32(obj[Model.Customer.CUSTOMERTYPENO]);
                        t.AccessLevel = Convert.ToInt32(obj[Model.Customer.ACCESSLEVEL]);
                        t.Password = obj[Model.Customer.PASSWORD].ToString();
                        t.ChainLeaderYesNo = Convert.ToInt32(obj[Model.Customer.CHAINLEADERYESNO]);
                        t.TypeOfChain = Convert.ToInt32(obj[Model.Customer.TYPEOFCHAIN]);
                        t.ProductNo = Convert.ToInt32(obj[Model.Customer.PRODUCTNO]);
                        t.ProjectNo = Convert.ToInt32(obj[Model.Customer.PROJECTNO]);
                        t.DepNo = Convert.ToInt32(obj[Model.Customer.DEPNO]);
                        t.SupplierNo = Convert.ToInt32(obj[Model.Customer.SUPPLIERNO]);
                        t.DeliveryAddressNo = Convert.ToInt32(obj[Model.Customer.DELIVERYADDRESSNO]);
                        t.Address3 = obj[Model.Customer.ADDRESS3].ToString();
                        t.LastUpdate = Convert.ToDateTime(obj[Model.Customer.LASTUPDATE]);
                        t.ExtraCostUnitIVNo = Convert.ToInt32(obj[Model.Customer.EXTRACOSTUNITIVNO]);
                        t.ExtraCostUnitIIINo = Convert.ToInt32(obj[Model.Customer.EXTRACOSTUNITIIINO]);
                        t.ExtraCostUnitIINo = Convert.ToInt32(obj[Model.Customer.EXTRACOSTUNITIINO]);
                        t.ExtraCostUnitINo = Convert.ToInt32(obj[Model.Customer.EXTRACOSTUNITINO]);
                        t.Created = Convert.ToDateTime(obj[Model.Customer.CREATED]);
                        t.CreatedBy = Convert.ToInt32(obj[Model.Customer.CREATEDBY]);
                        t.LastUpdatedBy = Convert.ToInt32(obj[Model.Customer.LASTUPDATEDBY]);
                        t.EANLocationNo = obj[Model.Customer.EANLOCATIONNO].ToString();
                        t.CustomerBonusProfileNo = Convert.ToInt32(obj[Model.Customer.CUSTOMERBONUSPROFILENO]);
                        t.LocalGovernmentNo = Convert.ToInt32(obj[Model.Customer.LOCALGOVERNMENTNO]);
                        t.ChartererCompanyNo = Convert.ToInt32(obj[Model.Customer.CHARTERERCOMPANYNO]);
                        t.AgentNo = Convert.ToInt32(obj[Model.Customer.AGENTNO]);
                        t.CommissionProfileNo = Convert.ToInt32(obj[Model.Customer.COMMISSIONPROFILENO]);
                        t.RemittanceProfileNo = Convert.ToInt32(obj[Model.Customer.REMITTANCEPROFILENO]);
                        t.AutogiroAgreementID = obj[Model.Customer.AUTOGIROAGREEMENTID].ToString();
                        t.AgentYesNo = Convert.ToInt32(obj[Model.Customer.AGENTYESNO]);
                        t.ShipmentTypeNo = Convert.ToInt32(obj[Model.Customer.SHIPMENTTYPENO]);
                        t.RemainderOrderYesNo = Convert.ToInt32(obj[Model.Customer.REMAINDERORDERYESNO]);
                        t.AcceptReplacementArticleYesNo = Convert.ToInt32(obj[Model.Customer.ACCEPTREPLACEMENTARTICLEYESNO]);
                        t.PrintProfileNo = Convert.ToInt32(obj[Model.Customer.PRINTPROFILENO]);
                        t.PaymentPattern = Convert.ToInt32(obj[Model.Customer.PAYMENTPATTERN]);
                        t.AltPriceListYesNo = Convert.ToInt32(obj[Model.Customer.ALTPRICELISTYESNO]);
                        t.AltPriceListNo = Convert.ToInt32(obj[Model.Customer.ALTPRICELISTNO]);
                        t.InvoiceAdressNo = Convert.ToInt32(obj[Model.Customer.INVOICEADRESSNO]);
                        t.EdiProfileNo = Convert.ToInt32(obj[Model.Customer.EDIPROFILENO]);
                        t.EinvoiceStatus = Convert.ToInt32(obj[Model.Customer.EINVOICESTATUS]);
                        t.EinvoiceRef = obj[Model.Customer.EINVOICEREF].ToString();
                        t.EDISellerRefNo = obj[Model.Customer.EDISELLERREFNO].ToString();
                        t.EDIBuyerRefNo = obj[Model.Customer.EDIBUYERREFNO].ToString();
                        t.VATRegNo = obj[Model.Customer.VATREGNO].ToString();
                        t.WebshopRefNo = obj[Model.Customer.WEBSHOPREFNO].ToString();
                        t.IBAN = obj[Model.Customer.IBAN].ToString();
                        t.SwiftCodeNo = Convert.ToInt32(obj[Model.Customer.SWIFTCODENO]);
                        t.ContactNoConfirmOrder = Convert.ToInt32(obj[Model.Customer.CONTACTNOCONFIRMORDER]);
                        t.ContactNoPickingList = Convert.ToInt32(obj[Model.Customer.CONTACTNOPICKINGLIST]);
                        t.IsUpdated = true;
                        DB.vCustomers.Add(t);
                        DB.SaveChanges();
                    }
                    else
                    {
                        bool IsUpdated = false;
                        if (oldt.Name != obj[Model.Customer.NAME].ToString())
                        {
                            IsUpdated = true;
                            oldt.Name = obj[Model.Customer.NAME].ToString();
                        }
                        if (oldt.Address1 != obj[Model.Customer.ADDRESS1].ToString())
                        {
                            IsUpdated = true;
                            oldt.Address1 = obj[Model.Customer.ADDRESS1].ToString();
                        }
                        if (oldt.EmailAddress != obj[Model.Customer.EMAILADDRESS].ToString())
                        {
                            IsUpdated = true;
                            oldt.EmailAddress = obj[Model.Customer.EMAILADDRESS].ToString();
                        }
                        if (oldt.Address2 != obj[Model.Customer.ADDRESS2].ToString())
                        {
                            IsUpdated = true;
                            oldt.Address2 = obj[Model.Customer.ADDRESS2].ToString();
                        }
                        if (oldt.PostCode != obj[Model.Customer.POSTCODE].ToString())
                        {
                            IsUpdated = true;
                            oldt.PostCode = obj[Model.Customer.POSTCODE].ToString();
                        }
                        if (oldt.PostOffice != obj[Model.Customer.POSTOFFICE].ToString())
                        {
                            IsUpdated = true;
                            oldt.PostOffice = obj[Model.Customer.POSTOFFICE].ToString();
                        }
                        if (oldt.CountryNo != Convert.ToInt32(obj[Model.Customer.COUNTRYNO]))
                        {
                            IsUpdated = true;
                            oldt.CountryNo = Convert.ToInt32(obj[Model.Customer.COUNTRYNO]);
                        }
                        if (oldt.Phone != obj[Model.Customer.PHONE].ToString())
                        {
                            IsUpdated = true;
                            oldt.Phone = obj[Model.Customer.PHONE].ToString();
                        }
                        if (oldt.InActiveYesNo != Convert.ToBoolean(obj[Model.Customer.INACTIVEYESNO]))
                        {
                            IsUpdated = true;
                            oldt.InActiveYesNo = Convert.ToBoolean(obj[Model.Customer.INACTIVEYESNO]);
                        }
                        if (oldt.Balance != Convert.ToInt32(obj[Model.Customer.BALANCE]))
                        {
                            IsUpdated = true;
                            oldt.Balance = Convert.ToInt32(obj[Model.Customer.BALANCE]);
                        }
                        if (oldt.FormProfileCustNo != Convert.ToInt32(obj[Model.Customer.FORMPROFILECUSTNO]))
                        {
                            IsUpdated = true;
                            oldt.FormProfileCustNo = Convert.ToInt32(obj[Model.Customer.FORMPROFILECUSTNO]);
                        }
                        if (oldt.DeliveryMethodsNo != Convert.ToInt32(obj[Model.Customer.DELIVERYMETHODSNO]))
                        {
                            IsUpdated = true;
                            oldt.DeliveryMethodsNo = Convert.ToInt32(obj[Model.Customer.DELIVERYMETHODSNO]);
                        }
                        if (oldt.BusinessNo != Convert.ToInt32(obj[Model.Customer.BUSINESSNO]))
                        {
                            IsUpdated = true;
                            oldt.BusinessNo = Convert.ToInt32(obj[Model.Customer.BUSINESSNO]);
                        }
                        if (oldt.CustomerProfileNo != Convert.ToInt32(obj[Model.Customer.CUSTOMERPROFILENO]))
                        {
                            IsUpdated = true;
                            oldt.CustomerProfileNo = Convert.ToInt32(obj[Model.Customer.CUSTOMERPROFILENO]);
                        }
                        if (oldt.EmployeeNo != Convert.ToInt32(obj[Model.Customer.EMPLOYEENO]))
                        {
                            IsUpdated = true;
                            oldt.EmployeeNo = Convert.ToInt32(obj[Model.Customer.EMPLOYEENO]);
                        }
                        if (oldt.TermsOfPayCustNo != Convert.ToInt32(obj[Model.Customer.TERMSOFPAYCUSTNO]))
                        {
                            IsUpdated = true;
                            oldt.TermsOfPayCustNo = Convert.ToInt32(obj[Model.Customer.TERMSOFPAYCUSTNO]);
                        }
                        if (oldt.CustomerGrpNo != Convert.ToInt32(obj[Model.Customer.CUSTOMERGRPNO]))
                        {
                            IsUpdated = true;
                            oldt.CustomerGrpNo = Convert.ToInt32(obj[Model.Customer.CUSTOMERGRPNO]);
                        }
                        if (oldt.DistrictNo != Convert.ToInt32(obj[Model.Customer.DISTRICTNO]))
                        {
                            IsUpdated = true;
                            oldt.DistrictNo = Convert.ToInt32(obj[Model.Customer.DISTRICTNO]);
                        }
                        if (oldt.PriceCode != Convert.ToInt32(obj[Model.Customer.PRICECODE]))
                        {
                            IsUpdated = true;
                            oldt.PriceCode = Convert.ToInt32(obj[Model.Customer.PRICECODE]);
                        }
                        if (oldt.CurrencyNo != Convert.ToInt32(obj[Model.Customer.CURRENCYNO]))
                        {
                            IsUpdated = true;
                            oldt.CurrencyNo = Convert.ToInt32(obj[Model.Customer.CURRENCYNO]);
                        }
                        if (oldt.CreditLimit != Convert.ToDecimal(obj[Model.Customer.CREDITLIMIT]))
                        {
                            IsUpdated = true;
                            oldt.CreditLimit = Convert.ToDecimal(obj[Model.Customer.CREDITLIMIT]);
                        }
                        if (oldt.CompanyNo != obj[Model.Customer.COMPANYNO].ToString())
                        {
                            IsUpdated = true;
                            oldt.CompanyNo = obj[Model.Customer.COMPANYNO].ToString();
                        }
                        if (oldt.BankAccount != obj[Model.Customer.BANKACCOUNT].ToString())
                        {
                            IsUpdated = true;
                            oldt.BankAccount = obj[Model.Customer.BANKACCOUNT].ToString();
                        }
                        if (oldt.OurSupplNo != Convert.ToInt32(obj[Model.Customer.OURSUPPLNO]))
                        {
                            IsUpdated = true;
                            oldt.OurSupplNo = Convert.ToInt32(obj[Model.Customer.OURSUPPLNO]);
                        }
                        if (oldt.CustomerTypeNo != Convert.ToInt32(obj[Model.Customer.CUSTOMERTYPENO]))
                        {
                            IsUpdated = true;
                            oldt.CustomerTypeNo = Convert.ToInt32(obj[Model.Customer.CUSTOMERTYPENO]);
                        }
                        if (oldt.AccessLevel != Convert.ToInt32(obj[Model.Customer.ACCESSLEVEL]))
                        {
                            IsUpdated = true;
                            oldt.AccessLevel = Convert.ToInt32(obj[Model.Customer.ACCESSLEVEL]);
                        }
                        if (oldt.Password != obj[Model.Customer.PASSWORD].ToString())
                        {
                            IsUpdated = true;
                            oldt.Password = obj[Model.Customer.PASSWORD].ToString();
                        }
                        if (oldt.ChainLeaderYesNo != Convert.ToInt32(obj[Model.Customer.CHAINLEADERYESNO]))
                        {
                            IsUpdated = true;
                            oldt.ChainLeaderYesNo = Convert.ToInt32(obj[Model.Customer.CHAINLEADERYESNO]);
                        }
                        if (oldt.TypeOfChain != Convert.ToInt32(obj[Model.Customer.TYPEOFCHAIN]))
                        {
                            IsUpdated = true;
                            oldt.TypeOfChain = Convert.ToInt32(obj[Model.Customer.TYPEOFCHAIN]);
                        }
                        if (oldt.ProductNo != Convert.ToInt32(obj[Model.Customer.PRODUCTNO]))
                        {
                            IsUpdated = true;
                            oldt.ProductNo = Convert.ToInt32(obj[Model.Customer.PRODUCTNO]);
                        }
                        if (oldt.DepNo != Convert.ToInt32(obj[Model.Customer.DEPNO]))
                        {
                            IsUpdated = true;
                            oldt.DepNo = Convert.ToInt32(obj[Model.Customer.DEPNO]);
                        }
                        if (oldt.SupplierNo != Convert.ToInt32(obj[Model.Customer.SUPPLIERNO]))
                        {
                            IsUpdated = true;
                            oldt.SupplierNo = Convert.ToInt32(obj[Model.Customer.SUPPLIERNO]);
                        }
                        if (oldt.DeliveryAddressNo != Convert.ToInt32(obj[Model.Customer.DELIVERYADDRESSNO]))
                        {
                            IsUpdated = true;
                            oldt.DeliveryAddressNo = Convert.ToInt32(obj[Model.Customer.DELIVERYADDRESSNO]);
                        }
                        if (oldt.Address3 != obj[Model.Customer.ADDRESS3].ToString())
                        {
                            IsUpdated = true;
                            oldt.Address3 = obj[Model.Customer.ADDRESS3].ToString();
                        }
                        if (oldt.LastUpdate != Convert.ToDateTime(obj[Model.Customer.LASTUPDATE]))
                        {
                            IsUpdated = true;
                            oldt.LastUpdate = Convert.ToDateTime(obj[Model.Customer.LASTUPDATE]);
                        }
                        if (oldt.ExtraCostUnitIVNo != Convert.ToInt32(obj[Model.Customer.EXTRACOSTUNITIVNO]))
                        {
                            IsUpdated = true;
                            oldt.ExtraCostUnitIVNo = Convert.ToInt32(obj[Model.Customer.EXTRACOSTUNITIVNO]);
                        }
                        if (oldt.ExtraCostUnitIIINo != Convert.ToInt32(obj[Model.Customer.EXTRACOSTUNITIIINO]))
                        {
                            IsUpdated = true;
                            oldt.ExtraCostUnitIIINo = Convert.ToInt32(obj[Model.Customer.EXTRACOSTUNITIIINO]);
                        }
                        if (oldt.ExtraCostUnitIINo != Convert.ToInt32(obj[Model.Customer.EXTRACOSTUNITIINO]))
                        {
                            IsUpdated = true;
                            oldt.ExtraCostUnitIINo = Convert.ToInt32(obj[Model.Customer.EXTRACOSTUNITIINO]);
                        }
                        if (oldt.ExtraCostUnitINo != Convert.ToInt32(obj[Model.Customer.EXTRACOSTUNITINO]))
                        {
                            IsUpdated = true;
                            oldt.ExtraCostUnitINo = Convert.ToInt32(obj[Model.Customer.EXTRACOSTUNITINO]);
                        }
                        if (oldt.Created != Convert.ToDateTime(obj[Model.Customer.CREATED]))
                        {
                            IsUpdated = true;
                            oldt.Created = Convert.ToDateTime(obj[Model.Customer.CREATED]);
                        }
                        if (oldt.CreatedBy != Convert.ToInt32(obj[Model.Customer.CREATEDBY]))
                        {
                            IsUpdated = true;
                            oldt.CreatedBy = Convert.ToInt32(obj[Model.Customer.CREATEDBY]);
                        }
                        if (oldt.LastUpdatedBy != Convert.ToInt32(obj[Model.Customer.LASTUPDATEDBY]))
                        {
                            IsUpdated = true;
                            oldt.LastUpdatedBy = Convert.ToInt32(obj[Model.Customer.LASTUPDATEDBY]);
                        }
                        if (oldt.EANLocationNo != obj[Model.Customer.EANLOCATIONNO].ToString())
                        {
                            IsUpdated = true;
                            oldt.EANLocationNo = obj[Model.Customer.EANLOCATIONNO].ToString();
                        }
                        if (oldt.CustomerBonusProfileNo != Convert.ToDecimal(obj[Model.Customer.CUSTOMERBONUSPROFILENO]))
                        {
                            IsUpdated = true;
                            oldt.CustomerBonusProfileNo = Convert.ToInt32(obj[Model.Customer.CUSTOMERBONUSPROFILENO]);
                        }
                        if (oldt.LocalGovernmentNo != Convert.ToInt32(obj[Model.Customer.LOCALGOVERNMENTNO]))
                        {
                            IsUpdated = true;
                            oldt.LocalGovernmentNo = Convert.ToInt32(obj[Model.Customer.LOCALGOVERNMENTNO]);
                        }
                        if (oldt.ChartererCompanyNo != Convert.ToInt32(obj[Model.Customer.CHARTERERCOMPANYNO]))
                        {
                            IsUpdated = true;
                            oldt.ChartererCompanyNo = Convert.ToInt32(obj[Model.Customer.CHARTERERCOMPANYNO]);
                        }
                        if (oldt.AgentNo != Convert.ToInt32(obj[Model.Customer.AGENTNO]))
                        {
                            IsUpdated = true;
                            oldt.AgentNo = Convert.ToInt32(obj[Model.Customer.AGENTNO]);
                        }
                        if (oldt.CommissionProfileNo != Convert.ToInt32(obj[Model.Customer.COMMISSIONPROFILENO]))
                        {
                            IsUpdated = true;
                            oldt.CommissionProfileNo = Convert.ToInt32(obj[Model.Customer.COMMISSIONPROFILENO]);
                        }
                        if (oldt.RemittanceProfileNo != Convert.ToInt32(obj[Model.Customer.REMITTANCEPROFILENO]))
                        {
                            IsUpdated = true;
                            oldt.RemittanceProfileNo = Convert.ToInt32(obj[Model.Customer.REMITTANCEPROFILENO]);
                        }
                        if (oldt.AutogiroAgreementID != obj[Model.Customer.AUTOGIROAGREEMENTID].ToString())
                        {
                            IsUpdated = true;
                            oldt.AutogiroAgreementID = obj[Model.Customer.AUTOGIROAGREEMENTID].ToString();
                        }
                        if (oldt.AgentYesNo != Convert.ToInt32(obj[Model.Customer.AGENTYESNO]))
                        {
                            IsUpdated = true;
                            oldt.AgentYesNo = Convert.ToInt32(obj[Model.Customer.AGENTYESNO]);
                        }
                        if (oldt.ShipmentTypeNo != Convert.ToInt32(obj[Model.Customer.SHIPMENTTYPENO]))
                        {
                            IsUpdated = true;
                            oldt.ShipmentTypeNo = Convert.ToInt32(obj[Model.Customer.SHIPMENTTYPENO]);
                        }
                        if (oldt.RemainderOrderYesNo != Convert.ToInt32(obj[Model.Customer.REMAINDERORDERYESNO]))
                        {
                            IsUpdated = true;
                            oldt.RemainderOrderYesNo = Convert.ToInt32(obj[Model.Customer.REMAINDERORDERYESNO]);
                        }
                        if (oldt.AcceptReplacementArticleYesNo != Convert.ToInt32(obj[Model.Customer.ACCEPTREPLACEMENTARTICLEYESNO]))
                        {
                            IsUpdated = true;
                            oldt.AcceptReplacementArticleYesNo = Convert.ToInt32(obj[Model.Customer.ACCEPTREPLACEMENTARTICLEYESNO]);
                        }
                        if (oldt.PrintProfileNo != Convert.ToInt32(obj[Model.Customer.PRINTPROFILENO]))
                        {
                            IsUpdated = true;
                            oldt.PrintProfileNo = Convert.ToInt32(obj[Model.Customer.PRINTPROFILENO]);
                        }
                        if (oldt.PaymentPattern != Convert.ToInt32(obj[Model.Customer.PAYMENTPATTERN]))
                        {
                            IsUpdated = true;
                            oldt.PaymentPattern = Convert.ToInt32(obj[Model.Customer.PAYMENTPATTERN]);
                        }
                        if (oldt.AltPriceListYesNo != Convert.ToInt32(obj[Model.Customer.ALTPRICELISTYESNO]))
                        {
                            IsUpdated = true;
                            oldt.AltPriceListYesNo = Convert.ToInt32(obj[Model.Customer.ALTPRICELISTYESNO]);
                        }
                        if (oldt.AltPriceListNo != Convert.ToInt32(obj[Model.Customer.ALTPRICELISTNO]))
                        {
                            IsUpdated = true;
                            oldt.AltPriceListNo = Convert.ToInt32(obj[Model.Customer.ALTPRICELISTNO]);
                        }
                        if (oldt.InvoiceAdressNo != Convert.ToInt32(obj[Model.Customer.INVOICEADRESSNO]))
                        {
                            IsUpdated = true;
                            oldt.InvoiceAdressNo = Convert.ToInt32(obj[Model.Customer.INVOICEADRESSNO]);
                        }
                        if (oldt.EdiProfileNo != Convert.ToInt32(obj[Model.Customer.EDIPROFILENO]))
                        {
                            IsUpdated = true;
                            oldt.EdiProfileNo = Convert.ToInt32(obj[Model.Customer.EDIPROFILENO]);
                        }
                        if (oldt.EinvoiceStatus != Convert.ToInt32(obj[Model.Customer.EINVOICESTATUS]))
                        {
                            IsUpdated = true;
                            oldt.EinvoiceStatus = Convert.ToInt32(obj[Model.Customer.EINVOICESTATUS]);
                        }
                        if (oldt.EinvoiceRef != obj[Model.Customer.EINVOICEREF].ToString())
                        {
                            IsUpdated = true;
                            oldt.EinvoiceRef = obj[Model.Customer.EINVOICEREF].ToString();
                        }
                        if (oldt.EDISellerRefNo != obj[Model.Customer.EDISELLERREFNO].ToString())
                        {
                            IsUpdated = true;
                            oldt.EDISellerRefNo = obj[Model.Customer.EDISELLERREFNO].ToString();
                        }
                        if (oldt.EDIBuyerRefNo != obj[Model.Customer.EDIBUYERREFNO].ToString())
                        {
                            IsUpdated = true;
                            oldt.EDIBuyerRefNo = obj[Model.Customer.EDIBUYERREFNO].ToString();
                        }
                        if (oldt.VATRegNo != obj[Model.Customer.VATREGNO].ToString())
                        {
                            IsUpdated = true;
                            oldt.VATRegNo = obj[Model.Customer.VATREGNO].ToString();
                        }
                        if (oldt.WebshopRefNo != obj[Model.Customer.WEBSHOPREFNO].ToString())
                        {
                            IsUpdated = true;
                            oldt.WebshopRefNo = obj[Model.Customer.WEBSHOPREFNO].ToString();
                        }
                        if (oldt.IBAN != obj[Model.Customer.IBAN].ToString())
                        {
                            IsUpdated = true;
                            oldt.IBAN = obj[Model.Customer.IBAN].ToString();
                        }
                        if (oldt.SwiftCodeNo != Convert.ToInt32(obj[Model.Customer.SWIFTCODENO]))
                        {
                            IsUpdated = true;
                            oldt.SwiftCodeNo = Convert.ToInt32(obj[Model.Customer.SWIFTCODENO]);
                        }
                        if (oldt.ContactNoConfirmOrder != Convert.ToInt32(obj[Model.Customer.CONTACTNOCONFIRMORDER]))
                        {
                            IsUpdated = true;
                            oldt.ContactNoConfirmOrder = Convert.ToInt32(obj[Model.Customer.CONTACTNOCONFIRMORDER]);
                        }
                        if (oldt.ContactNoPickingList != Convert.ToInt32(obj[Model.Customer.CONTACTNOPICKINGLIST]))
                        {
                            IsUpdated = true;
                            oldt.ContactNoPickingList = Convert.ToInt32(obj[Model.Customer.CONTACTNOPICKINGLIST]);
                        }
                        if (IsUpdated)
                        {
                            oldt.IsUpdated = IsUpdated;
                            DB.SaveChanges();
                        }
                    }
                    if (!(obj[CustomersCustomFields.ARRAY_CUSTOMERS_CUSTOM_FIELDS] is JArray)) return;
                    var col = (JArray)obj[CustomersCustomFields.ARRAY_CUSTOMERS_CUSTOM_FIELDS];
                    if (col != null)
                    {
                        foreach (JObject o in col)
                            this.AddCustomFields(o, CustomerNo);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void AddCustomFields(JObject obj, int CustomerNo)
        {
            try
            {
                using (Admin.DBLayer.ICONEntities2 DB = new Admin.DBLayer.ICONEntities2())
                {
                    var Id = Convert.ToInt32(obj[CustomersCustomFields.ID]);
                    var oldt = DB.vCustomerCustomFields.Where(u => u.CustomerNo == CustomerNo && u.Id == Id).FirstOrDefault();
                    if (oldt == null)
                    {
                        var t = new Admin.DBLayer.vCustomerCustomField();
                        t.CustomField = Guid.NewGuid();
                        t.CustomerNo = CustomerNo;
                        t.Id = Convert.ToInt32(obj[CustomersCustomFields.ID]);
                        t.Name = obj[CustomersCustomFields.NAME].ToString();
                        t.Value = obj[CustomersCustomFields.VALUE].ToString();
                        t.IsUpdated = true;
                        DB.vCustomerCustomFields.Add(t);
                        DB.SaveChanges();
                    }
                    else
                    {
                        bool IsUpdated = false;
                        if (oldt.Name != obj[CustomersCustomFields.NAME].ToString())
                        {
                            IsUpdated = true;
                            oldt.Name = obj[CustomersCustomFields.NAME].ToString();
                        }
                        if (oldt.Value != obj[CustomersCustomFields.VALUE].ToString())
                        {
                            IsUpdated = true;
                            oldt.Value = obj[CustomersCustomFields.VALUE].ToString();
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

        public void  UpdateCustomer()
        {
            try
            {
                using (Admin.DBLayer.ICONEntities2 DB = new Admin.DBLayer.ICONEntities2())
                {
                    var vcustomers = DB.vCustomers.Where(u =>  u.EmailAddress != "" && u.IsUpdated==true).ToList();
                    foreach (var v in vcustomers)
                    {
                        try
                        {
                            var t = DB.tblCustomers.Where(u => u.CustomerNo == v.CustomerNo).FirstOrDefault();
                            using (Admin.DBLayer.ICONEntities2 DB2 = new Admin.DBLayer.ICONEntities2())
                            {
                                if (t == null)
                                {

                                    var CustomerId = Guid.NewGuid();
                                    var c = new Admin.DBLayer.AspNetUser();
                                    c.Id = Guid.NewGuid().ToString();
                                    c.Email = v.EmailAddress;
                                    c.EmailConfirmed = false;
                                    c.PasswordHash = "ANh25QQtU/QcoqiLgCVWlMpAD74xYGzljT+xr+2aYSpDjmRHLUQWsivHL+naolCpiQ==";
                                    c.SecurityStamp = Guid.NewGuid().ToString();
                                    c.PhoneNumber = null;
                                    c.PhoneNumberConfirmed = false;
                                    c.TwoFactorEnabled = false;
                                    c.LockoutEndDateUtc = null;
                                    c.LockoutEnabled = true;
                                    c.AccessFailedCount = 0;
                                    c.UserName = v.EmailAddress;
                                    c.CustomerId = CustomerId;
                                    c.StatusId = v.InActiveYesNo == true ? new Guid(Utilities.Status_Online) : new Guid(Utilities.Status_Block);
                                    DB2.AspNetUsers.Add(c);
                                    DB2.SaveChanges();

                                    t = new Admin.DBLayer.tblCustomer();
                                    t.Address1 = v.Address1;
                                    t.Address2 = v.Address2;
                                    t.BankAccount = v.BankAccount;
                                    t.ContactNoConfirmOrder = Convert.ToString(v.ContactNoConfirmOrder);
                                    t.CreateBy = "VISMA";
                                    t.CreationDate = DateTime.Now;
                                    t.CreditLimit = v.CreditLimit;
                                    t.CustomerId = CustomerId;
                                    t.CustomerNo = v.CustomerNo;
                                    t.City = v.Address3;
                                    t.CountryId = new Guid("2A8B3E38-7D7F-4A43-B38B-1CC19FB2D144");
                                    t.CurrencyId = new Guid("34DD283F-DD4B-4A55-AA26-505245FDB52C"); 
                                    t.Email = v.EmailAddress;
                                    t.IBAN = v.IBAN;
                                    t.IsUser = false;
                                    t.IsVISMA = true;
                                    t.Name = v.Name;
                                    t.OrganizationNumber = v.CompanyNo;
                                    t.Phone = v.Phone;
                                    t.PostOffice = v.PostOffice;
                                    t.StatusId = v.InActiveYesNo == true?new Guid(Utilities.Status_Online): new Guid(Utilities.Status_Block);
                                    t.SwiftCode = Convert.ToString(v.SwiftCodeNo);
                                    t.UserName = v.EmailAddress;
                                    DB2.tblCustomers.Add(t);
                                    DB2.SaveChanges();

                                    var tblru = new Admin.DBLayer.tblRoleUser();
                                    tblru.RoleUserId = Guid.NewGuid();
                                    tblru.RoleId = new Guid(Utilities.Role_Customer);
                                    tblru.UserName = v.EmailAddress;
                                    tblru.CreateBy = "VISMA";
                                    tblru.CreationDate = DateTime.Now;
                                    DB2.tblRoleUsers.Add(tblru);
                                    DB2.SaveChanges();

                                }
                                else
                                {
                                    t.Address1 = v.Address1;
                                    t.Address2 = v.Address2;
                                    t.BankAccount = v.BankAccount;
                                    t.ContactNoConfirmOrder = Convert.ToString(v.ContactNoConfirmOrder);
                                    t.ModifyBy = "VISMA";
                                    t.ModifyDate = DateTime.Now;
                                    t.CreditLimit = v.CreditLimit;
                                    t.Email = v.EmailAddress;
                                    t.IBAN = v.IBAN;
                                    t.IsVISMA = true;
                                    t.Name = v.Name;
                                    t.OrganizationNumber = v.CompanyNo;
                                    t.Phone = v.Phone;
                                    t.PostOffice = v.PostOffice;
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

        public void UpdateShippingAddress()
        {
            try
            {
                using (Admin.DBLayer.ICONEntities2 DB = new Admin.DBLayer.ICONEntities2())
                {
                    var vCustomerAddresses = DB.vCustomerAddresses.Where(u => u.IsUpdated ==true).ToList();
                    foreach (var v in vCustomerAddresses)
                    {
                        try
                        {
                            var c = DB.tblCustomers.Where(u => u.CustomerNo == v.CustomerNo).FirstOrDefault();
                            if (c != null)
                            {
                                var t = DB.tblCustomerShippings.Where(u => u.AddressId == v.Id).FirstOrDefault();
                                using (Admin.DBLayer.ICONEntities2 DB2 = new Admin.DBLayer.ICONEntities2())
                                {
                                    if (t == null)
                                    {
                                        t = new Admin.DBLayer.tblCustomerShipping();
                                        t.Address1 = v.InvoiceAdress1;
                                        t.Address2 = v.InvoiceAdress2;
                                        t.AddressId = v.Id;
                                        t.City = v.InvoiceAdress3;
                                        t.CountryId = new Guid("2A8B3E38-7D7F-4A43-B38B-1CC19FB2D144");
                                        t.CustomerId = c.CustomerId;
                                        t.CustomerShippingId = Guid.NewGuid();
                                        t.CreateBy = "VISMA";
                                        t.CreationDate = DateTime.Now;
                                        t.IsVISMA = true;
                                        t.Name = v.Name;
                                        t.PostOffice = v.PostOffice;
                                        t.StatusId = new Guid(Utilities.Status_Active); 
                                        DB2.tblCustomerShippings.Add(t);
                                        DB2.SaveChanges();
                                    }
                                    else
                                    {
                                        t.Address1 = v.InvoiceAdress1;
                                        t.Address2 = v.InvoiceAdress2;
                                        t.AddressId = v.Id;
                                        t.City = v.InvoiceAdress3;
                                        t.CountryId = new Guid("2A8B3E38-7D7F-4A43-B38B-1CC19FB2D144");
                                        t.IsVISMA = true;
                                        t.Name = v.Name;
                                        t.PostOffice = v.PostOffice;
                                        t.StatusId =  new Guid(Utilities.Status_Active);
                                        t.ModifyBy = "VISMA";
                                        t.ModifyDate = DateTime.Now;
                                        DB2.SaveChanges();
                                    }
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

    public class CustomersAddresses
    {
        private string urlParameters = "";
        public async Task GetCustomerAddressses()
        {
            try
            {
                using (Admin.DBLayer.ICONEntities2 DB = new Admin.DBLayer.ICONEntities2())
                {
                    var customers = DB.vCustomers.ToList();
                    foreach (var customer in customers)
                    {
                        HttpClient client = new HttpClient();
                        var URL = Utilities.URL + "customers/" + customer.CustomerNo +"/adresses/delivery";
                        client.BaseAddress = new Uri(URL);
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage response = client.GetAsync(urlParameters).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var json = await response.Content.ReadAsAsync<JObject>();
                            if (json[CustomersAddress.ARRAY_CUSTOMERS_ADRESSES] is JArray)
                            {
                                var col = (JArray)json[CustomersAddress.ARRAY_CUSTOMERS_ADRESSES];
                                foreach (JObject obj in col)
                                    this.AddCustomerAddress(obj, customer.CustomerNo);
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

        private void AddCustomerAddress(JObject obj, int CustomerNo)
        {
            try
            {
                using (Admin.DBLayer.ICONEntities2 DB = new Admin.DBLayer.ICONEntities2())
                {
                    var ID = Convert.ToInt32(obj[CustomersAddress.ID]);
                    var oldt = DB.vCustomerAddresses.Where(u => u.Id  == ID).FirstOrDefault();
                    if (oldt == null)
                    {
                        var t = new Admin.DBLayer.vCustomerAddress();
                        t.CustomerNo = CustomerNo;
                        t.Id = ID;
                        t.Name = obj[CustomersAddress.NAME].ToString();
                        t.InvoiceAdress1 = obj[CustomersAddress.InvoiceAdress1].ToString();
                        t.InvoiceAdress2 = obj[CustomersAddress.InvoiceAdress2].ToString();
                        t.InvoiceAdress3 = obj[CustomersAddress.InvoiceAdress3].ToString();
                        t.PostCode = obj[CustomersAddress.PostCode].ToString();
                        t.PostOffice = obj[CustomersAddress.PostOffice].ToString();
                        t.IsUpdated = true; 
                        DB.vCustomerAddresses.Add(t);
                        DB.SaveChanges();
                    }
                    else
                    {
                        bool IsUpdated = false;
                        if (oldt.Name != obj[CustomersAddress.NAME].ToString())
                        {
                            IsUpdated = true;
                            oldt.Name = obj[CustomersAddress.NAME].ToString();
                        }
                        if (oldt.InvoiceAdress1 != obj[CustomersAddress.InvoiceAdress1].ToString())
                        {
                            IsUpdated = true;
                            oldt.InvoiceAdress1 = obj[CustomersAddress.InvoiceAdress1].ToString();
                        }
                        if (oldt.InvoiceAdress2 != obj[CustomersAddress.InvoiceAdress2].ToString())
                        {
                            IsUpdated = true;
                            oldt.InvoiceAdress2 = obj[CustomersAddress.InvoiceAdress2].ToString();
                        }
                        if (oldt.InvoiceAdress3 != obj[CustomersAddress.InvoiceAdress3].ToString())
                        {
                            IsUpdated = true;
                            oldt.InvoiceAdress3 = obj[CustomersAddress.InvoiceAdress3].ToString();
                        }
                        if (oldt.PostCode != obj[CustomersAddress.PostCode].ToString())
                        {
                            IsUpdated = true;
                            oldt.PostCode = obj[CustomersAddress.PostCode].ToString();
                        }
                        if (oldt.PostOffice != obj[CustomersAddress.PostOffice].ToString())
                        {
                            IsUpdated = true;
                            oldt.PostOffice = obj[CustomersAddress.PostOffice].ToString();
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
