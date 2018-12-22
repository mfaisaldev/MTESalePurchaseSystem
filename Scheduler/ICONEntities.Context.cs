﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Scheduler
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<tblBrand> tblBrands { get; set; }
        public virtual DbSet<tblCategory> tblCategories { get; set; }
        public virtual DbSet<tblCountry> tblCountries { get; set; }
        public virtual DbSet<tblCurrency> tblCurrencies { get; set; }
        public virtual DbSet<tblCustomer> tblCustomers { get; set; }
        public virtual DbSet<tblCustomerShipping> tblCustomerShippings { get; set; }
        public virtual DbSet<tblEmployee> tblEmployees { get; set; }
        public virtual DbSet<tblFile> tblFiles { get; set; }
        public virtual DbSet<tblIntermediateGroup> tblIntermediateGroups { get; set; }
        public virtual DbSet<tblMainGroup> tblMainGroups { get; set; }
        public virtual DbSet<tblMenu> tblMenus { get; set; }
        public virtual DbSet<tblOffer> tblOffers { get; set; }
        public virtual DbSet<tblOfferDetail> tblOfferDetails { get; set; }
        public virtual DbSet<tblOfferDetailLog> tblOfferDetailLogs { get; set; }
        public virtual DbSet<tblOfferLog> tblOfferLogs { get; set; }
        public virtual DbSet<tblOrder> tblOrders { get; set; }
        public virtual DbSet<tblOrderDetail> tblOrderDetails { get; set; }
        public virtual DbSet<tblProduct> tblProducts { get; set; }
        public virtual DbSet<tblProductBrand> tblProductBrands { get; set; }
        public virtual DbSet<tblProductCategory> tblProductCategories { get; set; }
        public virtual DbSet<tblProductFile> tblProductFiles { get; set; }
        public virtual DbSet<tblProductHistory> tblProductHistories { get; set; }
        public virtual DbSet<tblProductSupplier> tblProductSuppliers { get; set; }
        public virtual DbSet<tblProductSupplierHistory> tblProductSupplierHistories { get; set; }
        public virtual DbSet<tblProductUnitType> tblProductUnitTypes { get; set; }
        public virtual DbSet<tblPurchasOrder> tblPurchasOrders { get; set; }
        public virtual DbSet<tblPurchasOrderDetail> tblPurchasOrderDetails { get; set; }
        public virtual DbSet<tblPurchasOrderDetailLog> tblPurchasOrderDetailLogs { get; set; }
        public virtual DbSet<tblPurchasOrderLog> tblPurchasOrderLogs { get; set; }
        public virtual DbSet<tblRole> tblRoles { get; set; }
        public virtual DbSet<tblRoleMenu> tblRoleMenus { get; set; }
        public virtual DbSet<tblRoleUser> tblRoleUsers { get; set; }
        public virtual DbSet<tblStatu> tblStatus { get; set; }
        public virtual DbSet<tblStatusType> tblStatusTypes { get; set; }
        public virtual DbSet<tblSubGroup> tblSubGroups { get; set; }
        public virtual DbSet<tblSupplier> tblSuppliers { get; set; }
        public virtual DbSet<tblUnit> tblUnits { get; set; }
        public virtual DbSet<vArticle> vArticles { get; set; }
        public virtual DbSet<vArticleCustomField> vArticleCustomFields { get; set; }
        public virtual DbSet<vArticleGroupMain> vArticleGroupMains { get; set; }
        public virtual DbSet<vArticleIntermediateGroup> vArticleIntermediateGroups { get; set; }
        public virtual DbSet<vArticleStockInfo> vArticleStockInfoes { get; set; }
        public virtual DbSet<vArticleSubGroup> vArticleSubGroups { get; set; }
        public virtual DbSet<vArticleUnitType> vArticleUnitTypes { get; set; }
        public virtual DbSet<vCustomer> vCustomers { get; set; }
        public virtual DbSet<vCustomerAddress> vCustomerAddresses { get; set; }
        public virtual DbSet<vCustomerCustomField> vCustomerCustomFields { get; set; }
        public virtual DbSet<vEmployee> vEmployees { get; set; }
        public virtual DbSet<vPO> vPOes { get; set; }
        public virtual DbSet<vPOLine> vPOLines { get; set; }
        public virtual DbSet<vSO> vSOes { get; set; }
        public virtual DbSet<vSOLine> vSOLines { get; set; }
        public virtual DbSet<vSupplier> vSuppliers { get; set; }
        public virtual DbSet<vUnit> vUnits { get; set; }
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<View_Customer> View_Customer { get; set; }
    }
}