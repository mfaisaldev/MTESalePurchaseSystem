namespace shopapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblProductSupplierHistory")]
    public partial class tblProductSupplierHistory
    {
        [Key]
        public Guid ProductSupplierHistoryId { get; set; }

        public Guid SupplierId { get; set; }

        public decimal? Price { get; set; }

        public int? Qty { get; set; }

        public DateTime? SaleDate { get; set; }

        public Guid? ProductId { get; set; }

        public Guid? StatusId { get; set; }

        [StringLength(250)]
        public string CreateBy { get; set; }

        public DateTime? CreationDate { get; set; }

        [StringLength(250)]
        public string ProductName { get; set; }

        public string Remarks { get; set; }

        public virtual tblProduct tblProduct { get; set; }

        public virtual tblStatu tblStatu { get; set; }

        public virtual tblSupplier tblSupplier { get; set; }
    }
}
