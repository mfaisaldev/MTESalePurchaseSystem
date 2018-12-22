namespace shopapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblProductUnitType")]
    public partial class tblProductUnitType
    {
        [Key]
        public Guid ProductUnitTypeId { get; set; }

        public Guid ProductId { get; set; }

        public Guid UnitId { get; set; }

        [Required]
        [StringLength(300)]
        public string Name { get; set; }

        [StringLength(300)]
        public string UnitNamePurchase { get; set; }

        public int? Factor { get; set; }

        [StringLength(300)]
        public string ISOCode { get; set; }

        public int? Height { get; set; }

        public bool? VariableQty { get; set; }

        public int? Width { get; set; }

        public int? Length { get; set; }

        public int? Volume { get; set; }

        public int? Rounding { get; set; }

        public string Comment { get; set; }

        public int? UnitInPurchase { get; set; }

        public int? SplitPurchase { get; set; }

        public int? UnitInSales { get; set; }

        public bool? SplitSales { get; set; }

        public int? Weight { get; set; }

        [StringLength(300)]
        public string PackingType { get; set; }

        public bool? ComparableUnit { get; set; }

        [StringLength(300)]
        public string Location { get; set; }

        public int? UnitInStockControl { get; set; }

        public int? UnitTypeNo { get; set; }

        public Guid StatusId { get; set; }

        public DateTime CreationDate { get; set; }

        [StringLength(250)]
        public string ModifyBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ModifyDate { get; set; }

        public bool IsVISMA { get; set; }

        [Required]
        [StringLength(250)]
        public string CreateBy { get; set; }

        public virtual tblProduct tblProduct { get; set; }

        public virtual tblStatu tblStatu { get; set; }

        public virtual tblUnit tblUnit { get; set; }
    }
}
