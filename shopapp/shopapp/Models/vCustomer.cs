namespace shopapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vCustomer")]
    public partial class vCustomer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerNo { get; set; }

        [StringLength(300)]
        public string Name { get; set; }

        [StringLength(300)]
        public string Address1 { get; set; }

        [StringLength(300)]
        public string EmailAddress { get; set; }

        [StringLength(300)]
        public string Address2 { get; set; }

        [StringLength(300)]
        public string PostCode { get; set; }

        [StringLength(300)]
        public string PostOffice { get; set; }

        public int? CountryNo { get; set; }

        [StringLength(300)]
        public string Phone { get; set; }

        public bool? InActiveYesNo { get; set; }

        public int? Balance { get; set; }

        public int? FormProfileCustNo { get; set; }

        public int? DeliveryMethodsNo { get; set; }

        public int? BusinessNo { get; set; }

        public int? CustomerProfileNo { get; set; }

        public int? EmployeeNo { get; set; }

        public int? TermsOfPayCustNo { get; set; }

        public int? CustomerGrpNo { get; set; }

        public int? DistrictNo { get; set; }

        public int? PriceCode { get; set; }

        public int? CurrencyNo { get; set; }

        public decimal? CreditLimit { get; set; }

        [StringLength(300)]
        public string CompanyNo { get; set; }

        [StringLength(300)]
        public string BankAccount { get; set; }

        public int? OurSupplNo { get; set; }

        public int? CustomerTypeNo { get; set; }

        public int? AccessLevel { get; set; }

        [StringLength(300)]
        public string Password { get; set; }

        public int? ChainLeaderYesNo { get; set; }

        public int? TypeOfChain { get; set; }

        public int? ProductNo { get; set; }

        public int? ProjectNo { get; set; }

        public int? DepNo { get; set; }

        public int? SupplierNo { get; set; }

        public int? DeliveryAddressNo { get; set; }

        [StringLength(300)]
        public string Address3 { get; set; }

        public DateTime? LastUpdate { get; set; }

        public int? ExtraCostUnitIVNo { get; set; }

        public int? ExtraCostUnitIIINo { get; set; }

        public int? ExtraCostUnitIINo { get; set; }

        public int? ExtraCostUnitINo { get; set; }

        public DateTime? Created { get; set; }

        public int? CreatedBy { get; set; }

        public int? LastUpdatedBy { get; set; }

        [StringLength(300)]
        public string EANLocationNo { get; set; }

        public int? CustomerBonusProfileNo { get; set; }

        public int? LocalGovernmentNo { get; set; }

        public int? ChartererCompanyNo { get; set; }

        public int? AgentNo { get; set; }

        public int? CommissionProfileNo { get; set; }

        public int? RemittanceProfileNo { get; set; }

        [StringLength(300)]
        public string AutogiroAgreementID { get; set; }

        public int? AgentYesNo { get; set; }

        public int? ShipmentTypeNo { get; set; }

        public int? RemainderOrderYesNo { get; set; }

        public int? AcceptReplacementArticleYesNo { get; set; }

        public int? PrintProfileNo { get; set; }

        public int? PaymentPattern { get; set; }

        public int? AltPriceListYesNo { get; set; }

        public int? AltPriceListNo { get; set; }

        public int? InvoiceAdressNo { get; set; }

        public int? EdiProfileNo { get; set; }

        public int? EinvoiceStatus { get; set; }

        [StringLength(300)]
        public string EinvoiceRef { get; set; }

        [StringLength(300)]
        public string EDISellerRefNo { get; set; }

        [StringLength(300)]
        public string EDIBuyerRefNo { get; set; }

        [StringLength(300)]
        public string VATRegNo { get; set; }

        [StringLength(300)]
        public string WebshopRefNo { get; set; }

        [StringLength(300)]
        public string IBAN { get; set; }

        public int? SwiftCodeNo { get; set; }

        public int? ContactNoConfirmOrder { get; set; }

        public int? ContactNoPickingList { get; set; }

        public bool IsUpdated { get; set; }
    }
}
