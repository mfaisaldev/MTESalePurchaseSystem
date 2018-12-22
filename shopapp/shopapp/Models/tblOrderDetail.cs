namespace shopapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblOrderDetail")]
    public partial class tblOrderDetail
    {
        [Key]
        public Guid OrderDetailId { get; set; }

        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }

        [Required]
        [StringLength(250)]
        public string ProductName { get; set; }

        public decimal? ProductPrice { get; set; }

        public int? ProductStock { get; set; }

        public decimal? OrderPrice { get; set; }

        public int? OrderQty { get; set; }

        public string OrderRemarks { get; set; }

        public Guid StatusId { get; set; }

        [Required]
        [StringLength(250)]
        public string CreateBy { get; set; }

        public DateTime CreationDate { get; set; }

        [StringLength(250)]
        public string ModifyBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ModifyDate { get; set; }

        [StringLength(250)]
        public string ProductUCPCode { get; set; }

        public Guid? OfferDetailId { get; set; }

        public virtual tblOrder tblOrder { get; set; }

        public virtual tblProduct tblProduct { get; set; }

        public virtual tblStatu tblStatu { get; set; }
    }
}
