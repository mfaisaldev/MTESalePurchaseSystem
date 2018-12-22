//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Admin.DBLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblProduct()
        {
            this.tblOfferDetails = new HashSet<tblOfferDetail>();
            this.tblOrderDetails = new HashSet<tblOrderDetail>();
            this.tblProductBrands = new HashSet<tblProductBrand>();
            this.tblProductCategories = new HashSet<tblProductCategory>();
            this.tblProductFiles = new HashSet<tblProductFile>();
            this.tblProductHistories = new HashSet<tblProductHistory>();
            this.tblProductSuppliers = new HashSet<tblProductSupplier>();
            this.tblProductSupplierHistories = new HashSet<tblProductSupplierHistory>();
            this.tblProductUnitTypes = new HashSet<tblProductUnitType>();
            this.tblPurchasOrderDetails = new HashSet<tblPurchasOrderDetail>();
        }
    
        public System.Guid ProductId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public System.Guid StatusId { get; set; }
        public string CreateBy { get; set; }
        public System.DateTime CreationDate { get; set; }
        public string ModifyBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public bool IsVISMA { get; set; }
        public Nullable<System.Guid> FileId { get; set; }
        public string UPC_code { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> Purchase_Price_NOK { get; set; }
        public Nullable<decimal> Purchase_price_USD_EURO { get; set; }
        public Nullable<decimal> Price_customs_NOK { get; set; }
        public Nullable<System.Guid> MainGroupId { get; set; }
        public Nullable<System.Guid> IntermediateGroupId { get; set; }
        public Nullable<System.Guid> SubGroupId { get; set; }
        public Nullable<System.Guid> ProductTypeId { get; set; }
        public string Lager_profile { get; set; }
        public Nullable<System.Guid> SupplierId { get; set; }
        public string Year_Article_type { get; set; }
        public string Season { get; set; }
        public string Segment { get; set; }
        public string Gender { get; set; }
        public string Size { get; set; }
        public string Colour { get; set; }
        public Nullable<System.Guid> UnitId { get; set; }
        public string Sales_Pack { get; set; }
        public string Master_Pack { get; set; }
        public Nullable<int> ProductStock { get; set; }
        public Nullable<System.DateTime> PublishDate { get; set; }
        public Nullable<System.Guid> CurrencyId { get; set; }
        public string ArticleNo { get; set; }
        public Nullable<bool> IsNew { get; set; }
        public Nullable<bool> IsHot { get; set; }
        public string style { get; set; }
        public Nullable<decimal> Out_Price { get; set; }
        public Nullable<decimal> In_Price { get; set; }
        public Nullable<decimal> Cost_Price { get; set; }
        public Nullable<decimal> Supplier_price { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Product { get; set; }
        public string ProductType { get; set; }
        public string Brand { get; set; }
        public Nullable<int> WareHouseNo { get; set; }
        public Nullable<int> UnitOnPurchase { get; set; }
        public Nullable<int> MaxStock { get; set; }
        public Nullable<int> MinStock { get; set; }
        public Nullable<int> UnitInStock { get; set; }
        public Nullable<int> UnitOnOrder { get; set; }
        public Nullable<int> UnitOnReminder { get; set; }
        public Nullable<int> UnitPacked { get; set; }
        public Nullable<int> QtyManualReserved { get; set; }
        public Nullable<int> QtyReserved { get; set; }
        public string ImgURL { get; set; }
        public string Hovedgr { get; set; }
        public string Mellomgr { get; set; }
        public string Undergr { get; set; }
        public string Unit { get; set; }
    
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
