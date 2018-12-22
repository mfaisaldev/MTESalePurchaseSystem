namespace shopapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblPurchasOrderLog")]
    public partial class tblPurchasOrderLog
    {
        [Key]
        public Guid PurchasOrderLogId { get; set; }

        public Guid? PurchasOrderId { get; set; }

        public Guid? SupplierId { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid? StatusId { get; set; }

        [StringLength(250)]
        public string CreateBy { get; set; }

        public DateTime? CreationDate { get; set; }

        [StringLength(250)]
        public string ModifyBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ModifyDate { get; set; }

        public bool? IsVISMA { get; set; }

        public DateTime? PurchasOrderDate { get; set; }

        public DateTime? ExpectDeliveryDate { get; set; }

        public DateTime? ActualDeliveryDate { get; set; }

        public bool? IsAllItemReceive { get; set; }
    }
}
