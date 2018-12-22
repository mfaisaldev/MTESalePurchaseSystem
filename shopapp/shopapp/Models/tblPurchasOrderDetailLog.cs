namespace shopapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblPurchasOrderDetailLog")]
    public partial class tblPurchasOrderDetailLog
    {
        [Key]
        public Guid PurchasOrderDetailLogId { get; set; }

        public Guid PurchasOrderLogId { get; set; }

        public Guid PurchasOrderDetailId { get; set; }

        public Guid PurchasOrderId { get; set; }

        public Guid ProductId { get; set; }

        [Required]
        [StringLength(250)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(250)]
        public string ProductUCPCode { get; set; }

        public string PurchaseOrderHistory { get; set; }

        public decimal? PurchaseOrderPrice { get; set; }

        public int? PurchaseOrderQty { get; set; }

        public int? ReceiveQty { get; set; }

        public DateTime? ReceiveDate { get; set; }

        public string PurchaseOrderRemark { get; set; }

        public bool? IsAllItemReceive { get; set; }

        public Guid StatusId { get; set; }

        [Required]
        [StringLength(250)]
        public string CreateBy { get; set; }

        public DateTime CreationDate { get; set; }

        [StringLength(250)]
        public string ModifyBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ModifyDate { get; set; }

        public Guid? CustomerId { get; set; }

        public int? OrderQty { get; set; }

        public Guid? OrderId { get; set; }

        public Guid? OrderDetailId { get; set; }

        public decimal? OrderPrice { get; set; }
    }
}
