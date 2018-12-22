namespace shopapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vSupplier")]
    public partial class vSupplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SupplierNo { get; set; }

        [StringLength(300)]
        public string Name { get; set; }

        public int? ContactNo { get; set; }

        [StringLength(300)]
        public string PostCode { get; set; }

        [StringLength(300)]
        public string PostOffice { get; set; }

        [StringLength(300)]
        public string Telephone { get; set; }

        [StringLength(300)]
        public string Telefax { get; set; }

        [StringLength(300)]
        public string EmailAddress { get; set; }

        public int? FormProfileSuppNo { get; set; }

        public int? DeliveryMethodsNo { get; set; }

        public int? TermsOfDeliveryNo { get; set; }

        public int? SwiftCodeNo { get; set; }

        [StringLength(300)]
        public string PostAccount { get; set; }

        [StringLength(300)]
        public string BankAccount { get; set; }

        public int? CountryNo { get; set; }

        [StringLength(300)]
        public string Address1 { get; set; }

        [StringLength(300)]
        public string SortName { get; set; }

        public int? BuContactNo { get; set; }

        public int? SupplierGrpNo { get; set; }

        public int? BusinessNo { get; set; }

        public int? SupplierProfileNo { get; set; }

        public int? EmployeeNo { get; set; }

        public int? TermsOfPaySupplNo { get; set; }

        public int? WareHouseNo { get; set; }

        [StringLength(300)]
        public string OurCustomerNo { get; set; }

        [StringLength(300)]
        public string CompanyNo { get; set; }

        public int? DistrictNo { get; set; }

        public int? CurrencyNo { get; set; }

        public decimal? CreditLimit { get; set; }

        public int? GLAccPay { get; set; }

        public int? SupplierTypeNo { get; set; }

        public int? DiscountGrpSupplNo { get; set; }

        public DateTime? LastMovementDate { get; set; }

        public bool? InActiveYesNo { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public int? AccessLevel { get; set; }

        [StringLength(300)]
        public string Password { get; set; }

        public int? CustomerNo { get; set; }

        public int? ProjectNo { get; set; }

        public int? ProductNo { get; set; }

        public int? DepNo { get; set; }

        public int? SupplierClassification { get; set; }

        public int? ChainNo { get; set; }

        [StringLength(300)]
        public string WWWAddress { get; set; }

        [StringLength(300)]
        public string Address3 { get; set; }

        [StringLength(300)]
        public string Address2 { get; set; }

        public DateTime? LastUpdate { get; set; }

        public int? ExtraCostUnitIVNo { get; set; }

        public int? ExtraCostUnitIIINo { get; set; }

        public int? ExtraCostUnitIINo { get; set; }

        public int? ExtraCostUnitINo { get; set; }

        public int? RemittanceProfileNo { get; set; }

        public int? LocalGovernmentNo { get; set; }

        public int? ReminderProfileNo { get; set; }

        public int? NoOfReceivedPrOrder { get; set; }

        public int? AvgDaysDelayedDelivery { get; set; }

        public int? EbusinessType { get; set; }

        public int? OrderConfirmationTime { get; set; }

        [StringLength(300)]
        public string EANLocationNo { get; set; }

        [StringLength(300)]
        public string VATRegNo { get; set; }

        public int? PrefGLAccountNo { get; set; }

        public int? PLAttResponsible { get; set; }

        [StringLength(300)]
        public string BankGiro { get; set; }

        public int? RiksBankKod { get; set; }

        [StringLength(300)]
        public string BankName { get; set; }

        [StringLength(300)]
        public string PgKontorUtland { get; set; }

        [StringLength(300)]
        public string Telephone2 { get; set; }

        public int? LanguageNo { get; set; }

        public int? BankConNo { get; set; }

        public int? ForeignPaymentYesNo { get; set; }

        public int? CurrencyAccount { get; set; }

        [StringLength(300)]
        public string UserNumber { get; set; }

        public int? KIDSupplier { get; set; }

        [StringLength(300)]
        public string ForeignBankCode { get; set; }

        [StringLength(300)]
        public string CountryCode { get; set; }

        public int? PaymentMethod { get; set; }

        [StringLength(300)]
        public string GLAccPayAlfa { get; set; }

        public int? AccountingRuleNo { get; set; }

        public int? EuroFicka { get; set; }

        public int? TransType { get; set; }

        [StringLength(300)]
        public string TransTypeText { get; set; }

        public int? AttestationResponsible { get; set; }

        public int? FloatGroupNo { get; set; }

        public int? ChartererCompanyNo { get; set; }

        [StringLength(300)]
        public string IBAN { get; set; }

        public DateTime? DateLastFinancialStatement { get; set; }

        public int? AnnualSales { get; set; }

        public int? NoOfEmployees { get; set; }

        public int? CostTrackingProfileNo { get; set; }

        public bool IsUpdated { get; set; }
    }
}
