using Admin.Models;
using LinqToExcel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using PagedList;
namespace Admin.Controllers
{
    public class ProductsController : Controller
    {
        #region Product

        [HttpGet]
        [Authorize]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            try
            {
                DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2();
                var UserRoles = this.GetRoles();
                ViewBag.UserRoles = UserRoles;
                if (UserRoles.Where(u => u.RoleId.ToString().ToUpper() == Utilities.Role_Customer).FirstOrDefault() != null)
                    return RedirectToAction("Customer", "Products");

                ViewBag.CurrentSort = sortOrder;
                ViewBag.UPCCodeSortParm = String.IsNullOrEmpty(sortOrder) ? "UPCCode_desc" : "";
                ViewBag.NameSortParm = sortOrder == "Name" ? "Name_desc" : "Name";
                ViewBag.PriceSortParm = sortOrder == "Price" ? "Price_desc" : "Price";
                ViewBag.StockSortParm = sortOrder == "Stock" ? "Stock_desc" : "Stock";
                ViewBag.StatusSortParm = sortOrder == "Status" ? "Status_desc" : "Status";

                if (searchString != null)
                {
                    page = 1;
                }
                else
                {
                    searchString = currentFilter;
                }

                ViewBag.CurrentFilter = searchString;

                var C =from g in DB.tblProducts
                       select g;

                if (!String.IsNullOrEmpty(searchString))
                {
                    C = C.Where(s => s.UPC_code.Contains(searchString)
                              || s.Name.Contains(searchString));
                }
                switch (sortOrder)
                {
                    case "UPCCode_desc":
                        C = C.OrderByDescending(s => s.UPC_code);
                        break;
                    case "Name":
                        C = C.OrderBy(s => s.Name);
                        break;
                    case "Name_desc":
                        C = C.OrderByDescending(s => s.Name);
                        break;
                    case "Price":
                        C = C.OrderBy(s => s.Price);
                        break;
                    case "Price_desc":
                        C = C.OrderByDescending(s => s.Price);
                        break;
                    case "Stock":
                        C = C.OrderBy(s => s.Name);
                        break;
                    case "Stock_desc":
                        C = C.OrderByDescending(s => s.Name);
                        break;
                    case "Status":
                        C = C.OrderBy(s => s.Name);
                        break;
                    case "Status_desc":
                        C = C.OrderByDescending(s => s.Name);
                        break;
                    default:  // Name ascending 
                        C = C.OrderBy(s => s.CreationDate);
                        break;
                }

                int pageSize = 50;
                int pageNumber = (page ?? 1);
                return View(C.ToPagedList(pageNumber, pageSize));
            }
            catch
            {
                return View();
            }
        }


