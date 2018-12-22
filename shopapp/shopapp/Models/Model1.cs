namespace shopapp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=ModelDB")
        {
        }

        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<tblBrand> tblBrands { get; set; }
        public virtual DbSet<tblCategory> tblCategories { get; set; }
        public virtual DbSet<tblCountry> tblCountries { get; set; }
        public virtual DbSet<tblCurrency> tblCurrencies { get; set; }
        public virtual DbSet<tblCustomer> tblCustomers { get; set; }
        public virtual DbSet<tblCustomerShipping> tblCustomerShippings { get; set; }
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
        public virtual DbSet<vArticleSubGroup> vArticleSubGroups { get; set; }
        public virtual DbSet<vArticleUnitType> vArticleUnitTypes { get; set; }
        public virtual DbSet<vCustomer> vCustomers { get; set; }
        public virtual DbSet<vCustomerAddress> vCustomerAddresses { get; set; }
        public virtual DbSet<vCustomerCustomField> vCustomerCustomFields { get; set; }
        public virtual DbSet<vSupplier> vSuppliers { get; set; }
        public virtual DbSet<vUnit> vUnits { get; set; }
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblBrand>()
                .HasMany(e => e.tblProductBrands)
                .WithRequired(e => e.tblBrand)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblCategory>()
                .HasMany(e => e.tblProductCategories)
                .WithRequired(e => e.tblCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblCountry>()
                .HasMany(e => e.tblSuppliers)
                .WithRequired(e => e.tblCountry)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblCustomer>()
                .HasMany(e => e.tblCustomerShippings)
                .WithRequired(e => e.tblCustomer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblCustomer>()
                .HasMany(e => e.tblOffers)
                .WithRequired(e => e.tblCustomer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblCustomer>()
                .HasMany(e => e.tblOrders)
                .WithRequired(e => e.tblCustomer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblCustomer>()
                .HasMany(e => e.tblProductHistories)
                .WithRequired(e => e.tblCustomer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblFile>()
                .HasMany(e => e.tblProductFiles)
                .WithRequired(e => e.tblFile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblMenu>()
                .HasMany(e => e.tblRoleMenus)
                .WithRequired(e => e.tblMenu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblOffer>()
                .HasMany(e => e.tblOfferDetails)
                .WithRequired(e => e.tblOffer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblOfferLog>()
                .HasMany(e => e.tblOfferDetailLogs)
                .WithRequired(e => e.tblOfferLog)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblOrder>()
                .HasMany(e => e.tblOrderDetails)
                .WithRequired(e => e.tblOrder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblProduct>()
                .Property(e => e.ArticleNo)
                .IsUnicode(false);

            modelBuilder.Entity<tblProduct>()
                .HasMany(e => e.tblOfferDetails)
                .WithRequired(e => e.tblProduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblProduct>()
                .HasMany(e => e.tblOrderDetails)
                .WithRequired(e => e.tblProduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblProduct>()
                .HasMany(e => e.tblProductBrands)
                .WithRequired(e => e.tblProduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblProduct>()
                .HasMany(e => e.tblProductCategories)
                .WithRequired(e => e.tblProduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblProduct>()
                .HasMany(e => e.tblProductFiles)
                .WithRequired(e => e.tblProduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblProduct>()
                .HasMany(e => e.tblProductHistories)
                .WithRequired(e => e.tblProduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblProduct>()
                .HasMany(e => e.tblProductSuppliers)
                .WithRequired(e => e.tblProduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblProduct>()
                .HasMany(e => e.tblProductUnitTypes)
                .WithRequired(e => e.tblProduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblProduct>()
                .HasMany(e => e.tblPurchasOrderDetails)
                .WithRequired(e => e.tblProduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblPurchasOrder>()
                .HasMany(e => e.tblPurchasOrderDetails)
                .WithRequired(e => e.tblPurchasOrder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblPurchasOrderDetail>()
                .Property(e => e.OrderPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tblPurchasOrderDetailLog>()
                .Property(e => e.OrderPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tblRole>()
                .HasMany(e => e.tblRoleMenus)
                .WithRequired(e => e.tblRole)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblRole>()
                .HasMany(e => e.tblRoleUsers)
                .WithRequired(e => e.tblRole)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblStatu>()
                .HasMany(e => e.tblBrands)
                .WithRequired(e => e.tblStatu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblStatu>()
                .HasMany(e => e.tblCountries)
                .WithRequired(e => e.tblStatu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblStatu>()
                .HasMany(e => e.tblIntermediateGroups)
                .WithRequired(e => e.tblStatu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblStatu>()
                .HasMany(e => e.tblMainGroups)
                .WithRequired(e => e.tblStatu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblStatu>()
                .HasMany(e => e.tblOffers)
                .WithRequired(e => e.tblStatu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblStatu>()
                .HasMany(e => e.tblOfferDetails)
                .WithRequired(e => e.tblStatu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblStatu>()
                .HasMany(e => e.tblOrders)
                .WithRequired(e => e.tblStatu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblStatu>()
                .HasMany(e => e.tblOrderDetails)
                .WithRequired(e => e.tblStatu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblStatu>()
                .HasMany(e => e.tblProducts)
                .WithRequired(e => e.tblStatu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblStatu>()
                .HasMany(e => e.tblProductUnitTypes)
                .WithRequired(e => e.tblStatu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblStatu>()
                .HasMany(e => e.tblPurchasOrders)
                .WithRequired(e => e.tblStatu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblStatu>()
                .HasMany(e => e.tblPurchasOrderDetails)
                .WithRequired(e => e.tblStatu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblStatu>()
                .HasMany(e => e.tblRoles)
                .WithRequired(e => e.tblStatu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblStatu>()
                .HasMany(e => e.tblSubGroups)
                .WithRequired(e => e.tblStatu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblStatu>()
                .HasMany(e => e.tblUnits)
                .WithRequired(e => e.tblStatu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblStatusType>()
                .HasMany(e => e.tblStatus)
                .WithRequired(e => e.tblStatusType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblSupplier>()
                .HasMany(e => e.tblProductSuppliers)
                .WithRequired(e => e.tblSupplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblSupplier>()
                .HasMany(e => e.tblProductSupplierHistories)
                .WithRequired(e => e.tblSupplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblSupplier>()
                .HasMany(e => e.tblPurchasOrders)
                .WithRequired(e => e.tblSupplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblUnit>()
                .HasMany(e => e.tblProductUnitTypes)
                .WithRequired(e => e.tblUnit)
                .WillCascadeOnDelete(false);
        }
    }
}
