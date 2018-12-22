
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/21/2018 21:49:28
-- Generated from EDMX file: C:\Users\nbs\source\repos\ICON\Admin\DBLayer\ICONEntities.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ICON];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_tblBrand_tblFile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblBrand] DROP CONSTRAINT [FK_tblBrand_tblFile];
GO
IF OBJECT_ID(N'[dbo].[FK_tblBrand_tblStatus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblBrand] DROP CONSTRAINT [FK_tblBrand_tblStatus];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCountry_tblStatus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCountry] DROP CONSTRAINT [FK_tblCountry_tblStatus];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCustomer_tblCountry]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCustomer] DROP CONSTRAINT [FK_tblCustomer_tblCountry];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCustomer_tblCurrency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCustomer] DROP CONSTRAINT [FK_tblCustomer_tblCurrency];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCustomer_tblStatus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCustomer] DROP CONSTRAINT [FK_tblCustomer_tblStatus];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCustomerShipping_tblCountry]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCustomerShipping] DROP CONSTRAINT [FK_tblCustomerShipping_tblCountry];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCustomerShipping_tblCustomer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCustomerShipping] DROP CONSTRAINT [FK_tblCustomerShipping_tblCustomer];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCustomerShipping_tblStatus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCustomerShipping] DROP CONSTRAINT [FK_tblCustomerShipping_tblStatus];
GO
IF OBJECT_ID(N'[dbo].[FK_tblOffer_tblCustomer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblOffer] DROP CONSTRAINT [FK_tblOffer_tblCustomer];
GO
IF OBJECT_ID(N'[dbo].[FK_tblOffer_tblStatus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblOffer] DROP CONSTRAINT [FK_tblOffer_tblStatus];
GO
IF OBJECT_ID(N'[dbo].[FK_tblOfferDetail_tblOffer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblOfferDetail] DROP CONSTRAINT [FK_tblOfferDetail_tblOffer];
GO
IF OBJECT_ID(N'[dbo].[FK_tblOfferDetail_tblProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblOfferDetail] DROP CONSTRAINT [FK_tblOfferDetail_tblProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_tblOfferDetail_tblStatus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblOfferDetail] DROP CONSTRAINT [FK_tblOfferDetail_tblStatus];
GO
IF OBJECT_ID(N'[dbo].[FK_tblOfferDetailLog_tblOfferLog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblOfferDetailLog] DROP CONSTRAINT [FK_tblOfferDetailLog_tblOfferLog];
GO
IF OBJECT_ID(N'[dbo].[FK_tblProduct_tblCurrency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblProduct] DROP CONSTRAINT [FK_tblProduct_tblCurrency];
GO
IF OBJECT_ID(N'[dbo].[FK_tblProduct_tblFile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblProduct] DROP CONSTRAINT [FK_tblProduct_tblFile];
GO
IF OBJECT_ID(N'[dbo].[FK_tblProduct_tblStatus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblProduct] DROP CONSTRAINT [FK_tblProduct_tblStatus];
GO
IF OBJECT_ID(N'[dbo].[FK_tblProductBrand_tblBrand]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblProductBrand] DROP CONSTRAINT [FK_tblProductBrand_tblBrand];
GO
IF OBJECT_ID(N'[dbo].[FK_tblProductBrand_tblProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblProductBrand] DROP CONSTRAINT [FK_tblProductBrand_tblProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_tblProductCategory_tblCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblProductCategory] DROP CONSTRAINT [FK_tblProductCategory_tblCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_tblProductCategory_tblProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblProductCategory] DROP CONSTRAINT [FK_tblProductCategory_tblProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_tblProductFile_tblFile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblProductFile] DROP CONSTRAINT [FK_tblProductFile_tblFile];
GO
IF OBJECT_ID(N'[dbo].[FK_tblProductFile_tblProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblProductFile] DROP CONSTRAINT [FK_tblProductFile_tblProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_tblProductHistory_tblCustomer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblProductHistory] DROP CONSTRAINT [FK_tblProductHistory_tblCustomer];
GO
IF OBJECT_ID(N'[dbo].[FK_tblProductHistory_tblProductHistory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblProductHistory] DROP CONSTRAINT [FK_tblProductHistory_tblProductHistory];
GO
IF OBJECT_ID(N'[dbo].[FK_tblProductSupplier_tblProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblProductSupplier] DROP CONSTRAINT [FK_tblProductSupplier_tblProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_tblProductSupplier_tblSupplier]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblProductSupplier] DROP CONSTRAINT [FK_tblProductSupplier_tblSupplier];
GO
IF OBJECT_ID(N'[dbo].[FK_tblProductSupplierHistory_tblProductSupplierHistory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblProductSupplierHistory] DROP CONSTRAINT [FK_tblProductSupplierHistory_tblProductSupplierHistory];
GO
IF OBJECT_ID(N'[dbo].[FK_tblProductSupplierHistory_tblStatus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblProductSupplierHistory] DROP CONSTRAINT [FK_tblProductSupplierHistory_tblStatus];
GO
IF OBJECT_ID(N'[dbo].[FK_tblProductSupplierHistory_tblSupplier]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblProductSupplierHistory] DROP CONSTRAINT [FK_tblProductSupplierHistory_tblSupplier];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPurchasOrder_tblPurchasOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchasOrder] DROP CONSTRAINT [FK_tblPurchasOrder_tblPurchasOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPurchasOrder_tblSupplier]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchasOrder] DROP CONSTRAINT [FK_tblPurchasOrder_tblSupplier];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPurchasOrderDetail_tblCustomer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchasOrderDetail] DROP CONSTRAINT [FK_tblPurchasOrderDetail_tblCustomer];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPurchasOrderDetail_tblProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchasOrderDetail] DROP CONSTRAINT [FK_tblPurchasOrderDetail_tblProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPurchasOrderDetail_tblPurchasOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchasOrderDetail] DROP CONSTRAINT [FK_tblPurchasOrderDetail_tblPurchasOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPurchasOrderDetail_tblStatus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchasOrderDetail] DROP CONSTRAINT [FK_tblPurchasOrderDetail_tblStatus];
GO
IF OBJECT_ID(N'[dbo].[FK_tblRole_tblStatus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblRole] DROP CONSTRAINT [FK_tblRole_tblStatus];
GO
IF OBJECT_ID(N'[dbo].[FK_tblRoleMenu_tblMenu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblRoleMenu] DROP CONSTRAINT [FK_tblRoleMenu_tblMenu];
GO
IF OBJECT_ID(N'[dbo].[FK_tblRoleMenu_tblRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblRoleMenu] DROP CONSTRAINT [FK_tblRoleMenu_tblRole];
GO
IF OBJECT_ID(N'[dbo].[FK_tblRoleUser_tblRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblRoleUser] DROP CONSTRAINT [FK_tblRoleUser_tblRole];
GO
IF OBJECT_ID(N'[dbo].[FK_tblStatus_tblStatusType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblStatus] DROP CONSTRAINT [FK_tblStatus_tblStatusType];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSupplier_tblCountry]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSupplier] DROP CONSTRAINT [FK_tblSupplier_tblCountry];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSupplier_tblCurrency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSupplier] DROP CONSTRAINT [FK_tblSupplier_tblCurrency];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSupplier_tblFile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSupplier] DROP CONSTRAINT [FK_tblSupplier_tblFile];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSupplier_tblStatus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSupplier] DROP CONSTRAINT [FK_tblSupplier_tblStatus];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[tblBrand]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblBrand];
GO
IF OBJECT_ID(N'[dbo].[tblCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCategory];
GO
IF OBJECT_ID(N'[dbo].[tblCountry]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCountry];
GO
IF OBJECT_ID(N'[dbo].[tblCurrency]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCurrency];
GO
IF OBJECT_ID(N'[dbo].[tblCustomer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCustomer];
GO
IF OBJECT_ID(N'[dbo].[tblCustomerShipping]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCustomerShipping];
GO
IF OBJECT_ID(N'[dbo].[tblFile]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblFile];
GO
IF OBJECT_ID(N'[dbo].[tblMenu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblMenu];
GO
IF OBJECT_ID(N'[dbo].[tblOffer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblOffer];
GO
IF OBJECT_ID(N'[dbo].[tblOfferDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblOfferDetail];
GO
IF OBJECT_ID(N'[dbo].[tblOfferDetailLog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblOfferDetailLog];
GO
IF OBJECT_ID(N'[dbo].[tblOfferLog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblOfferLog];
GO
IF OBJECT_ID(N'[dbo].[tblProduct]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblProduct];
GO
IF OBJECT_ID(N'[dbo].[tblProductBrand]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblProductBrand];
GO
IF OBJECT_ID(N'[dbo].[tblProductCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblProductCategory];
GO
IF OBJECT_ID(N'[dbo].[tblProductFile]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblProductFile];
GO
IF OBJECT_ID(N'[dbo].[tblProductHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblProductHistory];
GO
IF OBJECT_ID(N'[dbo].[tblProductSupplier]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblProductSupplier];
GO
IF OBJECT_ID(N'[dbo].[tblProductSupplierHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblProductSupplierHistory];
GO
IF OBJECT_ID(N'[dbo].[tblPurchasOrder]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblPurchasOrder];
GO
IF OBJECT_ID(N'[dbo].[tblPurchasOrderDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblPurchasOrderDetail];
GO
IF OBJECT_ID(N'[dbo].[tblPurchasOrderDetailLog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblPurchasOrderDetailLog];
GO
IF OBJECT_ID(N'[dbo].[tblPurchasOrderLog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblPurchasOrderLog];
GO
IF OBJECT_ID(N'[dbo].[tblRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblRole];
GO
IF OBJECT_ID(N'[dbo].[tblRoleMenu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblRoleMenu];
GO
IF OBJECT_ID(N'[dbo].[tblRoleUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblRoleUser];
GO
IF OBJECT_ID(N'[dbo].[tblStatus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblStatus];
GO
IF OBJECT_ID(N'[dbo].[tblStatusType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblStatusType];
GO
IF OBJECT_ID(N'[dbo].[tblSupplier]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblSupplier];
GO
IF OBJECT_ID(N'[ICONEntitiesStoreContainer].[__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [ICONEntitiesStoreContainer].[__MigrationHistory];
GO
IF OBJECT_ID(N'[ICONEntitiesStoreContainer].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [ICONEntitiesStoreContainer].[AspNetRoles];
GO
IF OBJECT_ID(N'[ICONEntitiesStoreContainer].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [ICONEntitiesStoreContainer].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[ICONEntitiesStoreContainer].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [ICONEntitiesStoreContainer].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[ICONEntitiesStoreContainer].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [ICONEntitiesStoreContainer].[AspNetUserRoles];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL,
    [CustomerId] uniqueidentifier  NOT NULL,
    [StatusId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'tblBrands'
CREATE TABLE [dbo].[tblBrands] (
    [BrandId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [DisplayOrder] int  NULL,
    [StatusId] uniqueidentifier  NOT NULL,
    [CreateBy] nvarchar(250)  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [ModifyBy] nvarchar(250)  NULL,
    [ModifyDate] datetime  NULL,
    [FileId] uniqueidentifier  NULL,
    [IsVISMA] bit  NOT NULL
);
GO

-- Creating table 'tblCategories'
CREATE TABLE [dbo].[tblCategories] (
    [CategoryId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [DisplayOrder] int  NULL,
    [StatusId] uniqueidentifier  NOT NULL,
    [CreateBy] nvarchar(250)  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [ModifyBy] nvarchar(250)  NULL,
    [ModifyDate] datetime  NULL,
    [FileId] uniqueidentifier  NULL,
    [IsVISMA] bit  NOT NULL,
    [ParentCategoryId] uniqueidentifier  NULL,
    [MainGroupNo] int  NULL,
    [IntermediateGroupNo] int  NULL
);
GO

-- Creating table 'tblCountries'
CREATE TABLE [dbo].[tblCountries] (
    [CountryId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [DisplayOrder] int  NULL,
    [StatusId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'tblCurrencies'
CREATE TABLE [dbo].[tblCurrencies] (
    [CurrencyId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [DisplayOrder] int  NULL,
    [StatusId] uniqueidentifier  NOT NULL,
    [Symbol] nvarchar(250)  NULL
);
GO

-- Creating table 'tblCustomers'
CREATE TABLE [dbo].[tblCustomers] (
    [CustomerId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(256)  NOT NULL,
    [OrganizationName] nvarchar(256)  NULL,
    [Email] nvarchar(256)  NOT NULL,
    [Phone] nvarchar(256)  NULL,
    [Address1] nvarchar(1024)  NULL,
    [Address2] nvarchar(1024)  NULL,
    [PostOffice] nvarchar(256)  NULL,
    [Kommune] nvarchar(256)  NULL,
    [CountryId] uniqueidentifier  NULL,
    [CurrencyId] uniqueidentifier  NULL,
    [CreditLimit] decimal(18,2)  NULL,
    [BankAccount] nvarchar(256)  NULL,
    [IBAN] nvarchar(256)  NULL,
    [SwiftCode] nvarchar(256)  NULL,
    [ContactNoConfirmOrder] nvarchar(256)  NULL,
    [OrganizationNumber] nvarchar(256)  NULL,
    [StatusId] uniqueidentifier  NULL,
    [CreateBy] nvarchar(250)  NULL,
    [CreationDate] datetime  NULL,
    [ModifyBy] nvarchar(250)  NULL,
    [ModifyDate] datetime  NULL,
    [FileId] uniqueidentifier  NULL,
    [IsVISMA] bit  NOT NULL,
    [City] nvarchar(256)  NULL,
    [IsUser] bit  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL,
    [CustomerNo] int  NULL,
    [EmployeeId] uniqueidentifier  NULL
);
GO

-- Creating table 'tblCustomerShippings'
CREATE TABLE [dbo].[tblCustomerShippings] (
    [CustomerShippingId] uniqueidentifier  NOT NULL,
    [CustomerId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(256)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [Phone] nvarchar(256)  NULL,
    [Address1] nvarchar(1024)  NULL,
    [Address2] nvarchar(1024)  NULL,
    [PostOffice] nvarchar(256)  NULL,
    [Kommune] nvarchar(256)  NULL,
    [CountryId] uniqueidentifier  NULL,
    [City] nvarchar(256)  NULL,
    [StatusId] uniqueidentifier  NULL,
    [CreateBy] nvarchar(250)  NULL,
    [CreationDate] datetime  NULL,
    [ModifyBy] nvarchar(250)  NULL,
    [ModifyDate] datetime  NULL,
    [IsVISMA] bit  NOT NULL,
    [AddressId] int  NOT NULL
);
GO

-- Creating table 'tblEmployees'
CREATE TABLE [dbo].[tblEmployees] (
    [EmployeeId] uniqueidentifier  NOT NULL,
    [EmployeeNo] int  NULL,
    [Name] nvarchar(300)  NOT NULL,
    [Title] nvarchar(300)  NULL,
    [InternalTelephone] nvarchar(300)  NULL,
    [MobileTelephone] nvarchar(300)  NULL,
    [CountryId] uniqueidentifier  NULL,
    [PostOffice] nvarchar(300)  NULL,
    [PostCode] nvarchar(300)  NULL,
    [Address1] nvarchar(300)  NULL,
    [HireDate] datetime  NULL,
    [ReportsToId] uniqueidentifier  NULL,
    [BankAccount] nvarchar(300)  NOT NULL,
    [PostAccount] nvarchar(300)  NULL,
    [Email] nvarchar(300)  NULL,
    [Address3] nvarchar(300)  NULL,
    [Address2] nvarchar(300)  NULL,
    [NickName] nvarchar(300)  NULL,
    [Sex] int  NULL,
    [MiddleName] nvarchar(300)  NULL,
    [FamilyName] nvarchar(300)  NULL,
    [DisplayOrder] int  NULL,
    [StatusId] uniqueidentifier  NOT NULL,
    [CreateBy] nvarchar(250)  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [ModifyBy] nvarchar(250)  NULL,
    [ModifyDate] datetime  NULL,
    [FileId] uniqueidentifier  NULL,
    [IsVISMA] bit  NOT NULL
);
GO

-- Creating table 'tblFiles'
CREATE TABLE [dbo].[tblFiles] (
    [FileId] uniqueidentifier  NOT NULL,
    [FileName] nvarchar(250)  NOT NULL,
    [ContentType] nvarchar(250)  NOT NULL,
    [ContentData] varbinary(max)  NOT NULL,
    [FileType] tinyint  NOT NULL
);
GO

-- Creating table 'tblIntermediateGroups'
CREATE TABLE [dbo].[tblIntermediateGroups] (
    [IntermediateGroupId] uniqueidentifier  NOT NULL,
    [IntermediateGroupNo] int  NULL,
    [MainGroupNo] int  NULL,
    [MainGroupId] uniqueidentifier  NULL,
    [Name] nvarchar(250)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [DisplayOrder] int  NULL,
    [StatusId] uniqueidentifier  NOT NULL,
    [CreateBy] nvarchar(250)  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [ModifyBy] nvarchar(250)  NULL,
    [ModifyDate] datetime  NULL,
    [FileId] uniqueidentifier  NULL,
    [IsVISMA] bit  NOT NULL
);
GO

-- Creating table 'tblMainGroups'
CREATE TABLE [dbo].[tblMainGroups] (
    [MainGroupId] uniqueidentifier  NOT NULL,
    [MainGroupNo] int  NULL,
    [Name] nvarchar(250)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [DisplayOrder] int  NULL,
    [StatusId] uniqueidentifier  NOT NULL,
    [CreateBy] nvarchar(250)  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [ModifyBy] nvarchar(250)  NULL,
    [ModifyDate] datetime  NULL,
    [FileId] uniqueidentifier  NULL,
    [IsVISMA] bit  NOT NULL
);
GO

-- Creating table 'tblMenus'
CREATE TABLE [dbo].[tblMenus] (
    [MenuId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [URL] nvarchar(250)  NULL,
    [DisplayOrder] int  NULL,
    [ParentMenuId] uniqueidentifier  NULL,
    [CSSClass] nvarchar(250)  NULL
);
GO

-- Creating table 'tblOffers'
CREATE TABLE [dbo].[tblOffers] (
    [OfferId] uniqueidentifier  NOT NULL,
    [CustomerId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [StatusId] uniqueidentifier  NOT NULL,
    [CreateBy] nvarchar(250)  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [ModifyBy] nvarchar(250)  NULL,
    [ModifyDate] datetime  NULL,
    [IsVISMA] bit  NOT NULL,
    [OfferDate] datetime  NULL,
    [OfferAcceptanceDate] datetime  NULL,
    [OfferApprovalDate] datetime  NULL
);
GO

-- Creating table 'tblOfferDetails'
CREATE TABLE [dbo].[tblOfferDetails] (
    [OfferDetailId] uniqueidentifier  NOT NULL,
    [OfferId] uniqueidentifier  NOT NULL,
    [ProductId] uniqueidentifier  NOT NULL,
    [ProductName] nvarchar(250)  NOT NULL,
    [History] nvarchar(max)  NULL,
    [ProductPrice] decimal(18,2)  NULL,
    [ProductStock] int  NULL,
    [OfferPrice] decimal(18,2)  NULL,
    [OfferQty] int  NULL,
    [OfferRemarks] nvarchar(max)  NULL,
    [StatusId] uniqueidentifier  NOT NULL,
    [CreateBy] nvarchar(250)  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [ModifyBy] nvarchar(250)  NULL,
    [ModifyDate] datetime  NULL,
    [CustomerPrice] decimal(18,2)  NULL,
    [CustomerQty] int  NULL,
    [CustomerRemarks] nvarchar(max)  NULL,
    [FinalPrice] decimal(18,2)  NULL,
    [FinalQty] int  NULL,
    [FinalRemarks] nvarchar(max)  NULL,
    [ProductUCPCode] nvarchar(250)  NULL
);
GO

-- Creating table 'tblOfferDetailLogs'
CREATE TABLE [dbo].[tblOfferDetailLogs] (
    [OfferDetailLogId] uniqueidentifier  NOT NULL,
    [OfferlogId] uniqueidentifier  NOT NULL,
    [OfferDetailId] uniqueidentifier  NOT NULL,
    [OfferId] uniqueidentifier  NOT NULL,
    [ProductId] uniqueidentifier  NOT NULL,
    [ProductName] nvarchar(250)  NOT NULL,
    [History] nvarchar(max)  NULL,
    [ProductPrice] decimal(18,2)  NULL,
    [ProductStock] int  NULL,
    [OfferPrice] decimal(18,2)  NULL,
    [OfferQty] int  NULL,
    [OfferRemarks] nvarchar(max)  NULL,
    [StatusId] uniqueidentifier  NOT NULL,
    [CreateBy] nvarchar(250)  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [ModifyBy] nvarchar(250)  NULL,
    [ModifyDate] datetime  NULL,
    [CustomerPrice] decimal(18,2)  NULL,
    [CustomerQty] int  NULL,
    [CustomerRemarks] nvarchar(max)  NULL,
    [FinalPrice] decimal(18,2)  NULL,
    [FinalQty] int  NULL,
    [FinalRemarks] nvarchar(max)  NULL
);
GO

-- Creating table 'tblOfferLogs'
CREATE TABLE [dbo].[tblOfferLogs] (
    [OfferlogId] uniqueidentifier  NOT NULL,
    [OfferId] uniqueidentifier  NOT NULL,
    [CustomerId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [StatusId] uniqueidentifier  NOT NULL,
    [CreateBy] nvarchar(250)  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [ModifyBy] nvarchar(250)  NULL,
    [ModifyDate] datetime  NULL,
    [IsVISMA] bit  NOT NULL,
    [OfferDate] datetime  NULL,
    [OfferAcceptanceDate] datetime  NULL,
    [OfferApprovalDate] datetime  NULL
);
GO

-- Creating table 'tblOrders'
CREATE TABLE [dbo].[tblOrders] (
    [OrderId] uniqueidentifier  NOT NULL,
    [CustomerId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [StatusId] uniqueidentifier  NOT NULL,
    [CreateBy] nvarchar(250)  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [ModifyBy] nvarchar(250)  NULL,
    [ModifyDate] datetime  NULL,
    [IsVISMA] bit  NOT NULL,
    [OrderDate] datetime  NULL,
    [AcceptanceDeliveryDate] datetime  NULL,
    [ActualDeliveryDate] datetime  NULL,
    [OfferId] uniqueidentifier  NULL,
    [TotalAcount] decimal(18,2)  NULL,
    [EmployeeId] uniqueidentifier  NULL,
    [OrderNo] nvarchar(300)  NULL
);
GO

-- Creating table 'tblOrderDetails'
CREATE TABLE [dbo].[tblOrderDetails] (
    [OrderDetailId] uniqueidentifier  NOT NULL,
    [OrderId] uniqueidentifier  NOT NULL,
    [ProductId] uniqueidentifier  NOT NULL,
    [ProductName] nvarchar(250)  NOT NULL,
    [ProductPrice] decimal(18,2)  NULL,
    [ProductStock] int  NULL,
    [OrderPrice] decimal(18,2)  NULL,
    [OrderQty] int  NULL,
    [OrderRemarks] nvarchar(max)  NULL,
    [StatusId] uniqueidentifier  NOT NULL,
    [CreateBy] nvarchar(250)  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [ModifyBy] nvarchar(250)  NULL,
    [ModifyDate] datetime  NULL,
    [ProductUCPCode] nvarchar(250)  NULL,
    [OfferDetailId] uniqueidentifier  NULL
);
GO

-- Creating table 'tblProducts'
CREATE TABLE [dbo].[tblProducts] (
    [ProductId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [ShortDescription] nvarchar(1000)  NULL,
    [FullDescription] nvarchar(max)  NULL,
    [DisplayOrder] int  NULL,
    [StatusId] uniqueidentifier  NOT NULL,
    [CreateBy] nvarchar(250)  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [ModifyBy] nvarchar(250)  NULL,
    [ModifyDate] datetime  NULL,
    [IsVISMA] bit  NOT NULL,
    [FileId] uniqueidentifier  NULL,
    [UPC_code] nvarchar(250)  NULL,
    [Price] decimal(18,2)  NULL,
    [Purchase_Price_NOK] decimal(18,2)  NULL,
    [Purchase_price_USD_EURO] decimal(18,2)  NULL,
    [Price_customs_NOK] decimal(18,2)  NULL,
    [MainGroupId] uniqueidentifier  NULL,
    [IntermediateGroupId] uniqueidentifier  NULL,
    [SubGroupId] uniqueidentifier  NULL,
    [ProductTypeId] uniqueidentifier  NULL,
    [Lager_profile] nvarchar(250)  NULL,
    [SupplierId] uniqueidentifier  NULL,
    [Year_Article_type] nvarchar(250)  NULL,
    [Season] nvarchar(250)  NULL,
    [Segment] nvarchar(250)  NULL,
    [Gender] nvarchar(50)  NULL,
    [Size] nvarchar(250)  NULL,
    [Colour] nvarchar(250)  NULL,
    [UnitId] uniqueidentifier  NULL,
    [Sales_Pack] nvarchar(250)  NULL,
    [Master_Pack] nvarchar(250)  NULL,
    [ProductStock] int  NULL,
    [PublishDate] datetime  NULL,
    [CurrencyId] uniqueidentifier  NULL,
    [ArticleNo] nvarchar(300)  NULL,
    [IsNew] bit  NULL,
    [IsHot] bit  NULL,
    [style] nvarchar(300)  NULL,
    [Out_Price] decimal(18,2)  NULL,
    [In_Price] decimal(18,2)  NULL,
    [Cost_Price] decimal(18,2)  NULL,
    [Supplier_price] decimal(18,2)  NULL,
    [Category] nvarchar(300)  NULL,
    [SubCategory] nvarchar(300)  NULL,
    [Product] nvarchar(300)  NULL,
    [ProductType] nvarchar(300)  NULL,
    [Brand] nvarchar(300)  NULL,
    [WareHouseNo] int  NULL,
    [UnitOnPurchase] int  NULL,
    [MaxStock] int  NULL,
    [MinStock] int  NULL,
    [UnitInStock] int  NULL,
    [UnitOnOrder] int  NULL,
    [UnitOnReminder] int  NULL,
    [UnitPacked] int  NULL,
    [QtyManualReserved] int  NULL,
    [QtyReserved] int  NULL,
    [ImgURL] nvarchar(300)  NULL,
    [Hovedgr] nvarchar(250)  NULL,
    [Mellomgr] nvarchar(250)  NULL,
    [Undergr] nvarchar(250)  NULL,
    [Unit] nvarchar(250)  NULL
);
GO

-- Creating table 'tblProductBrands'
CREATE TABLE [dbo].[tblProductBrands] (
    [ProductBrandId] uniqueidentifier  NOT NULL,
    [ProductId] uniqueidentifier  NOT NULL,
    [BrandId] uniqueidentifier  NOT NULL,
    [CreateBy] nvarchar(250)  NOT NULL,
    [CreationDate] datetime  NOT NULL
);
GO

-- Creating table 'tblProductCategories'
CREATE TABLE [dbo].[tblProductCategories] (
    [ProductCategoryId] uniqueidentifier  NOT NULL,
    [ProductId] uniqueidentifier  NOT NULL,
    [CategoryId] uniqueidentifier  NOT NULL,
    [CreateBy] nvarchar(250)  NOT NULL,
    [CreationDate] datetime  NOT NULL
);
GO

-- Creating table 'tblProductFiles'
CREATE TABLE [dbo].[tblProductFiles] (
    [ProductFileId] uniqueidentifier  NOT NULL,
    [ProductId] uniqueidentifier  NOT NULL,
    [FileId] uniqueidentifier  NOT NULL,
    [CreateBy] nvarchar(250)  NOT NULL,
    [CreationDate] datetime  NOT NULL
);
GO

-- Creating table 'tblProductHistories'
CREATE TABLE [dbo].[tblProductHistories] (
    [ProductHistoryId] uniqueidentifier  NOT NULL,
    [CustomerId] uniqueidentifier  NOT NULL,
    [Price] decimal(18,2)  NOT NULL,
    [Qty] int  NOT NULL,
    [SaleDate] datetime  NOT NULL,
    [ProductId] uniqueidentifier  NOT NULL,
    [StatusId] uniqueidentifier  NOT NULL,
    [CreateBy] nvarchar(250)  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [ProductName] nvarchar(250)  NOT NULL,
    [Remarks] nvarchar(max)  NULL
);
GO

-- Creating table 'tblProductSuppliers'
CREATE TABLE [dbo].[tblProductSuppliers] (
    [ProductSupplierId] uniqueidentifier  NOT NULL,
    [ProductId] uniqueidentifier  NOT NULL,
    [SupplierId] uniqueidentifier  NOT NULL,
    [CreateBy] nvarchar(250)  NOT NULL,
    [CreationDate] datetime  NOT NULL
);
GO

-- Creating table 'tblProductSupplierHistories'
CREATE TABLE [dbo].[tblProductSupplierHistories] (
    [ProductSupplierHistoryId] uniqueidentifier  NOT NULL,
    [SupplierId] uniqueidentifier  NOT NULL,
    [Price] decimal(18,2)  NULL,
    [Qty] int  NULL,
    [SaleDate] datetime  NULL,
    [ProductId] uniqueidentifier  NULL,
    [StatusId] uniqueidentifier  NULL,
    [CreateBy] nvarchar(250)  NULL,
    [CreationDate] datetime  NULL,
    [ProductName] nvarchar(250)  NULL,
    [Remarks] nvarchar(max)  NULL
);
GO

-- Creating table 'tblProductUnitTypes'
CREATE TABLE [dbo].[tblProductUnitTypes] (
    [ProductUnitTypeId] uniqueidentifier  NOT NULL,
    [ProductId] uniqueidentifier  NOT NULL,
    [UnitId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(300)  NOT NULL,
    [UnitNamePurchase] nvarchar(300)  NULL,
    [Factor] int  NULL,
    [ISOCode] nvarchar(300)  NULL,
    [Height] int  NULL,
    [VariableQty] bit  NULL,
    [Width] int  NULL,
    [Length] int  NULL,
    [Volume] int  NULL,
    [Rounding] int  NULL,
    [Comment] nvarchar(max)  NULL,
    [UnitInPurchase] int  NULL,
    [SplitPurchase] int  NULL,
    [UnitInSales] int  NULL,
    [SplitSales] bit  NULL,
    [Weight] int  NULL,
    [PackingType] nvarchar(300)  NULL,
    [ComparableUnit] bit  NULL,
    [Location] nvarchar(300)  NULL,
    [UnitInStockControl] int  NULL,
    [UnitTypeNo] int  NULL,
    [StatusId] uniqueidentifier  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [ModifyBy] nvarchar(250)  NULL,
    [ModifyDate] datetime  NULL,
    [IsVISMA] bit  NOT NULL,
    [CreateBy] nvarchar(250)  NOT NULL
);
GO

-- Creating table 'tblPurchasOrders'
CREATE TABLE [dbo].[tblPurchasOrders] (
    [PurchasOrderId] uniqueidentifier  NOT NULL,
    [SupplierId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [StatusId] uniqueidentifier  NOT NULL,
    [CreateBy] nvarchar(250)  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [ModifyBy] nvarchar(250)  NULL,
    [ModifyDate] datetime  NULL,
    [IsVISMA] bit  NOT NULL,
    [PurchasOrderDate] datetime  NULL,
    [ExpectDeliveryDate] datetime  NULL,
    [ActualDeliveryDate] datetime  NULL,
    [IsAllItemReceive] bit  NULL,
    [TotalAcount] decimal(18,2)  NULL,
    [SupplierOrderNo] nvarchar(300)  NULL
);
GO

-- Creating table 'tblPurchasOrderDetails'
CREATE TABLE [dbo].[tblPurchasOrderDetails] (
    [PurchasOrderDetailId] uniqueidentifier  NOT NULL,
    [PurchasOrderId] uniqueidentifier  NOT NULL,
    [ProductId] uniqueidentifier  NOT NULL,
    [ProductName] nvarchar(250)  NOT NULL,
    [ProductUCPCode] nvarchar(250)  NOT NULL,
    [PurchaseOrderHistory] nvarchar(max)  NULL,
    [PurchaseOrderPrice] decimal(18,2)  NULL,
    [PurchaseOrderQty] int  NULL,
    [ReceiveQty] int  NULL,
    [ReceiveDate] datetime  NULL,
    [PurchaseOrderRemark] nvarchar(max)  NULL,
    [IsAllItemReceive] bit  NULL,
    [StatusId] uniqueidentifier  NOT NULL,
    [CreateBy] nvarchar(250)  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [ModifyBy] nvarchar(250)  NULL,
    [ModifyDate] datetime  NULL,
    [CustomerId] uniqueidentifier  NULL,
    [OrderQty] int  NULL,
    [OrderId] uniqueidentifier  NULL,
    [OrderDetailId] uniqueidentifier  NULL,
    [OrderPrice] decimal(18,2)  NULL,
    [History] nvarchar(max)  NULL,
    [Remark] nvarchar(max)  NULL,
    [OfferQty] int  NULL,
    [OfferId] uniqueidentifier  NULL,
    [OfferDetailId] uniqueidentifier  NULL,
    [OfferPrice] decimal(18,0)  NULL
);
GO

-- Creating table 'tblPurchasOrderDetailLogs'
CREATE TABLE [dbo].[tblPurchasOrderDetailLogs] (
    [PurchasOrderDetailLogId] uniqueidentifier  NOT NULL,
    [PurchasOrderLogId] uniqueidentifier  NOT NULL,
    [PurchasOrderDetailId] uniqueidentifier  NOT NULL,
    [PurchasOrderId] uniqueidentifier  NOT NULL,
    [ProductId] uniqueidentifier  NOT NULL,
    [ProductName] nvarchar(250)  NOT NULL,
    [ProductUCPCode] nvarchar(250)  NOT NULL,
    [PurchaseOrderHistory] nvarchar(max)  NULL,
    [PurchaseOrderPrice] decimal(18,2)  NULL,
    [PurchaseOrderQty] int  NULL,
    [ReceiveQty] int  NULL,
    [ReceiveDate] datetime  NULL,
    [PurchaseOrderRemark] nvarchar(max)  NULL,
    [IsAllItemReceive] bit  NULL,
    [StatusId] uniqueidentifier  NOT NULL,
    [CreateBy] nvarchar(250)  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [ModifyBy] nvarchar(250)  NULL,
    [ModifyDate] datetime  NULL,
    [CustomerId] uniqueidentifier  NULL,
    [OrderQty] int  NULL,
    [OrderId] uniqueidentifier  NULL,
    [OrderDetailId] uniqueidentifier  NULL,
    [OrderPrice] decimal(18,2)  NULL,
    [History] nvarchar(max)  NULL,
    [Remark] nvarchar(max)  NULL,
    [OfferQty] int  NULL,
    [OfferId] uniqueidentifier  NULL,
    [OfferDetailId] uniqueidentifier  NULL,
    [OfferPrice] decimal(18,0)  NULL
);
GO

-- Creating table 'tblPurchasOrderLogs'
CREATE TABLE [dbo].[tblPurchasOrderLogs] (
    [PurchasOrderLogId] uniqueidentifier  NOT NULL,
    [PurchasOrderId] uniqueidentifier  NOT NULL,
    [SupplierId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [StatusId] uniqueidentifier  NOT NULL,
    [CreateBy] nvarchar(250)  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [ModifyBy] nvarchar(250)  NULL,
    [ModifyDate] datetime  NULL,
    [IsVISMA] bit  NOT NULL,
    [PurchasOrderDate] datetime  NULL,
    [ExpectDeliveryDate] datetime  NULL,
    [ActualDeliveryDate] datetime  NULL,
    [IsAllItemReceive] bit  NULL
);
GO

-- Creating table 'tblRoles'
CREATE TABLE [dbo].[tblRoles] (
    [RoleId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [Description] nvarchar(1024)  NULL,
    [StatusId] uniqueidentifier  NOT NULL,
    [CreateBy] nvarchar(250)  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [ModifyBy] nvarchar(250)  NULL,
    [ModifyDate] datetime  NULL
);
GO

-- Creating table 'tblRoleMenus'
CREATE TABLE [dbo].[tblRoleMenus] (
    [RoleMenuId] uniqueidentifier  NOT NULL,
    [RoleId] uniqueidentifier  NOT NULL,
    [MenuId] uniqueidentifier  NOT NULL,
    [CreateBy] nvarchar(250)  NOT NULL,
    [CreationDate] datetime  NOT NULL
);
GO

-- Creating table 'tblRoleUsers'
CREATE TABLE [dbo].[tblRoleUsers] (
    [RoleUserId] uniqueidentifier  NOT NULL,
    [RoleId] uniqueidentifier  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL,
    [CreateBy] nvarchar(250)  NOT NULL,
    [CreationDate] datetime  NOT NULL
);
GO

-- Creating table 'tblStatus'
CREATE TABLE [dbo].[tblStatus] (
    [StatusId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [StatusTypeId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'tblStatusTypes'
CREATE TABLE [dbo].[tblStatusTypes] (
    [StatusTypeId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'tblSubGroups'
CREATE TABLE [dbo].[tblSubGroups] (
    [SubGroupId] uniqueidentifier  NOT NULL,
    [SubGroupNo] int  NULL,
    [IntermediateGroupId] uniqueidentifier  NULL,
    [IntermediateGroupNo] int  NULL,
    [Name] nvarchar(250)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [DisplayOrder] int  NULL,
    [StatusId] uniqueidentifier  NOT NULL,
    [CreateBy] nvarchar(250)  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [ModifyBy] nvarchar(250)  NULL,
    [ModifyDate] datetime  NULL,
    [FileId] uniqueidentifier  NULL,
    [IsVISMA] bit  NOT NULL
);
GO

-- Creating table 'tblSuppliers'
CREATE TABLE [dbo].[tblSuppliers] (
    [SupplierId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [Phone] nvarchar(256)  NULL,
    [Address1] nvarchar(1024)  NULL,
    [Address2] nvarchar(1024)  NULL,
    [PostOffice] nvarchar(256)  NULL,
    [Kommune] nvarchar(256)  NULL,
    [CountryId] uniqueidentifier  NOT NULL,
    [CurrencyId] uniqueidentifier  NULL,
    [CreditLimit] decimal(18,2)  NULL,
    [BankAccount] nvarchar(256)  NULL,
    [BankName] nvarchar(256)  NULL,
    [IBAN] nvarchar(256)  NULL,
    [PostAccount] nvarchar(256)  NULL,
    [SwiftCode] nvarchar(256)  NULL,
    [Contact] nvarchar(256)  NULL,
    [StatusId] uniqueidentifier  NULL,
    [CreateBy] nvarchar(250)  NULL,
    [CreationDate] datetime  NULL,
    [ModifyBy] nvarchar(250)  NULL,
    [ModifyDate] datetime  NULL,
    [FileId] uniqueidentifier  NULL,
    [IsVISMA] bit  NOT NULL,
    [City] nvarchar(256)  NULL,
    [RegistrationDate] datetime  NULL,
    [Telefax] nvarchar(256)  NULL,
    [SupplierNo] int  NOT NULL,
    [UserName] nvarchar(300)  NULL,
    [EmployeeId] uniqueidentifier  NULL
);
GO

-- Creating table 'tblUnits'
CREATE TABLE [dbo].[tblUnits] (
    [UnitId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(300)  NOT NULL,
    [EDIName] nvarchar(300)  NULL,
    [DisplayOrder] int  NULL,
    [StatusId] uniqueidentifier  NOT NULL,
    [CreateBy] nvarchar(250)  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [ModifyBy] nvarchar(250)  NULL,
    [ModifyDate] datetime  NULL,
    [IsVISMA] bit  NOT NULL,
    [UnitNo] int  NULL
);
GO

-- Creating table 'vArticles'
CREATE TABLE [dbo].[vArticles] (
    [ArticleNo] nvarchar(300)  NOT NULL,
    [Name] nvarchar(300)  NULL,
    [Price1] decimal(18,2)  NULL,
    [PriceCalcMethodsNo] int  NULL,
    [QuantityPerUnitPurchase] int  NULL,
    [QuantityPerUnitSale] int  NULL,
    [StockProfileNo] int  NULL,
    [RegistrationDate] datetime  NULL,
    [StopDateOfferPrice] datetime  NULL,
    [ValidTo] datetime  NULL,
    [WarehouseNo] int  NULL,
    [PostingTemplateNo] int  NULL,
    [AgreedPrice] decimal(18,2)  NULL,
    [NetPrice] decimal(18,2)  NULL,
    [DiscountI] decimal(18,2)  NULL,
    [DiscountII] decimal(18,2)  NULL,
    [MainGroupNo] int  NULL,
    [IntermediateGroupNo] int  NULL,
    [SubGroupNo] int  NULL,
    [LastUpdate] datetime  NULL,
    [LastUpdatedBy] int  NULL,
    [InActiveYesNo] bit  NULL,
    [WebshopLastAvailableInStock] int  NULL,
    [WebshopArticleYesNo] bit  NULL,
    [ShowOnWebYesNo] bit  NULL,
    [MainStructureArtYesNo] bit  NULL,
    [CountedYesNo] bit  NULL,
    [PicturePath] nvarchar(300)  NULL,
    [MemoFilePath] nvarchar(300)  NULL,
    [POSArticleInfo] nvarchar(300)  NULL,
    [EUFiguresNo] int  NULL,
    [CountryOfOriginNo] int  NULL,
    [IsUpdated] bit  NOT NULL
);
GO

-- Creating table 'vArticleCustomFields'
CREATE TABLE [dbo].[vArticleCustomFields] (
    [ArticleNo] nvarchar(300)  NOT NULL,
    [Factor] int  NULL,
    [FactorCalcMethod] int  NULL,
    [NetPrice] decimal(18,2)  NULL,
    [Available] int  NULL,
    [ContributionCurrentPeriod] int  NULL,
    [ContributionYear] int  NULL,
    [ContributionPercent] int  NULL,
    [ProjectNo] int  NULL,
    [CurrencyCode] nvarchar(300)  NULL,
    [AgreedPrice] decimal(18,2)  NULL,
    [Discount] int  NULL,
    [PriceType] nvarchar(300)  NULL,
    [FirstDate] nvarchar(300)  NULL,
    [LastDate] nvarchar(300)  NULL,
    [DiscountI] int  NULL,
    [DiscountII] int  NULL,
    [DiscountIII] int  NULL,
    [Price1FromDate] datetime  NULL,
    [SupplPriceFromDate] datetime  NULL,
    [FullCostFromDate] datetime  NULL,
    [PriceCalcDate] datetime  NULL,
    [InActiveStatus] nvarchar(300)  NULL,
    [PriceTimesPurchUnit] decimal(18,2)  NULL,
    [ErrorCode] int  NULL,
    [UpdateStock] int  NULL,
    [LastMovementDate] datetime  NULL,
    [AutoConsumptionYesNo] int  NULL,
    [WeightedPurchasePriceYesNo] int  NULL,
    [ExchangePrice] decimal(18,2)  NULL,
    [CurrencyNo] nvarchar(300)  NULL,
    [TemplateArticle] nvarchar(300)  NULL,
    [Quantity] int  NULL,
    [ComparableUnitPrice] decimal(18,2)  NULL,
    [ComparableUnitType] nvarchar(300)  NULL,
    [ContributionInCurrency] int  NULL,
    [ColorMark] int  NULL,
    [IsUpdated] bit  NOT NULL
);
GO

-- Creating table 'vArticleGroupMains'
CREATE TABLE [dbo].[vArticleGroupMains] (
    [MainGroupNo] int  NOT NULL,
    [Name] nvarchar(300)  NULL,
    [StockControlYesNo] int  NULL,
    [RemainderOrderYesNo] int  NULL,
    [RemainderPurchasingYesNo] int  NULL,
    [AutoConsumptionYesNo] int  NULL,
    [AutoPriceVarianceYesNo] int  NULL,
    [ParentMainGroupNo] int  NULL,
    [FIFOYesNo] int  NULL,
    [InActiveYesNo] int  NULL,
    [LastUpdate] datetime  NULL,
    [LastUpdatedBy] int  NULL,
    [Created] datetime  NULL,
    [CreatedBy] int  NULL,
    [ShowInShoppingCart] int  NULL,
    [IsUpdated] bit  NOT NULL
);
GO

-- Creating table 'vArticleIntermediateGroups'
CREATE TABLE [dbo].[vArticleIntermediateGroups] (
    [IntermediateGroupNo] int  NOT NULL,
    [Name] nvarchar(300)  NULL,
    [MainGroupNo] int  NULL,
    [SortName] nvarchar(300)  NULL,
    [LastUpdate] datetime  NULL,
    [LastUpdatedBy] int  NULL,
    [Created] datetime  NULL,
    [CreatedBy] int  NULL,
    [InActiveYesNo] int  NULL,
    [IsUpdated] bit  NOT NULL
);
GO

-- Creating table 'vArticleStockInfoes'
CREATE TABLE [dbo].[vArticleStockInfoes] (
    [WareHouseNo] int  NULL,
    [ArticleNo] nvarchar(300)  NOT NULL,
    [Location] nvarchar(300)  NULL,
    [CountedUnit] int  NULL,
    [LotNo] int  NULL,
    [UnitOnPurchase] int  NULL,
    [MaxStock] int  NULL,
    [MinStock] int  NULL,
    [UnitInStock] int  NULL,
    [UnitOnOrder] int  NULL,
    [UnitOnReminder] int  NULL,
    [LastMovementDate] datetime  NULL,
    [UnitPacked] int  NULL,
    [CountedYesNo] int  NULL,
    [UnitOnLoan] int  NULL,
    [LastUpdate] datetime  NULL,
    [LastUpdatedBy] int  NULL,
    [QtyManualReserved] int  NULL,
    [QtyReserved] int  NULL,
    [LastStockCountDate] datetime  NULL,
    [IsUpdated] bit  NULL
);
GO

-- Creating table 'vArticleSubGroups'
CREATE TABLE [dbo].[vArticleSubGroups] (
    [SubGroupNo] int  NOT NULL,
    [IntermediateGroupNo] int  NOT NULL,
    [Name] nvarchar(300)  NULL,
    [SortName] nvarchar(300)  NULL,
    [LastUpdate] datetime  NULL,
    [LastUpdatedBy] int  NULL,
    [Created] datetime  NULL,
    [CreatedBy] int  NULL,
    [InActiveYesNo] int  NULL,
    [IsUpdated] bit  NOT NULL
);
GO

-- Creating table 'vArticleUnitTypes'
CREATE TABLE [dbo].[vArticleUnitTypes] (
    [UnitTypeNo] int  NOT NULL,
    [ArticleNo] nvarchar(300)  NULL,
    [WareHouseNo] int  NULL,
    [Name] nvarchar(300)  NULL,
    [UnitNamePurchase] nvarchar(300)  NULL,
    [Factor] int  NULL,
    [LastUpdate] datetime  NULL,
    [LastUpdatedBy] int  NULL,
    [ISOCode] nvarchar(300)  NULL,
    [Height] int  NULL,
    [VariableQtyYesNo] bit  NULL,
    [Width] int  NULL,
    [Length] int  NULL,
    [Volume] int  NULL,
    [Rounding] int  NULL,
    [PriceListNo] int  NULL,
    [Comment] nvarchar(300)  NULL,
    [UnitInPurchase] int  NULL,
    [SplitPurchaseYesNo] int  NULL,
    [UnitInSales] int  NULL,
    [SplitSalesYesNo] bit  NULL,
    [FactorCalcMethod] int  NULL,
    [Weight] int  NULL,
    [UnitNo] int  NULL,
    [PackingType] nvarchar(300)  NULL,
    [ComparableUnitYesNo] bit  NULL,
    [Location] nvarchar(300)  NULL,
    [UnitInStockControl] int  NULL,
    [IsUpdated] bit  NOT NULL
);
GO

-- Creating table 'vCustomers'
CREATE TABLE [dbo].[vCustomers] (
    [CustomerNo] int  NOT NULL,
    [Name] nvarchar(300)  NULL,
    [Address1] nvarchar(300)  NULL,
    [EmailAddress] nvarchar(300)  NULL,
    [Address2] nvarchar(300)  NULL,
    [PostCode] nvarchar(300)  NULL,
    [PostOffice] nvarchar(300)  NULL,
    [CountryNo] int  NULL,
    [Phone] nvarchar(300)  NULL,
    [InActiveYesNo] bit  NULL,
    [Balance] int  NULL,
    [FormProfileCustNo] int  NULL,
    [DeliveryMethodsNo] int  NULL,
    [BusinessNo] int  NULL,
    [CustomerProfileNo] int  NULL,
    [EmployeeNo] int  NULL,
    [TermsOfPayCustNo] int  NULL,
    [CustomerGrpNo] int  NULL,
    [DistrictNo] int  NULL,
    [PriceCode] int  NULL,
    [CurrencyNo] int  NULL,
    [CreditLimit] decimal(18,2)  NULL,
    [CompanyNo] nvarchar(300)  NULL,
    [BankAccount] nvarchar(300)  NULL,
    [OurSupplNo] int  NULL,
    [CustomerTypeNo] int  NULL,
    [AccessLevel] int  NULL,
    [Password] nvarchar(300)  NULL,
    [ChainLeaderYesNo] int  NULL,
    [TypeOfChain] int  NULL,
    [ProductNo] int  NULL,
    [ProjectNo] int  NULL,
    [DepNo] int  NULL,
    [SupplierNo] int  NULL,
    [DeliveryAddressNo] int  NULL,
    [Address3] nvarchar(300)  NULL,
    [LastUpdate] datetime  NULL,
    [ExtraCostUnitIVNo] int  NULL,
    [ExtraCostUnitIIINo] int  NULL,
    [ExtraCostUnitIINo] int  NULL,
    [ExtraCostUnitINo] int  NULL,
    [Created] datetime  NULL,
    [CreatedBy] int  NULL,
    [LastUpdatedBy] int  NULL,
    [EANLocationNo] nvarchar(300)  NULL,
    [CustomerBonusProfileNo] int  NULL,
    [LocalGovernmentNo] int  NULL,
    [ChartererCompanyNo] int  NULL,
    [AgentNo] int  NULL,
    [CommissionProfileNo] int  NULL,
    [RemittanceProfileNo] int  NULL,
    [AutogiroAgreementID] nvarchar(300)  NULL,
    [AgentYesNo] int  NULL,
    [ShipmentTypeNo] int  NULL,
    [RemainderOrderYesNo] int  NULL,
    [AcceptReplacementArticleYesNo] int  NULL,
    [PrintProfileNo] int  NULL,
    [PaymentPattern] int  NULL,
    [AltPriceListYesNo] int  NULL,
    [AltPriceListNo] int  NULL,
    [InvoiceAdressNo] int  NULL,
    [EdiProfileNo] int  NULL,
    [EinvoiceStatus] int  NULL,
    [EinvoiceRef] nvarchar(300)  NULL,
    [EDISellerRefNo] nvarchar(300)  NULL,
    [EDIBuyerRefNo] nvarchar(300)  NULL,
    [VATRegNo] nvarchar(300)  NULL,
    [WebshopRefNo] nvarchar(300)  NULL,
    [IBAN] nvarchar(300)  NULL,
    [SwiftCodeNo] int  NULL,
    [ContactNoConfirmOrder] int  NULL,
    [ContactNoPickingList] int  NULL,
    [IsUpdated] bit  NOT NULL
);
GO

-- Creating table 'vCustomerAddresses'
CREATE TABLE [dbo].[vCustomerAddresses] (
    [Id] int  NOT NULL,
    [Name] nvarchar(300)  NULL,
    [InvoiceAdress1] nvarchar(300)  NULL,
    [InvoiceAdress2] nvarchar(300)  NULL,
    [InvoiceAdress3] nvarchar(300)  NULL,
    [PostCode] nvarchar(300)  NULL,
    [PostOffice] nvarchar(300)  NULL,
    [IsUpdated] bit  NOT NULL,
    [CustomerNo] int  NOT NULL
);
GO

-- Creating table 'vCustomerCustomFields'
CREATE TABLE [dbo].[vCustomerCustomFields] (
    [CustomField] uniqueidentifier  NOT NULL,
    [CustomerNo] int  NULL,
    [Id] int  NULL,
    [Name] nvarchar(300)  NULL,
    [Value] nvarchar(300)  NULL,
    [IsUpdated] bit  NOT NULL
);
GO

-- Creating table 'vEmployees'
CREATE TABLE [dbo].[vEmployees] (
    [EmployeeNo] int  NOT NULL,
    [Name] nvarchar(300)  NULL,
    [Titel] nvarchar(300)  NULL,
    [DepNo] int  NULL,
    [InternalTelephone] nvarchar(300)  NULL,
    [MobileTelephone] nvarchar(300)  NULL,
    [CountryNo] int  NULL,
    [PostOffice] nvarchar(300)  NULL,
    [PostCode] nvarchar(300)  NULL,
    [Address1] nvarchar(300)  NULL,
    [CommissionNo] int  NULL,
    [Telefax] nvarchar(300)  NULL,
    [PrivateTelephone] nvarchar(300)  NULL,
    [HireDate] datetime  NULL,
    [ReportsTo] int  NULL,
    [NameReportsTo] nvarchar(300)  NULL,
    [InActiveYesNo] bit  NULL,
    [BankAccount] nvarchar(300)  NULL,
    [PostAccount] nvarchar(300)  NULL,
    [InternalEmailAddress] nvarchar(300)  NULL,
    [PrivateEmailAddress] nvarchar(300)  NULL,
    [ProjectNo] int  NULL,
    [ProductNo] int  NULL,
    [Address3] nvarchar(300)  NULL,
    [Address2] nvarchar(300)  NULL,
    [LastUpdate] datetime  NULL,
    [NickName] nvarchar(300)  NULL,
    [BusyReason] nvarchar(300)  NULL,
    [BusyStatus] bit  NULL,
    [EndedDate] datetime  NULL,
    [Sex] int  NULL,
    [Bleeper] nvarchar(300)  NULL,
    [PersonalWWWAddress] nvarchar(300)  NULL,
    [UserNo] int  NULL,
    [Birthday] nvarchar(300)  NULL,
    [MiddleName] nvarchar(300)  NULL,
    [FamilyName] nvarchar(300)  NULL,
    [ParentFamilyName] nvarchar(300)  NULL,
    [ParentName] nvarchar(300)  NULL,
    [LastUpdatedBy] int  NULL,
    [Created] datetime  NULL,
    [CreatedBy] int  NULL,
    [EbusinessType] int  NULL,
    [Password] nvarchar(300)  NULL,
    [PLUser] int  NULL,
    [TSApproverEmployeeNo] int  NULL,
    [DeviationControlYesNo] bit  NULL,
    [SubstManagerYesNo] bit  NULL,
    [EmployeeCatNo] int  NULL,
    [TimeCostPrice] int  NULL,
    [TimeSalesPrice] int  NULL,
    [WorkingHours] int  NULL,
    [AllowTimeSheetRegAllUsers] bit  NULL,
    [UseWagesortYesNo] int  NULL,
    [TimeWgSrtNo] int  NULL,
    [DeputyNo] int  NULL,
    [MaxAttestationAmount] int  NULL,
    [SuperiorNo] int  NULL,
    [WareHouseNo] int  NULL,
    [IsUpdated] bit  NULL
);
GO

-- Creating table 'vPOes'
CREATE TABLE [dbo].[vPOes] (
    [SupplierOrderNo] nvarchar(300)  NOT NULL,
    [SupplierName] nvarchar(300)  NULL,
    [SupplierOrderDate] datetime  NULL,
    [DeliveryDate] datetime  NULL,
    [TotalAmount] int  NULL,
    [OurRef] nvarchar(300)  NULL,
    [ContactNo] int  NULL,
    [NameContactNo] nvarchar(300)  NULL,
    [SupplierNo] int  NULL,
    [TermsOfPaySupplNo] int  NULL,
    [WareHouseNo] int  NULL,
    [ProductNo] int  NULL,
    [DepNo] int  NULL,
    [ProjectNo] int  NULL,
    [VATCode] int  NULL,
    [TaxClassNo] int  NULL,
    [CurrencyNo] int  NULL,
    [Telephone] nvarchar(300)  NULL,
    [DeliveredYesNo] int  NULL,
    [Address1] nvarchar(300)  NULL,
    [PostOffice] nvarchar(300)  NULL,
    [PostCode] nvarchar(300)  NULL,
    [CountryNo] int  NULL,
    [EmployeeNo] int  NULL,
    [DeliveryMethodsNo] int  NULL,
    [TermsOfDeliveryNo] int  NULL,
    [TotalDelivery] int  NULL,
    [InvoiceFee] int  NULL,
    [HandlingCharge] int  NULL,
    [Postage] int  NULL,
    [PurchaseDiscount] int  NULL,
    [PurchaseDiscountTaxFree] int  NULL,
    [PostageTaxFree] int  NULL,
    [CashDiscount] int  NULL,
    [CashDiscountTaxFree] int  NULL,
    [DueDate] datetime  NULL,
    [ExchangeAmount] int  NULL,
    [ExchangeRate] int  NULL,
    [CompanyNo] nvarchar(300)  NULL,
    [TotalVAT] int  NULL,
    [VoucherDate] datetime  NULL,
    [DeliveryAddressNo] int  NULL,
    [DeliveryCountryNo] int  NULL,
    [DeliveryPostOffice] nvarchar(300)  NULL,
    [DeliveryAddress1] nvarchar(300)  NULL,
    [DeliveryPostCode] nvarchar(300)  NULL,
    [DeliveryAddress2] nvarchar(300)  NULL,
    [Address2] nvarchar(300)  NULL,
    [OrderConfirmationDate] datetime  NULL,
    [SuppliersOrderNoRef] nvarchar(300)  NULL,
    [TotalAmountFromInvoice] int  NULL,
    [OrderStatus] int  NULL,
    [RemainderOrderYesNo] int  NULL,
    [FreightCost] int  NULL,
    [OrderType] int  NULL,
    [IsUpdated] bit  NOT NULL
);
GO

-- Creating table 'vPOLines'
CREATE TABLE [dbo].[vPOLines] (
    [POLineId] uniqueidentifier  NOT NULL,
    [AltArtNo] nvarchar(300)  NULL,
    [Amount] int  NULL,
    [ArticleNo] nvarchar(300)  NULL,
    [CurrencyNo] int  NULL,
    [DeliveryDate] datetime  NULL,
    [DepNo] int  NULL,
    [Description] nvarchar(300)  NULL,
    [DiscountGrpArtNo] int  NULL,
    [DiscountI] int  NULL,
    [EANNo] nvarchar(300)  NULL,
    [EmployeeNo] int  NULL,
    [ExchangeAmount] int  NULL,
    [ExchangePurchasePrice] int  NULL,
    [ExchangeRate] int  NULL,
    [ExpiryDate] datetime  NULL,
    [FullCost] int  NULL,
    [Invoiced] int  NULL,
    [InvoicePrice] int  NULL,
    [Name] nvarchar(300)  NULL,
    [NetDeliveryAmount] int  NULL,
    [NetRemainderAmount] int  NULL,
    [OrderDate] datetime  NULL,
    [OrderStatus] int  NULL,
    [OrderType] int  NULL,
    [OriginalLineNo] int  NULL,
    [OriginalPrice] int  NULL,
    [OriginalQuantity] int  NULL,
    [PartReceived] int  NULL,
    [PostingTemplateNo] int  NULL,
    [PriceCalculationNo] int  NULL,
    [ProductNo] int  NULL,
    [ProjectNo] int  NULL,
    [Quantity] int  NULL,
    [Remainder] int  NULL,
    [StockProfileNo] int  NULL,
    [SupplierNo] int  NULL,
    [SupplierOrderNo] nvarchar(300)  NULL,
    [TaxClassNo] int  NULL,
    [VATCode] int  NULL,
    [WareHouseNo] int  NULL,
    [Weight] int  NULL,
    [SuppliersOrderLineNo] int  NULL,
    [TotalInvoiced] int  NULL,
    [UniqueId] int  NULL,
    [UnitHeight] int  NULL,
    [UnitWidth] int  NULL,
    [UnitLength] int  NULL,
    [UnitTypeNo] int  NULL,
    [IsUpdated] bit  NOT NULL
);
GO

-- Creating table 'vSOes'
CREATE TABLE [dbo].[vSOes] (
    [OrderNo] nvarchar(300)  NOT NULL,
    [CustomerName] nvarchar(300)  NULL,
    [ContactNoInvoice] int  NULL,
    [OrderDate] datetime  NULL,
    [DeliveryDate] datetime  NULL,
    [TotalAmount] int  NULL,
    [OurRef] nvarchar(300)  NULL,
    [CustomerGrpNo] int  NULL,
    [DepNo] int  NULL,
    [ProjectNo] int  NULL,
    [VATCode] int  NULL,
    [CurrencyNo] int  NULL,
    [InvoicePostOffice] nvarchar(300)  NULL,
    [InvoiceAddress1] nvarchar(300)  NULL,
    [DeliveryPostOffice] nvarchar(300)  NULL,
    [InvoicePostCode] nvarchar(300)  NULL,
    [CustomerNo] int  NULL,
    [DeliveryCountryNo] int  NULL,
    [EmployeeNo] int  NULL,
    [DeliveryAddress1] nvarchar(300)  NULL,
    [DueDate] datetime  NULL,
    [OrderStatus] int  NULL,
    [CompanyNo] nvarchar(300)  NULL,
    [TotalWeight] int  NULL,
    [TotalVAT] int  NULL,
    [DeliveryPostCode] nvarchar(300)  NULL,
    [ExchangeAmount] int  NULL,
    [ExchangeRate] int  NULL,
    [PurchaseNo] int  NULL,
    [ProductNo] int  NULL,
    [ContactNoDelivery] int  NULL,
    [InvoiceAddress2] nvarchar(300)  NULL,
    [DeliveryAddress2] nvarchar(300)  NULL,
    [FactNo] int  NULL,
    [TotalWeightDelivered] int  NULL,
    [FactCustomerNo] nvarchar(300)  NULL,
    [OriginalOrderNo] nvarchar(300)  NULL,
    [AgreedAmount] int  NULL,
    [TermsOfDeliveryNo] int  NULL,
    [PaymentTypeNo] int  NULL,
    [TermsOfPayCustNo] int  NULL,
    [CashPaymentYesNo] bit  NULL,
    [InvoiceEmailAddress] nvarchar(300)  NULL,
    [YourReference] nvarchar(300)  NULL,
    [HandlingCharge] int  NULL,
    [Postage] int  NULL,
    [FreightcostPer] int  NULL,
    [DeliveryMethodsNo] int  NULL,
    [OrderType] int  NULL,
    [IsUpdated] bit  NOT NULL
);
GO

-- Creating table 'vSOLines'
CREATE TABLE [dbo].[vSOLines] (
    [SOLineId] uniqueidentifier  NOT NULL,
    [OrderNo] nvarchar(300)  NOT NULL,
    [AltArtNo] nvarchar(300)  NULL,
    [OrderStatus] int  NULL,
    [DepNo] int  NULL,
    [EANNo] nvarchar(300)  NULL,
    [OrderDate] datetime  NULL,
    [PLUNo] nvarchar(300)  NULL,
    [PostingTemplateNo] int  NULL,
    [PurchasePrice] int  NULL,
    [TotalDelivered] int  NULL,
    [Amount] int  NULL,
    [ArticleNo] nvarchar(300)  NULL,
    [CurrencyNo] int  NULL,
    [DeliveryDate] datetime  NULL,
    [DiscountI] int  NULL,
    [DiscountII] int  NULL,
    [DistributionFormulaNo] int  NULL,
    [EmployeeNo] int  NULL,
    [ExchangeAmount] int  NULL,
    [ExchangeRate] int  NULL,
    [ExchangeSalesPrice] int  NULL,
    [FullCost] int  NULL,
    [GLSalesAccountNo] int  NULL,
    [GrossPrice] int  NULL,
    [IntermediateGroupNo] int  NULL,
    [Invoiced] int  NULL,
    [MainGroupNo] int  NULL,
    [Name] nvarchar(300)  NULL,
    [NetDeliveryAmount] int  NULL,
    [NetPrice] int  NULL,
    [ProductNo] int  NULL,
    [ProjectNo] int  NULL,
    [Quantity] int  NULL,
    [Remainder] int  NULL,
    [SubGroupNo] int  NULL,
    [TaxClassNo] int  NULL,
    [VATCode] int  NULL,
    [WareHouseNo] int  NULL,
    [Weight] int  NULL,
    [UniqueId] int  NULL,
    [PartDelivered] int  NULL,
    [UnitHeight] int  NULL,
    [UnitWidth] int  NULL,
    [UnitLength] int  NULL,
    [UnitTypeNo] int  NULL,
    [IsUpdated] bit  NOT NULL
);
GO

-- Creating table 'vSuppliers'
CREATE TABLE [dbo].[vSuppliers] (
    [SupplierNo] int  NOT NULL,
    [Name] nvarchar(300)  NULL,
    [ContactNo] int  NULL,
    [PostCode] nvarchar(300)  NULL,
    [PostOffice] nvarchar(300)  NULL,
    [Telephone] nvarchar(300)  NULL,
    [Telefax] nvarchar(300)  NULL,
    [EmailAddress] nvarchar(300)  NULL,
    [FormProfileSuppNo] int  NULL,
    [DeliveryMethodsNo] int  NULL,
    [TermsOfDeliveryNo] int  NULL,
    [SwiftCodeNo] int  NULL,
    [PostAccount] nvarchar(300)  NULL,
    [BankAccount] nvarchar(300)  NULL,
    [CountryNo] int  NULL,
    [Address1] nvarchar(300)  NULL,
    [SortName] nvarchar(300)  NULL,
    [BuContactNo] int  NULL,
    [SupplierGrpNo] int  NULL,
    [BusinessNo] int  NULL,
    [SupplierProfileNo] int  NULL,
    [EmployeeNo] int  NULL,
    [TermsOfPaySupplNo] int  NULL,
    [WareHouseNo] int  NULL,
    [OurCustomerNo] nvarchar(300)  NULL,
    [CompanyNo] nvarchar(300)  NULL,
    [DistrictNo] int  NULL,
    [CurrencyNo] int  NULL,
    [CreditLimit] decimal(18,2)  NULL,
    [GLAccPay] int  NULL,
    [SupplierTypeNo] int  NULL,
    [DiscountGrpSupplNo] int  NULL,
    [LastMovementDate] datetime  NULL,
    [InActiveYesNo] bit  NULL,
    [RegistrationDate] datetime  NULL,
    [AccessLevel] int  NULL,
    [Password] nvarchar(300)  NULL,
    [CustomerNo] int  NULL,
    [ProjectNo] int  NULL,
    [ProductNo] int  NULL,
    [DepNo] int  NULL,
    [SupplierClassification] int  NULL,
    [ChainNo] int  NULL,
    [WWWAddress] nvarchar(300)  NULL,
    [Address3] nvarchar(300)  NULL,
    [Address2] nvarchar(300)  NULL,
    [LastUpdate] datetime  NULL,
    [ExtraCostUnitIVNo] int  NULL,
    [ExtraCostUnitIIINo] int  NULL,
    [ExtraCostUnitIINo] int  NULL,
    [ExtraCostUnitINo] int  NULL,
    [RemittanceProfileNo] int  NULL,
    [LocalGovernmentNo] int  NULL,
    [ReminderProfileNo] int  NULL,
    [NoOfReceivedPrOrder] int  NULL,
    [AvgDaysDelayedDelivery] int  NULL,
    [EbusinessType] int  NULL,
    [OrderConfirmationTime] int  NULL,
    [EANLocationNo] nvarchar(300)  NULL,
    [VATRegNo] nvarchar(300)  NULL,
    [PrefGLAccountNo] int  NULL,
    [PLAttResponsible] int  NULL,
    [BankGiro] nvarchar(300)  NULL,
    [RiksBankKod] int  NULL,
    [BankName] nvarchar(300)  NULL,
    [PgKontorUtland] nvarchar(300)  NULL,
    [Telephone2] nvarchar(300)  NULL,
    [LanguageNo] int  NULL,
    [BankConNo] int  NULL,
    [ForeignPaymentYesNo] int  NULL,
    [CurrencyAccount] int  NULL,
    [UserNumber] nvarchar(300)  NULL,
    [KIDSupplier] int  NULL,
    [ForeignBankCode] nvarchar(300)  NULL,
    [CountryCode] nvarchar(300)  NULL,
    [PaymentMethod] int  NULL,
    [GLAccPayAlfa] nvarchar(300)  NULL,
    [AccountingRuleNo] int  NULL,
    [EuroFicka] int  NULL,
    [TransType] int  NULL,
    [TransTypeText] nvarchar(300)  NULL,
    [AttestationResponsible] int  NULL,
    [FloatGroupNo] int  NULL,
    [ChartererCompanyNo] int  NULL,
    [IBAN] nvarchar(300)  NULL,
    [DateLastFinancialStatement] datetime  NULL,
    [AnnualSales] int  NULL,
    [NoOfEmployees] int  NULL,
    [CostTrackingProfileNo] int  NULL,
    [IsUpdated] bit  NOT NULL
);
GO

-- Creating table 'vUnits'
CREATE TABLE [dbo].[vUnits] (
    [UnitNo] int  NOT NULL,
    [LastUpdate] datetime  NULL,
    [LastUpdatedBy] int  NULL,
    [Created] datetime  NULL,
    [CreatedBy] int  NULL,
    [UnitName] nvarchar(300)  NULL,
    [EDIName] nvarchar(300)  NULL,
    [IsUpdated] bit  NOT NULL
);
GO

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [UserId] nvarchar(128)  NOT NULL,
    [RoleId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'View_Customer'
CREATE TABLE [dbo].[View_Customer] (
    [OrderId] uniqueidentifier  NOT NULL,
    [ProductName] nvarchar(250)  NOT NULL,
    [Name] nvarchar(250)  NULL,
    [Expr1] nvarchar(256)  NOT NULL,
    [CustomerNo] int  NULL,
    [ProductPrice] decimal(18,2)  NULL,
    [OrderQty] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [BrandId] in table 'tblBrands'
ALTER TABLE [dbo].[tblBrands]
ADD CONSTRAINT [PK_tblBrands]
    PRIMARY KEY CLUSTERED ([BrandId] ASC);
GO

-- Creating primary key on [CategoryId] in table 'tblCategories'
ALTER TABLE [dbo].[tblCategories]
ADD CONSTRAINT [PK_tblCategories]
    PRIMARY KEY CLUSTERED ([CategoryId] ASC);
GO

-- Creating primary key on [CountryId] in table 'tblCountries'
ALTER TABLE [dbo].[tblCountries]
ADD CONSTRAINT [PK_tblCountries]
    PRIMARY KEY CLUSTERED ([CountryId] ASC);
GO

-- Creating primary key on [CurrencyId] in table 'tblCurrencies'
ALTER TABLE [dbo].[tblCurrencies]
ADD CONSTRAINT [PK_tblCurrencies]
    PRIMARY KEY CLUSTERED ([CurrencyId] ASC);
GO

-- Creating primary key on [CustomerId] in table 'tblCustomers'
ALTER TABLE [dbo].[tblCustomers]
ADD CONSTRAINT [PK_tblCustomers]
    PRIMARY KEY CLUSTERED ([CustomerId] ASC);
GO

-- Creating primary key on [CustomerShippingId] in table 'tblCustomerShippings'
ALTER TABLE [dbo].[tblCustomerShippings]
ADD CONSTRAINT [PK_tblCustomerShippings]
    PRIMARY KEY CLUSTERED ([CustomerShippingId] ASC);
GO

-- Creating primary key on [EmployeeId] in table 'tblEmployees'
ALTER TABLE [dbo].[tblEmployees]
ADD CONSTRAINT [PK_tblEmployees]
    PRIMARY KEY CLUSTERED ([EmployeeId] ASC);
GO

-- Creating primary key on [FileId] in table 'tblFiles'
ALTER TABLE [dbo].[tblFiles]
ADD CONSTRAINT [PK_tblFiles]
    PRIMARY KEY CLUSTERED ([FileId] ASC);
GO

-- Creating primary key on [IntermediateGroupId] in table 'tblIntermediateGroups'
ALTER TABLE [dbo].[tblIntermediateGroups]
ADD CONSTRAINT [PK_tblIntermediateGroups]
    PRIMARY KEY CLUSTERED ([IntermediateGroupId] ASC);
GO

-- Creating primary key on [MainGroupId] in table 'tblMainGroups'
ALTER TABLE [dbo].[tblMainGroups]
ADD CONSTRAINT [PK_tblMainGroups]
    PRIMARY KEY CLUSTERED ([MainGroupId] ASC);
GO

-- Creating primary key on [MenuId] in table 'tblMenus'
ALTER TABLE [dbo].[tblMenus]
ADD CONSTRAINT [PK_tblMenus]
    PRIMARY KEY CLUSTERED ([MenuId] ASC);
GO

-- Creating primary key on [OfferId] in table 'tblOffers'
ALTER TABLE [dbo].[tblOffers]
ADD CONSTRAINT [PK_tblOffers]
    PRIMARY KEY CLUSTERED ([OfferId] ASC);
GO

-- Creating primary key on [OfferDetailId] in table 'tblOfferDetails'
ALTER TABLE [dbo].[tblOfferDetails]
ADD CONSTRAINT [PK_tblOfferDetails]
    PRIMARY KEY CLUSTERED ([OfferDetailId] ASC);
GO

-- Creating primary key on [OfferDetailLogId] in table 'tblOfferDetailLogs'
ALTER TABLE [dbo].[tblOfferDetailLogs]
ADD CONSTRAINT [PK_tblOfferDetailLogs]
    PRIMARY KEY CLUSTERED ([OfferDetailLogId] ASC);
GO

-- Creating primary key on [OfferlogId] in table 'tblOfferLogs'
ALTER TABLE [dbo].[tblOfferLogs]
ADD CONSTRAINT [PK_tblOfferLogs]
    PRIMARY KEY CLUSTERED ([OfferlogId] ASC);
GO

-- Creating primary key on [OrderId] in table 'tblOrders'
ALTER TABLE [dbo].[tblOrders]
ADD CONSTRAINT [PK_tblOrders]
    PRIMARY KEY CLUSTERED ([OrderId] ASC);
GO

-- Creating primary key on [OrderDetailId] in table 'tblOrderDetails'
ALTER TABLE [dbo].[tblOrderDetails]
ADD CONSTRAINT [PK_tblOrderDetails]
    PRIMARY KEY CLUSTERED ([OrderDetailId] ASC);
GO

-- Creating primary key on [ProductId] in table 'tblProducts'
ALTER TABLE [dbo].[tblProducts]
ADD CONSTRAINT [PK_tblProducts]
    PRIMARY KEY CLUSTERED ([ProductId] ASC);
GO

-- Creating primary key on [ProductBrandId] in table 'tblProductBrands'
ALTER TABLE [dbo].[tblProductBrands]
ADD CONSTRAINT [PK_tblProductBrands]
    PRIMARY KEY CLUSTERED ([ProductBrandId] ASC);
GO

-- Creating primary key on [ProductCategoryId] in table 'tblProductCategories'
ALTER TABLE [dbo].[tblProductCategories]
ADD CONSTRAINT [PK_tblProductCategories]
    PRIMARY KEY CLUSTERED ([ProductCategoryId] ASC);
GO

-- Creating primary key on [ProductFileId] in table 'tblProductFiles'
ALTER TABLE [dbo].[tblProductFiles]
ADD CONSTRAINT [PK_tblProductFiles]
    PRIMARY KEY CLUSTERED ([ProductFileId] ASC);
GO

-- Creating primary key on [ProductHistoryId] in table 'tblProductHistories'
ALTER TABLE [dbo].[tblProductHistories]
ADD CONSTRAINT [PK_tblProductHistories]
    PRIMARY KEY CLUSTERED ([ProductHistoryId] ASC);
GO

-- Creating primary key on [ProductSupplierId] in table 'tblProductSuppliers'
ALTER TABLE [dbo].[tblProductSuppliers]
ADD CONSTRAINT [PK_tblProductSuppliers]
    PRIMARY KEY CLUSTERED ([ProductSupplierId] ASC);
GO

-- Creating primary key on [ProductSupplierHistoryId] in table 'tblProductSupplierHistories'
ALTER TABLE [dbo].[tblProductSupplierHistories]
ADD CONSTRAINT [PK_tblProductSupplierHistories]
    PRIMARY KEY CLUSTERED ([ProductSupplierHistoryId] ASC);
GO

-- Creating primary key on [ProductUnitTypeId] in table 'tblProductUnitTypes'
ALTER TABLE [dbo].[tblProductUnitTypes]
ADD CONSTRAINT [PK_tblProductUnitTypes]
    PRIMARY KEY CLUSTERED ([ProductUnitTypeId] ASC);
GO

-- Creating primary key on [PurchasOrderId] in table 'tblPurchasOrders'
ALTER TABLE [dbo].[tblPurchasOrders]
ADD CONSTRAINT [PK_tblPurchasOrders]
    PRIMARY KEY CLUSTERED ([PurchasOrderId] ASC);
GO

-- Creating primary key on [PurchasOrderDetailId] in table 'tblPurchasOrderDetails'
ALTER TABLE [dbo].[tblPurchasOrderDetails]
ADD CONSTRAINT [PK_tblPurchasOrderDetails]
    PRIMARY KEY CLUSTERED ([PurchasOrderDetailId] ASC);
GO

-- Creating primary key on [PurchasOrderDetailLogId] in table 'tblPurchasOrderDetailLogs'
ALTER TABLE [dbo].[tblPurchasOrderDetailLogs]
ADD CONSTRAINT [PK_tblPurchasOrderDetailLogs]
    PRIMARY KEY CLUSTERED ([PurchasOrderDetailLogId] ASC);
GO

-- Creating primary key on [PurchasOrderLogId] in table 'tblPurchasOrderLogs'
ALTER TABLE [dbo].[tblPurchasOrderLogs]
ADD CONSTRAINT [PK_tblPurchasOrderLogs]
    PRIMARY KEY CLUSTERED ([PurchasOrderLogId] ASC);
GO

-- Creating primary key on [RoleId] in table 'tblRoles'
ALTER TABLE [dbo].[tblRoles]
ADD CONSTRAINT [PK_tblRoles]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [RoleMenuId] in table 'tblRoleMenus'
ALTER TABLE [dbo].[tblRoleMenus]
ADD CONSTRAINT [PK_tblRoleMenus]
    PRIMARY KEY CLUSTERED ([RoleMenuId] ASC);
GO

-- Creating primary key on [RoleUserId] in table 'tblRoleUsers'
ALTER TABLE [dbo].[tblRoleUsers]
ADD CONSTRAINT [PK_tblRoleUsers]
    PRIMARY KEY CLUSTERED ([RoleUserId] ASC);
GO

-- Creating primary key on [StatusId] in table 'tblStatus'
ALTER TABLE [dbo].[tblStatus]
ADD CONSTRAINT [PK_tblStatus]
    PRIMARY KEY CLUSTERED ([StatusId] ASC);
GO

-- Creating primary key on [StatusTypeId] in table 'tblStatusTypes'
ALTER TABLE [dbo].[tblStatusTypes]
ADD CONSTRAINT [PK_tblStatusTypes]
    PRIMARY KEY CLUSTERED ([StatusTypeId] ASC);
GO

-- Creating primary key on [SubGroupId] in table 'tblSubGroups'
ALTER TABLE [dbo].[tblSubGroups]
ADD CONSTRAINT [PK_tblSubGroups]
    PRIMARY KEY CLUSTERED ([SubGroupId] ASC);
GO

-- Creating primary key on [SupplierId] in table 'tblSuppliers'
ALTER TABLE [dbo].[tblSuppliers]
ADD CONSTRAINT [PK_tblSuppliers]
    PRIMARY KEY CLUSTERED ([SupplierId] ASC);
GO

-- Creating primary key on [UnitId] in table 'tblUnits'
ALTER TABLE [dbo].[tblUnits]
ADD CONSTRAINT [PK_tblUnits]
    PRIMARY KEY CLUSTERED ([UnitId] ASC);
GO

-- Creating primary key on [ArticleNo] in table 'vArticles'
ALTER TABLE [dbo].[vArticles]
ADD CONSTRAINT [PK_vArticles]
    PRIMARY KEY CLUSTERED ([ArticleNo] ASC);
GO

-- Creating primary key on [ArticleNo] in table 'vArticleCustomFields'
ALTER TABLE [dbo].[vArticleCustomFields]
ADD CONSTRAINT [PK_vArticleCustomFields]
    PRIMARY KEY CLUSTERED ([ArticleNo] ASC);
GO

-- Creating primary key on [MainGroupNo] in table 'vArticleGroupMains'
ALTER TABLE [dbo].[vArticleGroupMains]
ADD CONSTRAINT [PK_vArticleGroupMains]
    PRIMARY KEY CLUSTERED ([MainGroupNo] ASC);
GO

-- Creating primary key on [IntermediateGroupNo] in table 'vArticleIntermediateGroups'
ALTER TABLE [dbo].[vArticleIntermediateGroups]
ADD CONSTRAINT [PK_vArticleIntermediateGroups]
    PRIMARY KEY CLUSTERED ([IntermediateGroupNo] ASC);
GO

-- Creating primary key on [ArticleNo] in table 'vArticleStockInfoes'
ALTER TABLE [dbo].[vArticleStockInfoes]
ADD CONSTRAINT [PK_vArticleStockInfoes]
    PRIMARY KEY CLUSTERED ([ArticleNo] ASC);
GO

-- Creating primary key on [SubGroupNo] in table 'vArticleSubGroups'
ALTER TABLE [dbo].[vArticleSubGroups]
ADD CONSTRAINT [PK_vArticleSubGroups]
    PRIMARY KEY CLUSTERED ([SubGroupNo] ASC);
GO

-- Creating primary key on [UnitTypeNo] in table 'vArticleUnitTypes'
ALTER TABLE [dbo].[vArticleUnitTypes]
ADD CONSTRAINT [PK_vArticleUnitTypes]
    PRIMARY KEY CLUSTERED ([UnitTypeNo] ASC);
GO

-- Creating primary key on [CustomerNo] in table 'vCustomers'
ALTER TABLE [dbo].[vCustomers]
ADD CONSTRAINT [PK_vCustomers]
    PRIMARY KEY CLUSTERED ([CustomerNo] ASC);
GO

-- Creating primary key on [Id] in table 'vCustomerAddresses'
ALTER TABLE [dbo].[vCustomerAddresses]
ADD CONSTRAINT [PK_vCustomerAddresses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [CustomField] in table 'vCustomerCustomFields'
ALTER TABLE [dbo].[vCustomerCustomFields]
ADD CONSTRAINT [PK_vCustomerCustomFields]
    PRIMARY KEY CLUSTERED ([CustomField] ASC);
GO

-- Creating primary key on [EmployeeNo] in table 'vEmployees'
ALTER TABLE [dbo].[vEmployees]
ADD CONSTRAINT [PK_vEmployees]
    PRIMARY KEY CLUSTERED ([EmployeeNo] ASC);
GO

-- Creating primary key on [SupplierOrderNo] in table 'vPOes'
ALTER TABLE [dbo].[vPOes]
ADD CONSTRAINT [PK_vPOes]
    PRIMARY KEY CLUSTERED ([SupplierOrderNo] ASC);
GO

-- Creating primary key on [POLineId] in table 'vPOLines'
ALTER TABLE [dbo].[vPOLines]
ADD CONSTRAINT [PK_vPOLines]
    PRIMARY KEY CLUSTERED ([POLineId] ASC);
GO

-- Creating primary key on [OrderNo] in table 'vSOes'
ALTER TABLE [dbo].[vSOes]
ADD CONSTRAINT [PK_vSOes]
    PRIMARY KEY CLUSTERED ([OrderNo] ASC);
GO

-- Creating primary key on [SOLineId] in table 'vSOLines'
ALTER TABLE [dbo].[vSOLines]
ADD CONSTRAINT [PK_vSOLines]
    PRIMARY KEY CLUSTERED ([SOLineId] ASC);
GO

-- Creating primary key on [SupplierNo] in table 'vSuppliers'
ALTER TABLE [dbo].[vSuppliers]
ADD CONSTRAINT [PK_vSuppliers]
    PRIMARY KEY CLUSTERED ([SupplierNo] ASC);
GO

-- Creating primary key on [UnitNo] in table 'vUnits'
ALTER TABLE [dbo].[vUnits]
ADD CONSTRAINT [PK_vUnits]
    PRIMARY KEY CLUSTERED ([UnitNo] ASC);
GO

-- Creating primary key on [MigrationId], [ContextKey], [Model], [ProductVersion] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey], [Model], [ProductVersion] ASC);
GO

-- Creating primary key on [Id], [Name] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id], [Name] ASC);
GO

-- Creating primary key on [Id], [UserId] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id], [UserId] ASC);
GO

-- Creating primary key on [LoginProvider], [ProviderKey], [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([LoginProvider], [ProviderKey], [UserId] ASC);
GO

-- Creating primary key on [UserId], [RoleId] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([UserId], [RoleId] ASC);
GO

-- Creating primary key on [OrderId], [ProductName], [Expr1] in table 'View_Customer'
ALTER TABLE [dbo].[View_Customer]
ADD CONSTRAINT [PK_View_Customer]
    PRIMARY KEY CLUSTERED ([OrderId], [ProductName], [Expr1] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [FileId] in table 'tblBrands'
ALTER TABLE [dbo].[tblBrands]
ADD CONSTRAINT [FK_tblBrand_tblFile]
    FOREIGN KEY ([FileId])
    REFERENCES [dbo].[tblFiles]
        ([FileId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblBrand_tblFile'
CREATE INDEX [IX_FK_tblBrand_tblFile]
ON [dbo].[tblBrands]
    ([FileId]);
GO

-- Creating foreign key on [StatusId] in table 'tblBrands'
ALTER TABLE [dbo].[tblBrands]
ADD CONSTRAINT [FK_tblBrand_tblStatus]
    FOREIGN KEY ([StatusId])
    REFERENCES [dbo].[tblStatus]
        ([StatusId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblBrand_tblStatus'
CREATE INDEX [IX_FK_tblBrand_tblStatus]
ON [dbo].[tblBrands]
    ([StatusId]);
GO

-- Creating foreign key on [BrandId] in table 'tblProductBrands'
ALTER TABLE [dbo].[tblProductBrands]
ADD CONSTRAINT [FK_tblProductBrand_tblBrand]
    FOREIGN KEY ([BrandId])
    REFERENCES [dbo].[tblBrands]
        ([BrandId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProductBrand_tblBrand'
CREATE INDEX [IX_FK_tblProductBrand_tblBrand]
ON [dbo].[tblProductBrands]
    ([BrandId]);
GO

-- Creating foreign key on [CategoryId] in table 'tblProductCategories'
ALTER TABLE [dbo].[tblProductCategories]
ADD CONSTRAINT [FK_tblProductCategory_tblCategory]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[tblCategories]
        ([CategoryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProductCategory_tblCategory'
CREATE INDEX [IX_FK_tblProductCategory_tblCategory]
ON [dbo].[tblProductCategories]
    ([CategoryId]);
GO

-- Creating foreign key on [StatusId] in table 'tblCountries'
ALTER TABLE [dbo].[tblCountries]
ADD CONSTRAINT [FK_tblCountry_tblStatus]
    FOREIGN KEY ([StatusId])
    REFERENCES [dbo].[tblStatus]
        ([StatusId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCountry_tblStatus'
CREATE INDEX [IX_FK_tblCountry_tblStatus]
ON [dbo].[tblCountries]
    ([StatusId]);
GO

-- Creating foreign key on [CountryId] in table 'tblCustomers'
ALTER TABLE [dbo].[tblCustomers]
ADD CONSTRAINT [FK_tblCustomer_tblCountry]
    FOREIGN KEY ([CountryId])
    REFERENCES [dbo].[tblCountries]
        ([CountryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCustomer_tblCountry'
CREATE INDEX [IX_FK_tblCustomer_tblCountry]
ON [dbo].[tblCustomers]
    ([CountryId]);
GO

-- Creating foreign key on [CountryId] in table 'tblCustomerShippings'
ALTER TABLE [dbo].[tblCustomerShippings]
ADD CONSTRAINT [FK_tblCustomerShipping_tblCountry]
    FOREIGN KEY ([CountryId])
    REFERENCES [dbo].[tblCountries]
        ([CountryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCustomerShipping_tblCountry'
CREATE INDEX [IX_FK_tblCustomerShipping_tblCountry]
ON [dbo].[tblCustomerShippings]
    ([CountryId]);
GO

-- Creating foreign key on [CountryId] in table 'tblEmployees'
ALTER TABLE [dbo].[tblEmployees]
ADD CONSTRAINT [FK_tblEmployees_tblCountry]
    FOREIGN KEY ([CountryId])
    REFERENCES [dbo].[tblCountries]
        ([CountryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblEmployees_tblCountry'
CREATE INDEX [IX_FK_tblEmployees_tblCountry]
ON [dbo].[tblEmployees]
    ([CountryId]);
GO

-- Creating foreign key on [CountryId] in table 'tblSuppliers'
ALTER TABLE [dbo].[tblSuppliers]
ADD CONSTRAINT [FK_tblSupplier_tblCountry]
    FOREIGN KEY ([CountryId])
    REFERENCES [dbo].[tblCountries]
        ([CountryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSupplier_tblCountry'
CREATE INDEX [IX_FK_tblSupplier_tblCountry]
ON [dbo].[tblSuppliers]
    ([CountryId]);
GO

-- Creating foreign key on [CurrencyId] in table 'tblCustomers'
ALTER TABLE [dbo].[tblCustomers]
ADD CONSTRAINT [FK_tblCustomer_tblCurrency]
    FOREIGN KEY ([CurrencyId])
    REFERENCES [dbo].[tblCurrencies]
        ([CurrencyId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCustomer_tblCurrency'
CREATE INDEX [IX_FK_tblCustomer_tblCurrency]
ON [dbo].[tblCustomers]
    ([CurrencyId]);
GO

-- Creating foreign key on [CurrencyId] in table 'tblProducts'
ALTER TABLE [dbo].[tblProducts]
ADD CONSTRAINT [FK_tblProduct_tblCurrency]
    FOREIGN KEY ([CurrencyId])
    REFERENCES [dbo].[tblCurrencies]
        ([CurrencyId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProduct_tblCurrency'
CREATE INDEX [IX_FK_tblProduct_tblCurrency]
ON [dbo].[tblProducts]
    ([CurrencyId]);
GO

-- Creating foreign key on [CurrencyId] in table 'tblSuppliers'
ALTER TABLE [dbo].[tblSuppliers]
ADD CONSTRAINT [FK_tblSupplier_tblCurrency]
    FOREIGN KEY ([CurrencyId])
    REFERENCES [dbo].[tblCurrencies]
        ([CurrencyId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSupplier_tblCurrency'
CREATE INDEX [IX_FK_tblSupplier_tblCurrency]
ON [dbo].[tblSuppliers]
    ([CurrencyId]);
GO

-- Creating foreign key on [FileId] in table 'tblCustomers'
ALTER TABLE [dbo].[tblCustomers]
ADD CONSTRAINT [FK_tblCustomer_tblStatus]
    FOREIGN KEY ([FileId])
    REFERENCES [dbo].[tblFiles]
        ([FileId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCustomer_tblStatus'
CREATE INDEX [IX_FK_tblCustomer_tblStatus]
ON [dbo].[tblCustomers]
    ([FileId]);
GO

-- Creating foreign key on [CustomerId] in table 'tblCustomerShippings'
ALTER TABLE [dbo].[tblCustomerShippings]
ADD CONSTRAINT [FK_tblCustomerShipping_tblCustomer]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[tblCustomers]
        ([CustomerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCustomerShipping_tblCustomer'
CREATE INDEX [IX_FK_tblCustomerShipping_tblCustomer]
ON [dbo].[tblCustomerShippings]
    ([CustomerId]);
GO

-- Creating foreign key on [CustomerId] in table 'tblOffers'
ALTER TABLE [dbo].[tblOffers]
ADD CONSTRAINT [FK_tblOffer_tblCustomer]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[tblCustomers]
        ([CustomerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblOffer_tblCustomer'
CREATE INDEX [IX_FK_tblOffer_tblCustomer]
ON [dbo].[tblOffers]
    ([CustomerId]);
GO

-- Creating foreign key on [CustomerId] in table 'tblOrders'
ALTER TABLE [dbo].[tblOrders]
ADD CONSTRAINT [FK_tblOrder_tblCustomer]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[tblCustomers]
        ([CustomerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblOrder_tblCustomer'
CREATE INDEX [IX_FK_tblOrder_tblCustomer]
ON [dbo].[tblOrders]
    ([CustomerId]);
GO

-- Creating foreign key on [CustomerId] in table 'tblProductHistories'
ALTER TABLE [dbo].[tblProductHistories]
ADD CONSTRAINT [FK_tblProductHistory_tblCustomer]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[tblCustomers]
        ([CustomerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProductHistory_tblCustomer'
CREATE INDEX [IX_FK_tblProductHistory_tblCustomer]
ON [dbo].[tblProductHistories]
    ([CustomerId]);
GO

-- Creating foreign key on [CustomerId] in table 'tblPurchasOrderDetails'
ALTER TABLE [dbo].[tblPurchasOrderDetails]
ADD CONSTRAINT [FK_tblPurchasOrderDetail_tblCustomer]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[tblCustomers]
        ([CustomerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPurchasOrderDetail_tblCustomer'
CREATE INDEX [IX_FK_tblPurchasOrderDetail_tblCustomer]
ON [dbo].[tblPurchasOrderDetails]
    ([CustomerId]);
GO

-- Creating foreign key on [StatusId] in table 'tblCustomerShippings'
ALTER TABLE [dbo].[tblCustomerShippings]
ADD CONSTRAINT [FK_tblCustomerShipping_tblStatus]
    FOREIGN KEY ([StatusId])
    REFERENCES [dbo].[tblStatus]
        ([StatusId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCustomerShipping_tblStatus'
CREATE INDEX [IX_FK_tblCustomerShipping_tblStatus]
ON [dbo].[tblCustomerShippings]
    ([StatusId]);
GO

-- Creating foreign key on [FileId] in table 'tblEmployees'
ALTER TABLE [dbo].[tblEmployees]
ADD CONSTRAINT [FK_tblEmployees_tblFile]
    FOREIGN KEY ([FileId])
    REFERENCES [dbo].[tblFiles]
        ([FileId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblEmployees_tblFile'
CREATE INDEX [IX_FK_tblEmployees_tblFile]
ON [dbo].[tblEmployees]
    ([FileId]);
GO

-- Creating foreign key on [StatusId] in table 'tblEmployees'
ALTER TABLE [dbo].[tblEmployees]
ADD CONSTRAINT [FK_tblEmployees_tblStatus]
    FOREIGN KEY ([StatusId])
    REFERENCES [dbo].[tblStatus]
        ([StatusId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblEmployees_tblStatus'
CREATE INDEX [IX_FK_tblEmployees_tblStatus]
ON [dbo].[tblEmployees]
    ([StatusId]);
GO

-- Creating foreign key on [FileId] in table 'tblIntermediateGroups'
ALTER TABLE [dbo].[tblIntermediateGroups]
ADD CONSTRAINT [FK_tblIntermediateGroup_tblFile]
    FOREIGN KEY ([FileId])
    REFERENCES [dbo].[tblFiles]
        ([FileId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblIntermediateGroup_tblFile'
CREATE INDEX [IX_FK_tblIntermediateGroup_tblFile]
ON [dbo].[tblIntermediateGroups]
    ([FileId]);
GO

-- Creating foreign key on [FileId] in table 'tblMainGroups'
ALTER TABLE [dbo].[tblMainGroups]
ADD CONSTRAINT [FK_tblMainGroup_tblFile]
    FOREIGN KEY ([FileId])
    REFERENCES [dbo].[tblFiles]
        ([FileId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblMainGroup_tblFile'
CREATE INDEX [IX_FK_tblMainGroup_tblFile]
ON [dbo].[tblMainGroups]
    ([FileId]);
GO

-- Creating foreign key on [FileId] in table 'tblProducts'
ALTER TABLE [dbo].[tblProducts]
ADD CONSTRAINT [FK_tblProduct_tblFile]
    FOREIGN KEY ([FileId])
    REFERENCES [dbo].[tblFiles]
        ([FileId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProduct_tblFile'
CREATE INDEX [IX_FK_tblProduct_tblFile]
ON [dbo].[tblProducts]
    ([FileId]);
GO

-- Creating foreign key on [FileId] in table 'tblProductFiles'
ALTER TABLE [dbo].[tblProductFiles]
ADD CONSTRAINT [FK_tblProductFile_tblFile]
    FOREIGN KEY ([FileId])
    REFERENCES [dbo].[tblFiles]
        ([FileId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProductFile_tblFile'
CREATE INDEX [IX_FK_tblProductFile_tblFile]
ON [dbo].[tblProductFiles]
    ([FileId]);
GO

-- Creating foreign key on [FileId] in table 'tblSubGroups'
ALTER TABLE [dbo].[tblSubGroups]
ADD CONSTRAINT [FK_tblSubGroup_tblFile]
    FOREIGN KEY ([FileId])
    REFERENCES [dbo].[tblFiles]
        ([FileId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSubGroup_tblFile'
CREATE INDEX [IX_FK_tblSubGroup_tblFile]
ON [dbo].[tblSubGroups]
    ([FileId]);
GO

-- Creating foreign key on [FileId] in table 'tblSuppliers'
ALTER TABLE [dbo].[tblSuppliers]
ADD CONSTRAINT [FK_tblSupplier_tblFile]
    FOREIGN KEY ([FileId])
    REFERENCES [dbo].[tblFiles]
        ([FileId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSupplier_tblFile'
CREATE INDEX [IX_FK_tblSupplier_tblFile]
ON [dbo].[tblSuppliers]
    ([FileId]);
GO

-- Creating foreign key on [MainGroupId] in table 'tblIntermediateGroups'
ALTER TABLE [dbo].[tblIntermediateGroups]
ADD CONSTRAINT [FK_tblIntermediateGroup_tblMainGroup]
    FOREIGN KEY ([MainGroupId])
    REFERENCES [dbo].[tblMainGroups]
        ([MainGroupId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblIntermediateGroup_tblMainGroup'
CREATE INDEX [IX_FK_tblIntermediateGroup_tblMainGroup]
ON [dbo].[tblIntermediateGroups]
    ([MainGroupId]);
GO

-- Creating foreign key on [StatusId] in table 'tblIntermediateGroups'
ALTER TABLE [dbo].[tblIntermediateGroups]
ADD CONSTRAINT [FK_tblIntermediateGroup_tblStatus]
    FOREIGN KEY ([StatusId])
    REFERENCES [dbo].[tblStatus]
        ([StatusId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblIntermediateGroup_tblStatus'
CREATE INDEX [IX_FK_tblIntermediateGroup_tblStatus]
ON [dbo].[tblIntermediateGroups]
    ([StatusId]);
GO

-- Creating foreign key on [IntermediateGroupId] in table 'tblProducts'
ALTER TABLE [dbo].[tblProducts]
ADD CONSTRAINT [FK_tblProduct_tblIntermediateGroup]
    FOREIGN KEY ([IntermediateGroupId])
    REFERENCES [dbo].[tblIntermediateGroups]
        ([IntermediateGroupId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProduct_tblIntermediateGroup'
CREATE INDEX [IX_FK_tblProduct_tblIntermediateGroup]
ON [dbo].[tblProducts]
    ([IntermediateGroupId]);
GO

-- Creating foreign key on [IntermediateGroupId] in table 'tblSubGroups'
ALTER TABLE [dbo].[tblSubGroups]
ADD CONSTRAINT [FK_tblSubGroup_tblIntermediateGroup]
    FOREIGN KEY ([IntermediateGroupId])
    REFERENCES [dbo].[tblIntermediateGroups]
        ([IntermediateGroupId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSubGroup_tblIntermediateGroup'
CREATE INDEX [IX_FK_tblSubGroup_tblIntermediateGroup]
ON [dbo].[tblSubGroups]
    ([IntermediateGroupId]);
GO

-- Creating foreign key on [StatusId] in table 'tblMainGroups'
ALTER TABLE [dbo].[tblMainGroups]
ADD CONSTRAINT [FK_tblMainGroup_tblStatus]
    FOREIGN KEY ([StatusId])
    REFERENCES [dbo].[tblStatus]
        ([StatusId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblMainGroup_tblStatus'
CREATE INDEX [IX_FK_tblMainGroup_tblStatus]
ON [dbo].[tblMainGroups]
    ([StatusId]);
GO

-- Creating foreign key on [MainGroupId] in table 'tblProducts'
ALTER TABLE [dbo].[tblProducts]
ADD CONSTRAINT [FK_tblProduct_tblMainGroup]
    FOREIGN KEY ([MainGroupId])
    REFERENCES [dbo].[tblMainGroups]
        ([MainGroupId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProduct_tblMainGroup'
CREATE INDEX [IX_FK_tblProduct_tblMainGroup]
ON [dbo].[tblProducts]
    ([MainGroupId]);
GO

-- Creating foreign key on [MenuId] in table 'tblRoleMenus'
ALTER TABLE [dbo].[tblRoleMenus]
ADD CONSTRAINT [FK_tblRoleMenu_tblMenu]
    FOREIGN KEY ([MenuId])
    REFERENCES [dbo].[tblMenus]
        ([MenuId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblRoleMenu_tblMenu'
CREATE INDEX [IX_FK_tblRoleMenu_tblMenu]
ON [dbo].[tblRoleMenus]
    ([MenuId]);
GO

-- Creating foreign key on [StatusId] in table 'tblOffers'
ALTER TABLE [dbo].[tblOffers]
ADD CONSTRAINT [FK_tblOffer_tblStatus]
    FOREIGN KEY ([StatusId])
    REFERENCES [dbo].[tblStatus]
        ([StatusId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblOffer_tblStatus'
CREATE INDEX [IX_FK_tblOffer_tblStatus]
ON [dbo].[tblOffers]
    ([StatusId]);
GO

-- Creating foreign key on [OfferId] in table 'tblOfferDetails'
ALTER TABLE [dbo].[tblOfferDetails]
ADD CONSTRAINT [FK_tblOfferDetail_tblOffer]
    FOREIGN KEY ([OfferId])
    REFERENCES [dbo].[tblOffers]
        ([OfferId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblOfferDetail_tblOffer'
CREATE INDEX [IX_FK_tblOfferDetail_tblOffer]
ON [dbo].[tblOfferDetails]
    ([OfferId]);
GO

-- Creating foreign key on [ProductId] in table 'tblOfferDetails'
ALTER TABLE [dbo].[tblOfferDetails]
ADD CONSTRAINT [FK_tblOfferDetail_tblProduct]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[tblProducts]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblOfferDetail_tblProduct'
CREATE INDEX [IX_FK_tblOfferDetail_tblProduct]
ON [dbo].[tblOfferDetails]
    ([ProductId]);
GO

-- Creating foreign key on [StatusId] in table 'tblOfferDetails'
ALTER TABLE [dbo].[tblOfferDetails]
ADD CONSTRAINT [FK_tblOfferDetail_tblStatus]
    FOREIGN KEY ([StatusId])
    REFERENCES [dbo].[tblStatus]
        ([StatusId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblOfferDetail_tblStatus'
CREATE INDEX [IX_FK_tblOfferDetail_tblStatus]
ON [dbo].[tblOfferDetails]
    ([StatusId]);
GO

-- Creating foreign key on [OfferlogId] in table 'tblOfferDetailLogs'
ALTER TABLE [dbo].[tblOfferDetailLogs]
ADD CONSTRAINT [FK_tblOfferDetailLog_tblOfferLog]
    FOREIGN KEY ([OfferlogId])
    REFERENCES [dbo].[tblOfferLogs]
        ([OfferlogId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblOfferDetailLog_tblOfferLog'
CREATE INDEX [IX_FK_tblOfferDetailLog_tblOfferLog]
ON [dbo].[tblOfferDetailLogs]
    ([OfferlogId]);
GO

-- Creating foreign key on [StatusId] in table 'tblOrders'
ALTER TABLE [dbo].[tblOrders]
ADD CONSTRAINT [FK_tblOrder_tblStatus]
    FOREIGN KEY ([StatusId])
    REFERENCES [dbo].[tblStatus]
        ([StatusId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblOrder_tblStatus'
CREATE INDEX [IX_FK_tblOrder_tblStatus]
ON [dbo].[tblOrders]
    ([StatusId]);
GO

-- Creating foreign key on [OrderId] in table 'tblOrderDetails'
ALTER TABLE [dbo].[tblOrderDetails]
ADD CONSTRAINT [FK_tblOrderDetail_tblOrder]
    FOREIGN KEY ([OrderId])
    REFERENCES [dbo].[tblOrders]
        ([OrderId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblOrderDetail_tblOrder'
CREATE INDEX [IX_FK_tblOrderDetail_tblOrder]
ON [dbo].[tblOrderDetails]
    ([OrderId]);
GO

-- Creating foreign key on [ProductId] in table 'tblOrderDetails'
ALTER TABLE [dbo].[tblOrderDetails]
ADD CONSTRAINT [FK_tblOrderDetail_tblProduct]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[tblProducts]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblOrderDetail_tblProduct'
CREATE INDEX [IX_FK_tblOrderDetail_tblProduct]
ON [dbo].[tblOrderDetails]
    ([ProductId]);
GO

-- Creating foreign key on [StatusId] in table 'tblOrderDetails'
ALTER TABLE [dbo].[tblOrderDetails]
ADD CONSTRAINT [FK_tblOrderDetail_tblStatus]
    FOREIGN KEY ([StatusId])
    REFERENCES [dbo].[tblStatus]
        ([StatusId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblOrderDetail_tblStatus'
CREATE INDEX [IX_FK_tblOrderDetail_tblStatus]
ON [dbo].[tblOrderDetails]
    ([StatusId]);
GO

-- Creating foreign key on [StatusId] in table 'tblProducts'
ALTER TABLE [dbo].[tblProducts]
ADD CONSTRAINT [FK_tblProduct_tblStatus]
    FOREIGN KEY ([StatusId])
    REFERENCES [dbo].[tblStatus]
        ([StatusId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProduct_tblStatus'
CREATE INDEX [IX_FK_tblProduct_tblStatus]
ON [dbo].[tblProducts]
    ([StatusId]);
GO

-- Creating foreign key on [SubGroupId] in table 'tblProducts'
ALTER TABLE [dbo].[tblProducts]
ADD CONSTRAINT [FK_tblProduct_tblSubGroup]
    FOREIGN KEY ([SubGroupId])
    REFERENCES [dbo].[tblSubGroups]
        ([SubGroupId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProduct_tblSubGroup'
CREATE INDEX [IX_FK_tblProduct_tblSubGroup]
ON [dbo].[tblProducts]
    ([SubGroupId]);
GO

-- Creating foreign key on [UnitId] in table 'tblProducts'
ALTER TABLE [dbo].[tblProducts]
ADD CONSTRAINT [FK_tblProduct_tblUnit]
    FOREIGN KEY ([UnitId])
    REFERENCES [dbo].[tblUnits]
        ([UnitId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProduct_tblUnit'
CREATE INDEX [IX_FK_tblProduct_tblUnit]
ON [dbo].[tblProducts]
    ([UnitId]);
GO

-- Creating foreign key on [ProductId] in table 'tblProductBrands'
ALTER TABLE [dbo].[tblProductBrands]
ADD CONSTRAINT [FK_tblProductBrand_tblProduct]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[tblProducts]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProductBrand_tblProduct'
CREATE INDEX [IX_FK_tblProductBrand_tblProduct]
ON [dbo].[tblProductBrands]
    ([ProductId]);
GO

-- Creating foreign key on [ProductId] in table 'tblProductCategories'
ALTER TABLE [dbo].[tblProductCategories]
ADD CONSTRAINT [FK_tblProductCategory_tblProduct]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[tblProducts]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProductCategory_tblProduct'
CREATE INDEX [IX_FK_tblProductCategory_tblProduct]
ON [dbo].[tblProductCategories]
    ([ProductId]);
GO

-- Creating foreign key on [ProductId] in table 'tblProductFiles'
ALTER TABLE [dbo].[tblProductFiles]
ADD CONSTRAINT [FK_tblProductFile_tblProduct]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[tblProducts]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProductFile_tblProduct'
CREATE INDEX [IX_FK_tblProductFile_tblProduct]
ON [dbo].[tblProductFiles]
    ([ProductId]);
GO

-- Creating foreign key on [ProductId] in table 'tblProductHistories'
ALTER TABLE [dbo].[tblProductHistories]
ADD CONSTRAINT [FK_tblProductHistory_tblProductHistory]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[tblProducts]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProductHistory_tblProductHistory'
CREATE INDEX [IX_FK_tblProductHistory_tblProductHistory]
ON [dbo].[tblProductHistories]
    ([ProductId]);
GO

-- Creating foreign key on [ProductId] in table 'tblProductSuppliers'
ALTER TABLE [dbo].[tblProductSuppliers]
ADD CONSTRAINT [FK_tblProductSupplier_tblProduct]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[tblProducts]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProductSupplier_tblProduct'
CREATE INDEX [IX_FK_tblProductSupplier_tblProduct]
ON [dbo].[tblProductSuppliers]
    ([ProductId]);
GO

-- Creating foreign key on [ProductId] in table 'tblProductSupplierHistories'
ALTER TABLE [dbo].[tblProductSupplierHistories]
ADD CONSTRAINT [FK_tblProductSupplierHistory_tblProductSupplierHistory]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[tblProducts]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProductSupplierHistory_tblProductSupplierHistory'
CREATE INDEX [IX_FK_tblProductSupplierHistory_tblProductSupplierHistory]
ON [dbo].[tblProductSupplierHistories]
    ([ProductId]);
GO

-- Creating foreign key on [ProductId] in table 'tblProductUnitTypes'
ALTER TABLE [dbo].[tblProductUnitTypes]
ADD CONSTRAINT [FK_tblProductUnitType_tblProduct]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[tblProducts]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProductUnitType_tblProduct'
CREATE INDEX [IX_FK_tblProductUnitType_tblProduct]
ON [dbo].[tblProductUnitTypes]
    ([ProductId]);
GO

-- Creating foreign key on [ProductId] in table 'tblPurchasOrderDetails'
ALTER TABLE [dbo].[tblPurchasOrderDetails]
ADD CONSTRAINT [FK_tblPurchasOrderDetail_tblProduct]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[tblProducts]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPurchasOrderDetail_tblProduct'
CREATE INDEX [IX_FK_tblPurchasOrderDetail_tblProduct]
ON [dbo].[tblPurchasOrderDetails]
    ([ProductId]);
GO

-- Creating foreign key on [SupplierId] in table 'tblProductSuppliers'
ALTER TABLE [dbo].[tblProductSuppliers]
ADD CONSTRAINT [FK_tblProductSupplier_tblSupplier]
    FOREIGN KEY ([SupplierId])
    REFERENCES [dbo].[tblSuppliers]
        ([SupplierId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProductSupplier_tblSupplier'
CREATE INDEX [IX_FK_tblProductSupplier_tblSupplier]
ON [dbo].[tblProductSuppliers]
    ([SupplierId]);
GO

-- Creating foreign key on [StatusId] in table 'tblProductSupplierHistories'
ALTER TABLE [dbo].[tblProductSupplierHistories]
ADD CONSTRAINT [FK_tblProductSupplierHistory_tblStatus]
    FOREIGN KEY ([StatusId])
    REFERENCES [dbo].[tblStatus]
        ([StatusId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProductSupplierHistory_tblStatus'
CREATE INDEX [IX_FK_tblProductSupplierHistory_tblStatus]
ON [dbo].[tblProductSupplierHistories]
    ([StatusId]);
GO

-- Creating foreign key on [SupplierId] in table 'tblProductSupplierHistories'
ALTER TABLE [dbo].[tblProductSupplierHistories]
ADD CONSTRAINT [FK_tblProductSupplierHistory_tblSupplier]
    FOREIGN KEY ([SupplierId])
    REFERENCES [dbo].[tblSuppliers]
        ([SupplierId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProductSupplierHistory_tblSupplier'
CREATE INDEX [IX_FK_tblProductSupplierHistory_tblSupplier]
ON [dbo].[tblProductSupplierHistories]
    ([SupplierId]);
GO

-- Creating foreign key on [StatusId] in table 'tblProductUnitTypes'
ALTER TABLE [dbo].[tblProductUnitTypes]
ADD CONSTRAINT [FK_tblProductUnitType_tblStatus]
    FOREIGN KEY ([StatusId])
    REFERENCES [dbo].[tblStatus]
        ([StatusId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProductUnitType_tblStatus'
CREATE INDEX [IX_FK_tblProductUnitType_tblStatus]
ON [dbo].[tblProductUnitTypes]
    ([StatusId]);
GO

-- Creating foreign key on [UnitId] in table 'tblProductUnitTypes'
ALTER TABLE [dbo].[tblProductUnitTypes]
ADD CONSTRAINT [FK_tblProductUnitType_tblUnit]
    FOREIGN KEY ([UnitId])
    REFERENCES [dbo].[tblUnits]
        ([UnitId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProductUnitType_tblUnit'
CREATE INDEX [IX_FK_tblProductUnitType_tblUnit]
ON [dbo].[tblProductUnitTypes]
    ([UnitId]);
GO

-- Creating foreign key on [StatusId] in table 'tblPurchasOrders'
ALTER TABLE [dbo].[tblPurchasOrders]
ADD CONSTRAINT [FK_tblPurchasOrder_tblPurchasOrder]
    FOREIGN KEY ([StatusId])
    REFERENCES [dbo].[tblStatus]
        ([StatusId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPurchasOrder_tblPurchasOrder'
CREATE INDEX [IX_FK_tblPurchasOrder_tblPurchasOrder]
ON [dbo].[tblPurchasOrders]
    ([StatusId]);
GO

-- Creating foreign key on [SupplierId] in table 'tblPurchasOrders'
ALTER TABLE [dbo].[tblPurchasOrders]
ADD CONSTRAINT [FK_tblPurchasOrder_tblSupplier]
    FOREIGN KEY ([SupplierId])
    REFERENCES [dbo].[tblSuppliers]
        ([SupplierId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPurchasOrder_tblSupplier'
CREATE INDEX [IX_FK_tblPurchasOrder_tblSupplier]
ON [dbo].[tblPurchasOrders]
    ([SupplierId]);
GO

-- Creating foreign key on [PurchasOrderId] in table 'tblPurchasOrderDetails'
ALTER TABLE [dbo].[tblPurchasOrderDetails]
ADD CONSTRAINT [FK_tblPurchasOrderDetail_tblPurchasOrder]
    FOREIGN KEY ([PurchasOrderId])
    REFERENCES [dbo].[tblPurchasOrders]
        ([PurchasOrderId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPurchasOrderDetail_tblPurchasOrder'
CREATE INDEX [IX_FK_tblPurchasOrderDetail_tblPurchasOrder]
ON [dbo].[tblPurchasOrderDetails]
    ([PurchasOrderId]);
GO

-- Creating foreign key on [StatusId] in table 'tblPurchasOrderDetails'
ALTER TABLE [dbo].[tblPurchasOrderDetails]
ADD CONSTRAINT [FK_tblPurchasOrderDetail_tblStatus]
    FOREIGN KEY ([StatusId])
    REFERENCES [dbo].[tblStatus]
        ([StatusId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPurchasOrderDetail_tblStatus'
CREATE INDEX [IX_FK_tblPurchasOrderDetail_tblStatus]
ON [dbo].[tblPurchasOrderDetails]
    ([StatusId]);
GO

-- Creating foreign key on [StatusId] in table 'tblRoles'
ALTER TABLE [dbo].[tblRoles]
ADD CONSTRAINT [FK_tblRole_tblStatus]
    FOREIGN KEY ([StatusId])
    REFERENCES [dbo].[tblStatus]
        ([StatusId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblRole_tblStatus'
CREATE INDEX [IX_FK_tblRole_tblStatus]
ON [dbo].[tblRoles]
    ([StatusId]);
GO

-- Creating foreign key on [RoleId] in table 'tblRoleMenus'
ALTER TABLE [dbo].[tblRoleMenus]
ADD CONSTRAINT [FK_tblRoleMenu_tblRole]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[tblRoles]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblRoleMenu_tblRole'
CREATE INDEX [IX_FK_tblRoleMenu_tblRole]
ON [dbo].[tblRoleMenus]
    ([RoleId]);
GO

-- Creating foreign key on [RoleId] in table 'tblRoleUsers'
ALTER TABLE [dbo].[tblRoleUsers]
ADD CONSTRAINT [FK_tblRoleUser_tblRole]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[tblRoles]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblRoleUser_tblRole'
CREATE INDEX [IX_FK_tblRoleUser_tblRole]
ON [dbo].[tblRoleUsers]
    ([RoleId]);
GO

-- Creating foreign key on [StatusTypeId] in table 'tblStatus'
ALTER TABLE [dbo].[tblStatus]
ADD CONSTRAINT [FK_tblStatus_tblStatusType]
    FOREIGN KEY ([StatusTypeId])
    REFERENCES [dbo].[tblStatusTypes]
        ([StatusTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblStatus_tblStatusType'
CREATE INDEX [IX_FK_tblStatus_tblStatusType]
ON [dbo].[tblStatus]
    ([StatusTypeId]);
GO

-- Creating foreign key on [StatusId] in table 'tblSubGroups'
ALTER TABLE [dbo].[tblSubGroups]
ADD CONSTRAINT [FK_tblSubGroup_tblStatus]
    FOREIGN KEY ([StatusId])
    REFERENCES [dbo].[tblStatus]
        ([StatusId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSubGroup_tblStatus'
CREATE INDEX [IX_FK_tblSubGroup_tblStatus]
ON [dbo].[tblSubGroups]
    ([StatusId]);
GO

-- Creating foreign key on [StatusId] in table 'tblSuppliers'
ALTER TABLE [dbo].[tblSuppliers]
ADD CONSTRAINT [FK_tblSupplier_tblStatus]
    FOREIGN KEY ([StatusId])
    REFERENCES [dbo].[tblStatus]
        ([StatusId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSupplier_tblStatus'
CREATE INDEX [IX_FK_tblSupplier_tblStatus]
ON [dbo].[tblSuppliers]
    ([StatusId]);
GO

-- Creating foreign key on [StatusId] in table 'tblUnits'
ALTER TABLE [dbo].[tblUnits]
ADD CONSTRAINT [FK_tblUnit_tblStatus]
    FOREIGN KEY ([StatusId])
    REFERENCES [dbo].[tblStatus]
        ([StatusId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblUnit_tblStatus'
CREATE INDEX [IX_FK_tblUnit_tblStatus]
ON [dbo].[tblUnits]
    ([StatusId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------