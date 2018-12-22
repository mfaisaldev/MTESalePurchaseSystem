namespace shopapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblProductSupplier")]
    public partial class tblProductSupplier
    {
        [Key]
        public Guid ProductSupplierId { get; set; }

        public Guid ProductId { get; set; }

        public Guid SupplierId { get; set; }

        [Required]
        [StringLength(250)]
        public string CreateBy { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual tblProduct tblProduct { get; set; }

        public virtual tblSupplier tblSupplier { get; set; }
    }
}
