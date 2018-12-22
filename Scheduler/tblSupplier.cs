//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Scheduler
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblSupplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblSupplier()
        {
            this.tblProductSuppliers = new HashSet<tblProductSupplier>();
            this.tblProductSupplierHistories = new HashSet<tblProductSupplierHistory>();
            this.tblPurchasOrders = new HashSet<tblPurchasOrder>();
        }
    
        public System.Guid SupplierId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PostOffice { get; set; }
        public string Kommune { get; set; }
        public System.Guid CountryId { get; set; }
        public Nullable<System.Guid> CurrencyId { get; set; }
        public Nullable<decimal> CreditLimit { get; set; }
        public string BankAccount { get; set; }
        public string BankName { get; set; }
        public string IBAN { get; set; }
        public string PostAccount { get; set; }
        public string SwiftCode { get; set; }
        public string Contact { get; set; }
        public Nullable<System.Guid> StatusId { get; set; }
        public string CreateBy { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string ModifyBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public Nullable<System.Guid> FileId { get; set; }
        public bool IsVISMA { get; set; }
        public string City { get; set; }
        public Nullable<System.DateTime> RegistrationDate { get; set; }
        public string Telefax { get; set; }
        public int SupplierNo { get; set; }
        public string UserName { get; set; }
        public Nullable<System.Guid> EmployeeId { get; set; }
    
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
