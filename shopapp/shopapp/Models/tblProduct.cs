namespace shopapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblProduct")]
    public partial class tblProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblProduct()
        {
            tblOfferDetails = new HashSet<tblOfferDetail>();
            tblOrderDetails = new HashSet<tblOrderDetail>();
            tblProductBrands = new HashSet<tblProductBrand>();
            tblProductCategories = new HashSet<tblProductCategory>();
            tblProductFiles = new HashSet<tblProductFile>();
            tblProductHistories = new HashSet<tblProductHistory>();
            tblProductSuppliers = new HashSet<tblProductSupplier>();
            tblProductSupplierHistories = new HashSet<tblProductSupplierHistory>();
            tblProductUnitTypes = new HashSet<tblProductUnitType>();
            tblPurchasOrderDetails = new HashSet<tblPurchasOrderDetail>();
        }

        [Key]
        public Guid ProductId { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string ShortDescription { get; set; }

        public string FullDescription { get; set; }

        public string ImgURL { get; set; }

        public int? DisplayOrder { get; set; }

        public Guid StatusId { get; set; }

        [Required]
        [StringLength(250)]
        public string CreateBy { get; set; }

        public DateTime CreationDate { get; set; }

        [StringLength(250)]
        public string ModifyBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ModifyDate { get; set; }

        public bool IsVISMA { get; set; }

        public Guid? FileId { get; set; }

        [StringLength(250)]
        public string UPC_code { get; set; }

        public decimal? Price { get; set; }

        public decimal? Purchase_Price_NOK { get; set; }

        public decimal? Purchase_price_USD_EURO { get; set; }

        public decimal? Price_customs_NOK { get; set; }

        public Guid? MainGroupId { get; set; }

        public Guid? IntermediateGroupId { get; set; }

        public Guid? SubGroupId { get; set; }

        public Guid? ProductTypeId { get; set; }

        [StringLength(250)]
        public string Lager_profile { get; set; }

        public Guid? SupplierId { get; set; }

        [StringLength(250)]
        public string Year_Article_type { get; set; }

        [StringLength(250)]
        public string Season { get; set; }

        [StringLength(250)]
        public string Segment { get; set; }

        [StringLength(50)]
        public string Gender { get; set; }

        [StringLength(250)]
        public string Size { get; set; }

        [StringLength(250)]
        public string Colour { get; set; }

        public Guid? UnitId { get; set; }

        [StringLength(250)]
        public string Sales_Pack { get; set; }

        [StringLength(250)]
        public string Master_Pack { get; set; }

        public int? ProductStock { get; set; }

        public DateTime? PublishDate { get; set; }

        public Guid? CurrencyId { get; set; }

        [StringLength(300)]
        public string ArticleNo { get; set; }

        public bool? IsNew { get; set; }

        public bool? IsHot { get; set; }

        public virtual tblCurrency tblCurrency { get; set; }

        public virtual tblFile tblFile { get; set; }

        public virtual tblIntermediateGroup tblIntermediateGroup { get; set; }

        public virtual tblMainGroup tblMainGroup { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblOfferDetail> tblOfferDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblOrderDetail> tblOrderDetails { get; set; }

        public virtual tblStatu tblStatu { get; set; }

        public virtual tblSubGroup tblSubGroup { get; set; }

        public virtual tblUnit tblUnit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProductBrand> tblProductBrands { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProductCategory> tblProductCategories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProductFile> tblProductFiles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProductHistory> tblProductHistories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProductSupplier> tblProductSuppliers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProductSupplierHistory> tblProductSupplierHistories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProductUnitType> tblProductUnitTypes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPurchasOrderDetail> tblPurchasOrderDetails { get; set; }
    }
}