        [Authorize]
        [HttpGet]
        public ActionResult Create(string Id)
        {
            try
            {
                if (Id != null)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        Guid ProductId = Guid.Parse(Id);
                        DBLayer.tblProduct tbl = (from g in DB.tblProducts
                                                  where g.ProductId == ProductId
                                                  select g).SingleOrDefault();
                        Product m = new Product();
                        m.ProductId = tbl.ProductId;
                        m.DisplayOrder = tbl.DisplayOrder;
                        m.Name = tbl.Name;
                        m.FullDescription = tbl.FullDescription;
                        m.ShortDescription = tbl.ShortDescription;
                        m.FileId = tbl.FileId;
                        m.myStatus = tbl.StatusId.ToString();
                        m.UPC_code = tbl.UPC_code;
                        m.Price = tbl.Price;
                        m.Purchase_Price_NOK = tbl.Purchase_Price_NOK;
                        m.Purchase_price_USD_EURO = tbl.Purchase_price_USD_EURO;
                        m.Price_customs_NOK = tbl.Price_customs_NOK;
                        m.MainGroupId = tbl.MainGroupId;
                        m.IntermediateGroupId = tbl.IntermediateGroupId;
                        m.SubGroupId = tbl.SubGroupId;
                        m.Lager_profile = tbl.Lager_profile;
                        m.Year_Article_type = tbl.Year_Article_type;
                        m.Season = tbl.Season;
                        m.Segment = tbl.Segment;
                        m.Gender = tbl.Gender;
                        m.Size = tbl.Size;
                        m.Colour = tbl.Colour;
                        m.UnitId = tbl.UnitId;
                        m.SupplierId = tbl.SupplierId;
                        m.Sales_Pack = tbl.Sales_Pack;
                        m.Master_Pack = tbl.Master_Pack;
                        m.ProductStock = tbl.ProductStock;
                        m.PublishDate = tbl.PublishDate;
                        m.CurrencyId = tbl.CurrencyId;

                        m.style = tbl.style;
                        m.Out_Price = tbl.Out_Price;
                        m.In_Price = tbl.In_Price;
                        m.Cost_Price = tbl.Cost_Price;
                        m.Supplier_price = tbl.Supplier_price;
                        m.Category = tbl.Category;
                        m.SubCategory = tbl.SubCategory;
                        m.Products = tbl.Product;
                        m.ProductType = tbl.ProductType;
                        m.Brands = tbl.Brand;
                        m.UnitOnPurchase = tbl.UnitOnPurchase;
                        m.MaxStock = tbl.MaxStock;
                        m.MinStock = tbl.MinStock;
                        m.UnitInStock = tbl.UnitInStock;
                        m.UnitOnOrder = tbl.UnitOnOrder;
                        m.UnitOnReminder = tbl.UnitOnReminder;
                        m.QtyManualReserved = tbl.QtyManualReserved;
                        m.QtyReserved = tbl.QtyReserved;

                        ViewBag.Files = DB.tblProductFiles.Where(u => u.ProductId == tbl.ProductId).ToList();
                        ViewBag.FileId = tbl.FileId;
                        return View(m);
                    }
                }
                else
                {
                    Product m = new Product();
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblCustomer tbl = (from g in DB.tblCustomers
                                                   where g.UserName == User.Identity.Name
                                                   select g).SingleOrDefault();
                        m.CurrencyId = tbl.CurrencyId;
                    }
                    return View(m);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
                return View();
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Create Product")]
        [ValidateInput(false)]
        public async Task<ActionResult> Create(Product m, HttpPostedFileBase upload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblProduct tbl = DB.tblProducts.Where(u => u.Name.ToLower() == m.Name.ToLower() && u.StatusId != new Guid(Utilities.Status_Delete)).FirstOrDefault();
                        if (tbl == null)
                        {
                            var NewFileId = Guid.NewGuid();
                            var ProductId = Guid.NewGuid();
                            tbl = new DBLayer.tblProduct();
                            tbl.ProductId = ProductId;
                            tbl.Name = m.Name;
                            tbl.FullDescription = m.FullDescription;
                            tbl.ShortDescription = m.ShortDescription;
                            tbl.DisplayOrder = m.DisplayOrder;
                            tbl.StatusId = new Guid(m.myStatus);
                            tbl.CreationDate = DateTime.Now;
                            tbl.CreateBy = User.Identity.Name;
                            tbl.UPC_code = m.UPC_code;
                            tbl.Price = m.Price;
                            tbl.Purchase_Price_NOK = m.Purchase_Price_NOK;
                            tbl.Purchase_price_USD_EURO = m.Purchase_price_USD_EURO;
                            tbl.Price_customs_NOK = m.Price_customs_NOK;
                            tbl.Lager_profile = m.Lager_profile;
                            tbl.Year_Article_type = m.Year_Article_type;
                            tbl.Season = m.Season;
                            tbl.Segment = m.Segment;
                            tbl.Gender = m.Gender;
                            tbl.Size = m.Size;
                            tbl.Colour = m.Colour;
                            tbl.Sales_Pack = m.Sales_Pack;
                            tbl.Master_Pack = m.Master_Pack;
                            tbl.ProductStock = m.ProductStock;
                            tbl.PublishDate = m.PublishDate;
                            tbl.CurrencyId = m.CurrencyId;
                            tbl.SupplierId = m.SupplierId;
                            if (!(m.UnitId == null || m.UnitId == Guid.Empty))
                                tbl.UnitId = m.UnitId;
                            if (!(m.MainGroupId == null || m.MainGroupId == Guid.Empty))
                                tbl.MainGroupId = m.MainGroupId;
                            if (!(m.IntermediateGroupId == null || m.IntermediateGroupId == Guid.Empty))
                                tbl.IntermediateGroupId = m.IntermediateGroupId;
                            if (!(m.SubGroupId == null || m.SubGroupId == Guid.Empty))
                                tbl.SubGroupId = m.SubGroupId;
                            tbl.style = m.style;
                            tbl.Out_Price = m.Out_Price;
                            tbl.In_Price = m.In_Price;
                            tbl.Cost_Price = m.Cost_Price;
                            tbl.Supplier_price = m.Supplier_price;

                            tbl.Category = m.Category;
                            tbl.SubCategory = m.SubCategory;
                            tbl.Product = m.Products;
                            tbl.ProductType = m.ProductType;
                            tbl.Brand = m.Brands;


                            // Add Image
                            if (upload != null && upload.ContentLength > 0)
                            {
                                DBLayer.tblFile tblFile = new DBLayer.tblFile();
                                tblFile.FileName = System.IO.Path.GetFileName(upload.FileName);
                                tblFile.FileType = (byte)FileType.Avatar;
                                tblFile.ContentType = upload.ContentType;
                                using (var reader = new System.IO.BinaryReader(upload.InputStream))
                                {
                                    tblFile.ContentData = reader.ReadBytes(upload.ContentLength);
                                }
                                tblFile.FileId = NewFileId;
                                DB.tblFiles.Add(tblFile);

                                tbl.FileId = NewFileId;
                            }

                            DB.tblProducts.Add(tbl);
                            DB.SaveChanges();
                            //Update VISMA

                            bool isUpdate = await this.UpdateArticle(tbl, true);
                            if (isUpdate)
                            {
                                ViewBag.Error = "Records is successfull updated";
                                return View(m);
                                //  return RedirectToAction("Create", "Products", new { Id = ProductId });
                            }
                            else
                            {
                                ViewBag.Error = "Records is successfull update in B2B but unable to update VISMA";
                                return View(m);
                            }
                            //return RedirectToAction("Create", "Products", new { Id = ProductId });
                        }
                        else
                        {
                            ViewBag.Error = "Product Name Already Exists";
                            return View(m);
                        }
                    }
                }
                else
                {
                    return View(m);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
                return View(m);
            }
        }


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Edit Product")]
        [ValidateInput(false)]
        public async Task<ActionResult> Edit(Product m, HttpPostedFileBase upload)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblProduct tblcheck = DB.tblProducts.Where(u => u.Name.ToLower() == m.Name.ToLower() && u.StatusId != new Guid(Utilities.Status_Delete) && u.ProductId != m.ProductId).FirstOrDefault();
                        if (tblcheck == null)
                        {
                            DBLayer.tblProduct tbl = (from g in DB.tblProducts
                                                      where g.ProductId == m.ProductId
                                                      select g).SingleOrDefault();
                            tbl.Name = m.Name;
                            tbl.DisplayOrder = m.DisplayOrder;
                            tbl.FullDescription = m.FullDescription;
                            tbl.ShortDescription = m.ShortDescription;
                            tbl.StatusId = new Guid(m.myStatus);
                            tbl.ModifyDate = DateTime.Now;
                            tbl.ModifyBy = User.Identity.Name;
                            tbl.IsVISMA = false;
                            //tbl.UPC_code = m.UPC_code;
                            tbl.Price = m.Price;
                            tbl.Purchase_Price_NOK = m.Purchase_Price_NOK;
                            tbl.Purchase_price_USD_EURO = m.Purchase_price_USD_EURO;
                            tbl.Price_customs_NOK = m.Price_customs_NOK;
                            tbl.Lager_profile = m.Lager_profile;
                            tbl.Year_Article_type = m.Year_Article_type;
                            tbl.Season = m.Season;
                            tbl.Segment = m.Segment;
                            tbl.Gender = m.Gender;
                            tbl.Size = m.Size;
                            tbl.Colour = m.Colour;
                            tbl.Sales_Pack = m.Sales_Pack;
                            tbl.Master_Pack = m.Master_Pack;
                            tbl.ProductStock = m.ProductStock;
                            tbl.PublishDate = m.PublishDate;
                            tbl.CurrencyId = m.CurrencyId;
                            tbl.SupplierId = m.SupplierId;
                            if (!(m.UnitId == null || m.UnitId == Guid.Empty))
                                tbl.UnitId = m.UnitId;
                            if (!(m.MainGroupId == null || m.MainGroupId == Guid.Empty))
                                tbl.MainGroupId = m.MainGroupId;
                            if (!(m.IntermediateGroupId == null || m.IntermediateGroupId == Guid.Empty))
                                tbl.IntermediateGroupId = m.IntermediateGroupId;
                            if (!(m.SubGroupId == null || m.SubGroupId == Guid.Empty))
                                tbl.SubGroupId = m.SubGroupId;
                            tbl.style = m.style;
                            tbl.Out_Price = m.Out_Price;
                            tbl.In_Price = m.In_Price;
                            tbl.Cost_Price = m.Cost_Price;
                            tbl.Supplier_price = m.Supplier_price;
                            tbl.Category = m.Category;
                            tbl.SubCategory = m.SubCategory;
                            tbl.Product = m.Products;
                            tbl.ProductType = m.ProductType;
                            tbl.Brand  = m.Brands;

                            if (upload != null && upload.ContentLength > 0)
                            {

                                var NewFileId = Guid.NewGuid();
                                if (m.FileId == Guid.Empty || m.FileId == null)
                                {
                                    DBLayer.tblFile tblFile = new DBLayer.tblFile();
                                    tblFile.FileName = System.IO.Path.GetFileName(upload.FileName);
                                    tblFile.FileType = (byte)FileType.Avatar;
                                    tblFile.ContentType = upload.ContentType;
                                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                                    {
                                        tblFile.ContentData = reader.ReadBytes(upload.ContentLength);
                                    }
                                    tblFile.FileId = NewFileId;
                                    tbl.FileId = NewFileId;

                                    DB.tblFiles.Add(tblFile);

                                }
                                else
                                {
                                    if (m.FileId.ToString() == "d7253a72-9b86-426e-8716-85028ac3582c")
                                    {
                                        DBLayer.tblFile tblFile = new DBLayer.tblFile();
                                        tblFile.FileName = System.IO.Path.GetFileName(upload.FileName);
                                        tblFile.FileType = (byte)FileType.Avatar;
                                        tblFile.ContentType = upload.ContentType;
                                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                                        {
                                            tblFile.ContentData = reader.ReadBytes(upload.ContentLength);
                                        }
                                        tblFile.FileId = NewFileId;
                                        tbl.FileId = NewFileId;

                                        DB.tblFiles.Add(tblFile);
                                    }
                                    else
                                    {
                                        DBLayer.tblFile tblFile = DB.tblFiles.Where(u => u.FileId == m.FileId).FirstOrDefault();
                                        tblFile.FileName = System.IO.Path.GetFileName(upload.FileName);
                                        tblFile.FileType = (byte)FileType.Avatar;
                                        tblFile.ContentType = upload.ContentType;
                                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                                        {
                                            tblFile.ContentData = reader.ReadBytes(upload.ContentLength);
                                        }
                                    }
                                }
                            }

                            DB.SaveChanges();
                            //Update VISMA
                            bool isUpdate = await this.UpdateArticle(tbl, false);
                            if (isUpdate)
                                return RedirectToAction("Index", "Products");
                            else
                            {
                                ViewBag.Error = "Records is successfull update in B2B but unable to update VISMA";
                                return View(m);
                            }
                           // return RedirectToAction("Index", "Products");
                        }
                        else
                        {
                            ViewBag.Error = "Product Name Already Exists";
                            return View(m);
                        }
                    }
                }
                else
                {
                    return View(m);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
                return View();
            }
        }


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Delete Product")]
        public ActionResult Delete(Product m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblProduct tbl = (from g in DB.tblProducts
                                                  where g.ProductId == m.ProductId
                                                  select g).SingleOrDefault();
                        tbl.StatusId = new Guid(Utilities.Status_Delete);
                        tbl.ModifyDate = DateTime.Now;
                        tbl.ModifyBy = User.Identity.Name;
                        //Delete File
                        DBLayer.tblFile tblFile = (from g in DB.tblFiles
                                                   where g.FileId == m.FileId
                                                   select g).SingleOrDefault();
                        if(tblFile!=null)
                            DB.tblFiles.Remove(tblFile);
                        DB.SaveChanges();
                        return RedirectToAction("Index", "Products");
                    }
                }
                else
                {
                    return View(m);
                }
            }

            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
                return View();
            }

        }

        public ActionResult Upload()
        {
            return View();
        }
        protected override void HandleUnknownAction(string actionName)
        {
            this.View(actionName).ExecuteResult(this.ControllerContext);
            //base.HandleUnknownAction(actionName);
        }

        public ActionResult SaveUploadedFile(string Id)
        {
            if (Id != null)
            {
                var ProductId = new Guid(Id);
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    string fName = "";
                    foreach (string fileName in Request.Files)
                    {
                        HttpPostedFileBase file = Request.Files[fileName];
                        //Save file content goes here
                        if (file != null && file.ContentLength > 0)
                        {
                            DBLayer.tblFile tblFile = DB.tblFiles.Where(u => u.FileName == file.FileName && u.ContentType == file.ContentType).FirstOrDefault();
                            var NewFileId = Guid.NewGuid();
                            Guid OldFileId = Guid.Empty;
                            if (tblFile == null)
                            {
                                tblFile = new DBLayer.tblFile();
                                tblFile.FileName = System.IO.Path.GetFileName(file.FileName);
                                tblFile.FileType = (byte)FileType.Avatar;
                                tblFile.ContentType = file.ContentType;
                                using (var reader = new System.IO.BinaryReader(file.InputStream))
                                {
                                    tblFile.ContentData = reader.ReadBytes(file.ContentLength);
                                }
                                tblFile.FileId = NewFileId;
                                DB.tblFiles.Add(tblFile);
                            }
                            else
                            {
                                tblFile.FileName = System.IO.Path.GetFileName(file.FileName);
                                tblFile.FileType = (byte)FileType.Avatar;
                                tblFile.ContentType = file.ContentType;
                                using (var reader = new System.IO.BinaryReader(file.InputStream))
                                {
                                    tblFile.ContentData = reader.ReadBytes(file.ContentLength);
                                }
                                OldFileId = tblFile.FileId;
                            }
                            DB.SaveChanges();

                            if (OldFileId != Guid.Empty)
                            {
                                List<DBLayer.tblProductFile> listru = DB.tblProductFiles.Where(u => u.ProductId == ProductId && u.FileId == OldFileId).ToList();
                                foreach (DBLayer.tblProductFile obj in listru)
                                    DB.tblProductFiles.Remove(obj);
                                DB.SaveChanges();
                            }
                                DBLayer.tblProductFile pf = new DBLayer.tblProductFile();
                                pf.CreateBy = User.Identity.Name;
                                pf.CreationDate = DateTime.Now;
                                pf.FileId = NewFileId;
                                pf.ProductId = ProductId;
                                pf.ProductFileId = Guid.NewGuid();
                                DB.tblProductFiles.Add(pf);
                            DB.SaveChanges();

                        }

                    }
                    return Json(new { Message = fName });
                }
            }
            return Json(new { Message = "Error in saving file" });
        }
        
       public string GetIntermediateGroupForMainGroup(string id)
        {
            var intermediategroup = new List<SelectListItem>();
            using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
            {

                var ct = (from c in DB.tblIntermediateGroups
                          where c.StatusId != new Guid(Utilities.Status_Delete)
                          && c.MainGroupId.ToString() == id
                          select new { c.IntermediateGroupId, c.Name, c.DisplayOrder }).OrderBy(x => x.DisplayOrder);

                intermediategroup.Add(new SelectListItem() { Text = "", Value = Guid.Empty.ToString() });

                foreach (var q in ct)
                {
                    intermediategroup.Add(new SelectListItem() { Text = q.Name, Value = q.IntermediateGroupId.ToString() });
                }
                return new JavaScriptSerializer().Serialize(intermediategroup);
            }
        }

        public string GetSubGroupForIntermediateGroup(string id)
        {
            var subgroup = new List<SelectListItem>();
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {

                    var ct = (from c in DB.tblSubGroups
                              where c.StatusId != new Guid(Utilities.Status_Delete)
                              && c.IntermediateGroupId.ToString() == id 
                              select new { c.SubGroupId, c.Name, c.DisplayOrder }).OrderBy(x => x.DisplayOrder);

                    subgroup.Add(new SelectListItem() { Text = "", Value = Guid.Empty.ToString() });

                    foreach (var q in ct)
                    {
                        subgroup.Add(new SelectListItem() { Text = q.Name, Value = q.SubGroupId.ToString() });
                    }
                    return new JavaScriptSerializer().Serialize(subgroup);
                }
        }

        #endregion

        #region Customer View
        [HttpGet]
        [Authorize]
        public ActionResult Customer()
        {
            try
            {
                List<ProductCustomerView> myColl = new List<ProductCustomerView>();
                IEnumerable<ProductCustomerView> items = null;
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    //var C = (from p in  DB.tblProducts
                    //         where p.StatusId == new Guid(Utilities.Status_Active)

                    var C = (from od in DB.tblOrderDetails
                             join p in DB.tblProducts
                              on od.ProductId equals p.ProductId
                             join o in DB.tblOrders
                             on od.OrderId equals o.OrderId
                             join c in DB.tblCustomers
                              on o.CustomerId equals c.CustomerId
                             where p.StatusId == new Guid(Utilities.Status_Active)
                             && o.StatusId.ToString() != Utilities.Status_Delete
                             && c.UserName == User.Identity.Name  

                             select new { p.ProductId, p.Name, p.Price, p.ShortDescription, p.PublishDate, p.tblCurrency.Symbol, p.DisplayOrder, p.FileId }).OrderBy(x => x.DisplayOrder);
                    foreach (var ele in C)
                    {
                        myColl.Add(new ProductCustomerView()
                        {
                            ProductId = ele.ProductId,
                            Name = ele.Name,
                            DisplayOrder = ele.DisplayOrder,
                            ShortDescription = ele.ShortDescription,
                            Price = ele.Price,
                            PublishDate = ele.PublishDate,
                            CurrencySymbol = ele.Symbol,
                            FileId = ele.FileId
                        });
                    }


                    var C1 = (from p in DB.tblProducts
                              join pb in DB.tblMainGroups 
                                  on p.MainGroupId  equals pb.MainGroupId  into pp
                              from pb in pp.DefaultIfEmpty()
                              where pb != null
                              where p.StatusId == new Guid(Utilities.Status_Active)
                              select new { p.ProductId , MainGroupId = (Guid?)pb.MainGroupId ?? Guid.Empty, MainGroupName = pb.Name  });

                    foreach (var ele in C1)
                    {
                        var obj = myColl.FirstOrDefault(x => x.ProductId == ele.ProductId);
                        if (obj != null)
                        {
                            obj.MainGroupId = ele.MainGroupId ;
                            obj.MainGroupName  = ele.MainGroupName;
                        } 
                    }

                    var C2 = (from p in DB.tblProducts
                             join pc in DB.tblIntermediateGroups
                                on p.IntermediateGroupId  equals pc.IntermediateGroupId  into ppp
                             from pc in ppp.DefaultIfEmpty()
                              where pc != null
                              where p.StatusId == new Guid(Utilities.Status_Active)
                             select new { p.ProductId, p.Name, p.Price, p.ShortDescription, p.PublishDate, p.tblCurrency.Symbol, p.DisplayOrder, p.FileId, IntermediateGroupId = (Guid?)pc.IntermediateGroupId ?? Guid.Empty, IntermediateGroupName = pc.Name  }).OrderBy(x => x.DisplayOrder);

                    foreach (var ele in C2)
                    {
                        var obj = myColl.FirstOrDefault(x => x.ProductId == ele.ProductId);
                        if (obj != null)
                        {
                            obj.IntermediateGroupId = ele.IntermediateGroupId;
                            obj.IntermediateGroupName = ele.IntermediateGroupName;
                        }
                    }

                    items = myColl as IEnumerable<ProductCustomerView>;
                    //Get All roles
                    var UserRoles = this.GetRoles();
                    ViewBag.UserRoles = UserRoles;
                    ViewBag.MainGroup = DB.tblMainGroups.Where(u => u.StatusId.ToString() == Utilities.Status_Active).ToList();
                    ViewBag.IntermediateGroup = DB.tblIntermediateGroups.Where(u => u.StatusId.ToString() == Utilities.Status_Active).ToList();
                    return View(items);
                }
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult CustomerDetail(string Id)
        {
            try
            {
                if(Id!= null)
                {

                    var p = new Product();
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        var t = DB.tblProducts.Where(u => u.ProductId.ToString() == Id).SingleOrDefault();
                        p.Colour = t.Colour;
                        p.FileId = t.FileId;
                        p.FullDescription = t.FullDescription;
                        p.Price = t.Price;
                        p.Season = t.Season;
                        p.Size = t.Size;
                        p.ShortDescription = t.ShortDescription;
                        p.Name = t.Name;
                        p.ProductId = t.ProductId;
                        p.ProductStock = t.ProductStock;
                        p.UPC_code = t.UPC_code; 
                        p.myCurrency = t.tblCurrency.Symbol;
                        ViewBag.Files = DB.tblProductFiles.Where(u => u.ProductId.ToString() == Id).ToList();
                    }
                    //Get All roles
                    var UserRoles = this.GetRoles();
                    ViewBag.UserRoles = UserRoles;

                    return View(p);
                }
                else
                {
                    return RedirectToAction("Customer", "Products");
                }
            }
            catch
            {
                return View();
            }
        }

        #endregion

        #region Role
        private List<RoleUser> GetRoles()
        {
            if (Session == null)
            {

                List<RoleUser> lst = new List<RoleUser>();
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    var rs = (from c in DB.tblRoleUsers
                              where c.UserName == User.Identity.Name.ToString()
                              select new { c.RoleId });


                    foreach (var r in rs)
                    {
                        lst.Add(new RoleUser
                        {
                            RoleId = r.RoleId
                        });
                    }
                    Session["RoleId"] = lst;

                }
            }
            else if (Session["RoleId"] == null)
            {
                List<RoleUser> lst = new List<RoleUser>();
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    var roles = (from c in DB.tblRoleUsers
                                 where c.UserName == User.Identity.Name.ToString()
                                 select new { c.RoleId });

                    if (roles != null)
                    {
                        foreach (var r in roles)
                        {
                            lst.Add(new RoleUser
                            {
                                RoleId = r.RoleId,
                            });
                        }
                        Session["RoleId"] = lst;
                    }
                }
            }
            return (List<RoleUser>)Session["RoleId"];
        }
        #endregion

        #region Product Unit Type
        [HttpGet]
        [Authorize]
        public ActionResult ProductUnitType(string ProductId)
        {
            try
            {
                if (ProductId != null)
                {
                    Collection<ProductUnitType> myColl = new Collection<ProductUnitType>();
                    IEnumerable<ProductUnitType> items = null;
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        var C = (from cs in DB.tblProductUnitTypes
                                 join status in DB.tblStatus
                                 on cs.StatusId equals status.StatusId
                                 join c in DB.tblUnits
                                 on cs.UnitId equals c.UnitId
                                 where cs.StatusId != new Guid(Utilities.Status_Delete) &
                                 cs.ProductId == new Guid(ProductId)
                                 let Status = status.Name
                                 let Unit = c.Name
                                 let StatusId = status.StatusId
                                 select new { cs.ProductUnitTypeId, cs.Name, cs.UnitNamePurchase, cs.ISOCode, Unit, Status, StatusId, cs.CreationDate, cs.ProductId }).OrderBy(x => x.CreationDate);

                        foreach (var ele in C)
                        {
                            myColl.Add(new ProductUnitType()
                            {
                                ProductUnitTypeId = ele.ProductUnitTypeId,
                                Name = ele.Name,
                                UnitNamePurchase = ele.UnitNamePurchase,
                                ISOCode = ele.ISOCode,
                                myUnit = ele.Unit,
                                myStatus = ele.Status,
                                StatusId = ele.StatusId,
                                ProductId = ele.ProductId
                            });
                        }
                        items = myColl as IEnumerable<ProductUnitType>;
                        return View(items);
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult ProductUnitTypeAdd(string Id, string ProductId)
        {
            try
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {

                    if (Id != null)
                    {
                        var ProductUnitTypeId = Guid.Parse(Id);
                        DBLayer.tblProductUnitType tbl = (from g in DB.tblProductUnitTypes
                                                          where g.ProductUnitTypeId == ProductUnitTypeId
                                                          select g).SingleOrDefault();
                        ProductUnitType m = new ProductUnitType();
                        m.ProductUnitTypeId = tbl.ProductUnitTypeId;
                        m.Comment = tbl.Comment;
                        m.ComparableUnit = tbl.ComparableUnit;
                        m.Factor = tbl.Factor;
                        m.Height = tbl.Height;
                        m.ISOCode = tbl.ISOCode;
                        m.Length = tbl.Length;
                        m.Location = tbl.Location;
                        m.PackingType = tbl.PackingType;
                        m.ProductId = tbl.ProductId;
                        m.Rounding = tbl.Rounding;
                        m.SplitPurchase = tbl.SplitPurchase;
                        m.SplitSales = tbl.SplitSales;
                        m.UnitInPurchase = tbl.UnitInPurchase;
                        m.UnitInSales = tbl.UnitInSales;
                        m.UnitInStockControl = tbl.UnitInStockControl;
                        m.UnitNamePurchase = tbl.UnitNamePurchase;
                        m.VariableQty = tbl.VariableQty;
                        m.Volume = tbl.Volume;
                        m.Weight = tbl.Weight;
                        m.Width = tbl.Width;
                        m.UnitId = tbl.UnitId;
                        m.myUnit = tbl.UnitId.ToString();
                        m.Name = tbl.Name;
                        m.StatusId = tbl.StatusId;
                        m.ProductName = tbl.tblProduct.Name;
                        m.myStatus = tbl.StatusId.ToString();
                        return View(m);
                    }
                    else
                    {
                        ProductUnitType m = new ProductUnitType();
                        m.ProductId = new Guid(ProductId);
                        m.ProductName = DB.tblProducts.Where(u => u.ProductId == m.ProductId).FirstOrDefault().Name;   
                        m.myStatus = Utilities.Status_InActive;
                        return View(m);
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
                return View();
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Create Product UnitType")]
        public ActionResult ProductUnitTypeAdd(ProductUnitType m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        var tbl = new DBLayer.tblProductUnitType();
                        tbl.ProductUnitTypeId = Guid.NewGuid();
                        tbl.Comment = m.Comment;
                        tbl.ComparableUnit = m.ComparableUnit;
                        tbl.Factor = m.Factor;
                        tbl.Height = m.Height;
                        tbl.ISOCode = m.ISOCode;
                        tbl.Length = m.Length;
                        tbl.Location = m.Location;
                        tbl.PackingType = m.PackingType;
                        tbl.ProductId = m.ProductId;
                        tbl.Rounding = m.Rounding;
                        tbl.SplitPurchase = m.SplitPurchase;
                        tbl.SplitSales = m.SplitSales;
                        tbl.UnitInPurchase = m.UnitInPurchase;
                        tbl.UnitInSales = m.UnitInSales;
                        tbl.UnitInStockControl = m.UnitInStockControl;
                        tbl.UnitNamePurchase = m.UnitNamePurchase;
                        tbl.VariableQty = m.VariableQty;
                        tbl.Volume = m.Volume;
                        tbl.Weight = m.Weight;
                        tbl.Width = m.Width;
                        tbl.UnitId = m.UnitId;
                        tbl.Name = m.Name;
                        tbl.CreateBy = User.Identity.Name;
                        tbl.CreationDate = DateTime.Now;
                        tbl.StatusId = new Guid(m.myStatus);
                        tbl.IsVISMA = false;
                        DB.tblProductUnitTypes.Add(tbl);
                        DB.SaveChanges();
                        return RedirectToAction("ProductUnitType", "Products", new { ProductId = m.ProductId.ToString() });
                    }
                }
                else
                {
                    return View(m);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
                return View();
            }
        }


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Edit Product UnitType")]
        public ActionResult ProductUnitTypeEdit(ProductUnitType m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        var tbl = (from g in DB.tblProductUnitTypes
                                   where g.ProductUnitTypeId == m.ProductUnitTypeId
                                   select g).SingleOrDefault();
                        tbl.Comment = m.Comment;
                        tbl.ComparableUnit = m.ComparableUnit;
                        tbl.Factor = m.Factor;
                        tbl.Height = m.Height;
                        tbl.ISOCode = m.ISOCode;
                        tbl.Length = m.Length;
                        tbl.Location = m.Location;
                        tbl.PackingType = m.PackingType;
                        tbl.Rounding = m.Rounding;
                        tbl.SplitPurchase = m.SplitPurchase;
                        tbl.SplitSales = m.SplitSales;
                        tbl.UnitInPurchase = m.UnitInPurchase;
                        tbl.UnitInSales = m.UnitInSales;
                        tbl.UnitInStockControl = m.UnitInStockControl;
                        tbl.UnitNamePurchase = m.UnitNamePurchase;
                        tbl.VariableQty = m.VariableQty;
                        tbl.Volume = m.Volume;
                        tbl.Weight = m.Weight;
                        tbl.Width = m.Width;
                        tbl.UnitId = m.UnitId;
                        tbl.ModifyDate = DateTime.Now;
                        tbl.ModifyBy = User.Identity.Name;
                        tbl.Name = m.Name;
                        tbl.StatusId = new Guid(m.myStatus);
                        tbl.IsVISMA = false;
                        DB.SaveChanges();
                        return RedirectToAction("ProductUnitType", "Products", new { ProductId = m.ProductId.ToString() });
                    }
                }
                else
                {
                    return View(m);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
                return View();
            }
        }


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Delete Product UnitType")]
        public ActionResult Delete(ProductUnitType m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        var tbl = (from g in DB.tblProductUnitTypes
                                   where g.ProductUnitTypeId == m.ProductUnitTypeId
                                   select g).SingleOrDefault();
                        tbl.StatusId = new Guid(Utilities.Status_Delete);
                        tbl.ModifyDate = DateTime.Now;
                        tbl.ModifyBy = User.Identity.Name;
                        DB.SaveChanges();
                        return RedirectToAction("ProductUnitType", "Products", new { ProductId = m.ProductId.ToString() });
                    }
                }
                else
                {
                    return View(m);
                }
            }

            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
                return View();
            }

        }
        #endregion

        #region UpdateVisma
        private async Task<bool> UpdateArticle(DBLayer.tblProduct p, bool IsAdd)
        {
            using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
            {

                var obj = new Article();
                obj.ArticleNo = p.UPC_code;
                obj.Name = p.Name;
                obj.Price1 = Convert.ToInt16(p.Price);
                obj.PriceCalcMethodsNo = 0;
                obj.QuantityPerUnitPurchase = 0;
                obj.QuantityPerUnitSale = 0;
                obj.StockProfileNo = 0;
                obj.RegistrationDate = p.CreationDate;
                obj.StopDateOfferPrice = p.CreationDate.AddYears(1);
                obj.ValidTo = p.CreationDate.AddYears(1);
                obj.WarehouseNo = 0;
                obj.PostingTemplateNo = 0;
                if (p.MainGroupId == null || p.MainGroupId == Guid.Empty)
                    obj.MainGroupNo = 0;
                else
                    obj.MainGroupNo = Convert.ToInt32(DB.tblMainGroups.Where(u=>u.MainGroupId== p.MainGroupId).FirstOrDefault().MainGroupNo) ;

                if (p.IntermediateGroupId == null || p.IntermediateGroupId == Guid.Empty)
                    obj.IntermediateGroupNo = 0;
                else
                    obj.IntermediateGroupNo = Convert.ToInt32(DB.tblIntermediateGroups.Where(u => u.IntermediateGroupId == p.IntermediateGroupId).FirstOrDefault().IntermediateGroupNo); 

                if (p.SubGroupId == null || p.SubGroupId == Guid.Empty)
                    obj.SubGroupNo = 0;
                else
                    obj.SubGroupNo = Convert.ToInt32(DB.tblSubGroups.Where(u => u.SubGroupId == p.SubGroupId).FirstOrDefault().SubGroupNo);

                obj.InActiveYesNo = (p.StatusId.ToString() == Utilities.Status_Active) ? true : false;
                obj.WebshopLastAvailableInStock = 0;
                obj.WebshopArticleYesNo = true;
                obj.ShowOnWebYesNo = true;
                obj.MainStructureArtYesNo = true;
                obj.CountedYesNo = true;
                obj.PicturePath = "";
                obj.MemoFilePath = "";
                obj.POSArticleInfo = "";
                obj.EUFiguresNo = 0;
                obj.CountryOfOriginNo = 0;
                if (IsAdd)
                {
                    bool isUpdate = await this.AddArticle(obj);
                    return isUpdate;
                }
                else
                {
                    bool isUpdate = await this.UpdateArticle(obj);
                    return isUpdate;
                }

            }            
        }
        private async Task<bool> AddArticle(Article model)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var uri = new Uri(Utilities.URL + "articles");
                    var json = new JavaScriptSerializer().Serialize(model);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(uri, stringContent);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task<bool> UpdateArticle(Article model)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var json = new JavaScriptSerializer().Serialize(model);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpRequestMessage request = new HttpRequestMessage
                    {
                        Method = new HttpMethod("PATCH"),
                        RequestUri = new Uri(Utilities.URL + "articles/" + model.ArticleNo),
                        Content = stringContent,
                    };
                    var response = await client.SendAsync(request);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public ActionResult MultiProductAdd()
        {
            var p = new MultiProduct();
            return View(p);
        }

        #region UploadExcel
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Add Multiple Products")]
        [ValidateInput(false)]
        public async Task<ActionResult> MultiProductAdd(MultiProduct p, HttpPostedFileBase upload)
        {
            try
            {
                List<string> data = new List<string>();
                if (upload != null)
                {
                    if (upload.ContentType == "application/vnd.ms-excel" || upload.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        string filename = upload.FileName;
                        string targetpath = Server.MapPath("~/Doc/");
                        upload.SaveAs(targetpath + filename);
                        string pathToExcelFile = targetpath + filename;
                        var connectionString = "";
                        if (filename.EndsWith(".xls"))
                        {
                            connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", pathToExcelFile);
                        }
                        else if (filename.EndsWith(".xlsx"))
                        {

                            connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";", pathToExcelFile);
                        }

                        var adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connectionString);
                        var ds = new DataSet();

                        adapter.Fill(ds, "ExcelTable");
                        DataTable dtable = ds.Tables["ExcelTable"];

                        using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                        {
                            int d = Convert.ToInt32(DB.tblProducts.Max(x => x.DisplayOrder));
                            foreach (DataRow row in dtable.Rows)
                            {
                                if (!String.IsNullOrWhiteSpace(row[0].ToString()) && !String.IsNullOrWhiteSpace(row[1].ToString()))
                                {
                                    d = d + 1;
                                    var ProductId = Guid.NewGuid();
                                    var tbl = new DBLayer.tblProduct();
                                    tbl.ProductId = ProductId;
                                    tbl.UPC_code = row[0].ToString();
                                    tbl.style = row[1].ToString();
                                    tbl.Name = row[2].ToString();
                                    tbl.Colour = row[4].ToString();
                                    tbl.Size = row[5].ToString();
                                    tbl.Brand= row[9].ToString();
                                    tbl.Segment = row[10].ToString();
                                    tbl.Product = row[11].ToString();
                                    tbl.Year_Article_type= row[12].ToString();
                                    tbl.Out_Price = Convert.ToDecimal(row[13]);
                                    tbl.Price = Convert.ToDecimal(row[13]);
                                    tbl.In_Price = Convert.ToDecimal(row[14]);
                                    tbl.Supplier_price  = Convert.ToDecimal(row[15]);
                                    tbl.Cost_Price = Convert.ToDecimal(row[17]);
                                    tbl.DisplayOrder = d;
                                    tbl.StatusId = new Guid(Utilities.Status_Active);
                                    tbl.CreationDate = DateTime.Now;
                                    tbl.CreateBy = User.Identity.Name;
                                    tbl.SupplierId = p.SupplierId;
                                    DB.tblProducts.Add(tbl);
                                    DB.SaveChanges();
                                    //Update VISMA
                                    if (p.IsUpdateVISMA)
                                    {
                                        bool isUpdate = await this.UpdateArticle(tbl, true);
                                    }
                                }
                            }
                            //deleting excel file from folder  
                            if ((System.IO.File.Exists(pathToExcelFile)))
                            {
                                System.IO.File.Delete(pathToExcelFile);
                            }

                        }
                        return RedirectToAction("Index", "Products");
                    }
                    else
                    {
                        ViewBag.Error = "Kindly upload only Excel File.";
                        return View(p);
                    }
                }
                else
                {
                    ViewBag.Error = "Kindly upload only Excel File.";
                    return View(p);
                }
            }catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(new MultiProduct()) ;
            }
        }
        #endregion


        #region Stock Info Product
        [HttpGet]
        [Authorize]
        public ActionResult ProductStockInfo(ProductSearch m)
        {
            try
            {
                List<Product> myColl = new List<Product>();
                if (m.Search)
                {
                    if (m.page == 0)
                    {
                        m.page = 1;
                        myColl = this.GetProducts(m,  0, 500);
                    }
                    else
                    {
                        int start = (m.page - 1) * 500;
                        myColl = this.GetProducts(m,  start, 500);
                    }
                    m.count = myColl.Count();
                }

                m.Products = myColl;
                return View(m);
            }
            catch
            {
                return View();
            }
        }

        private List<Product> GetProducts(ProductSearch m, int start, int end)
        {
            var myColl = new List<Product>();
            using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
            {
                //Search by Brand
                if (string.IsNullOrWhiteSpace(m.ProductName) && string.IsNullOrWhiteSpace(m.UPC_code))
                {

                    var tblProduct = (from p in DB.tblProducts
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                      let Status = p.Name

                                      select new { p.ProductId, p.Name,p.ProductStock,  Status, p.StatusId, p.UPC_code,p.MaxStock, p.MinStock, p.UnitInStock, p.UnitOnOrder, p.UnitOnReminder, p.QtyManualReserved, p.QtyReserved }).OrderBy(x => x.Name).Skip(start).Take(end);
                    foreach (var ele in tblProduct)
                    {
                        myColl.Add(new Product()
                        {
                            ProductId = ele.ProductId,
                            Name = ele.Name,
                            UPC_code = ele.UPC_code,
                            myStatus = ele.Status,
                            StatusId = ele.StatusId,
                            MaxStock = ele.MaxStock,
                            MinStock = ele.MinStock,
                            UnitInStock = ele.UnitInStock,
                            UnitOnOrder =ele.UnitOnOrder,
                            UnitOnReminder = ele.UnitOnReminder,
                            QtyManualReserved =ele.QtyManualReserved,
                            QtyReserved = ele.QtyReserved,
                            ProductStock = ele.ProductStock
                        });
                    }
                }
                else if (!string.IsNullOrWhiteSpace(m.ProductName) && string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                      && (p.Name == m.ProductName || p.Name.Contains(m.ProductName))
                                      let Status = p.Name
                                      select new { p.ProductId, p.Name, p.ProductStock,Status, p.StatusId, p.UPC_code, p.MaxStock, p.MinStock, p.UnitInStock, p.UnitOnOrder, p.UnitOnReminder, p.QtyManualReserved, p.QtyReserved }).OrderBy(x => x.Name).Skip(start).Take(end);
                    foreach (var ele in tblProduct)
                    {
                        myColl.Add(new Product()
                        {
                            ProductId = ele.ProductId,
                            Name = ele.Name,
                            UPC_code = ele.UPC_code,
                            myStatus = ele.Status,
                            StatusId = ele.StatusId,
                            MaxStock = ele.MaxStock,
                            MinStock = ele.MinStock,
                            UnitInStock = ele.UnitInStock,
                            UnitOnOrder = ele.UnitOnOrder,
                            UnitOnReminder = ele.UnitOnReminder,
                            QtyManualReserved = ele.QtyManualReserved,
                            QtyReserved = ele.QtyReserved
                        });
                    }
                }
                else if (string.IsNullOrWhiteSpace(m.ProductName) && !string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                      && (p.UPC_code == m.UPC_code || p.UPC_code.Contains(m.UPC_code))
                                      let Status = p.Name
                                      select new { p.ProductId, p.Name, Status, p.ProductStock, p.StatusId, p.UPC_code, p.MaxStock, p.MinStock, p.UnitInStock, p.UnitOnOrder, p.UnitOnReminder, p.QtyManualReserved, p.QtyReserved }).OrderBy(x => x.Name).Skip(start).Take(end);
                    foreach (var ele in tblProduct)
                    {
                        myColl.Add(new Product()
                        {
                            ProductId = ele.ProductId,
                            Name = ele.Name,
                            UPC_code = ele.UPC_code,
                            myStatus = ele.Status,
                            StatusId = ele.StatusId,
                            MaxStock = ele.MaxStock,
                            MinStock = ele.MinStock,
                            UnitInStock = ele.UnitInStock,
                            UnitOnOrder = ele.UnitOnOrder,
                            UnitOnReminder = ele.UnitOnReminder,
                            QtyManualReserved = ele.QtyManualReserved,
                            QtyReserved = ele.QtyReserved,
                            ProductStock = ele.ProductStock
                        });
                    }
                }
                else if (!string.IsNullOrWhiteSpace(m.ProductName) && !string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (p.Name == m.ProductName || p.Name.Contains(m.ProductName))
                                     && (p.UPC_code == m.UPC_code || p.UPC_code.Contains(m.UPC_code))
                                      let Status = p.Name
                                      select new { p.ProductId, p.Name,p.ProductStock,  Status, p.StatusId, p.UPC_code, p.MaxStock, p.MinStock, p.UnitInStock, p.UnitOnOrder, p.UnitOnReminder, p.QtyManualReserved, p.QtyReserved }).OrderBy(x => x.Name).Skip(start).Take(end);
                    foreach (var ele in tblProduct)
                    {
                        myColl.Add(new Product()
                        {
                            ProductId = ele.ProductId,
                            Name = ele.Name,
                            UPC_code = ele.UPC_code,
                            myStatus = ele.Status,
                            StatusId = ele.StatusId,
                            MaxStock = ele.MaxStock,
                            MinStock = ele.MinStock,
                            UnitInStock = ele.UnitInStock,
                            UnitOnOrder = ele.UnitOnOrder,
                            UnitOnReminder = ele.UnitOnReminder,
                            QtyManualReserved = ele.QtyManualReserved,
                            QtyReserved = ele.QtyReserved,
                            ProductStock = ele.ProductStock 
                        });
                    }


                }
            }
            return myColl;
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Next")]
        public ActionResult ProductNext(ProductSearch m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    m.page = m.page + 1;
                    return RedirectToAction("ProductStockInfo", "Products", new { page = m.page, count = m.count, ProductName = m.ProductName, UPC_code = m.UPC_code, Search = true, });
                }
                else
                {
                    return View(m);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
                return View(m);
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Back")]
        public ActionResult ProductBack(ProductSearch m, FormCollection fc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (m.page > 0)
                        m.page = m.page - 1;
                    return RedirectToAction("ProductStockInfo", "Products", new {page = m.page, count = m.count, ProductName = m.ProductName, UPC_code = m.UPC_code, Search = true, });
                }
                else
                {
                    return View(m);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
                return View(m);
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Add Products")]
        public ActionResult ProductAdd(ProductSearch m)
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
                return View();
            }
        }

        #endregion

    }
}
