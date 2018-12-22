namespace shopapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblOfferDetail")]
    public partial class tblOfferDetail
    {
        [Key]
        public Guid OfferDetailId { get; set; }

        public Guid OfferId { get; set; }

        public Guid ProductId { get; set; }

        [Required]
        [StringLength(250)]
        public string ProductName { get; set; }

        public string History { get; set; }

        public decimal? ProductPrice { get; set; }

        public int? ProductStock { get; set; }

        public decimal? OfferPrice { get; set; }

        public int? OfferQty { get; set; }

        public string OfferRemarks { get; set; }

        public Guid StatusId { get; set; }

        [Required]
        [StringLength(250)]
        public string CreateBy { get; set; }

        public DateTime CreationDate { get; set; }

        [StringLength(250)]
        public string ModifyBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ModifyDate { get; set; }

        public decimal? CustomerPrice { get; set; }

        public int? CustomerQty { get; set; }

        public string CustomerRemarks { get; set; }

        public decimal? FinalPrice { get; set; }

        public int? FinalQty { get; set; }

        public string FinalRemarks { get; set; }

        [StringLength(250)]
        public string ProductUCPCode { get; set; }

        public virtual tblOffer tblOffer { get; set; }

        public virtual tblProduct tblProduct { get; set; }

        public virtual tblStatu tblStatu { get; set; }
    }
}
