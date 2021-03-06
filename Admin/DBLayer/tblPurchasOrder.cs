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
    
    public partial class tblPurchasOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblPurchasOrder()
        {
            this.tblPurchasOrderDetails = new HashSet<tblPurchasOrderDetail>();
        }
    
        public System.Guid PurchasOrderId { get; set; }
        public System.Guid SupplierId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.Guid StatusId { get; set; }
        public string CreateBy { get; set; }
        public System.DateTime CreationDate { get; set; }
        public string ModifyBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public bool IsVISMA { get; set; }
        public Nullable<System.DateTime> PurchasOrderDate { get; set; }
        public Nullable<System.DateTime> ExpectDeliveryDate { get; set; }
        public Nullable<System.DateTime> ActualDeliveryDate { get; set; }
        public Nullable<bool> IsAllItemReceive { get; set; }
        public Nullable<decimal> TotalAcount { get; set; }
        public string SupplierOrderNo { get; set; }
    
        public virtual tblStatu tblStatu { get; set; }
        public virtual tblSupplier tblSupplier { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPurchasOrderDetail> tblPurchasOrderDetails { get; set; }
    }
}
