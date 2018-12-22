namespace shopapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCustomer")]
    public partial class tblCustomer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblCustomer()
        {
            tblCustomerShippings = new HashSet<tblCustomerShipping>();
            tblOffers = new HashSet<tblOffer>();
            tblOrders = new HashSet<tblOrder>();
            tblProductHistories = new HashSet<tblProductHistory>();
            tblPurchasOrderDetails = new HashSet<tblPurchasOrderDetail>();
        }

        [Key]
        public Guid CustomerId { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [StringLength(256)]
        public string OrganizationName { get; set; }

        [Required]
        [StringLength(256)]
        public string Email { get; set; }

        [StringLength(256)]
        public string Phone { get; set; }

        [StringLength(1024)]
        public string Address1 { get; set; }

        [StringLength(1024)]
        public string Address2 { get; set; }

        [StringLength(256)]
        public string PostOffice { get; set; }

        [StringLength(256)]
        public string Kommune { get; set; }

        public Guid? CountryId { get; set; }

        public Guid? CurrencyId { get; set; }

        public decimal? CreditLimit { get; set; }

        [StringLength(256)]
        public string BankAccount { get; set; }

        [StringLength(256)]
        public string IBAN { get; set; }

        [StringLength(256)]
        public string SwiftCode { get; set; }

        [StringLength(256)]
        public string ContactNoConfirmOrder { get; set; }

        [StringLength(256)]
        public string OrganizationNumber { get; set; }

        public Guid? StatusId { get; set; }

        [StringLength(250)]
        public string CreateBy { get; set; }

        public DateTime? CreationDate { get; set; }

        [StringLength(250)]
        public string ModifyBy { get; set; }

        public DateTime? ModifyDate { get; set; }

        public Guid? FileId { get; set; }

        public bool IsVISMA { get; set; }

        [StringLength(256)]
        public string City { get; set; }

        public bool IsUser { get; set; }

        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

        public int? CustomerNo { get; set; }

        public virtual tblCountry tblCountry { get; set; }

        public virtual tblCurrency tblCurrency { get; set; }

        public virtual tblFile tblFile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCustomerShipping> tblCustomerShippings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblOffer> tblOffers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblOrder> tblOrders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProductHistory> tblProductHistories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPurchasOrderDetail> tblPurchasOrderDetails { get; set; }
    }
}
