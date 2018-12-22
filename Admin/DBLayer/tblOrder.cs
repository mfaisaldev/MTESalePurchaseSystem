//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Admin.DBLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblOrder()
        {
            this.tblOrderDetails = new HashSet<tblOrderDetail>();
        }
    
        public System.Guid OrderId { get; set; }
        public System.Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.Guid StatusId { get; set; }
        public string CreateBy { get; set; }
        public System.DateTime CreationDate { get; set; }
        public string ModifyBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public bool IsVISMA { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<System.DateTime> AcceptanceDeliveryDate { get; set; }
        public Nullable<System.DateTime> ActualDeliveryDate { get; set; }
        public Nullable<System.Guid> OfferId { get; set; }
        public Nullable<decimal> TotalAcount { get; set; }
        public Nullable<System.Guid> EmployeeId { get; set; }
        public string OrderNo { get; set; }
    
        public virtual tblCustomer tblCustomer { get; set; }
        public virtual tblStatu tblStatu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblOrderDetail> tblOrderDetails { get; set; }
    }
}