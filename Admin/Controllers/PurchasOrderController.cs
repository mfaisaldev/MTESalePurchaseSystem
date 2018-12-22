using Admin.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class PurchasOrderController : Controller
    {
        #region AddProduct
        private List<Product> GetProducts(ProductSearch m, string Id, int start, int end)
        {
            var myColl = new List<Product>();
            using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
            {
                var obj = DB.tblPurchasOrders.Where(u => u.PurchasOrderId.ToString() == Id && u.StatusId.ToString() != Utilities.Status_Delete).SingleOrDefault();
                //Search by Brand
                if (string.IsNullOrWhiteSpace(m.ProductName) && string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    //var innerQuery = from ps in DB.tblProductSuppliers where obj.SupplierId == ps.SupplierId  select ps.ProductId;
                    //where innerQuery.Contains(p.ProductId) 

                    var tblProduct = (from p in DB.tblProducts
                                      join od in DB.tblOrderDetails on p.ProductId equals od.ProductId
                                      join o in DB.tblOrders on od.OrderId  equals o.OrderId
                                      join c in DB.tblCustomers on o.CustomerId equals c.CustomerId
                                      join ps in DB.tblProductSuppliers on od.ProductId equals ps.ProductId
                                      join s in DB.tblStatus on p.StatusId equals s.StatusId
                                      where (od.StatusId.ToString() == Utilities.Order_Initialized)
                                      where ps.SupplierId == obj.SupplierId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                      let Status = s.Name
                                      let StatusId = s.StatusId
                                      select new { p.ProductId, p.Name, Status, StatusId, p.UPC_code, od.OrderQty , o.OrderDate , CustomerName = c.Name, c.CustomerId, o.OrderId, od.OrderDetailId }).OrderBy(x => x.Name).Skip(start).Take(end);
                    foreach (var ele in tblProduct)
                    {
                        myColl.Add(new Product()
                        {
                            ProductId = ele.ProductId,
                            Name = ele.Name,
                            UPC_code = ele.UPC_code,
                            myStatus = ele.Status,
                            StatusId = ele.StatusId,
                            OrderDate = ele.OrderDate,
                            CustomerName = ele.CustomerName,
                            OrderQty = ele.OrderQty ,
                            CustomerId = ele.CustomerId,
                            OrderId = ele.OrderId,
                            OrderDetailId = ele.OrderDetailId,
                            //IsAllow = DB.tblPurchasOrderDetails.Where(u => u.OfferDetailId == ele.OfferDetailId && u.PurchasOrderId.ToString() == Id).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (!string.IsNullOrWhiteSpace(m.ProductName) && string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join od in DB.tblOrderDetails on p.ProductId equals od.ProductId
                                      join o in DB.tblOrders on od.OrderId equals o.OrderId
                                      join c in DB.tblCustomers on o.CustomerId equals c.CustomerId
                                      join ps in DB.tblProductSuppliers on od.ProductId equals ps.ProductId
                                      join s in DB.tblStatus on p.StatusId equals s.StatusId
                                      where (od.StatusId.ToString() == Utilities.Order_Initialized)
                                      where ps.SupplierId == obj.SupplierId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (p.Name == m.ProductName || p.Name.Contains(m.ProductName))
                                      let Status = s.Name
                                      let StatusId = s.StatusId
                                      select new { p.ProductId, p.Name, Status, StatusId, p.UPC_code, od.OrderQty, o.OrderDate, CustomerName = c.Name, c.CustomerId, o.OrderId, od.OrderDetailId }).OrderBy(x => x.Name).Skip(start).Take(end);
                    foreach (var ele in tblProduct)
                    {
                        myColl.Add(new Product()
                        {
                            ProductId = ele.ProductId,
                            Name = ele.Name,
                            UPC_code = ele.UPC_code,
                            myStatus = ele.Status,
                            StatusId = ele.StatusId,
                            OrderDate = ele.OrderDate,
                            CustomerName = ele.CustomerName,
                            OrderQty = ele.OrderQty,
                            CustomerId = ele.CustomerId,
                            OrderId = ele.OrderId,
                            OrderDetailId = ele.OrderDetailId,
                            //IsAllow = DB.tblPurchasOrderDetails.Where(u => u.OfferDetailId == ele.OfferDetailId && u.PurchasOrderId.ToString() == Id).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (string.IsNullOrWhiteSpace(m.ProductName) && !string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join od in DB.tblOrderDetails on p.ProductId equals od.ProductId
                                      join o in DB.tblOrders on od.OrderId equals o.OrderId
                                      join c in DB.tblCustomers on o.CustomerId equals c.CustomerId
                                      join ps in DB.tblProductSuppliers on od.ProductId equals ps.ProductId
                                      join s in DB.tblStatus on p.StatusId equals s.StatusId
                                      where (od.StatusId.ToString() == Utilities.Order_Initialized)
                                      where ps.SupplierId == obj.SupplierId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (p.UPC_code == m.UPC_code || p.UPC_code.Contains(m.UPC_code))
                                      let Status = s.Name
                                      let StatusId = s.StatusId
                                      select new { p.ProductId, p.Name, Status, StatusId, p.UPC_code, od.OrderQty, o.OrderDate, CustomerName = c.Name, c.CustomerId, o.OrderId, od.OrderDetailId }).OrderBy(x => x.Name).Skip(start).Take(end);
                    foreach (var ele in tblProduct)
                    {
                        myColl.Add(new Product()
                        {
                            ProductId = ele.ProductId,
                            Name = ele.Name,
                            UPC_code = ele.UPC_code,
                            myStatus = ele.Status,
                            StatusId = ele.StatusId,
                            OrderDate = ele.OrderDate,
                            CustomerName = ele.CustomerName,
                            OrderQty = ele.OrderQty,
                            CustomerId = ele.CustomerId,
                            OrderId = ele.OrderId,
                            OrderDetailId = ele.OrderDetailId,
                            //IsAllow = DB.tblPurchasOrderDetails.Where(u => u.OfferDetailId == ele.OfferDetailId && u.PurchasOrderId.ToString() == Id).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (!string.IsNullOrWhiteSpace(m.ProductName) && !string.IsNullOrWhiteSpace(m.UPC_code) )
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join od in DB.tblOrderDetails on p.ProductId equals od.ProductId
                                      join o in DB.tblOrders on od.OrderId equals o.OrderId
                                      join c in DB.tblCustomers on o.CustomerId equals c.CustomerId
                                      join ps in DB.tblProductSuppliers on od.ProductId equals ps.ProductId
                                      join s in DB.tblStatus on p.StatusId equals s.StatusId
                                      where (od.StatusId.ToString() == Utilities.Order_Initialized)
                                      where ps.SupplierId == obj.SupplierId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (p.Name == m.ProductName || p.Name.Contains(m.ProductName))
                                     && (p.UPC_code == m.UPC_code || p.UPC_code.Contains(m.UPC_code))
                                      let Status = s.Name
                                      let StatusId = s.StatusId
                                      select new { p.ProductId, p.Name, Status, StatusId, p.UPC_code, od.OrderQty, o.OrderDate, CustomerName = c.Name, c.CustomerId, o.OrderId, od.OrderDetailId }).OrderBy(x => x.Name).Skip(start).Take(end);
                    foreach (var ele in tblProduct)
                    {
                        myColl.Add(new Product()
                        {
                            ProductId = ele.ProductId,
                            Name = ele.Name,
                            UPC_code = ele.UPC_code,
                            myStatus = ele.Status,
                            StatusId = ele.StatusId,
                            OrderDate = ele.OrderDate,
                            CustomerName = ele.CustomerName,
                            OrderQty = ele.OrderQty,
                            CustomerId = ele.CustomerId,
                            OrderId = ele.OrderId,
                            OrderDetailId = ele.OrderDetailId,
                            //IsAllow = DB.tblPurchasOrderDetails.Where(u => u.OfferDetailId == ele.OfferDetailId && u.PurchasOrderId.ToString() == Id).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                var pod = DB.tblPurchasOrderDetails.Where(u => u.PurchasOrderId.ToString() == Id).ToList();
                foreach (Product p in myColl)
                {
                    if (pod.Where(u => u.ProductId == p.ProductId && u.PurchasOrderId.ToString() == Id).FirstOrDefault() != null)
                        p.IsAllow = true;
                }

            }
            return myColl;
        }

        private void ProductSave(ProductSearch m, FormCollection fc)
        {
            List<OrderDetail> OrderDetails = new List<OrderDetail>();
            string[] chks = fc["item.IsAllow"].ToString().Split(',');
            string[] pId = fc["item.ProductId"].ToString().Split(',');
            string[] CustomerId = fc["item.CustomerId"].ToString().Split(',');
            string[] OrderId = fc["item.OrderId"].ToString().Split(',');
            string[] OrderDetailId = fc["item.OrderDetailId"].ToString().Split(',');
            int count = 0;
            for (int n = 0; n < chks.Length; n++)
            {
                if (chks[n] == "true")
                {
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.OrderDetailId = new Guid(OrderDetailId[count]);
                    OrderDetails.Add(orderDetail);
                    n++;
                }
                count++;
            }

            using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
            {
                //Delete All record
                var listod = DB.tblPurchasOrderDetails.Where(x => x.PurchasOrderId == m.PurchasOrder).ToList();
                foreach (DBLayer.tblPurchasOrderDetail obj in listod)
                {
                    if (OrderDetails.Where(p => p.OrderDetailId == obj.OrderDetailId).FirstOrDefault() == null)
                    {
                        if (Array.IndexOf(OrderDetailId, obj.OrderDetailId.ToString()) > -1)
                            DB.tblPurchasOrderDetails.Remove(obj);
                    }
                }
                DB.SaveChanges();
                //Add Select Records
                for (int n = 0; n < OrderDetailId.Length; n++)
                {
                    if (OrderDetails.Where(u => u.OrderDetailId.ToString() == OrderDetailId[n].ToString()).FirstOrDefault() != null)
                    {
                        var orderDetailId = new Guid(OrderDetailId[n].ToString());
                        //                                DBLayer.tblPurchasOrderDetail t = DB.tblPurchasOrderDetails.Where(u => u.OfferDetailId == offerDetailId && u.StatusId.ToString() != Utilities.Status_Delete).FirstOrDefault();
                        //                                if (t == null)
                        //                                {
                        var productId = new Guid(pId[n].ToString());
                        var t = new DBLayer.tblPurchasOrderDetail();
                        var objProduct = DB.tblProducts.Where(p => p.ProductId == productId).FirstOrDefault();
                        var objOrderDeatil = DB.tblOrderDetails.Where(o => o.OrderDetailId == orderDetailId).FirstOrDefault();
                        t.CreateBy = User.Identity.Name;
                        t.CreationDate = DateTime.Now;
                        t.CustomerId = new Guid(CustomerId[n].ToString());
                        t.OrderDetailId  = new Guid(OrderDetailId[n].ToString());
                        t.OrderId  = new Guid(OrderId[n].ToString());
                        t.OrderQty  = objOrderDeatil.OrderQty;
                        t.ProductId = objProduct.ProductId;
                        t.ProductName = objProduct.Name;
                        t.ProductUCPCode = objProduct.UPC_code;
                        t.PurchasOrderDetailId = Guid.NewGuid();
                        t.PurchasOrderId = m.PurchasOrder;
                        t.PurchaseOrderHistory = this.GetProductHistory(productId);
                        t.StatusId = new Guid(Utilities.Status_Active);
                        t.OrderPrice = objOrderDeatil.OrderPrice;
                        DB.tblPurchasOrderDetails.Add(t);
                        //                                }
                        DB.SaveChanges();
                    }
                }

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
                    return RedirectToAction("Create", "PurchasOrder", new { id = m.PurchasOrder });
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
                    return RedirectToAction("ProductSearch", "PurchasOrder", new { id = m.PurchasOrder, page = m.page, count = m.count, ProductName = m.ProductName, UPC_code = m.UPC_code, Brand = m.Brand, Category = m.Category, Supplier = m.Supplier, PurchasOrderName = m.PurchasOrderName , Search = true, });
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
                    return RedirectToAction("ProductSearch", "PurchasOrder", new { id = m.PurchasOrder, page = m.page, count = m.count, ProductName = m.ProductName, UPC_code = m.UPC_code, Brand = m.Brand, Category = m.Category, Supplier = m.Supplier, PurchasOrderName = m.PurchasOrderName, Search = true, });
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
                    List<Supplier> supplier = new List<Supplier>();
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
                    return RedirectToAction("Index", "PurchasOrder");
                }
            }
            catch
            {
                return View();
            }
        }

        private string GetProductHistory(Guid ProductId)
        {
            try
            {
                string strHistory = "";
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    List<DBLayer.tblProductSupplierHistory> listph = DB.tblProductSupplierHistories.Where(x => x.ProductId == ProductId && x.StatusId.ToString()!=Utilities.Status_Delete).ToList();
                    foreach (var ph in listph)
                    {
                        strHistory += "Supplier : " + ph.tblSupplier.Name + ", ";
                        strHistory += "Price : " + ph.Price + ", ";
                        strHistory += "Qty : " + ph.Qty + ", ";
                        strHistory += "Purchase Date : " + ph.SaleDate + ".   ";
                    }
                }
                return strHistory;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region PurchasOrder
        public ActionResult Index()
        {
            try
            {
                //Get All roles
                var UserRoles = this.GetRoles();
                ViewBag.UserRoles = UserRoles;
                Collection<PurchasOrder> myColl = new Collection<PurchasOrder>();
                IEnumerable<PurchasOrder> items = null;
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    var C = (from c in DB.tblPurchasOrders
                             join status in DB.tblStatus
                             on c.StatusId equals status.StatusId
                             join s in DB.tblSuppliers
                             on c.SupplierId equals s.SupplierId
                             where c.StatusId != new Guid(Utilities.Status_Delete)
                             let Status = status.Name
                             let StatusId = status.StatusId
                             let Supplier = s.Name
                             select new {s.UserName,c.CreateBy,  c.PurchasOrderId, c.Name, Supplier, c.CreationDate, Status, StatusId, c.PurchasOrderDate, c.ExpectDeliveryDate, c.ActualDeliveryDate }).OrderBy(x => x.CreationDate);

                    foreach (var ele in C)
                    {
                        if (UserRoles.Where(u => u.RoleId.ToString().ToUpper() == Utilities.Role_Operations).FirstOrDefault() != null)
                        {
                            if (ele.CreateBy == User.Identity.Name)
                            {
                                myColl.Add(new PurchasOrder()
                                {
                                    PurchasOrderId = ele.PurchasOrderId,
                                    Name = ele.Name,
                                    mySupplier = ele.Supplier,
                                    PurchasOrderDate = ele.PurchasOrderDate,
                                    ExpectDeliveryDate = ele.ExpectDeliveryDate,
                                    ActualDeliveryDate = ele.ActualDeliveryDate,
                                    myStatus = ele.Status,
                                    StatusId = ele.StatusId
                                });
                            }
                        }
                        else if (UserRoles.Where(u => u.RoleId.ToString().ToUpper() == Utilities.Role_CFO).FirstOrDefault() != null)
                        {
                            if (ele.StatusId.ToString() == Utilities.Purchas_Order_Initialized)
                            {
                                myColl.Add(new PurchasOrder()
                                {
                                    PurchasOrderId = ele.PurchasOrderId,
                                    Name = ele.Name,
                                    mySupplier = ele.Supplier,
                                    PurchasOrderDate = ele.PurchasOrderDate,
                                    ExpectDeliveryDate = ele.ExpectDeliveryDate,
                                    ActualDeliveryDate = ele.ActualDeliveryDate,
                                    myStatus = ele.Status,
                                    StatusId = ele.StatusId
                                });
                            }
                        }
                        else if (UserRoles.Where(u => u.RoleId.ToString().ToUpper() == Utilities.Role_Supplier).FirstOrDefault() != null)
                        {
                            if (ele.UserName == User.Identity.Name)
                            {
                                if (ele.StatusId.ToString() == Utilities.Purchas_Order_Approved || ele.StatusId.ToString() == Utilities.Purchase_Order_Supplier_Accepted || ele.StatusId.ToString() == Utilities.Purchase_Order_Supplier_Rejected || ele.StatusId.ToString() == Utilities.Purchas_Order_Partially_Delivered || ele.StatusId.ToString() == Utilities.Purchas_Order_Partially_Delivered)
                                {
                                    myColl.Add(new PurchasOrder()
                                    {
                                        PurchasOrderId = ele.PurchasOrderId,
                                        Name = ele.Name,
                                        mySupplier = ele.Supplier,
                                        PurchasOrderDate = ele.PurchasOrderDate,
                                        ExpectDeliveryDate = ele.ExpectDeliveryDate,
                                        ActualDeliveryDate = ele.ActualDeliveryDate,
                                        myStatus = ele.Status,
                                        StatusId = ele.StatusId
                                    });
                                }
                            }
                        }
                }
                items = myColl as IEnumerable<PurchasOrder>;
                    return View(items);
                }
            }
            catch
            {
                IEnumerable<Offer> items = null;
                return View(items);
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create(string Id)
        {
            try
            {
                //Get All roles
                var UserRoles = this.GetRoles();
                ViewBag.UserRoles = UserRoles;

                PurchasOrderModel pdm = new PurchasOrderModel();
                PurchasOrder pd = new PurchasOrder();
                List<PurchasOrderDetail> pddList = new List<PurchasOrderDetail>();
                if (Id != null)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        Guid PurchasOrderId = Guid.Parse(Id);
                        DBLayer.tblPurchasOrder tbl = (from g in DB.tblPurchasOrders
                                                       where g.PurchasOrderId == PurchasOrderId &
                                                        g.StatusId != new Guid(Utilities.Status_Delete)
                                                       select g).SingleOrDefault();
                        pd.PurchasOrderId = tbl.PurchasOrderId;
                        pd.Name = tbl.Name;
                        pd.Description = tbl.Description;
                        pd.myStatus = tbl.StatusId.ToString();
                        pd.SupplierId = tbl.SupplierId;
                        pd.ExpectDeliveryDate = tbl.ExpectDeliveryDate;

                        var tblPurchasOrderDetail = (from g in DB.tblPurchasOrderDetails
                                                     where g.PurchasOrderId == PurchasOrderId &
                                              g.StatusId != new Guid(Utilities.Status_Delete)
                                                     select g).ToList();
                        foreach (var i in tblPurchasOrderDetail)
                        {
                            pddList.Add(new PurchasOrderDetail()
                            {
                                OrderPrice = i.OrderPrice,
                                OrderQty = i.OrderQty,
                                PurchaseOrderRemark = i.PurchaseOrderRemark,
                                PurchaseOrderHistory = i.PurchaseOrderHistory,
                                myProduct = i.tblProduct.Name,
                                myStatus = i.tblStatu.Name,
                                PurchasOrderDetailId = i.PurchasOrderDetailId,
                                PurchasOrderId = i.PurchasOrderId,
                                ProductId = i.ProductId,
                                ProductName = i.ProductName,
                                StatusId = i.StatusId,
                                PurchaseOrderPrice = i.PurchaseOrderPrice,
                                PurchaseOrderQty = i.PurchaseOrderQty,
                                CustomerName = i.tblCustomer.Name
                            });

                        }
                    }
                }
            
                                    pdm.PurchasOrder = pd;
                pdm.PurchasOrderDetails = pddList;
                return View(pdm);
            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
                return View(new PurchasOrderModel());
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Add Product")]
        public ActionResult AddProductPO(PurchasOrderModel om)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (om.PurchasOrder.PurchasOrderId != Guid.Empty)
                    {
                        using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                        {
                            var tbl = DB.tblPurchasOrders.Where(u => u.PurchasOrderId == om.PurchasOrder.PurchasOrderId && u.StatusId.ToString() != Utilities.Status_Delete).SingleOrDefault();
                            tbl.SupplierId = om.PurchasOrder.SupplierId;
                            DB.SaveChanges();
                        }
                        return RedirectToAction("ProductSearch", "PurchasOrder", new { Id = om.PurchasOrder.PurchasOrderId, PurchasOrderName = om.PurchasOrder.Name });
                    }
                    else
                    {
                        using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                        {
                            var PurchasOrderId = Guid.NewGuid();
                            var tbl = new DBLayer.tblPurchasOrder();
                            tbl.StatusId = new Guid(Utilities.Status_Active);
                            tbl.CreationDate = DateTime.Now;
                            tbl.CreateBy = User.Identity.Name;
                            tbl.SupplierId = om.PurchasOrder.SupplierId;
                            tbl.Description = om.PurchasOrder.Description;
                            tbl.ExpectDeliveryDate = om.PurchasOrder.ExpectDeliveryDate;
                            tbl.IsVISMA = false;
                            tbl.Name = om.PurchasOrder.Name;
                            tbl.PurchasOrderId = PurchasOrderId;
                            tbl.PurchasOrderDate = DateTime.Now;
                            DB.tblPurchasOrders.Add(tbl);
                            DB.SaveChanges();
                            this.SavePurchasOrderLog(tbl);
                            return RedirectToAction("ProductSearch", "PurchasOrder", new { Id = PurchasOrderId, OfferName = om.PurchasOrder.Name });
                        }
                    }
                }
                else
                {
                    return View(om);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
                return View(om);
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Create Purchase Order")]
        public ActionResult Create(PurchasOrderModel om)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        var t = new DBLayer.tblPurchasOrder();
                        var NewOfferId = Guid.NewGuid();
                        t.CreateBy = User.Identity.Name;
                        t.CreationDate = DateTime.Now;
                        t.SupplierId  = om.PurchasOrder.SupplierId;
                        t.Description = om.PurchasOrder.Description;
                        t.ExpectDeliveryDate = om.PurchasOrder.ExpectDeliveryDate;
                        t.IsVISMA = false;
                        t.Name = om.PurchasOrder.Name;
                        t.PurchasOrderDate  = DateTime.Now;
                        t.PurchasOrderId  = NewOfferId;
                        t.StatusId = new Guid(Utilities.Status_Initialize);
                        DB.tblPurchasOrders.Add(t);
                        DB.SaveChanges();
                        this.SavePurchasOrderLog(t);
                        return RedirectToAction("Create", "PurchasOrder", new { Id = NewOfferId });
                    }
                }
                else
                {
                    return View(om);
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Edit")]
        public ActionResult Edit(PurchasOrderModel om, FormCollection fc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string[] PurchaseOrderPrice = fc["item.PurchaseOrderPrice"].ToString().Split(',');
                    string[] PurchaseOrderQty = fc["item.PurchaseOrderQty"].ToString().Split(',');
                    string[] PurchasOrderDetailId = fc["item.PurchasOrderDetailId"].ToString().Split(',');
                    string[] PurchaseOrderRemark = fc["item.PurchaseOrderRemark"].ToString().Split(',');
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblPurchasOrder t = (from g in DB.tblPurchasOrders
                                                     where g.PurchasOrderId  == om.PurchasOrder.PurchasOrderId &
                                              g.StatusId != new Guid(Utilities.Status_Delete)
                                                     select g).SingleOrDefault();

                        t.ModifyBy = User.Identity.Name;
                        t.ModifyDate = DateTime.Now;
                        t.SupplierId = om.PurchasOrder.SupplierId;
                        t.Description = om.PurchasOrder.Description;
                        t.ExpectDeliveryDate = om.PurchasOrder.ExpectDeliveryDate;
                        t.Name = om.PurchasOrder.Name;
                        var PurchasOrderLogId = this.SavePurchasOrderLog(t);
                        DB.SaveChanges();

                        for (int n = 0; n < PurchasOrderDetailId.Length; n++)
                        {
                            var Id = new Guid(PurchasOrderDetailId[n]);
                            DBLayer.tblPurchasOrderDetail tbl = (from g in DB.tblPurchasOrderDetails
                                                                 where g.PurchasOrderDetailId == Id &
                                              g.StatusId != new Guid(Utilities.Status_Delete)
                                                                 select g).SingleOrDefault();
                            tbl.PurchaseOrderPrice = String.IsNullOrWhiteSpace(PurchaseOrderPrice[n]) ? 0 : System.Convert.ToDecimal(PurchaseOrderPrice[n]);
                            tbl.PurchaseOrderQty = String.IsNullOrWhiteSpace(PurchaseOrderQty[n]) ? 0 : System.Convert.ToInt32(PurchaseOrderQty[n]);
                            tbl.PurchaseOrderRemark = PurchaseOrderRemark[n];
                            tbl.ModifyBy = User.Identity.Name;
                            tbl.ModifyDate = DateTime.Now;
                            this.SavePurchasOrderDetailLog(tbl, PurchasOrderLogId);
                            DB.SaveChanges();

                        }

                        return RedirectToAction("Create", "PurchasOrder", new { id = om.PurchasOrder.PurchasOrderId });
                    }
                }
                else
                {
                    return View(om);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
                return View(om);
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Delete")]
        public ActionResult Delete(PurchasOrderModel om, FormCollection fc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string[] PurchasOrderDetailId = fc["item.PurchasOrderDetailId"].ToString().Split(',');
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblPurchasOrder t = (from g in DB.tblPurchasOrders
                                              where g.PurchasOrderId == om.PurchasOrder.PurchasOrderId
                                              select g).SingleOrDefault();

                        t.ModifyBy = User.Identity.Name;
                        t.ModifyDate = DateTime.Now;
                        t.StatusId = new Guid(Utilities.Status_Delete);
                        var PurchasOrderLogId = this.SavePurchasOrderLog(t);
                        DB.SaveChanges();

                        for (int n = 0; n < PurchasOrderDetailId.Length; n++)
                        {
                            var Id = new Guid(PurchasOrderDetailId[n]);
                            DBLayer.tblPurchasOrderDetail tbl = (from g in DB.tblPurchasOrderDetails
                                                          where g.PurchasOrderDetailId == Id
                                                          select g).SingleOrDefault();
                            tbl.ModifyBy = User.Identity.Name;
                            tbl.ModifyDate = DateTime.Now;
                            tbl.StatusId = new Guid(Utilities.Status_Delete);
                            this.SavePurchasOrderDetailLog(tbl, PurchasOrderLogId);
                            DB.SaveChanges();
                        }
                        return RedirectToAction("Index", "PurchasOrder");
                    }
                }
                else
                {
                    return View(om);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
                return View(om);
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Submit")]
        public ActionResult Submit(PurchasOrderModel om, FormCollection fc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string[] PurchaseOrderPrice = fc["item.PurchaseOrderPrice"].ToString().Split(',');
                    string[] PurchaseOrderQty = fc["item.PurchaseOrderQty"].ToString().Split(',');
                    string[] PurchasOrderDetailId = fc["item.PurchasOrderDetailId"].ToString().Split(',');
                    string[] PurchaseOrderRemark = fc["item.PurchaseOrderRemark"].ToString().Split(',');
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblPurchasOrder t = (from g in DB.tblPurchasOrders
                                                     where g.PurchasOrderId == om.PurchasOrder.PurchasOrderId &
                                              g.StatusId != new Guid(Utilities.Status_Delete)
                                                     select g).SingleOrDefault();

                        t.ModifyBy = User.Identity.Name;
                        t.ModifyDate = DateTime.Now;
                        t.SupplierId = om.PurchasOrder.SupplierId;
                        t.Description = om.PurchasOrder.Description;
                        t.Name = om.PurchasOrder.Name;
                        t.ExpectDeliveryDate = om.PurchasOrder.ExpectDeliveryDate;
                        t.StatusId = new Guid(Utilities.Purchas_Order_Initialized);
                        var PurchasOrderLogId = this.SavePurchasOrderLog(t);
                        DB.SaveChanges();

                        for (int n = 0; n < PurchasOrderDetailId.Length; n++)
                        {
                            var Id = new Guid(PurchasOrderDetailId[n]);
                            DBLayer.tblPurchasOrderDetail tbl = (from g in DB.tblPurchasOrderDetails
                                                                 where g.PurchasOrderDetailId == Id &
                                              g.StatusId != new Guid(Utilities.Status_Delete)
                                                                 select g).SingleOrDefault();
                            tbl.PurchaseOrderPrice = String.IsNullOrWhiteSpace(PurchaseOrderPrice[n]) ? 0 : System.Convert.ToDecimal(PurchaseOrderPrice[n]);
                            tbl.PurchaseOrderQty = String.IsNullOrWhiteSpace(PurchaseOrderQty[n]) ? 0 : System.Convert.ToInt32(PurchaseOrderQty[n]);
                            tbl.PurchaseOrderRemark = PurchaseOrderRemark[n];
                            tbl.ModifyBy = User.Identity.Name;
                            tbl.ModifyDate = DateTime.Now;
                            tbl.StatusId = new Guid(Utilities.Purchas_Order_Initialized);
                            this.SavePurchasOrderDetailLog(tbl, PurchasOrderLogId);
                            DB.SaveChanges();

                        }
                        return RedirectToAction("Index", "PurchasOrder");
                    }
                }
                else
                {
                    return View(om);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
                return View(om);
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Approved")]
        public async System.Threading.Tasks.Task<ActionResult> Approved(PurchasOrderModel om, FormCollection fc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string[] PurchaseOrderPrice = fc["item.PurchaseOrderPrice"].ToString().Split(',');
                    string[] PurchaseOrderQty = fc["item.PurchaseOrderQty"].ToString().Split(',');
                    string[] PurchasOrderDetailId = fc["item.PurchasOrderDetailId"].ToString().Split(',');
                    string[] PurchaseOrderRemark = fc["item.PurchaseOrderRemark"].ToString().Split(',');
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblPurchasOrder t = (from g in DB.tblPurchasOrders
                                                     where g.PurchasOrderId == om.PurchasOrder.PurchasOrderId &
                                              g.StatusId != new Guid(Utilities.Status_Delete)
                                                     select g).SingleOrDefault();

                        t.ModifyBy = User.Identity.Name;
                        t.ModifyDate = DateTime.Now;
                        t.SupplierId = om.PurchasOrder.SupplierId;
                        t.Description = om.PurchasOrder.Description;
                        t.Name = om.PurchasOrder.Name;
                        t.ExpectDeliveryDate = om.PurchasOrder.ExpectDeliveryDate;
                        t.StatusId = new Guid(Utilities.Purchas_Order_Approved);
                        var PurchasOrderLogId = this.SavePurchasOrderLog(t);
                        DB.SaveChanges();
                        var col = new Collection<DBLayer.tblPurchasOrderDetail>();
                        for (int n = 0; n < PurchasOrderDetailId.Length; n++)
                        {
                            var Id = new Guid(PurchasOrderDetailId[n]);
                            DBLayer.tblPurchasOrderDetail tbl = (from g in DB.tblPurchasOrderDetails
                                                                 where g.PurchasOrderDetailId == Id &
                                              g.StatusId != new Guid(Utilities.Status_Delete)
                                                                 select g).SingleOrDefault();
                            tbl.PurchaseOrderPrice = String.IsNullOrWhiteSpace(PurchaseOrderPrice[n]) ? 0 : System.Convert.ToDecimal(PurchaseOrderPrice[n]);
                            tbl.PurchaseOrderQty = String.IsNullOrWhiteSpace(PurchaseOrderQty[n]) ? 0 : System.Convert.ToInt32(PurchaseOrderQty[n]);
                            tbl.PurchaseOrderRemark = PurchaseOrderRemark[n];
                            tbl.ModifyBy = User.Identity.Name;
                            tbl.ModifyDate = DateTime.Now;
                            tbl.StatusId = new Guid(Utilities.Purchas_Order_Approved);
                            this.SavePurchasOrderDetailLog(tbl, PurchasOrderLogId);
                            DB.SaveChanges();
                            col.Add(tbl);
                            // Save History 
                            var ph = new DBLayer.tblProductSupplierHistory();
                            ph.CreateBy = User.Identity.Name;
                            ph.CreationDate = DateTime.Now;
                            ph.SupplierId  = t.SupplierId;
                            ph.Price = tbl.PurchaseOrderPrice;
                            ph.ProductSupplierHistoryId  = Guid.NewGuid();
                            ph.ProductId = tbl.ProductId;
                            ph.ProductName = tbl.ProductName;
                            ph.Qty = tbl.PurchaseOrderQty;
                            ph.Remarks = tbl.PurchaseOrderRemark;
                            ph.SaleDate = DateTime.Now;
                            ph.StatusId = new Guid(Utilities.Status_Active);
                            DB.tblProductSupplierHistories.Add(ph);
                            DB.SaveChanges();

                            //update Order
                            var Order = DB.tblOrders.Where(u => u.OrderId == tbl.OrderId && u.StatusId.ToString() != Utilities.Status_Delete).SingleOrDefault();
                            Order.StatusId = new Guid(Utilities.Order_In_Process);
                            Order.ModifyBy = User.Identity.Name;
                            Order.ModifyDate = DateTime.Now;
                            DB.SaveChanges();
                            var Orderdetails = DB.tblOrderDetails.Where(u => u.OrderDetailId == tbl.OrderDetailId && u.StatusId.ToString() != Utilities.Status_Delete).ToList(); 
                            foreach(var Orderdetail in Orderdetails)
                            {
                                Orderdetail.StatusId = new Guid(Utilities.Order_In_Process);
                                Orderdetail.ModifyBy = User.Identity.Name;
                                Orderdetail.ModifyDate = DateTime.Now;
                                DB.SaveChanges();
                            } 

                        }
                        //Update VISMA
                        var SupplierOrderNo = await this.UpdateSupplierOrders(t, col);
                        if (!String.IsNullOrEmpty(SupplierOrderNo))
                        {
                            DBLayer.tblPurchasOrder order = (from g in DB.tblPurchasOrders
                                                             where g.PurchasOrderId == t.PurchasOrderId 
                                                      select g).SingleOrDefault();
                            order.SupplierOrderNo = SupplierOrderNo;
                            DB.SaveChanges();
                            return RedirectToAction("Index", "PurchasOrder");
                        }
                        else
                        {
                            ViewBag.Error = "Records is successfull update in B2B but unable to update VISMA";
                            return View(om);
                        }
                    }
                }
                else
                {
                    return View(om);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
                return View(om);
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Rejected")]
        public ActionResult Rejected(PurchasOrderModel om, FormCollection fc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string[] PurchaseOrderPrice = fc["item.PurchaseOrderPrice"].ToString().Split(',');
                    string[] PurchaseOrderQty = fc["item.PurchaseOrderQty"].ToString().Split(',');
                    string[] PurchasOrderDetailId = fc["item.PurchasOrderDetailId"].ToString().Split(',');
                    string[] PurchaseOrderRemark = fc["item.PurchaseOrderRemark"].ToString().Split(',');
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblPurchasOrder t = (from g in DB.tblPurchasOrders
                                                     where g.PurchasOrderId == om.PurchasOrder.PurchasOrderId &
                                              g.StatusId != new Guid(Utilities.Status_Delete)
                                                     select g).SingleOrDefault();

                        t.ModifyBy = User.Identity.Name;
                        t.ModifyDate = DateTime.Now;
                        t.SupplierId = om.PurchasOrder.SupplierId;
                        t.Description = om.PurchasOrder.Description;
                        t.Name = om.PurchasOrder.Name;
                        t.ExpectDeliveryDate = om.PurchasOrder.ExpectDeliveryDate;
                        t.StatusId = new Guid(Utilities.Purchas_Order_Rejected);
                        var PurchasOrderLogId = this.SavePurchasOrderLog(t);
                        DB.SaveChanges();

                        for (int n = 0; n < PurchasOrderDetailId.Length; n++)
                        {
                            var Id = new Guid(PurchasOrderDetailId[n]);
                            DBLayer.tblPurchasOrderDetail tbl = (from g in DB.tblPurchasOrderDetails
                                                                 where g.PurchasOrderDetailId == Id &
                                              g.StatusId != new Guid(Utilities.Status_Delete)
                                                                 select g).SingleOrDefault();
                            tbl.PurchaseOrderPrice = String.IsNullOrWhiteSpace(PurchaseOrderPrice[n]) ? 0 : System.Convert.ToDecimal(PurchaseOrderPrice[n]);
                            tbl.PurchaseOrderQty = String.IsNullOrWhiteSpace(PurchaseOrderQty[n]) ? 0 : System.Convert.ToInt32(PurchaseOrderQty[n]);
                            tbl.PurchaseOrderRemark = PurchaseOrderRemark[n];
                            tbl.ModifyBy = User.Identity.Name;
                            tbl.ModifyDate = DateTime.Now;
                            tbl.StatusId = new Guid(Utilities.Purchas_Order_Rejected);
                            this.SavePurchasOrderDetailLog(tbl, PurchasOrderLogId);
                            DB.SaveChanges();

                        }
                        return RedirectToAction("Index", "PurchasOrder");
                    }
                }
                else
                {
                    return View(om);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
                return View(om);
            }
        }


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Accepted")]
        public ActionResult Accepted(PurchasOrderModel om, FormCollection fc)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                   
                    string[] PurchasOrderDetailId = fc["item.PurchasOrderDetailId"].ToString().Split(',');
                    string[] ReceiveDate = fc["item.ReceiveDate"].ToString().Split(',');
                    
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblPurchasOrder t = (from g in DB.tblPurchasOrders
                                                     where g.PurchasOrderId == om.PurchasOrder.PurchasOrderId &
                                              g.StatusId != new Guid(Utilities.Status_Delete)
                                                     select g).SingleOrDefault();

                        t.ModifyBy = User.Identity.Name;
                        t.ModifyDate = DateTime.Now;
                        t.StatusId = new Guid(Utilities.Purchase_Order_Supplier_Accepted);
                        var PurchasOrderLogId = this.SavePurchasOrderLog(t);
                        DB.SaveChanges();

                        for (int n = 0; n < PurchasOrderDetailId.Length; n++)
                        {
                            var Id = new Guid(PurchasOrderDetailId[n]);
                            
                            DBLayer.tblPurchasOrderDetail tbl = (from g in DB.tblPurchasOrderDetails
                                                                 where g.PurchasOrderDetailId == Id &
                                              g.StatusId != new Guid(Utilities.Status_Delete)
                                                                 select g).SingleOrDefault();
                            if(!String.IsNullOrWhiteSpace(ReceiveDate[n]))
                            {
                                tbl.ReceiveDate = Convert.ToDateTime(ReceiveDate[n]);
                                this.updateOrder(tbl.ReceiveDate, tbl.OrderId, tbl.OrderDetailId);
                            }
                            tbl.ModifyBy = User.Identity.Name;
                            tbl.ModifyDate = DateTime.Now;
                            tbl.StatusId = new Guid(Utilities.Purchase_Order_Supplier_Accepted);
                            this.SavePurchasOrderDetailLog(tbl, PurchasOrderLogId);
                            DB.SaveChanges();


                        }

                      
                        return RedirectToAction("Index", "PurchasOrder");
                    }
                //}
                //else
                //{
                //    return View(om);
                //}
            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
                return View(om);
            }
        }
        
        private void updateOrder(DateTime? dt,Guid? OrderId, Guid? OrderDetailId)
        {
            using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
            {
                DBLayer.tblOrder t = (from g in DB.tblOrders
                                      where g.OrderId == OrderId
                                      select g).SingleOrDefault();
                if (t.AcceptanceDeliveryDate < dt|| t.AcceptanceDeliveryDate== null)
                {
                    t.AcceptanceDeliveryDate = dt;
                    t.ModifyBy = User.Identity.Name;
                    t.ModifyDate = DateTime.Now;
                    DB.SaveChanges();
                }
                DBLayer.tblOrderDetail tbl = (from g in DB.tblOrderDetails
                                              where g.OrderDetailId == OrderDetailId
                                              select g).SingleOrDefault();
                t.AcceptanceDeliveryDate = dt;
                t.ModifyBy = User.Identity.Name;
                t.ModifyDate = DateTime.Now;
                DB.SaveChanges();                
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Deny")]
        public ActionResult Deny(PurchasOrderModel om, FormCollection fc)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    string[] PurchasOrderDetailId = fc["item.PurchasOrderDetailId"].ToString().Split(',');
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblPurchasOrder t = (from g in DB.tblPurchasOrders
                                                     where g.PurchasOrderId == om.PurchasOrder.PurchasOrderId &
                                              g.StatusId != new Guid(Utilities.Status_Delete)
                                                     select g).SingleOrDefault();

                        t.ModifyBy = User.Identity.Name;
                        t.ModifyDate = DateTime.Now;
                        t.StatusId = new Guid(Utilities.Purchase_Order_Supplier_Rejected);
                        var PurchasOrderLogId = this.SavePurchasOrderLog(t);
                        DB.SaveChanges();

                        for (int n = 0; n < PurchasOrderDetailId.Length; n++)
                        {
                            var Id = new Guid(PurchasOrderDetailId[n]);
                            DBLayer.tblPurchasOrderDetail tbl = (from g in DB.tblPurchasOrderDetails
                                                                 where g.PurchasOrderDetailId == Id &
                                              g.StatusId != new Guid(Utilities.Status_Delete)
                                                                 select g).SingleOrDefault();
                            tbl.ModifyBy = User.Identity.Name;
                            tbl.ModifyDate = DateTime.Now;
                            tbl.StatusId = new Guid(Utilities.Purchase_Order_Supplier_Rejected);
                            this.SavePurchasOrderDetailLog(tbl, PurchasOrderLogId);
                            DB.SaveChanges();

                        }
                        return RedirectToAction("Index", "PurchasOrder");
                    }
                //}
                //else
                //{
                //    return View(om);
                //}
            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
                return View(om);
            }
        }


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "PO Delivered")]
        public ActionResult Delivered(PurchasOrderModel om, FormCollection fc)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                string[] PurchasOrderDetailId = fc["item.PurchasOrderDetailId"].ToString().Split(',');
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    DBLayer.tblPurchasOrder t = (from g in DB.tblPurchasOrders
                                                 where g.PurchasOrderId == om.PurchasOrder.PurchasOrderId &
                                          g.StatusId != new Guid(Utilities.Status_Delete)
                                                 select g).SingleOrDefault();

                    t.ModifyBy = User.Identity.Name;
                    t.ModifyDate = DateTime.Now;
                    t.StatusId = new Guid(Utilities.Purchase_Order_Delivered);
                    var PurchasOrderLogId = this.SavePurchasOrderLog(t);
                    DB.SaveChanges();

                    for (int n = 0; n < PurchasOrderDetailId.Length; n++)
                    {
                        var Id = new Guid(PurchasOrderDetailId[n]);
                        DBLayer.tblPurchasOrderDetail tbl = (from g in DB.tblPurchasOrderDetails
                                                             where g.PurchasOrderDetailId == Id &
                                          g.StatusId != new Guid(Utilities.Status_Delete)
                                                             select g).SingleOrDefault();
                        tbl.ModifyBy = User.Identity.Name;
                        tbl.ModifyDate = DateTime.Now;
                        tbl.StatusId = new Guid(Utilities.Purchase_Order_Delivered);
                        this.SavePurchasOrderDetailLog(tbl, PurchasOrderLogId);
                        DB.SaveChanges();

                    }
                    return RedirectToAction("Index", "PurchasOrder");
                }
                //}
                //else
                //{
                //    return View(om);
                //}
            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
                return View(om);
            }
        }
        #endregion

        #region UpdateVisma
