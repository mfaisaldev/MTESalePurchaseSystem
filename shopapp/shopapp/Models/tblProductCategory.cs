namespace shopapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblProductCategory")]
    public partial class tblProductCategory
    {
        [Key]
        public Guid ProductCategoryId { get; set; }

        public Guid ProductId { get; set; }

        public Guid CategoryId { get; set; }

        [Required]
        [StringLength(250)]
        public string CreateBy { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual tblCategory tblCategory { get; set; }

        public virtual tblProduct tblProduct { get; set; }
    }
}
