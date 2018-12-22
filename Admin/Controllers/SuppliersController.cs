using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Admin.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Admin.Controllers
{
    public class SuppliersController : Controller
    {
        private ApplicationUserManager _userManager;

        #region Add Product

        private List<Product> GetProducts(ProductSearch m, string Id, int start, int end)
        {
            var myColl = new List<Product>();
            using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
            {
                //Search by Brand
                if (m.Brand == Guid.Empty && m.Category == Guid.Empty && string.IsNullOrWhiteSpace(m.ProductName) && string.IsNullOrWhiteSpace(m.UPC_code))
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
                            //IsAllow = DB.tblProductSuppliers.Where(u => u.SupplierId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true

                        });
                    }
                }
                else if (m.Brand != Guid.Empty && m.Category == Guid.Empty && string.IsNullOrWhiteSpace(m.ProductName) && string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join s in DB.tblStatus
                                      on p.StatusId equals s.StatusId
                                      join b in DB.tblProductBrands
                                      on p.ProductId equals b.ProductId
                                      where p.StatusId != new Guid(Utilities.Status_Delete) &&
                                      (b.BrandId == m.Brand)
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
                            //IsAllow = DB.tblProductSuppliers.Where(u => u.SupplierId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true

                        });
                    }
                }
                else if (m.Brand != Guid.Empty && m.Category == Guid.Empty && !string.IsNullOrWhiteSpace(m.ProductName) && string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join s in DB.tblStatus
                                      on p.StatusId equals s.StatusId
                                      join b in DB.tblProductBrands
                                      on p.ProductId equals b.ProductId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (b.BrandId == m.Brand)
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
                            //IsAllow = DB.tblProductSuppliers.Where(u => u.SupplierId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Brand != Guid.Empty && m.Category == Guid.Empty && string.IsNullOrWhiteSpace(m.ProductName) && !string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join s in DB.tblStatus
                                      on p.StatusId equals s.StatusId
                                      join b in DB.tblProductBrands
                                      on p.ProductId equals b.ProductId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (b.BrandId == m.Brand)
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
                            //IsAllow = DB.tblProductSuppliers.Where(u => u.SupplierId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Brand != Guid.Empty && m.Category == Guid.Empty && !string.IsNullOrWhiteSpace(m.ProductName) && !string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join s in DB.tblStatus
                                      on p.StatusId equals s.StatusId
                                      join b in DB.tblProductBrands
                                      on p.ProductId equals b.ProductId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (b.BrandId == m.Brand)
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
                            //IsAllow = DB.tblProductSuppliers.Where(u => u.SupplierId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Brand != Guid.Empty && m.Category != Guid.Empty && string.IsNullOrWhiteSpace(m.ProductName) && string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join s in DB.tblStatus
                                      on p.StatusId equals s.StatusId
                                      join b in DB.tblProductBrands
                                      on p.ProductId equals b.ProductId
                                      join c in DB.tblProductCategories
                                      on p.ProductId equals c.ProductId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (b.BrandId == m.Brand)
                                     && (c.CategoryId == m.Category)
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
                            //IsAllow = DB.tblProductSuppliers.Where(u => u.SupplierId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Brand != Guid.Empty && m.Category != Guid.Empty && !string.IsNullOrWhiteSpace(m.ProductName) && string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join s in DB.tblStatus
                                      on p.StatusId equals s.StatusId
                                      join b in DB.tblProductBrands
                                      on p.ProductId equals b.ProductId
                                      join c in DB.tblProductCategories
                                      on p.ProductId equals c.ProductId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (b.BrandId == m.Brand)
                                     && (c.CategoryId == m.Category)
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
                            //IsAllow = DB.tblProductSuppliers.Where(u => u.SupplierId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Brand != Guid.Empty && m.Category != Guid.Empty && string.IsNullOrWhiteSpace(m.ProductName) && !string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join s in DB.tblStatus
                                      on p.StatusId equals s.StatusId
                                      join b in DB.tblProductBrands
                                      on p.ProductId equals b.ProductId
                                      join c in DB.tblProductCategories
                                      on p.ProductId equals c.ProductId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (b.BrandId == m.Brand)
                                     && (c.CategoryId == m.Category)
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
                            //IsAllow = DB.tblProductSuppliers.Where(u => u.SupplierId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Brand != Guid.Empty && m.Category != Guid.Empty && !string.IsNullOrWhiteSpace(m.ProductName) && !string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join s in DB.tblStatus
                                      on p.StatusId equals s.StatusId
                                      join b in DB.tblProductBrands
                                      on p.ProductId equals b.ProductId
                                      join c in DB.tblProductCategories
                                      on p.ProductId equals c.ProductId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (b.BrandId == m.Brand)
                                     && (c.CategoryId == m.Category)
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
                            //IsAllow = DB.tblProductSuppliers.Where(u => u.SupplierId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Brand == Guid.Empty && m.Category != Guid.Empty && !string.IsNullOrWhiteSpace(m.ProductName) && string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join s in DB.tblStatus
                                      on p.StatusId equals s.StatusId
                                      join c in DB.tblProductCategories
                                      on p.ProductId equals c.ProductId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (c.CategoryId == m.Category)
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
                            //IsAllow = DB.tblProductSuppliers.Where(u => u.SupplierId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Brand == Guid.Empty && m.Category != Guid.Empty && string.IsNullOrWhiteSpace(m.ProductName) && !string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join s in DB.tblStatus
                                      on p.StatusId equals s.StatusId
                                      join c in DB.tblProductCategories
                                      on p.ProductId equals c.ProductId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (c.CategoryId == m.Category)
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
                            //IsAllow = DB.tblProductSuppliers.Where(u => u.SupplierId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Brand == Guid.Empty && m.Category != Guid.Empty && !string.IsNullOrWhiteSpace(m.ProductName) && !string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join s in DB.tblStatus
                                      on p.StatusId equals s.StatusId
                                      join c in DB.tblProductCategories
                                      on p.ProductId equals c.ProductId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (c.CategoryId == m.Category)
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
                            //IsAllow = DB.tblProductSuppliers.Where(u => u.SupplierId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Brand == Guid.Empty && m.Category != Guid.Empty && string.IsNullOrWhiteSpace(m.ProductName) && string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join s in DB.tblStatus
                                      on p.StatusId equals s.StatusId
                                      join c in DB.tblProductCategories
                                      on p.ProductId equals c.ProductId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (c.CategoryId == m.Category)
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
                            //IsAllow = DB.tblProductSuppliers.Where(u => u.SupplierId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Brand == Guid.Empty && m.Category == Guid.Empty && !string.IsNullOrWhiteSpace(m.ProductName) && string.IsNullOrWhiteSpace(m.UPC_code))
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
                            //IsAllow = DB.tblProductSuppliers.Where(u => u.SupplierId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }

                }
                else if (m.Brand == Guid.Empty && m.Category == Guid.Empty && string.IsNullOrWhiteSpace(m.ProductName) && !string.IsNullOrWhiteSpace(m.UPC_code))
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
                            //IsAllow = DB.tblProductSuppliers.Where(u => u.SupplierId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Brand == Guid.Empty && m.Category == Guid.Empty && !string.IsNullOrWhiteSpace(m.ProductName) && !string.IsNullOrWhiteSpace(m.UPC_code))
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
                            //IsAllow = DB.tblProductSuppliers.Where(u => u.SupplierId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }

                }
                var od = DB.tblProductSuppliers.Where(u => u.SupplierId.ToString() == Id).ToList();
                foreach (Product p in myColl)
                {
                    if (od.Where(u => u.ProductId == p.ProductId && u.SupplierId.ToString() == Id).FirstOrDefault() != null)
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
                List<DBLayer.tblProductSupplier> listpc = DB.tblProductSuppliers.Where(x => x.SupplierId == m.Supplier).ToList();
                foreach (DBLayer.tblProductSupplier obj in listpc)
                {
                    if (Products.Where(u => u.ProductId == obj.ProductId).FirstOrDefault() == null)
                    {
                        if (Array.IndexOf(pId, obj.ProductId.ToString()) > -1)
                            DB.tblProductSuppliers.Remove(obj);
                    }
                }
                   
                DB.SaveChanges();
                //Add Select Records
                foreach (Product p in Products)
                {
                    DBLayer.tblProductSupplier tblpc = new DBLayer.tblProductSupplier();
                    tblpc.ProductSupplierId = Guid.NewGuid();
                    tblpc.ProductId = p.ProductId;
                    tblpc.SupplierId = m.Supplier;
                    tblpc.CreateBy = User.Identity.Name;
                    tblpc.CreationDate = DateTime.Now;
                    DB.tblProductSuppliers.Add(tblpc);
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
                    return RedirectToAction("Index", "Suppliers");
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
                    return RedirectToAction("ProductSearch", "Suppliers", new { id = m.Supplier, page = m.page, count = m.count, ProductName = m.ProductName, UPC_code = m.UPC_code, Brand = m.Brand, Category = m.Category, Search = true, });
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
                    return RedirectToAction("ProductSearch", "Suppliers", new { id = m.Supplier , page = m.page, count = m.count, ProductName = m.ProductName, UPC_code = m.UPC_code, Brand = m.Brand, Category = m.Category,  Search = true, });
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
                    List<Category> category = new List<Category>();
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        // Add Brand
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
                        ViewBag.Brand = brand;

                        // Add Category
                        category.Add(new Category()
                        {
                            CategoryId = Guid.Empty,
                            Name = "All Categories"
                        });
                        var tblCategory = DB.tblCategories.Where(x => x.StatusId != new Guid(Utilities.Status_Delete));
                        foreach (var ele in tblCategory)
                        {
                            category.Add(new Category()
                            {
                                CategoryId = ele.CategoryId,
                                Name = ele.Name
                            });
                        }
                        ViewBag.Category = category;
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
                    return RedirectToAction("Index", "Suppliers");
                }
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Supplier
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            try
            {
                Collection<Supplier> myColl = new Collection<Supplier>();
                IEnumerable<Supplier> items = null;
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    var C = (from g in DB.tblSuppliers
                             join status in DB.tblStatus
                             on g.StatusId equals status.StatusId
                             where g.StatusId != new Guid(Utilities.Status_Delete)
                             let Status = status.Name
                             let StatusId = status.StatusId
                             select new { g.SupplierId, g.Name, g.Email, g.Phone, Status, StatusId, g.FileId }).OrderBy(x => x.Name);

                    foreach (var ele in C)
                    {
                        myColl.Add(new Supplier()
                        {
                            SupplierId = ele.SupplierId,
                            Name = ele.Name,
                            Email = ele.Email,
                            Phone = ele.Phone,
                            myStatus = ele.Status,
                            StatusId = ele.StatusId,
                            FileId = ele.FileId
                        });
                    }
                    items = myColl as IEnumerable<Supplier>;
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
                        Guid SupplierId = Guid.Parse(Id);
                        DBLayer.tblSupplier tbl = (from g in DB.tblSuppliers
                                                where g.SupplierId == SupplierId
                                                select g).SingleOrDefault();
                        Supplier m = new Supplier();
                        m.SupplierId = tbl.SupplierId;
                        m.Name = tbl.Name;
                        m.Address1 = tbl.Address1;
                        m.Address2 = tbl.Address2;
                        m.BankAccount = tbl.BankAccount;
                        m.BankName = tbl.BankName;
                        m.City = tbl.City;
                        m.Contact = tbl.Contact;
                        m.CountryId = tbl.CountryId;
                        m.CreditLimit = tbl.CreditLimit;
                        m.CurrencyId = tbl.CurrencyId;
                        m.Email = tbl.Email;
                        m.IBAN = tbl.IBAN;
                        m.Kommune = tbl.Kommune;
                        m.myCountry = tbl.tblCountry.Name;
                        m.myCurrency = tbl.tblCurrency.Name;
                        m.Phone = tbl.Phone;
                        m.PostAccount = tbl.PostAccount;
                        m.PostOffice = tbl.PostOffice;
                        m.RegistrationDate = tbl.RegistrationDate;
                        m.StatusId = tbl.StatusId;
                        m.SwiftCode = tbl.SwiftCode;
                        m.Telefax = tbl.Telefax;
                        m.FileId = tbl.FileId;
                        m.myStatus = tbl.StatusId.ToString();
                        m.EmployeeId = tbl.EmployeeId;
                        ViewBag.FileId = tbl.FileId;
                        return View(m);
                    }
                }
                else
                {
                    Supplier m = new Supplier();
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblCustomer tbl = (from g in DB.tblCustomers 
                                                   where g.UserName  == User.Identity.Name 
                                                   select g).SingleOrDefault();
                        m.CurrencyId = tbl.CurrencyId;
                        m.CountryId = new Guid(tbl.CountryId.Value.ToString());
                        m.StatusId = new Guid(Utilities.Status_Online);
                        m.myStatus = Utilities.Status_Online;
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Create Supplier")]
        public async System.Threading.Tasks.Task<ActionResult> Create(Supplier m, HttpPostedFileBase upload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblSupplier tbl = DB.tblSuppliers.Where(u => u.Name.ToLower() == m.Name.ToLower() && u.StatusId != new Guid(Utilities.Status_Delete)).FirstOrDefault();
                        if (tbl == null)
                        {
                            var CustomerId = Guid.NewGuid();
                            var user = new ApplicationUser()
                            {
                                UserName = m.Email,
                                Email = m.Email,
                                CustomerId = CustomerId,
                                StatusId = new Guid(m.myStatus)
                            };
                            var result = await UserManager.CreateAsync(user, m.Password);
                            if (result.Succeeded)
                            {
                                // Add Customer
                                DBLayer.tblCustomer t;
                                t = new DBLayer.tblCustomer();
                                t.Address1 = m.Address1;
                                t.Address2 = m.Address2;
                                t.BankAccount = m.BankAccount;
                                t.City = m.City;
                                t.ContactNoConfirmOrder = m.Phone;
                                t.CountryId = m.CountryId;
                                t.CreateBy = User.Identity.Name;
                                t.CreationDate = DateTime.Now;
                                t.CreditLimit = m.CreditLimit;
                                t.CustomerId = CustomerId;
                                t.Email = m.Email;
                                t.IBAN = m.IBAN;
                                t.IsVISMA = m.IsVISMA;
                                t.Kommune = m.Kommune;
                                t.Name = m.Name;
                                t.OrganizationName = "";
                                t.OrganizationNumber = "";
                                t.Phone = m.Phone;
                                t.PostOffice = m.PostOffice;
                                t.SwiftCode = m.SwiftCode;
                                t.StatusId = new Guid(m.myStatus);
                                t.UserName = m.Email;
                                t.CurrencyId = m.CurrencyId;
                                t.IsVISMA = false;
                                t.IsUser = true;
                                DB.tblCustomers.Add(t);

                                //Add Role
                                DBLayer.tblRoleUser tblru = new DBLayer.tblRoleUser();
                                tblru.RoleUserId = Guid.NewGuid();
                                tblru.RoleId = new Guid(Utilities.Role_Supplier);
                                tblru.UserName = m.Email;
                                tblru.CreateBy = User.Identity.Name;
                                tblru.CreationDate = DateTime.Now;
                                DB.tblRoleUsers.Add(tblru);
                                // Add Supplier
                                var NewFileId = Guid.NewGuid();
                                tbl = new DBLayer.tblSupplier();
                                tbl.SupplierId = Guid.NewGuid();
                                tbl.Name = m.Name;
                                tbl.IsVISMA = false;
                                tbl.StatusId = new Guid(m.myStatus);
                                tbl.CreationDate = DateTime.Now;
                                tbl.CreateBy = User.Identity.Name;
                                tbl.Address1 = m.Address1;
                                tbl.Address2 = m.Address2;
                                tbl.BankAccount = m.BankAccount;
                                tbl.BankName = m.BankName;
                                tbl.City = m.City;
                                tbl.Contact = m.Contact;
                                tbl.CountryId = m.CountryId;
                                tbl.CreditLimit = m.CreditLimit;
                                tbl.CurrencyId = m.CurrencyId;
                                tbl.Email = m.Email;
                                tbl.IBAN = m.IBAN;
                                tbl.Kommune = m.Kommune;
                                tbl.Phone = m.Phone;
                                tbl.PostAccount = m.PostAccount;
                                tbl.PostOffice = m.PostOffice;
                                tbl.RegistrationDate = m.RegistrationDate;
                                tbl.SwiftCode = m.SwiftCode;
                                tbl.Telefax = m.Telefax;
                                tbl.UserName = m.Email;
                                tbl.EmployeeId = m.EmployeeId;
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
                                    t.FileId = NewFileId; 
                                }
                                var SupplierNo = await this.UpdateSuppliers(tbl);
                                tbl.SupplierNo = SupplierNo;
                                DB.tblSuppliers.Add(tbl);
                                DB.SaveChanges();
                                if (SupplierNo>0)
                                    return RedirectToAction("Index", "Suppliers");
                                else
                                {
                                    ViewBag.Error = "Records is successfull update in B2B but unable to update VISMA";
                                    return View(m);
                                }
                            }
                            else
                            {
                                ViewBag.Error = "Email Already Exists Or Invalid Password ";
                                return View(m);
                            }
                        }
                        else
                        {
                            ViewBag.Error = "Supplier Name Already Exists";
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

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Edit Supplier")]
        public async System.Threading.Tasks.Task<ActionResult> Edit(Supplier m, HttpPostedFileBase upload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblSupplier tblcheck = DB.tblSuppliers.Where(u => u.Name.ToLower() == m.Name.ToLower() && u.StatusId != new Guid(Utilities.Status_Delete) && u.SupplierId != m.SupplierId).FirstOrDefault();
                        if (tblcheck == null)
                        {
                            DBLayer.tblSupplier tbl = (from g in DB.tblSuppliers
                                                    where g.SupplierId == m.SupplierId
                                                    select g).SingleOrDefault();
                            tbl.Name = m.Name;
                            tbl.StatusId = new Guid(m.myStatus);
                            tbl.ModifyDate = DateTime.Now;
                            tbl.ModifyBy = User.Identity.Name;
                            tbl.IsVISMA = false;
                            tbl.Address1 = m.Address1;
                            tbl.Address2 = m.Address2;
                            tbl.BankAccount = m.BankAccount;
                            tbl.BankName = m.BankName;
                            tbl.City = m.City;
                            tbl.Contact = m.Contact;
                          tbl.CountryId = m.CountryId;
                            tbl.CreditLimit = m.CreditLimit;
                            tbl.CurrencyId = m.CurrencyId;
                            tbl.Email = m.Email;
                            tbl.IBAN = m.IBAN;
                            tbl.Kommune = m.Kommune;
                            tbl.Phone = m.Phone;
                            tbl.PostAccount = m.PostAccount;
                            tbl.PostOffice = m.PostOffice;
                            tbl.RegistrationDate = m.RegistrationDate;
                            tbl.SwiftCode = m.SwiftCode;
                            tbl.Telefax = m.Telefax;
                            tbl.EmployeeId = m.EmployeeId;

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

                            DBLayer.tblCustomer t = (from g in DB.tblCustomers
                                                     where g.UserName == tbl.UserName
                                                     select g).SingleOrDefault();
                            if (t != null)
                            {
                                t.Address1 = m.Address1;
                                t.Address2 = m.Address2;
                                t.BankAccount = m.BankAccount;
                                t.City = m.City;
                                t.ContactNoConfirmOrder = m.Phone;
                                t.CountryId = m.CountryId;
                                t.CreditLimit = m.CreditLimit;
                                t.Email = m.Email;
                                t.IBAN = m.IBAN;
                                t.IsVISMA = m.IsVISMA;
                                t.Kommune = m.Kommune;
                                t.Name = m.Name;
                                t.Phone = m.Phone;
                                t.PostOffice = m.PostOffice;
                                t.SwiftCode = m.SwiftCode;
                                t.StatusId = new Guid(m.myStatus);
                                t.UserName = m.Email;
                                t.IsUser = true;
                                t.ModifyDate = DateTime.Now;
                                t.ModifyBy = User.Identity.Name;
                                t.CurrencyId = m.CurrencyId;
                            }
                            var SupplierNo = await this.UpdateSuppliers(tbl);
                            tbl.SupplierNo = SupplierNo;
                            DB.SaveChanges();
                            if (SupplierNo > 0)
                                return RedirectToAction("Index", "Suppliers");
                            else
                            {
                                ViewBag.Error = "Records is successfull update in B2B but unable to update VISMA";
                                return View(m);
                            }
                        }
                        else
                        {
                            ViewBag.Error = "Supplier Name Already Exists";
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Delete Supplier")]
        public ActionResult Delete(Supplier m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblSupplier tbl = (from g in DB.tblSuppliers
                                                where g.SupplierId == m.SupplierId
                                                select g).SingleOrDefault();
                        tbl.StatusId = new Guid(Utilities.Status_Delete);
                        tbl.ModifyDate = DateTime.Now;
                        tbl.ModifyBy = User.Identity.Name;
                        //Delete File
                        DBLayer.tblFile tblFile = (from g in DB.tblFiles
                                                   where g.FileId == m.FileId
                                                   select g).SingleOrDefault();
                        if (tblFile != null)
                            DB.tblFiles.Remove(tblFile);

                        var t = (from c in DB.tblCustomers
                                                   where c.UserName == tbl.UserName 
                                 select c).SingleOrDefault();
                        if(t!=null)
                        {
                            t.StatusId = new Guid(Utilities.Status_Delete);
                            t.ModifyDate = DateTime.Now;
                            t.ModifyBy = User.Identity.Name;
                        }

                        var tblUser = (from g in DB.AspNetUsers 
                                                   where g.UserName == tbl.UserName
                                       select g).SingleOrDefault();
                        if (tblUser != null)
                            DB.AspNetUsers.Remove(tblUser);

                        DB.SaveChanges();
                        return RedirectToAction("Index", "Suppliers");
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
        private async Task<int> UpdateSuppliers(DBLayer.tblSupplier c)
        {
            try
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    var obj = new vSupplier();
                    obj.Name = c.Name;
                    obj.Address1 = c.Address1;
                    obj.EmailAddress = c.Email;
                    obj.Address2 = c.Address2;
                    obj.PostOffice = c.PostOffice;
                    obj.Telephone = c.Phone;
                    obj.InActiveYesNo = (c.StatusId.ToString() == Utilities.Status_Active) ? true : false;
                    obj.Telefax = c.Telefax;
                    obj.BankAccount = c.BankAccount;
                    obj.BankAccount = c.BankName;
                    obj.Address3 = c.City;
                    obj.CreditLimit = c.CreditLimit;
                    obj.IBAN = c.IBAN;
                    obj.PostAccount = c.PostAccount;
                    obj.SwiftCodeNo = Convert.ToInt32(c.SwiftCode);
                    obj.FormProfileSuppNo = 1;
                    obj.SortName = c.Name;
                    obj.SupplierGrpNo = 0;
                    obj.SupplierProfileNo = 1;
                    obj.WareHouseNo = 0;
                    obj.GLAccPay = 2400;
                    obj.RemittanceProfileNo = 1;
                    obj.SupplierNo = c.SupplierNo; 
                    if (c.EmployeeId == null)
                        obj.EmployeeNo = 0;// EmployeeId
                    else
                        obj.EmployeeNo = Convert.ToInt32(DB.tblEmployees.Where(u => u.EmployeeId == c.EmployeeId).FirstOrDefault().EmployeeNo);
                    if (c.SupplierNo == 0)
                        return await this.AddSupplier(obj);
                    else
                        return await this.UpdateSupplier(obj);
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        private async Task<int> AddSupplier(vSupplier model)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var uri = new Uri(Utilities.URL + "suppliers");
                    var json = new JavaScriptSerializer().Serialize(model);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(uri, stringContent);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var content = JObject.Parse(await response.Content.ReadAsStringAsync());
                       if(content["SupplierNo"] is JValue)
                        {
                            return (int)content["SupplierNo"];
                        }else
                            return 0;
                    }
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        private async Task<int> UpdateSupplier(vSupplier model)
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
                        RequestUri = new Uri(Utilities.URL + "suppliers/" + model.SupplierNo),
                        Content = stringContent,
                    };
                    var response = await client.SendAsync(request);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        return model.SupplierNo;
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        #endregion
    }
}