//{
//  "Lines": [
//    {
//      "Amount": 1900,
//      "ArticleNo": "999999790026",
//      "DeliveryDate": "2017-05-10T07:01:12.073Z",
//      "Description": "Test",
//      "Name": "TestName",
//      "Quantity": 10
//    }
//  ],
//  "SupplierName": "Testsupplier",
//  "SupplierOrderDate": "2017-05-10T07:01:12.074Z",
//  "SupplierNo": 50047,
//  "OrderType": 300
//}
        private async Task<string> UpdateSupplierOrders(DBLayer.tblPurchasOrder o, Collection<DBLayer.tblPurchasOrderDetail> od)
        {
            using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
            {
                var obj = new JObject();
                var arrayLines = new JArray();
                foreach (DBLayer.tblPurchasOrderDetail objOd in od)
                {
                    var lines = new JObject();
                    lines["Amount"] = Convert.ToInt32(objOd.OrderPrice);
                    lines["ArticleNo"] = objOd.tblProduct.ArticleNo;
                    lines["DeliveryDate"] = DateTime.Now.AddDays(10);
                    lines["Name"] = objOd.ProductName;
                    lines["Description"] = objOd.tblProduct.FullDescription;
                    lines["Quantity"] = Convert.ToInt32(objOd.OrderQty);
                    arrayLines.Add(lines);
                }
                obj["Lines"] = arrayLines;
                obj["SupplierName"] = o.tblSupplier.Name;
                obj["SupplierOrderDate"] = DateTime.Now;
                obj["SupplierNo"] = o.tblSupplier.SupplierNo;
                obj["OrderType"] = 300;

                return await this.AddSupplierOrder(obj);
            }
        }
        private async Task<string> AddSupplierOrder(JObject model)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var uri = new Uri(Utilities.URL + "SupplierOrders");
                    var json = JsonConvert.SerializeObject(model);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(uri, stringContent);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var content = JObject.Parse(await response.Content.ReadAsStringAsync());
                        if (content["SupplierOrderNo"] is JValue)
                        {
                            return content["SupplierOrderNo"].ToString();
                        }
                        else
                            return null;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                return null;
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

        #region PurchasOrderLog
        private Guid SavePurchasOrderLog(DBLayer.tblPurchasOrder obj)
        {
            try
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    var tbl = new DBLayer.tblPurchasOrderLog();
                    tbl.CreateBy = obj.CreateBy;
                    tbl.CreationDate = obj.CreationDate;
                    tbl.SupplierId  = obj.SupplierId;
                    tbl.Description = obj.Description;
                    tbl.IsVISMA = obj.IsVISMA;
                    tbl.ModifyBy = obj.ModifyBy;
                    tbl.ModifyDate = obj.ModifyDate;
                    tbl.Name = obj.Name;
                    tbl.PurchasOrderDate = obj.PurchasOrderDate;
                    tbl.PurchasOrderId = obj.PurchasOrderId;
                    tbl.PurchasOrderLogId  = Guid.NewGuid();
                    tbl.StatusId = obj.StatusId;
                    tbl.ActualDeliveryDate = obj.ActualDeliveryDate;
                    tbl.ExpectDeliveryDate = obj.ExpectDeliveryDate;
                    tbl.IsAllItemReceive = obj.IsAllItemReceive;
                    DB.tblPurchasOrderLogs.Add(tbl);
                    DB.SaveChanges();
                    return tbl.PurchasOrderLogId;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SavePurchasOrderDetailLog(DBLayer.tblPurchasOrderDetail obj, Guid PurchasOrderLogId)
        {
            try
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    var tbl = new DBLayer.tblPurchasOrderDetailLog();
                    tbl.CreateBy = obj.CreateBy;
                    tbl.CreationDate = obj.CreationDate;
                    tbl.ModifyBy = obj.ModifyBy;
                    tbl.ModifyDate = obj.ModifyDate;
                    tbl.PurchasOrderId = obj.PurchasOrderId;
                    tbl.PurchasOrderLogId  = PurchasOrderLogId;
                    tbl.StatusId = obj.StatusId;
                    tbl.PurchaseOrderHistory = obj.PurchaseOrderHistory;
                    tbl.PurchasOrderDetailId = obj.PurchasOrderDetailId;
                    tbl.PurchasOrderDetailLogId = Guid.NewGuid();
                    tbl.ProductId = obj.ProductId;
                    tbl.ProductName = obj.ProductName;
                    tbl.CustomerId = obj.CustomerId;
                    tbl.IsAllItemReceive = obj.IsAllItemReceive;
                    tbl.OrderDetailId = obj.OrderDetailId;
                    tbl.OrderId = obj.OrderId;
                    tbl.OrderPrice = obj.OrderPrice;
                    tbl.OrderQty = obj.OrderQty;
                    tbl.OrderPrice = obj.OrderPrice;
                    tbl.OrderQty = obj.OrderQty;
                    tbl.ProductUCPCode = obj.ProductUCPCode;
                    tbl.ReceiveDate = obj.ReceiveDate;
                    tbl.ReceiveQty = obj.ReceiveQty;
                    tbl.PurchaseOrderRemark  = obj.PurchaseOrderRemark;        
                    DB.tblPurchasOrderDetailLogs.Add(tbl);
                    DB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region OfferLog
        private Guid SaveOfferLog(DBLayer.tblOffer obj)
        {
            try
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    var tbl = new DBLayer.tblOfferLog();
                    tbl.CreateBy = obj.CreateBy;
                    tbl.CreationDate = obj.CreationDate;
                    tbl.CustomerId = obj.CustomerId;
                    tbl.Description = obj.Description;
                    tbl.IsVISMA = obj.IsVISMA;
                    tbl.ModifyBy = obj.ModifyBy;
                    tbl.ModifyDate = obj.ModifyDate;
                    tbl.Name = obj.Name;
                    tbl.OfferAcceptanceDate = obj.OfferAcceptanceDate;
                    tbl.OfferApprovalDate = obj.OfferApprovalDate;
                    tbl.OfferDate = obj.OfferDate;
                    tbl.OfferId = obj.OfferId;
                    tbl.OfferlogId = Guid.NewGuid();
                    tbl.StatusId = obj.StatusId;
                    DB.tblOfferLogs.Add(tbl);
                    DB.SaveChanges();
                    return tbl.OfferlogId;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SaveOfferDetailLog(DBLayer.tblOfferDetail obj, Guid OfferLogId)
        {
            try
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    var tbl = new DBLayer.tblOfferDetailLog();
                    tbl.CreateBy = obj.CreateBy;
                    tbl.CreationDate = obj.CreationDate;
                    tbl.ModifyBy = obj.ModifyBy;
                    tbl.ModifyDate = obj.ModifyDate;
                    tbl.OfferId = obj.OfferId;
                    tbl.OfferlogId = OfferLogId;
                    tbl.StatusId = obj.StatusId;
                    tbl.CustomerPrice = obj.CustomerPrice;
                    tbl.CustomerQty = obj.CustomerQty;
                    tbl.CustomerRemarks = obj.CustomerRemarks;
                    tbl.FinalPrice = obj.FinalPrice;
                    tbl.FinalQty = obj.FinalQty;
                    tbl.FinalRemarks = obj.FinalRemarks;
                    tbl.History = obj.History;
                    tbl.OfferDetailId = obj.OfferDetailId;
                    tbl.OfferDetailLogId = Guid.NewGuid();
                    tbl.OfferPrice = obj.OfferPrice;
                    tbl.OfferQty = obj.OfferQty;
                    tbl.OfferRemarks = obj.OfferRemarks;
                    tbl.ProductId = obj.ProductId;
                    tbl.ProductName = obj.ProductName;
                    tbl.ProductPrice = obj.ProductPrice;
                    tbl.ProductStock = obj.ProductStock;
                    DB.tblOfferDetailLogs.Add(tbl);
                    DB.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}