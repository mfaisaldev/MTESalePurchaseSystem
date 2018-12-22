using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }
        [Required]
        [Display(Name = "Name")]
        [StringLength(250, ErrorMessage = "Name cannot be longer than 250 characters.")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Short Description")]
        [StringLength(1000, ErrorMessage = "Name cannot be longer than 250 characters.")]
        public string ShortDescription { get; set; }
        [Display(Name = "Full Description")]
        [AllowHtml]
        public string FullDescription { get; set; }

        [Display(Name = "Display Order")]
        public int? DisplayOrder { get; set; }
        public Guid StatusId { get; set; }
        public bool IsVISMA { get; set; }
        public Guid? FileId { get; set; }

        public String myStatus { get; set; }
        public List<SelectListItem> status = new List<SelectListItem>();
        public List<SelectListItem> Status
        {
            get
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    Guid StatusType_CURD = new Guid(Utilities.StatusType_CURD);

                    var st = from g in DB.tblStatus
                             where g.StatusTypeId == StatusType_CURD
                             select new { g.StatusId, g.Name };

                    foreach (var q in st)
                    {
                        status.Add(new SelectListItem() { Text = q.Name, Value = q.StatusId.ToString() });
                    }
                    return status;
                }
            }
        }

        public string CreateBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool IsAllow { get; set; }
        [Required]
        [Display(Name = "UPC Code")]
        public string UPC_code { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Purchase Price NOK")]
        public decimal? Purchase_Price_NOK { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Purchase Price USD EURO")]
        public decimal? Purchase_price_USD_EURO { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Price Customs NOK")]
        public decimal? Price_customs_NOK { get; set; }
        [Display(Name = "Lager Profile")]
        public string Lager_profile { get; set; }
        [Display(Name = "Year Article Type")]
        public string Year_Article_type { get; set; }
        public string Season { get; set; }
        public string Segment { get; set; }
        public string Gender { get; set; }
        public string Size { get; set; }
        public string Colour { get; set; }
        public Guid? UnitId { get; set; }
        public String myUnit { get; set; }
        public List<SelectListItem> unit = new List<SelectListItem>();
        public List<SelectListItem> Unit
        {
            get
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {

                    var ct = (from c in DB.tblUnits
                              where c.StatusId != new Guid(Utilities.Status_Delete)
                              select new { c.UnitId, c.Name, c.DisplayOrder  }).OrderBy(x => x.DisplayOrder); 

                    unit.Add(new SelectListItem() { Text = "", Value = Guid.Empty.ToString() });

                    foreach (var q in ct)
                    {
                        unit.Add(new SelectListItem() { Text = q.Name, Value = q.UnitId.ToString() });
                    }
                    return unit;
                }
            }
        }

        [Display(Name = "Sales Pack")]
        public string Sales_Pack { get; set; }
        [Display(Name = "Master Pack")]
        public string Master_Pack { get; set; }
        public Guid ProductTypeId { get; set; }
        public Guid? SupplierId { get; set; }
        public String mySupplier { get; set; }
        public List<SelectListItem> supplier = new List<SelectListItem>();
        public List<SelectListItem> Supplier
        {
            get
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {

                    var ct = (from c in DB.tblSuppliers
                              where c.StatusId != new Guid(Utilities.Status_Delete)
                              select new { c.SupplierId, c.Name }).OrderBy(x => x.Name); 

                    foreach (var q in ct)
                    {
                        supplier.Add(new SelectListItem() { Text = q.Name, Value = q.SupplierId.ToString() });
                    }
                    return supplier;
                }
            }
        }

        [Display(Name = "Product Stock")]
        public int? ProductStock { get; set; }
        [Display(Name = "Publish Date")]
        public DateTime? PublishDate { get; set; }
        public Guid? CurrencyId { get; set; }
        public String myCurrency { get; set; }
        public List<SelectListItem> currency = new List<SelectListItem>();
        public List<SelectListItem> Currency
        {
            get
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {

                    var ct = (from c in DB.tblCurrencies
                              where c.StatusId != new Guid(Utilities.Status_Delete)
                              select new { c.CurrencyId, c.Name, c.DisplayOrder }).OrderBy(x => x.DisplayOrder); ;

                    foreach (var q in ct)
                    {
                        currency.Add(new SelectListItem() { Text = q.Name, Value = q.CurrencyId.ToString() });
                    }
                    return currency;
                }
            }
        }
        public Guid? MainGroupId { get; set; }
        public String myMainGroup { get; set; }
        public List<SelectListItem> maingroup = new List<SelectListItem>();
        public List<SelectListItem> MainGroup
        {
            get
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {

                    var ct = (from c in DB.tblMainGroups
                              where c.StatusId != new Guid(Utilities.Status_Delete)
                              select new { c.MainGroupId, c.Name, c.DisplayOrder }).OrderBy(x => x.DisplayOrder);

                    maingroup.Add(new SelectListItem() { Text = "", Value = Guid.Empty.ToString() });

                    foreach (var q in ct)
                    {
                        maingroup.Add(new SelectListItem() { Text = q.Name, Value = q.MainGroupId.ToString() });
                    }
                    return maingroup;
                }
            }
        }
        public Guid? IntermediateGroupId { get; set; }
        public String myIntermediateGroup { get; set; }
        public List<SelectListItem> intermediategroup = new List<SelectListItem>();
        public List<SelectListItem> IntermediateGroup
        {
            get
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {

                    var ct = (from c in DB.tblIntermediateGroups
                              where c.StatusId != new Guid(Utilities.Status_Delete)
                              select new { c.IntermediateGroupId, c.Name, c.DisplayOrder }).OrderBy(x => x.DisplayOrder);

                    intermediategroup.Add(new SelectListItem() { Text = "", Value = Guid.Empty.ToString() });

                    foreach (var q in ct)
                    {
                        intermediategroup.Add(new SelectListItem() { Text = q.Name, Value = q.IntermediateGroupId.ToString() });
                    }
                    return intermediategroup;
                }
            }
        }
        public Guid? SubGroupId { get; set; }
        public String mySubGroup { get; set; }
        public List<SelectListItem> subgroup = new List<SelectListItem>();
        public List<SelectListItem> SubGroup
        {
            get
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {

                    var ct = (from c in DB.tblSubGroups
                              where c.StatusId != new Guid(Utilities.Status_Delete)
                              select new { c.SubGroupId, c.Name, c.DisplayOrder }).OrderBy(x => x.DisplayOrder);

                    subgroup.Add(new SelectListItem() { Text = "", Value = Guid.Empty.ToString() });

                    foreach (var q in ct)
                    {
                        subgroup.Add(new SelectListItem() { Text = q.Name, Value = q.SubGroupId.ToString() });
                    }
                    return subgroup;
                }
            }
        }

        //for PO
        public string CustomerName { get; set; }
        public int? OrderQty { get; set; }
        public DateTime? OrderDate { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? OrderId { get; set; }
        public Guid? OrderDetailId { get; set; }

        public string style { get; set; }
        [Display(Name = "Out Price")]
        [DataType(DataType.Currency)]
        public decimal? Out_Price { get; set; }
        [Display(Name = "In Price")]
        [DataType(DataType.Currency)]
        public decimal? In_Price { get; set; }
        [Display(Name = "Cost Price")]
        [DataType(DataType.Currency)]
        public decimal? Cost_Price { get; set; }
        [Display(Name = "Supplier Price")]
        [DataType(DataType.Currency)]
        public decimal? Supplier_price { get; set; }

        [Display(Name = "Category")]
        public string Category { get; set; }
        [Display(Name = "Sub Category")]
        public string SubCategory { get; set; }
        [Display(Name = "Product")]
        public string Products { get; set; }
        [Display(Name = "Product Type")]
        public string ProductType { get; set; }
        [Display(Name = "Brand")]
        public string Brands { get; set; }

        public int? WareHouseNo { get; set; }
        [Display(Name = "Unit On Purchase")]
        public int? UnitOnPurchase { get; set; }
        [Display(Name = "Max Stock")]
        public int? MaxStock { get; set; }
        [Display(Name = "Min Stock")]
        public int? MinStock { get; set; }
        [Display(Name = "Unit In Stock")]
        public int? UnitInStock { get; set; }
        [Display(Name = "Unit On Order")]
        public int? UnitOnOrder { get; set; }
        [Display(Name = "Unit On Reminder")]
        public int? UnitOnReminder { get; set; }
        [Display(Name = "Unit Packed")]
        public int? UnitPacked { get; set; }
        [Display(Name = "Qty Manual Reserved")]
        public int? QtyManualReserved { get; set; }
        [Display(Name = "Qty Reserved")]
        public int? QtyReserved { get; set; }
    }

    public class ProductCustomerView
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public int? DisplayOrder { get; set; }
        public Guid? FileId { get; set; }
        public decimal? Price { get; set; }
        public DateTime? PublishDate { get; set; }
        public Guid? BrandId { get; set; }
        public string BrandName { get; set; }
        public Guid? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CurrencySymbol{ get; set; }
        public Guid? MainGroupId { get; set; }
        public string MainGroupName { get; set; }
        public Guid? IntermediateGroupId { get; set; }
        public string IntermediateGroupName { get; set; }


    }

    public class ProductType
    {
        public Guid ProductTypeId { get; set; }
        public string Name { get; set; }

    }
   
    public class ProductBrand
    {
        public Guid ProductBrandId { get; set; }
        public Guid ProductId { get; set; }
        public Guid BrandId { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreationDate { get; set; }

    }
    public class ProductCategory
    {
        public Guid ProductCategoryId { get; set; }
        public Guid ProductId { get; set; }
        public Guid CategoryId { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreationDate { get; set; }

    }
    public class ProductSearch
    {
        [Display(Name = "Product Name")]
        public String ProductName { get; set; }
        public Guid Category { get; set; }
        public Guid Brand { get; set; }
        public Guid Offer { get; set; }
        public Guid PurchasOrder { get; set; }
        public Guid Supplier { get; set; }

        public List<Product> Products = new List<Product>();
        public String CategoryName { get; set; }
        public String BrandName { get; set; }
        public String OfferName { get; set; }
        public String PurchasOrderName { get; set; }
        public String SupplierName { get; set; }
        [Display(Name = "UPC Code")]
        public string UPC_code { get; set; }
        public bool Search { get; set; }
        public int page { get; set; }
        public int count { get; set; }
        [Display(Name = "Main Group")]
        public Guid MainGroup { get; set; }
        [Display(Name = "Intermediate Group")]
        public Guid IntermediateGroup { get; set; }
        [Display(Name = "Sub Group")]
        public Guid SubGroup { get; set; }

    }

    public class ProductHistory
    {
        public Guid ProductHistoryId { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Product Name cannot be longer than 250 characters.")]
        public string ProductName { get; set; }
        public string Remarks { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }
        public DateTime? SaleDate { get; set; }
        public int? Qty { get; set; }
        public Guid StatusId { get; set; }
        public String myStatus { get; set; }
        public List<SelectListItem> status = new List<SelectListItem>();
        public List<SelectListItem> Status
        {
            get
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    Guid StatusType_CURD = new Guid(Utilities.StatusType_CURD);

                    var st = from g in DB.tblStatus
                             where g.StatusTypeId == StatusType_CURD
                             select new { g.StatusId, g.Name };

                    foreach (var q in st)
                    {
                        status.Add(new SelectListItem() { Text = q.Name, Value = q.StatusId.ToString() });
                    }
                    return status;
                }
            }
        }
        public Guid CustomerId { get; set; }
        public String myCustomer { get; set; }
        public List<SelectListItem> customer = new List<SelectListItem>();
        public List<SelectListItem> Customer
        {
            get
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    Guid StatusType_CURD = new Guid(Utilities.StatusType_CURD);

                    var st = from g in DB.tblCustomers
                             where g.StatusId == new Guid(Utilities.Status_Online)
                             select new { g.CustomerId, g.Name };

                    foreach (var q in st)
                    {
                        customer.Add(new SelectListItem() { Text = q.Name, Value = q.CustomerId.ToString() });
                    }
                    return customer;
                }
            }
        }
        public Guid ProductId { get; set; }
        public String myProduct { get; set; }
        public List<SelectListItem> product = new List<SelectListItem>();
        public List<SelectListItem> Product
        {
            get
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    Guid StatusType_CURD = new Guid(Utilities.StatusType_CURD);

                    var st = from g in DB.tblProducts
                             where g.StatusId == new Guid(Utilities.Status_Active)
                             select new { g.ProductId, g.Name };

                    foreach (var q in st)
                    {
                        status.Add(new SelectListItem() { Text = q.Name, Value = q.ProductId.ToString() });
                    }
                    return status;
                }
            }
        }
        public string CreateBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyDate { get; set; }
    }

    public class ProductSupplierHistory
    {
        public Guid ProductSupplierHistoryId { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Product Name cannot be longer than 250 characters.")]
        public string ProductName { get; set; }
        public string Remarks { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }
        public DateTime? SaleDate { get; set; }
        public int? Qty { get; set; }
        public Guid StatusId { get; set; }
        public String myStatus { get; set; }
        public List<SelectListItem> status = new List<SelectListItem>();
        public List<SelectListItem> Status
        {
            get
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    Guid StatusType_CURD = new Guid(Utilities.StatusType_CURD);

                    var st = from g in DB.tblStatus
                             where g.StatusTypeId == StatusType_CURD
                             select new { g.StatusId, g.Name };

                    foreach (var q in st)
                    {
                        status.Add(new SelectListItem() { Text = q.Name, Value = q.StatusId.ToString() });
                    }
                    return status;
                }
            }
        }
        public Guid SupplierId { get; set; }
        public String mySupplier { get; set; }
        public List<SelectListItem> supplier = new List<SelectListItem>();
        public List<SelectListItem> Supplier
        {
            get
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    Guid StatusType_CURD = new Guid(Utilities.StatusType_CURD);

                    var st = from g in DB.tblSuppliers
                             where g.StatusId == new Guid(Utilities.Status_Active)
                             select new { g.SupplierId, g.Name };

                    foreach (var q in st)
                    {
                        supplier.Add(new SelectListItem() { Text = q.Name, Value = q.SupplierId.ToString() });
                    }
                    return supplier;
                }
            }
        }
        public Guid ProductId { get; set; }
        public String myProduct { get; set; }
        public List<SelectListItem> product = new List<SelectListItem>();
        public List<SelectListItem> Product
        {
            get
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    Guid StatusType_CURD = new Guid(Utilities.StatusType_CURD);

                    var st = from g in DB.tblProducts
                             where g.StatusId == new Guid(Utilities.Status_Active)
                             select new { g.ProductId, g.Name };

                    foreach (var q in st)
                    {
                        product.Add(new SelectListItem() { Text = q.Name, Value = q.ProductId.ToString() });
                    }
                    return product;
                }
            }
        }
        public string CreateBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyDate { get; set; }
    }

    public class ProductUnitType
    {
        public Guid ProductUnitTypeId { get; set; }
        public Guid ProductId { get; set; }
        [Display(Name = "Unit Name Purchase")]
        [StringLength(300, ErrorMessage = "Unit Name Purchase cannot be longer than 300 characters.")]
        public string ProductName { get; set; }

        public string UnitNamePurchase { get; set; }
        public int? Factor { get; set; }
        [Display(Name = "ISO Code")]
        [StringLength(300, ErrorMessage = "ISO Code cannot be longer than 300 characters.")]
        public string ISOCode { get; set; }
        public int? Height { get; set; }
        [Display(Name = "Variable Qty")]
        public bool? VariableQty { get; set; }
        public int? Width { get; set; }
        public int? Length { get; set; }
        public int? Volume { get; set; }
        public int? Rounding { get; set; }
        public string Comment { get; set; }
        [Display(Name = "Unit In Purchase")]
        public int? UnitInPurchase { get; set; }
        [Display(Name = "Split Purchase")]
        public int? SplitPurchase { get; set; }
        [Display(Name = "Unit In Sales")]
        public int? UnitInSales { get; set; }
        [Display(Name = "Split Sales")]
        public bool? SplitSales { get; set; }
        public int? Weight { get; set; }
        [Display(Name = "PackingType")]
        [StringLength(300, ErrorMessage = "Packing Type cannot be longer than 300 characters.")]
        public string PackingType { get; set; }
        [Display(Name = "Comparable Unit")]
        public bool? ComparableUnit { get; set; }
        [StringLength(300, ErrorMessage = "Location cannot be longer than 300 characters.")]
        public string Location { get; set; }
        [Display(Name = "Unit In Stock Control")]
        public int? UnitInStockControl { get; set; }
        public Guid UnitId { get; set; }
        [Required]
        [StringLength(300, ErrorMessage = "Name cannot be longer than 300 characters.")]
        public string Name { get; set; }
        [Required]
        public Guid StatusId { get; set; }
        public bool IsVISMA { get; set; }
        public String myStatus { get; set; }
        public List<SelectListItem> status = new List<SelectListItem>();
        public List<SelectListItem> Status
        {
            get
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    Guid StatusType_CURD = new Guid(Utilities.StatusType_CURD);
                    var st = from g in DB.tblStatus
                             where g.StatusTypeId == StatusType_CURD
                             select new { g.StatusId, g.Name };
                    foreach (var q in st)
                    {
                        status.Add(new SelectListItem() { Text = q.Name, Value = q.StatusId.ToString() });
                    }
                    return status;
                }
            }
        }
        public String myUnit { get; set; }
        public List<SelectListItem> unit = new List<SelectListItem>();
        public List<SelectListItem> Unit
        {
            get
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {

                    var ct = (from c in DB.tblUnits
                              where c.StatusId != new Guid(Utilities.Status_Delete)
                              select new { c.UnitId, c.Name, c.DisplayOrder }).OrderBy(x => x.DisplayOrder); ;

                    foreach (var q in ct)
                    {
                        unit.Add(new SelectListItem() { Text = q.Name, Value = q.UnitId.ToString() });
                    }
                    return unit;
                }
            }
        }

        public string CreateBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyDate { get; set; }
    }

    public class MultiProduct
    {
        public Guid? SupplierId { get; set; }
        public List<SelectListItem> supplier = new List<SelectListItem>();
        public List<SelectListItem> Supplier
        {
            get
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {

                    var ct = (from c in DB.tblSuppliers
                              where c.StatusId != new Guid(Utilities.Status_Delete)
                              select new { c.SupplierId, c.Name }).OrderBy(x => x.Name);

                    foreach (var q in ct)
                    {
                        supplier.Add(new SelectListItem() { Text = q.Name, Value = q.SupplierId.ToString() });
                    }
                    return supplier;
                }
            }
        }
        public bool IsUpdateVISMA { get; set; }
        public string Excel { get; set; }
        public string UPC { get; set; }
        public string style { get; set; }
        public string navn { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string HG { get; set; }
        public string MG { get; set; }
        public string UG { get; set; }
        public string type { get; set; }
        public string UtPris { get; set; }
        public string Innpris { get; set; }
        public string LevPris { get; set; }
        public string KostPris { get; set; }
    }
}