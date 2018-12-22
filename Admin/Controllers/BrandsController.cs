using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin.Models;
namespace Admin.Controllers
{
    public class BrandsController : Controller
    {
        #region Add Product

        [HttpGet]
        [Authorize]
        public ActionResult ProductSearch(ProductSearch m, string Id)
        {
            try
            {
                if (Id != null)
                {
                    List<Product> myColl = new List<Product>();
                    List<Supplier> supplier = new List<Supplier>();
                    List<Category> category = new List<Category>();
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
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
                    return RedirectToAction("Index", "Brands");
                }
            }
            catch
            {
                return View();
            }
        }

        private List<Product> GetProducts(ProductSearch m, string Id, int start, int end)
        {
            var myColl = new List<Product>();
            using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
            {
                //Search by Brand
                if (m.Supplier == Guid.Empty && m.Category == Guid.Empty && string.IsNullOrWhiteSpace(m.ProductName) && string.IsNullOrWhiteSpace(m.UPC_code))
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
                            //IsAllow = DB.tblProductBrands.Where(u => u.BrandId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true

                        });
                    }
                }
                else if (m.Supplier != Guid.Empty && m.Category == Guid.Empty && string.IsNullOrWhiteSpace(m.ProductName) && string.IsNullOrWhiteSpace(m.UPC_code))
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
                            //IsAllow = DB.tblProductBrands.Where(u => u.BrandId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true

                        });
                    }
                }
                else if (m.Supplier != Guid.Empty && m.Category == Guid.Empty && !string.IsNullOrWhiteSpace(m.ProductName) && string.IsNullOrWhiteSpace(m.UPC_code))
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
                            //IsAllow = DB.tblProductBrands.Where(u => u.BrandId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Supplier != Guid.Empty && m.Category == Guid.Empty && string.IsNullOrWhiteSpace(m.ProductName) && !string.IsNullOrWhiteSpace(m.UPC_code))
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
                            //IsAllow = DB.tblProductBrands.Where(u => u.BrandId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Supplier != Guid.Empty && m.Category == Guid.Empty && !string.IsNullOrWhiteSpace(m.ProductName) && !string.IsNullOrWhiteSpace(m.UPC_code))
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
                            //IsAllow = DB.tblProductBrands.Where(u => u.BrandId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Supplier != Guid.Empty && m.Category != Guid.Empty && string.IsNullOrWhiteSpace(m.ProductName) && string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join s in DB.tblStatus
                                      on p.StatusId equals s.StatusId
                                      join b in DB.tblProductSuppliers
                                      on p.ProductId equals b.ProductId
                                      join c in DB.tblProductCategories
                                      on p.ProductId equals c.ProductId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (b.SupplierId == m.Supplier)
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
                            //IsAllow = DB.tblProductBrands.Where(u => u.BrandId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Supplier != Guid.Empty && m.Category != Guid.Empty && !string.IsNullOrWhiteSpace(m.ProductName) && string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join s in DB.tblStatus
                                      on p.StatusId equals s.StatusId
                                      join b in DB.tblProductSuppliers
                                      on p.ProductId equals b.ProductId
                                      join c in DB.tblProductCategories
                                      on p.ProductId equals c.ProductId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (b.SupplierId == m.Supplier)
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
                            //IsAllow = DB.tblProductBrands.Where(u => u.BrandId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Supplier != Guid.Empty && m.Category != Guid.Empty && string.IsNullOrWhiteSpace(m.ProductName) && !string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join s in DB.tblStatus
                                      on p.StatusId equals s.StatusId
                                      join b in DB.tblProductSuppliers
                                      on p.ProductId equals b.ProductId
                                      join c in DB.tblProductCategories
                                      on p.ProductId equals c.ProductId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (b.SupplierId == m.Supplier)
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
                            //IsAllow = DB.tblProductBrands.Where(u => u.BrandId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Supplier != Guid.Empty && m.Category != Guid.Empty && !string.IsNullOrWhiteSpace(m.ProductName) && !string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join s in DB.tblStatus
                                      on p.StatusId equals s.StatusId
                                      join b in DB.tblProductSuppliers
                                      on p.ProductId equals b.ProductId
                                      join c in DB.tblProductCategories
                                      on p.ProductId equals c.ProductId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (b.SupplierId == m.Supplier)
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
                            //IsAllow = DB.tblProductBrands.Where(u => u.BrandId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Supplier == Guid.Empty && m.Category != Guid.Empty && !string.IsNullOrWhiteSpace(m.ProductName) && string.IsNullOrWhiteSpace(m.UPC_code))
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
                            //IsAllow = DB.tblProductBrands.Where(u => u.BrandId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Supplier == Guid.Empty && m.Category != Guid.Empty && string.IsNullOrWhiteSpace(m.ProductName) && !string.IsNullOrWhiteSpace(m.UPC_code))
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
                            //IsAllow = DB.tblProductBrands.Where(u => u.BrandId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Supplier == Guid.Empty && m.Category != Guid.Empty && !string.IsNullOrWhiteSpace(m.ProductName) && !string.IsNullOrWhiteSpace(m.UPC_code))
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
                            //IsAllow = DB.tblProductBrands.Where(u => u.BrandId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Supplier == Guid.Empty && m.Category != Guid.Empty && string.IsNullOrWhiteSpace(m.ProductName) && string.IsNullOrWhiteSpace(m.UPC_code))
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
                            //IsAllow = DB.tblProductBrands.Where(u => u.BrandId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Supplier == Guid.Empty && m.Category == Guid.Empty && !string.IsNullOrWhiteSpace(m.ProductName) && string.IsNullOrWhiteSpace(m.UPC_code))
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
                            //IsAllow = DB.tblProductBrands.Where(u => u.BrandId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }

                }
                else if (m.Supplier == Guid.Empty && m.Category == Guid.Empty && string.IsNullOrWhiteSpace(m.ProductName) && !string.IsNullOrWhiteSpace(m.UPC_code))
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
                            //IsAllow = DB.tblProductBrands.Where(u => u.BrandId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Supplier == Guid.Empty && m.Category == Guid.Empty && !string.IsNullOrWhiteSpace(m.ProductName) && !string.IsNullOrWhiteSpace(m.UPC_code))
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
                            //IsAllow = DB.tblProductBrands.Where(u => u.BrandId == new Guid(Id) && u.ProductId == ele.ProductId).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                var od = DB.tblProductBrands.Where(u => u.BrandId.ToString() == Id).ToList();
                foreach (Product p in myColl)
                {
                    if (od.Where(u => u.ProductId == p.ProductId && u.BrandId.ToString() == Id).FirstOrDefault() != null)
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
                List<DBLayer.tblProductBrand> listpc = DB.tblProductBrands.Where(x => x.BrandId == m.Category).ToList();
                foreach (DBLayer.tblProductBrand obj in listpc)
                {
                    if (Products.Where(u => u.ProductId == obj.ProductId).FirstOrDefault() == null)
                    {
                        if (Array.IndexOf(pId, obj.ProductId.ToString()) > -1)
                            DB.tblProductBrands.Remove(obj);
                    }
                }
                DB.SaveChanges();
                //Add Select Records
                foreach (Product p in Products)
                {
                    DBLayer.tblProductBrand tblpc = new DBLayer.tblProductBrand();
                    tblpc.ProductBrandId = Guid.NewGuid();
                    tblpc.ProductId = p.ProductId;
                    tblpc.BrandId = m.Brand;
                    tblpc.CreateBy = User.Identity.Name;
                    tblpc.CreationDate = DateTime.Now;
                    DB.tblProductBrands.Add(tblpc);
                }
                DB.SaveChanges();

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
                    return RedirectToAction("ProductSearch", "Brands", new { id = m.Brand, page = m.page, count = m.count, ProductName = m.ProductName, UPC_code = m.UPC_code, Category = m.Category, Supplier = m.Supplier, Search = true, });
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
                    return RedirectToAction("ProductSearch", "Brands", new { id = m.Brand, page = m.page, count = m.count, ProductName = m.ProductName, UPC_code = m.UPC_code, Category = m.Category, Supplier = m.Supplier,  Search = true, });
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
        public ActionResult ProductAdd(ProductSearch m, FormCollection fc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.ProductSave(m, fc);
                    return RedirectToAction("Index", "Brands");
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

        #region Brand
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            try
            {
                Collection<Brand> myColl = new Collection<Brand>();
                IEnumerable<Brand> items = null;
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    var C = (from g in DB.tblBrands
                             join status in DB.tblStatus
                             on g.StatusId equals status.StatusId
                             where g.StatusId != new Guid(Utilities.Status_Delete)
                             let Status = status.Name
                             let StatusId = status.StatusId
                             select new { g.BrandId, g.Name, g.DisplayOrder, Status, StatusId , g.FileId}).OrderBy(x => x.DisplayOrder);

                    foreach (var ele in C)
                    {
                        myColl.Add(new Brand()
                        {
                            BrandId = ele.BrandId,
                            Name = ele.Name,
                            DisplayOrder = ele.DisplayOrder,
                            myStatus = ele.Status,
                            StatusId = ele.StatusId,
                            FileId =ele.FileId
                        });
                    }
                    items = myColl as IEnumerable<Brand>;
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
                        Guid BrandId = Guid.Parse(Id);
                        DBLayer.tblBrand tbl = (from g in DB.tblBrands
                                                  where g.BrandId == BrandId
                                                  select g).SingleOrDefault();
                        Brand m = new Brand();
                        m.BrandId = tbl.BrandId;
                        m.DisplayOrder = tbl.DisplayOrder;
                        m.Name = tbl.Name;
                        m.Description  = tbl.Description;
                        m.FileId = tbl.FileId;
                        m.myStatus = tbl.StatusId.ToString();
                        ViewBag.FileId = tbl.FileId;
                        return View(m);
                    }
                }
                else
                {
                    Brand m = new Brand();
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Create Brand")]
        public ActionResult Create(Brand m,  HttpPostedFileBase upload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblBrand tbl = DB.tblBrands.Where(u => u.Name.ToLower() == m.Name.ToLower() && u.StatusId != new Guid(Utilities.Status_Delete)).FirstOrDefault();
                        if (tbl == null)
                        {
                            var NewFileId = Guid.NewGuid();
                            tbl = new DBLayer.tblBrand();
                            tbl.BrandId = Guid.NewGuid();
                            tbl.Name = m.Name;
                            tbl.Description = m.Description;
                            tbl.DisplayOrder = m.DisplayOrder;
                            tbl.StatusId = new Guid(m.myStatus);
                            tbl.CreationDate = DateTime.Now;
                            tbl.CreateBy = User.Identity.Name;
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

                            DB.tblBrands.Add(tbl);
                            DB.SaveChanges();
                            return RedirectToAction("Index", "Brands");
                        }
                        else
                        {
                            ViewBag.Error = "Brand Name Already Exists";
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Edit Brand")]
        public ActionResult Edit(Brand m, HttpPostedFileBase upload)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblBrand tblcheck = DB.tblBrands.Where(u => u.Name.ToLower() == m.Name.ToLower() && u.StatusId != new Guid(Utilities.Status_Delete) && u.BrandId != m.BrandId).FirstOrDefault();
                        if (tblcheck == null)
                        {
                            DBLayer.tblBrand tbl = (from g in DB.tblBrands
                                                    where g.BrandId == m.BrandId
                                                    select g).SingleOrDefault();
                            tbl.Name = m.Name;
                            tbl.DisplayOrder = m.DisplayOrder;
                            tbl.Description = m.Description;
                            tbl.StatusId = new Guid(m.myStatus);
                            tbl.ModifyDate = DateTime.Now;
                            tbl.ModifyBy = User.Identity.Name;
                            tbl.IsVISMA = false;

                            if (upload != null && upload.ContentLength > 0)
                            {
                                var NewFileId = Guid.NewGuid();
                                if (m.FileId == Guid.Empty ||m.FileId== null)
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
                            return RedirectToAction("Index", "Brands");
                        }
                        else
                        {
                            ViewBag.Error = "Brand Name Already Exists";
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Delete Brand")]
        public ActionResult Delete(Brand m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblBrand tbl = (from g in DB.tblBrands
                                                where g.BrandId == m.BrandId
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
                        return RedirectToAction("Index", "Brands");
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
