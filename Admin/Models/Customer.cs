using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Models
{

    public class ProfileModel
    {
        public Customer customer { get; set; }
        public ResetPasswordViewModel Reset { get; set; }
    }
    public class Customer
    {

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [RegularExpression("([a-z]|[A-Z]|[0-9]|[\\W]){4}[a-zA-Z0-9\\W]{3,11}", ErrorMessage = "Invalid password format")]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Name *")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Organization Name *")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string OrganizationName { get; set; }
        [Required]
        [Display(Name = "Organization Number *")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        [StringLength(260, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string OrganizationNumber { get; set; }
        [StringLength(1024, ErrorMessage = "The {0} must be at least {2} characters long.")]
        [Required]
        [Display(Name = "Address line 1 *")]
        public string Address1 { get; set; }
        [StringLength(1024, ErrorMessage = "The {0} must be at least {2} characters long.")]
        [Display(Name = "Address line 2")]
        public string Address2 { get; set; }
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string City { get; set; }
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        [Display(Name = "Post Office")]
        public string PostOffice { get; set; }
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Kommune { get; set; }
       
        public Guid? CountryId { get; set; }
        [Required]
        [Display(Name = "Phone *")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Phone { get; set; }
        public Guid CustomerId { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email *")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Email { get; set; }

        [Display(Name = "Credit Limit")]
        [DataType(DataType.Currency)]
        public decimal? CreditLimit { get; set; }
        [Display(Name = "Bank Account")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string BankAccount { get; set; }
        [Display(Name = "IBAN")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string IBAN { get; set; }
        [Display(Name = "Swift Code")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string SwiftCode { get; set; }
        [Display(Name = "Contact No Confirm Order")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string ContactNoConfirmOrder { get; set; }
        public Guid? StatusId { get; set; }
        public bool IsVISMA { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyDate { get; set; }
        public Guid? FileId { get; set; }
        public List<File> File { get; set; }
        public string userName { get; set; }

        public String myStatus { get; set; }
        public List<SelectListItem> status = new List<SelectListItem>();
        public List<SelectListItem> Status
        {
            get
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    Guid StatusType_CURD = new Guid(Utilities.StatusType_CURD);

                    var st = from g in DB.tblStatus
                             where g.StatusTypeId ==  new Guid(Utilities.StatusType_User)
                             select new { g.StatusId, g.Name };

                    foreach (var q in st)
                    {
                        status.Add(new SelectListItem() { Text = q.Name, Value = q.StatusId.ToString() });
                    }
                    return status;
                }
            }
        }

        public String myCountry { get; set; }
        public List<SelectListItem> country = new List<SelectListItem>();
        public List<SelectListItem> Country
        {
            get
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {

                    var ct = (from c in DB.tblCountries
                             where c.StatusId != new Guid(Utilities.Status_Delete)
                             select new { c.CountryId ,c.Name,c.DisplayOrder  }).OrderBy(x => x.DisplayOrder); ;

                    foreach (var q in ct)
                    {
                        country.Add(new SelectListItem() { Text = q.Name, Value = q.CountryId.ToString() });
                    }
                    return country;
                }
            }
        }
        public Guid? CurrencyId { get; set; }
        public String myCurrency { get; set; }
        public List<SelectListItem> currency = new List<SelectListItem>();
        public List<SelectListItem> Currency
        {
            get
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {

                    var ct = (from c in DB.tblCurrencies
                              where c.StatusId != new Guid(Utilities.Status_Delete)
                              select new { c.CurrencyId, c.Name, c.DisplayOrder }).OrderBy(x => x.DisplayOrder); ;

                    foreach (var q in ct)
                    {
                        currency.Add(new SelectListItem() { Text = q.Name, Value = q.CurrencyId.ToString() });
                    }
                    return currency;
                }
            }
        }

        public Guid? EmployeeId { get; set; }
        public String myEmployee { get; set; }
        public List<SelectListItem> employee = new List<SelectListItem>();
        public List<SelectListItem> Employee
        {
            get
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {

                    var ct = (from c in DB.tblEmployees
                              where c.StatusId != new Guid(Utilities.Status_Delete)
                              select new { c.EmployeeId, c.Name, c.DisplayOrder }).OrderBy(x => x.DisplayOrder); ;

                    foreach (var q in ct)
                    {
                        employee.Add(new SelectListItem() { Text = q.Name, Value = q.EmployeeId.ToString() });
                    }
                    return employee;
                }
            }
        }
        public List<Role> role = new List<Role>();
        public List<Role> Role
        {
            get
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {

                    var r = (from c in DB.tblRoles 
                              where c.StatusId != new Guid(Utilities.Status_Delete)
                              select new { c.RoleId , c.Name }).OrderBy(x => x.Name); ;

                    foreach (var q in r)
                    {
                        role.Add(new Role() {
                            RoleId = q.RoleId,
                            Name = q.Name,
                            IsAllow = DB.tblRoleUsers.Where(u => u.RoleId == q.RoleId && u.UserName == this.userName).FirstOrDefault() == null ? false : true
                        });
                    }
                    return role;
                }
            }

        }

    }

    public class Registration
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [RegularExpression("([a-z]|[A-Z]|[0-9]|[\\W]){4}[a-zA-Z0-9\\W]{3,11}", ErrorMessage = "Minimum 6 characters in length Contains 1 /2 of the following items:<br>-Uppercase Letters<br>- Lowercase Letters<br>- Numbers<br>- Symbols")]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        [Display(Name = "Name")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Organization Name")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string OrganizationName { get; set; }
        [Required]
        [Display(Name = "Organization Number")]
        [StringLength(260, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string OrganizationNumber { get; set; }
        [StringLength(1024, ErrorMessage = "The {0} must be at least {2} characters long.")]
        [Display(Name = "Address line 1")]
        public string Address1 { get; set; }
        [StringLength(1024, ErrorMessage = "The {0} must be at least {2} characters long.")]
        [Display(Name = "Address line 2")]
        public string Address2 { get; set; }
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string City { get; set; }
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        [Display(Name = "Post Office")]
        public string PostOffice { get; set; }
        public Guid? CountryId { get; set; }
        [Display(Name = "Phone *")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Phone { get; set; }
        public Guid CustomerId { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Email { get; set; }
        public Guid? StatusId { get; set; }
        public bool IsVISMA { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public string userName { get; set; }

        public String myCountry { get; set; }
        public List<SelectListItem> country = new List<SelectListItem>();
        public List<SelectListItem> Country
        {
            get
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {

                    var ct = (from c in DB.tblCountries
                              where c.StatusId != new Guid(Utilities.Status_Delete)
                              select new { c.CountryId, c.Name,c.DisplayOrder }).OrderBy(x => x.DisplayOrder); ;

                    foreach (var q in ct)
                    {
                        country.Add(new SelectListItem() { Text = q.Name, Value = q.CountryId.ToString() });
                    }
                    return country;
                }
            }
        }

    }


    public class CustomerShipping
    {
        [Required]
        [Display(Name = "Name *")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Name { get; set; }
        [StringLength(1024, ErrorMessage = "The {0} must be at least {2} characters long.")]
        [Display(Name = "Address line 1")]
        public string Address1 { get; set; }
        [StringLength(1024, ErrorMessage = "The {0} must be at least {2} characters long.")]
        [Display(Name = "Address line 2")]
        public string Address2 { get; set; }
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string City { get; set; }
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        [Display(Name = "Post Office")]
        public string PostOffice { get; set; }
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Kommune { get; set; }

        public Guid? CountryId { get; set; }
        [Required]
        [Display(Name = "Phone *")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Phone { get; set; }
        public Guid CustomerId { get; set; }
        public String CustomerName { get; set; }
        public Guid CustomerShippingId { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email *")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Email { get; set; }

        public Guid? StatusId { get; set; }
        public bool IsVISMA { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyDate { get; set; }
        public String myStatus { get; set; }
        public List<SelectListItem> status = new List<SelectListItem>();
        public List<SelectListItem> Status
        {
            get
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    Guid StatusType_CURD = new Guid(Utilities.StatusType_CURD);

                    var st = from g in DB.tblStatus
                             where g.StatusTypeId == new Guid(Utilities.StatusType_CURD)
                             select new { g.StatusId, g.Name };

                    foreach (var q in st)
                    {
                        status.Add(new SelectListItem() { Text = q.Name, Value = q.StatusId.ToString() });
                    }
                    return status;
                }
            }
        }

        public String myCountry { get; set; }
        public List<SelectListItem> country = new List<SelectListItem>();
        public List<SelectListItem> Country
        {
            get
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {

                    var ct = (from c in DB.tblCountries
                              where c.StatusId != new Guid(Utilities.Status_Delete)
                              select new { c.CountryId, c.Name, c.DisplayOrder  }).OrderBy(x => x.DisplayOrder); ;

                    foreach (var q in ct)
                    {
                        country.Add(new SelectListItem() { Text = q.Name, Value = q.CountryId.ToString() });
                    }
                    return country;
                }
            }
        }
    }

    public class vCustomer
    {
        public int CustomerNo { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string EmailAddress { get; set; }
        public string Address2 { get; set; }
        public string PostCode { get; set; }
        public string PostOffice { get; set; }
        public int CountryNo { get; set; }
        public string Phone { get; set; }
        public bool InActiveYesNo { get; set; }
        public int Balance { get; set; }
        public int FormProfileCustNo { get; set; }
        public int DeliveryMethodsNo { get; set; }
        public int BusinessNo { get; set; }
        public int CustomerProfileNo { get; set; }
        public int EmployeeNo { get; set; }
        public int TermsOfPayCustNo { get; set; }
        public int CustomerGrpNo { get; set; }
        public int DistrictNo { get; set; }
        public int PriceCode { get; set; }
        public int CurrencyNo { get; set; }
        public int CreditLimit { get; set; }
        public string CompanyNo { get; set; }
        public string BankAccount { get; set; }
        public int OurSupplNo { get; set; }
        public int CustomerTypeNo { get; set; }
        public int AccessLevel { get; set; }
        public string Password { get; set; }
        public bool ChainLeaderYesNo { get; set; }
        public int TypeOfChain { get; set; }
        public int ProductNo { get; set; }
        public int ProjectNo { get; set; }
        public int DepNo { get; set; }
        public int SupplierNo { get; set; }
        public int DeliveryAddressNo { get; set; }
        public string Address3 { get; set; }
        public int ExtraCostUnitIVNo { get; set; }
        public int ExtraCostUnitIIINo { get; set; }
        public int ExtraCostUnitIINo { get; set; }
        public int ExtraCostUnitINo { get; set; }
        public string EANLocationNo { get; set; }
        public int CustomerBonusProfileNo { get; set; }
        public int LocalGovernmentNo { get; set; }
        public int ChartererCompanyNo { get; set; }
        public int AgentNo { get; set; }
        public int CommissionProfileNo { get; set; }
        public int RemittanceProfileNo { get; set; }
        public string AutogiroAgreementID { get; set; }
        public bool AgentYesNo { get; set; }
        public int ShipmentTypeNo { get; set; }
        public bool RemainderOrderYesNo { get; set; }
        public bool AcceptReplacementArticleYesNo { get; set; }
        public int PrintProfileNo { get; set; }
        public int PaymentPattern { get; set; }
        public int AltPriceListYesNo { get; set; }
        public int AltPriceListNo { get; set; }
        public int InvoiceAdressNo { get; set; }
        public int EdiProfileNo { get; set; }
        public int EinvoiceStatus { get; set; }
        public string EinvoiceRef { get; set; }
        public string EDISellerRefNo { get; set; }
        public string EDIBuyerRefNo { get; set; }
        public string VATRegNo { get; set; }
        public string WebshopRefNo { get; set; }
        public string IBAN { get; set; }
        public int SwiftCodeNo { get; set; }
        public int ContactNoConfirmOrder { get; set; }
        public int ContactNoPickingList { get; set; }
    }
}