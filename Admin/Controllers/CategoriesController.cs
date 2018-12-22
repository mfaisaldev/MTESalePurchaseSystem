using Admin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class CategoriesController : Controller
    {
        #region Add Product
        private List<Product> GetProducts(ProductSearch m, string Id, int start, int end)
        {
            var myColl = new List<Product>();
            using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
            {
                //Search by Brand
                if (m.Supplier == Guid.Empty && m.Brand == Guid.Empty && string.IsNullOrWhiteSpace(m.ProductName) && string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join s in DB.tblStatus
                                      on p.StatusId equals s.StatusId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                      let Status = s.Name
                                      let StatusId = s.StatusId
                                      select new { p.ProductId, p.Name, Status, StatusId, p.UPC_code }).OrderBy(x => x.Name).Skip(start).Take(end);
                    foreach (var ele in tblProduct)
                    {
                        myColl.Add(new Product()
                        {
                            ProductId = ele.ProductId,
                            Name = ele.Name,
                            UPC_code = ele.UPC_code,
                            myStatus = ele.Status,
                            StatusId = ele.StatusId,
                            //IsAllow = DB.tblProductCategories.Where(u => u.CategoryId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true

                        });
                    }
                }
                else if (m.Supplier != Guid.Empty && m.Brand == Guid.Empty && string.IsNullOrWhiteSpace(m.ProductName) && string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join s in DB.tblStatus
                                      on p.StatusId equals s.StatusId
                                      join b in DB.tblProductSuppliers
                                      on p.ProductId equals b.ProductId
                                      where p.StatusId != new Guid(Utilities.Status_Delete) &&
                                      (b.SupplierId == m.Supplier)
                                      let Status = s.Name
                                      let StatusId = s.StatusId
                                      select new { p.ProductId, p.Name, Status, StatusId, p.UPC_code }).OrderBy(x => x.Name).Skip(start).Take(end);
                    foreach (var ele in tblProduct)
                    {
                        myColl.Add(new Product()
                        {
                            ProductId = ele.ProductId,
                            Name = ele.Name,
                            UPC_code = ele.UPC_code,
                            myStatus = ele.Status,
                            StatusId = ele.StatusId,
                            //IsAllow = DB.tblProductCategories.Where(u => u.CategoryId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true

                        });
                    }
                }
                else if (m.Supplier != Guid.Empty && m.Brand == Guid.Empty && !string.IsNullOrWhiteSpace(m.ProductName) && string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join s in DB.tblStatus
                                      on p.StatusId equals s.StatusId
                                      join b in DB.tblProductSuppliers
                                      on p.ProductId equals b.ProductId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (b.SupplierId == m.Supplier)
                                     && (p.Name == m.ProductName || p.Name.Contains(m.ProductName))
                                      let Status = s.Name
                                      let StatusId = s.StatusId
                                      select new { p.ProductId, p.Name, Status, StatusId, p.UPC_code }).OrderBy(x => x.Name).Skip(start).Take(end);
                    foreach (var ele in tblProduct)
                    {
                        myColl.Add(new Product()
                        {
                            ProductId = ele.ProductId,
                            Name = ele.Name,
                            myStatus = ele.Status,
                            UPC_code = ele.UPC_code,
                            StatusId = ele.StatusId,
                            //IsAllow = DB.tblProductCategories.Where(u => u.CategoryId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Supplier != Guid.Empty && m.Brand == Guid.Empty && string.IsNullOrWhiteSpace(m.ProductName) && !string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join s in DB.tblStatus
                                      on p.StatusId equals s.StatusId
                                      join b in DB.tblProductSuppliers
                                      on p.ProductId equals b.ProductId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (b.SupplierId == m.Supplier)
                                     && (p.UPC_code == m.UPC_code || p.Name.Contains(m.UPC_code))
                                      let Status = s.Name
                                      let StatusId = s.StatusId
                                      select new { p.ProductId, p.Name, Status, StatusId, p.UPC_code }).OrderBy(x => x.Name).Skip(start).Take(end);
                    foreach (var ele in tblProduct)
                    {
                        myColl.Add(new Product()
                        {
                            ProductId = ele.ProductId,
                            Name = ele.Name,
                            myStatus = ele.Status,
                            UPC_code = ele.UPC_code,
                            StatusId = ele.StatusId,
                            //IsAllow = DB.tblProductCategories.Where(u => u.CategoryId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Supplier != Guid.Empty && m.Brand == Guid.Empty && !string.IsNullOrWhiteSpace(m.ProductName) && !string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join s in DB.tblStatus
                                      on p.StatusId equals s.StatusId
                                      join b in DB.tblProductSuppliers
                                      on p.ProductId equals b.ProductId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (b.SupplierId == m.Supplier)
                                     && (p.Name == m.ProductName || p.Name.Contains(m.ProductName))
                                     && (p.UPC_code == m.UPC_code || p.Name.Contains(m.UPC_code))
                                      let Status = s.Name
                                      let StatusId = s.StatusId
                                      select new { p.ProductId, p.Name, Status, StatusId, p.UPC_code }).OrderBy(x => x.Name).Skip(start).Take(end);
                    foreach (var ele in tblProduct)
                    {
                        myColl.Add(new Product()
                        {
                            ProductId = ele.ProductId,
                            Name = ele.Name,
                            myStatus = ele.Status,
                            UPC_code = ele.UPC_code,
                            StatusId = ele.StatusId,
                            //IsAllow = DB.tblProductCategories.Where(u => u.CategoryId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Supplier != Guid.Empty && m.Brand != Guid.Empty && string.IsNullOrWhiteSpace(m.ProductName) && string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join s in DB.tblStatus
                                      on p.StatusId equals s.StatusId
                                      join b in DB.tblProductSuppliers
                                      on p.ProductId equals b.ProductId
                                      join c in DB.tblProductBrands
                                      on p.ProductId equals c.ProductId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (b.SupplierId == m.Supplier)
                                     && (c.BrandId == m.Brand)
                                      let Status = s.Name
                                      let StatusId = s.StatusId
                                      select new { p.ProductId, p.Name, Status, StatusId, p.UPC_code }).OrderBy(x => x.Name).Skip(start).Take(end);
                    foreach (var ele in tblProduct)
                    {
                        myColl.Add(new Product()
                        {
                            ProductId = ele.ProductId,
                            Name = ele.Name,
                            UPC_code = ele.UPC_code,
                            myStatus = ele.Status,
                            StatusId = ele.StatusId,
                            //IsAllow = DB.tblProductCategories.Where(u => u.CategoryId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Supplier != Guid.Empty && m.Brand != Guid.Empty && !string.IsNullOrWhiteSpace(m.ProductName) && string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join s in DB.tblStatus
                                      on p.StatusId equals s.StatusId
                                      join b in DB.tblProductSuppliers
                                      on p.ProductId equals b.ProductId
                                      join c in DB.tblProductBrands
                                      on p.ProductId equals c.ProductId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (b.SupplierId == m.Supplier)
                                     && (c.BrandId == m.Brand)
                                     && (p.Name == m.ProductName || p.Name.Contains(m.ProductName))
                                      let Status = s.Name
                                      let StatusId = s.StatusId
                                      select new { p.ProductId, p.Name, Status, StatusId, p.UPC_code }).OrderBy(x => x.Name).Skip(start).Take(end);
                    foreach (var ele in tblProduct)
                    {
                        myColl.Add(new Product()
                        {
                            ProductId = ele.ProductId,
                            Name = ele.Name,
                            UPC_code = ele.UPC_code,
                            myStatus = ele.Status,
                            StatusId = ele.StatusId,
                            //IsAllow = DB.tblProductCategories.Where(u => u.CategoryId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Supplier != Guid.Empty && m.Brand != Guid.Empty && string.IsNullOrWhiteSpace(m.ProductName) && !string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join s in DB.tblStatus
                                      on p.StatusId equals s.StatusId
                                      join b in DB.tblProductSuppliers
                                      on p.ProductId equals b.ProductId
                                      join c in DB.tblProductBrands
                                      on p.ProductId equals c.ProductId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (b.SupplierId == m.Supplier)
                                     && (c.BrandId == m.Brand)
                                     && (p.UPC_code == m.UPC_code || p.UPC_code.Contains(m.UPC_code))
                                      let Status = s.Name
                                      let StatusId = s.StatusId
                                      select new { p.ProductId, p.Name, Status, StatusId, p.UPC_code }).OrderBy(x => x.Name).Skip(start).Take(end);
                    foreach (var ele in tblProduct)
                    {
                        myColl.Add(new Product()
                        {
                            ProductId = ele.ProductId,
                            Name = ele.Name,
                            UPC_code = ele.UPC_code,
                            myStatus = ele.Status,
                            StatusId = ele.StatusId,
                            //IsAllow = DB.tblProductCategories.Where(u => u.CategoryId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Supplier != Guid.Empty && m.Brand != Guid.Empty && !string.IsNullOrWhiteSpace(m.ProductName) && !string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join s in DB.tblStatus
                                      on p.StatusId equals s.StatusId
                                      join b in DB.tblProductSuppliers
                                      on p.ProductId equals b.ProductId
                                      join c in DB.tblProductBrands
                                      on p.ProductId equals c.ProductId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (b.SupplierId == m.Supplier)
                                     && (c.BrandId == m.Brand)
                                     && (p.Name == m.ProductName || p.Name.Contains(m.ProductName))
                                     && (p.UPC_code == m.UPC_code || p.UPC_code.Contains(m.UPC_code))
                                      let Status = s.Name
                                      let StatusId = s.StatusId
                                      select new { p.ProductId, p.Name, Status, StatusId, p.UPC_code }).OrderBy(x => x.Name).Skip(start).Take(end);
                    foreach (var ele in tblProduct)
                    {
                        myColl.Add(new Product()
                        {
                            ProductId = ele.ProductId,
                            Name = ele.Name,
                            UPC_code = ele.UPC_code,
                            myStatus = ele.Status,
                            StatusId = ele.StatusId,
                            //IsAllow = DB.tblProductCategories.Where(u => u.CategoryId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Supplier == Guid.Empty && m.Brand != Guid.Empty && !string.IsNullOrWhiteSpace(m.ProductName) && string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join s in DB.tblStatus
                                      on p.StatusId equals s.StatusId
                                      join c in DB.tblProductBrands
                                      on p.ProductId equals c.ProductId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (c.BrandId == m.Brand)
                                     && (p.Name == m.ProductName || p.Name.Contains(m.ProductName))
                                      let Status = s.Name
                                      let StatusId = s.StatusId
                                      select new { p.ProductId, p.Name, Status, StatusId, p.UPC_code }).OrderBy(x => x.Name).Skip(start).Take(end);
                    foreach (var ele in tblProduct)
                    {
                        myColl.Add(new Product()
                        {
                            ProductId = ele.ProductId,
                            Name = ele.Name,
                            UPC_code = ele.UPC_code,
                            myStatus = ele.Status,
                            StatusId = ele.StatusId,
                            //IsAllow = DB.tblProductCategories.Where(u => u.CategoryId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Supplier == Guid.Empty && m.Brand != Guid.Empty && string.IsNullOrWhiteSpace(m.ProductName) && !string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join s in DB.tblStatus
                                      on p.StatusId equals s.StatusId
                                      join c in DB.tblProductBrands
                                      on p.ProductId equals c.ProductId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (c.BrandId == m.Brand)
                                     && (p.UPC_code == m.UPC_code || p.UPC_code.Contains(m.UPC_code))
                                      let Status = s.Name
                                      let StatusId = s.StatusId
                                      select new { p.ProductId, p.Name, Status, StatusId, p.UPC_code }).OrderBy(x => x.Name).Skip(start).Take(end);
                    foreach (var ele in tblProduct)
                    {
                        myColl.Add(new Product()
                        {
                            ProductId = ele.ProductId,
                            Name = ele.Name,
                            UPC_code = ele.UPC_code,
                            myStatus = ele.Status,
                            StatusId = ele.StatusId,
                            //IsAllow = DB.tblProductCategories.Where(u => u.CategoryId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Supplier == Guid.Empty && m.Brand != Guid.Empty && !string.IsNullOrWhiteSpace(m.ProductName) && !string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join s in DB.tblStatus
                                      on p.StatusId equals s.StatusId
                                      join c in DB.tblProductBrands
                                      on p.ProductId equals c.ProductId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (c.BrandId == m.Brand)
                                     && (p.Name == m.ProductName || p.Name.Contains(m.ProductName))
                                     && (p.UPC_code == m.UPC_code || p.UPC_code.Contains(m.UPC_code))
                                      let Status = s.Name
                                      let StatusId = s.StatusId
                                      select new { p.ProductId, p.Name, Status, StatusId, p.UPC_code }).OrderBy(x => x.Name).Skip(start).Take(end);
                    foreach (var ele in tblProduct)
                    {
                        myColl.Add(new Product()
                        {
                            ProductId = ele.ProductId,
                            Name = ele.Name,
                            UPC_code = ele.UPC_code,
                            myStatus = ele.Status,
                            StatusId = ele.StatusId,
                            //IsAllow = DB.tblProductCategories.Where(u => u.CategoryId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Supplier == Guid.Empty && m.Brand != Guid.Empty && string.IsNullOrWhiteSpace(m.ProductName) && string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join s in DB.tblStatus
                                      on p.StatusId equals s.StatusId
                                      join c in DB.tblProductBrands
                                      on p.ProductId equals c.ProductId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (c.BrandId == m.Brand)
                                      let Status = s.Name
                                      let StatusId = s.StatusId
                                      select new { p.ProductId, p.Name, Status, StatusId, p.UPC_code }).OrderBy(x => x.Name).Skip(start).Take(end);
                    foreach (var ele in tblProduct)
                    {
                        myColl.Add(new Product()
                        {
                            ProductId = ele.ProductId,
                            Name = ele.Name,
                            UPC_code = ele.UPC_code,
                            myStatus = ele.Status,
                            StatusId = ele.StatusId,
                            //IsAllow = DB.tblProductCategories.Where(u => u.CategoryId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Supplier == Guid.Empty && m.Brand == Guid.Empty && !string.IsNullOrWhiteSpace(m.ProductName) && string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join s in DB.tblStatus
                                      on p.StatusId equals s.StatusId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (p.Name == m.ProductName || p.Name.Contains(m.ProductName))
                                      let Status = s.Name
                                      let StatusId = s.StatusId
                                      select new { p.ProductId, p.Name, Status, StatusId, p.UPC_code }).OrderBy(x => x.Name).Skip(start).Take(end);
                    foreach (var ele in tblProduct)
                    {
                        myColl.Add(new Product()
                        {
                            ProductId = ele.ProductId,
                            Name = ele.Name,
                            UPC_code = ele.UPC_code,
                            myStatus = ele.Status,
                            StatusId = ele.StatusId,
                            //IsAllow = DB.tblProductCategories.Where(u => u.CategoryId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }

                }
                else if (m.Supplier == Guid.Empty && m.Brand == Guid.Empty && string.IsNullOrWhiteSpace(m.ProductName) && !string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join s in DB.tblStatus
                                      on p.StatusId equals s.StatusId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (p.UPC_code == m.UPC_code || p.UPC_code.Contains(m.UPC_code))
                                      let Status = s.Name
                                      let StatusId = s.StatusId
                                      select new { p.ProductId, p.Name, Status, StatusId, p.UPC_code }).OrderBy(x => x.Name).Skip(start).Take(end);
                    foreach (var ele in tblProduct)
                    {
                        myColl.Add(new Product()
                        {
                            ProductId = ele.ProductId,
                            Name = ele.Name,
                            UPC_code = ele.UPC_code,
                            myStatus = ele.Status,
                            StatusId = ele.StatusId,
                            //IsAllow = DB.tblProductCategories.Where(u => u.CategoryId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Supplier == Guid.Empty && m.Brand == Guid.Empty && !string.IsNullOrWhiteSpace(m.ProductName) && !string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join s in DB.tblStatus
                                      on p.StatusId equals s.StatusId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (p.Name == m.ProductName || p.Name.Contains(m.ProductName))
                                     && (p.UPC_code == m.UPC_code || p.UPC_code.Contains(m.UPC_code))
                                      let Status = s.Name
                                      let StatusId = s.StatusId
                                      select new { p.ProductId, p.Name, Status, StatusId, p.UPC_code }).OrderBy(x => x.Name).Skip(start).Take(end);
                    foreach (var ele in tblProduct)
                    {
                        myColl.Add(new Product()
                        {
                            ProductId = ele.ProductId,
                            Name = ele.Name,
                            UPC_code = ele.UPC_code,
                            myStatus = ele.Status,
                            StatusId = ele.StatusId,
                            //IsAllow = DB.tblProductCategories.Where(u => u.CategoryId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                var od = DB.tblProductCategories.Where(u => u.CategoryId.ToString() == Id).ToList();
                foreach (Product p in myColl)
                {
                    if (od.Where(u => u.ProductId == p.ProductId && u.CategoryId.ToString() == Id).FirstOrDefault() != null)
                        p.IsAllow = true;
                }
            }
            return myColl;
        }

        private void ProductSave(ProductSearch m, FormCollection fc)
        {
            List<Product> Products = new List<Product>();
            string[] chks = fc["item.IsAllow"].ToString().Split(',');
            string[] pId = fc["item.ProductId"].ToString().Split(',');
            int count = 0;
            for (int n = 0; n < chks.Length; n++)
            {
                if (chks[n] == "true")
                {
                    Product product = new Product();
                    product.ProductId = new Guid(pId[count]);
                    Products.Add(product);
                    n++;
                }
                count++;
            }

            using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
            {
                //Delete All record 
                List<DBLayer.tblProductCategory> listpc = DB.tblProductCategories.Where(x => x.CategoryId == m.Category).ToList();
                foreach (DBLayer.tblProductCategory obj in listpc)
                {
                    if (Products.Where(u => u.ProductId == obj.ProductId).FirstOrDefault() == null)
                    {
                        if (Array.IndexOf(pId, obj.ProductId.ToString()) > -1)
                            DB.tblProductCategories.Remove(obj);
                    }
                }
                    
                DB.SaveChanges();
                //Add Select Records
                foreach (Product p in Products)
                {
                    DBLayer.tblProductCategory tblpc = new DBLayer.tblProductCategory();
                    tblpc.ProductCategoryId = Guid.NewGuid();
                    tblpc.ProductId = p.ProductId;
                    tblpc.CategoryId = m.Category;
                    tblpc.CreateBy = User.Identity.Name;
                    tblpc.CreationDate = DateTime.Now;
                    DB.tblProductCategories.Add(tblpc);
                }
                DB.SaveChanges();
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Add Products")]
        public ActionResult ProductAdd(ProductSearch m, FormCollection fc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.ProductSave(m, fc);
                    return RedirectToAction("Index", "Categories");
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Next")]
        public ActionResult ProductNext(ProductSearch m, FormCollection fc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.ProductSave(m, fc);
                    m.page = m.page + 1;
                    return RedirectToAction("ProductSearch", "Categories", new { id = m.Category , page = m.page, count = m.count, ProductName = m.ProductName, UPC_code = m.UPC_code, Brand = m.Brand,  Supplier = m.Supplier, Search = true, });
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
                    this.ProductSave(m, fc);
                    if (m.page > 0)
                        m.page = m.page - 1;
                    return RedirectToAction("ProductSearch", "Categories", new { id = m.Category, page = m.page, count = m.count, ProductName = m.ProductName, UPC_code = m.UPC_code, Brand = m.Brand, Supplier = m.Supplier, Search = true, });
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

        [HttpGet]
        [Authorize]
        public ActionResult ProductSearch(ProductSearch m, string Id)
        {
            try
            {
                if (Id != null)
                {
                    List<Product> myColl = new List<Product>();
                    List<Brand> brand = new List<Brand>();
                    List<Supplier> supplier = new List<Supplier>();
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        brand.Add(new Brand()
                        {
                            BrandId = Guid.Empty,
                            Name = "All Brands"
                        });
                        var tblBrand = DB.tblBrands.Where(x => x.StatusId != new Guid(Utilities.Status_Delete));
                        foreach (var ele in tblBrand)
                        {
                            brand.Add(new Brand()
                            {
                                BrandId = ele.BrandId,
                                Name = ele.Name
                            });
                        }

                        ViewBag.Brands = brand;
                        
                        // Add Supplier
                        supplier.Add(new Supplier()
                        {
                            SupplierId = Guid.Empty,
                            Name = "All Suppliers"
                        });
                        var tblSupplier = DB.tblSuppliers.Where(x => x.StatusId != new Guid(Utilities.Status_Delete));
                        foreach (var ele in tblSupplier)
                        {
                            supplier.Add(new Supplier()
                            {
                                SupplierId = ele.SupplierId,
                                Name = ele.Name
                            });
                        }
                        ViewBag.Supplier = supplier;

                        if (m.Search)
                        {
                            if (m.page == 0)
                            {
                                m.page = 1;
                                myColl = this.GetProducts(m, Id, 0, 500);
                            }
                            else
                            {
                                int start = (m.page - 1) * 500;
                                myColl = this.GetProducts(m, Id, start, 500);
                            }
                            m.count = myColl.Count();
                        }
                        m.Products = myColl;
                        return View(m);
                    }
                }
                else
                {
                 return   RedirectToAction("Index", "Categories");
                }
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Categories
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            try
            {
                Collection<Category> myColl = new Collection<Category>();
                IEnumerable<Category> items = null;
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    var C = (from g in DB.tblCategories
                             join status in DB.tblStatus
                             on g.StatusId equals status.StatusId
                             where g.StatusId != new Guid(Utilities.Status_Delete)
                             let Status = status.Name
                             let StatusId = status.StatusId

                             select new { g.CategoryId, g.Name, g.DisplayOrder, Status, StatusId, g.FileId, g.ParentCategoryId  }).OrderBy(x => x.DisplayOrder);

                    foreach (var ele in C)
                    {
                        var ParentCategory = "";
                        if (!(ele.ParentCategoryId == null || ele.ParentCategoryId == Guid.Empty))
                            ParentCategory = DB.tblCategories.Where(u => u.CategoryId == ele.ParentCategoryId).FirstOrDefault().Name;

                        myColl.Add(new Category()
                        {
                            CategoryId = ele.CategoryId,
                            Name = ele.Name,
                            DisplayOrder = ele.DisplayOrder,
                            myStatus = ele.Status,
                            StatusId = ele.StatusId,
                            FileId = ele.FileId,
                            myParentCategory = ParentCategory
                        });
                    }
                    items = myColl as IEnumerable<Category>;
                    return View(items);
                }
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
                        Guid CategoryId = Guid.Parse(Id);
                        DBLayer.tblCategory tbl = (from g in DB.tblCategories
                                                where g.CategoryId == CategoryId
                                                   select g).SingleOrDefault();
                        Category m = new Category();
                        m.CategoryId = tbl.CategoryId;
                        m.DisplayOrder = tbl.DisplayOrder;
                        m.Name = tbl.Name;
                        m.Description = tbl.Description;
                        m.FileId = tbl.FileId;
                        m.myStatus = tbl.StatusId.ToString();
                        m.ParentCategoryId = tbl.ParentCategoryId; 
                        ViewBag.FileId = tbl.FileId;
                        return View(m);
                    }
                }
                else
                {
                    Category m = new Category();
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Create Category")]
        public ActionResult Create(Category m, HttpPostedFileBase upload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblCategory tbl = DB.tblCategories.Where(u => u.Name.ToLower() == m.Name.ToLower() && u.StatusId != new Guid(Utilities.Status_Delete)).FirstOrDefault();
                        if (tbl == null)
                        {
                            var NewFileId = Guid.NewGuid();
                            tbl = new DBLayer.tblCategory();
                            tbl.CategoryId = Guid.NewGuid();
                            tbl.Name = m.Name;
                            tbl.Description = m.Description;
                            tbl.DisplayOrder = m.DisplayOrder;
                            tbl.StatusId = new Guid(m.myStatus);
                            tbl.CreationDate = DateTime.Now;
                            tbl.CreateBy = User.Identity.Name;
                            tbl.ParentCategoryId = m.ParentCategoryId; 
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

                            DB.tblCategories.Add(tbl);
                            DB.SaveChanges();
                            return RedirectToAction("Index", "Categories");
                        }
                        else
                        {
                            ViewBag.Error = "Category Name Already Exists";
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Edit Category")]
        public ActionResult Edit(Category m, HttpPostedFileBase upload)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblCategory tblcheck = DB.tblCategories.Where(u => u.Name.ToLower() == m.Name.ToLower() && u.StatusId != new Guid(Utilities.Status_Delete) && u.CategoryId != m.CategoryId).FirstOrDefault();
                        if (tblcheck == null)
                        {
                            DBLayer.tblCategory tbl = (from g in DB.tblCategories
                                                       where g.CategoryId == m.CategoryId
                                                       select g).SingleOrDefault();
                            tbl.Name = m.Name;
                            tbl.DisplayOrder = m.DisplayOrder;
                            tbl.Description = m.Description;
                            tbl.StatusId = new Guid(m.myStatus);
                            tbl.ModifyDate = DateTime.Now;
                            tbl.ModifyBy = User.Identity.Name;
                            tbl.IsVISMA = false;
                            tbl.ParentCategoryId = m.ParentCategoryId;

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

                            DB.SaveChanges();
                            return RedirectToAction("Index", "Categories");
                        }
                        else
                        {
                            ViewBag.Error = "Category Name Already Exists";
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Delete Category")]
        public ActionResult Delete(Category m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblCategory tbl = (from g in DB.tblCategories
                                                   where g.CategoryId == m.CategoryId
                                                   select g).SingleOrDefault();
                        tbl.StatusId = new Guid(Utilities.Status_Delete);
                        tbl.ModifyDate = DateTime.Now;
                        tbl.ModifyBy = User.Identity.Name;
                        //Delete File
                        DBLayer.tblFile tblFile = (from g in DB.tblFiles
                                                   where g.FileId == m.FileId
                                                   select g).SingleOrDefault();
                        DB.tblFiles.Remove(tblFile);
                        DB.SaveChanges();
                        return RedirectToAction("Index", "Categories");
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
    }
}
