namespace shopapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblProductHistory")]
    public partial class tblProductHistory
    {
        [Key]
        public Guid ProductHistoryId { get; set; }

        public Guid CustomerId { get; set; }

        public decimal Price { get; set; }

        public int Qty { get; set; }

        public DateTime SaleDate { get; set; }

        public Guid ProductId { get; set; }

        public Guid StatusId { get; set; }

        [Required]
        [StringLength(250)]
        public string CreateBy { get; set; }

        public DateTime CreationDate { get; set; }

        [Required]
        [StringLength(250)]
        public string ProductName { get; set; }

        public string Remarks { get; set; }

        public virtual tblCustomer tblCustomer { get; set; }

        public virtual tblProduct tblProduct { get; set; }
    }
}
