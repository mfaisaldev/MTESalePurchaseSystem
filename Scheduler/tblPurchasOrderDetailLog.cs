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
    
    public partial class tblPurchasOrderDetailLog
    {
        public System.Guid PurchasOrderDetailLogId { get; set; }
        public System.Guid PurchasOrderLogId { get; set; }
        public System.Guid PurchasOrderDetailId { get; set; }
        public System.Guid PurchasOrderId { get; set; }
        public System.Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductUCPCode { get; set; }
        public string PurchaseOrderHistory { get; set; }
        public Nullable<decimal> PurchaseOrderPrice { get; set; }
        public Nullable<int> PurchaseOrderQty { get; set; }
        public Nullable<int> ReceiveQty { get; set; }
        public Nullable<System.DateTime> ReceiveDate { get; set; }
        public string PurchaseOrderRemark { get; set; }
        public Nullable<bool> IsAllItemReceive { get; set; }
        public System.Guid StatusId { get; set; }
        public string CreateBy { get; set; }
        public System.DateTime CreationDate { get; set; }
        public string ModifyBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public Nullable<System.Guid> CustomerId { get; set; }
        public Nullable<int> OrderQty { get; set; }
        public Nullable<System.Guid> OrderId { get; set; }
        public Nullable<System.Guid> OrderDetailId { get; set; }
        public Nullable<decimal> OrderPrice { get; set; }
    }
}
