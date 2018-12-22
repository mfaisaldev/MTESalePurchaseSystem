namespace shopapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblProductBrand")]
    public partial class tblProductBrand
    {
        [Key]
        public Guid ProductBrandId { get; set; }

        public Guid ProductId { get; set; }

        public Guid BrandId { get; set; }

        [Required]
        [StringLength(250)]
        public string CreateBy { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual tblBrand tblBrand { get; set; }

        public virtual tblProduct tblProduct { get; set; }
    }
}
