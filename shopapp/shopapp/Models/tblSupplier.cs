namespace shopapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblSupplier")]
    public partial class tblSupplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblSupplier()
        {
            tblProductSuppliers = new HashSet<tblProductSupplier>();
            tblProductSupplierHistories = new HashSet<tblProductSupplierHistory>();
            tblPurchasOrders = new HashSet<tblPurchasOrder>();
        }

        [Key]
        public Guid SupplierId { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

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

        public Guid CountryId { get; set; }

        public Guid? CurrencyId { get; set; }

        public decimal? CreditLimit { get; set; }

        [StringLength(256)]
        public string BankAccount { get; set; }

        [StringLength(256)]
        public string BankName { get; set; }

        [StringLength(256)]
        public string IBAN { get; set; }

        [StringLength(256)]
        public string PostAccount { get; set; }

        [StringLength(256)]
        public string SwiftCode { get; set; }

        [StringLength(256)]
        public string Contact { get; set; }

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

        public DateTime? RegistrationDate { get; set; }

        [StringLength(256)]
        public string Telefax { get; set; }

        public int SupplierNo { get; set; }

        [StringLength(300)]
        public string UserName { get; set; }

        public virtual tblCountry tblCountry { get; set; }

        public virtual tblCurrency tblCurrency { get; set; }

        public virtual tblFile tblFile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProductSupplier> tblProductSuppliers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProductSupplierHistory> tblProductSupplierHistories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPurchasOrder> tblPurchasOrders { get; set; }

        public virtual tblStatu tblStatu { get; set; }
    }
}
