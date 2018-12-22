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
using System.Web.Script.Serialization;

namespace Admin.Controllers
{
    public class OffersController : Controller
    {
        //#region AddProduct
        //[HttpGet]
        //[Authorize]
        //public ActionResult ProductSearch(ProductSearch m, string Id)
        //{
        //    try
        //    {
        //        if (Id != null)
        //        {
        //            List<Product> myColl = new List<Product>();
        //            List<MainGroup> maingroup = new List<MainGroup>();
        //            List<IntermediateGroup> intermediategroup = new List<IntermediateGroup>();
        //            List<SubGroup> subgroup = new List<SubGroup>();
        //            List<Supplier> supplier = new List<Supplier>();
        //            using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
        //            {
        //                // Add MainGroup
        //                maingroup.Add(new MainGroup()
        //                {
        //                    MainGroupId = Guid.Empty,
        //                    Name = "All Main Group"
        //                });
        //                var tblMainGroup = DB.tblMainGroups.Where(x => x.StatusId != new Guid(Utilities.Status_Delete)).ToList();
        //                foreach (var ele in tblMainGroup)
        //                {
        //                    maingroup.Add(new MainGroup()
        //                    {
        //                        MainGroupId = ele.MainGroupId,
        //                        Name = ele.Name
        //                    });
        //                }
        //                ViewBag.MainGroup = maingroup;

        //                // Add IntermediateGroup
        //                intermediategroup.Add(new IntermediateGroup()
        //                {
        //                    IntermediateGroupId = Guid.Empty,
        //                    Name = "All Intermediate Group"
        //                });
        //                var tblIntermediateGroup = DB.tblIntermediateGroups.Where(x => x.StatusId != new Guid(Utilities.Status_Delete)).ToList();
        //                foreach (var ele in tblIntermediateGroup)
        //                {
        //                    intermediategroup.Add(new IntermediateGroup()
        //                    {
        //                        IntermediateGroupId = ele.IntermediateGroupId,
        //                        Name = ele.Name
        //                    });
        //                }
        //                ViewBag.IntermediateGroup = intermediategroup;

        //                // Add Supplier
        //                supplier.Add(new Supplier()
        //                {
        //                    SupplierId = Guid.Empty,
        //                    Name = "All Suppliers"
        //                });
        //                var tblSupplier = DB.tblSuppliers.Where(x => x.StatusId != new Guid(Utilities.Status_Delete));
        //                foreach (var ele in tblSupplier)
        //                {
        //                    supplier.Add(new Supplier()
        //                    {
        //                        SupplierId = ele.SupplierId,
        //                        Name = ele.Name
        //                    });
        //                }
        //                ViewBag.Supplier = supplier;

        //                // Add SubGroup
        //                subgroup.Add(new SubGroup()
        //                {
        //                    SubGroupId = Guid.Empty,
        //                    Name = "All Sub Group"
        //                });
        //                var tblSubGroup = DB.tblSubGroups.Where(x => x.StatusId != new Guid(Utilities.Status_Delete)).ToList();
        //                foreach (var ele in tblSubGroup)
        //                {
        //                    subgroup.Add(new SubGroup()
        //                    {
        //                        SubGroupId = ele.SubGroupId,
        //                        Name = ele.Name
        //                    });
        //                }
        //                ViewBag.SubGroup = subgroup;


        //                if (m.Search)
        //                {
        //                    if (m.page == 0)
        //                    {
        //                        m.page = 1;
        //                        myColl = this.GetProducts(m, Id, 0, 500);
        //                    }else
        //                    {
        //                        int start = (m.page -1) * 500;
        //                        myColl = this.GetProducts(m, Id, start, 500);
        //                    }
        //                    m.count = myColl.Count();
        //                }

        //                m.Products = myColl;
        //                return View(m);
        //            }
        //        }
        //        else
        //        {
        //            return RedirectToAction("Index", "Offers");
        //        }
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //[HttpPost]
        //[Authorize]
        //[ValidateAntiForgeryToken]
        //[MultiButton(MatchFormKey = "action", MatchFormValue = "Add Products")]
        //public ActionResult ProductAdd(ProductSearch m, FormCollection fc)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            this.ProductSave(m, fc); 
        //            return RedirectToAction("Create", "Offers", new { id = m.Offer } );
        //        }
        //        else
        //        {
        //            return View(m);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.ExceptionMessage = ex.Message;
        //        return View(m);
        //    }
        //}

        //[HttpPost]
        //[Authorize]
        //[ValidateAntiForgeryToken]
        //[MultiButton(MatchFormKey = "action", MatchFormValue = "Next")]
        //public ActionResult ProductNext(ProductSearch m, FormCollection fc)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            this.ProductSave(m, fc);
        //            m.page = m.page + 1;
        //            return RedirectToAction("ProductSearch", "Offers", new { id = m.Offer, page= m.page, count= m.count, ProductName =m.ProductName, UPC_code=m.UPC_code, MainGroup= m.MainGroup,  IntermediateGroup = m.IntermediateGroup, SubGroup = m.SubGroup, Supplier = m.Supplier , OfferName =m.OfferName, Search=true, } );
        //        }
        //        else
        //        {
        //            return View(m);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.ExceptionMessage = ex.Message;
        //        return View(m);
        //    }
        //}

        //[HttpPost]
        //[Authorize]
        //[ValidateAntiForgeryToken]
        //[MultiButton(MatchFormKey = "action", MatchFormValue = "Back")]
        //public ActionResult ProductBack(ProductSearch m, FormCollection fc)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            this.ProductSave(m, fc);
        //            if(m.page>0)
        //                m.page = m.page - 1;
        //            return RedirectToAction("ProductSearch", "Offers", new { id = m.Offer, page = m.page, count = m.count, ProductName = m.ProductName, UPC_code = m.UPC_code, MainGroup = m.MainGroup, IntermediateGroup = m.IntermediateGroup, SubGroup = m.SubGroup, Supplier = m.Supplier, OfferName = m.OfferName, Search = true, });
        //        }
        //        else
        //        {
        //            return View(m);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.ExceptionMessage = ex.Message;
        //        return View(m);
        //    }
        //}

        //private void ProductSave(ProductSearch m, FormCollection fc)
        //{
        //    List<Product> Products = new List<Product>();
        //    string[] chks = fc["item.IsAllow"].ToString().Split(',');
        //    string[] pId = fc["item.ProductId"].ToString().Split(',');
        //    int count = 0;
        //    for (int n = 0; n < chks.Length; n++)
        //    {
        //        if (chks[n] == "true")
        //        {
        //            Product product = new Product();
        //            product.ProductId = new Guid(pId[count]);
        //            Products.Add(product);
        //            n++;
        //        }
        //        count++;
        //    }

        //    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
        //    {
        //        //Delete All record
        //        List<DBLayer.tblOfferDetail> listod = DB.tblOfferDetails.Where(x => x.OfferId == m.Offer).ToList();
        //        foreach (DBLayer.tblOfferDetail obj in listod)
        //        {
        //            if (Products.Where(u => u.ProductId == obj.ProductId).FirstOrDefault() == null)
        //            {
        //              if(Array.IndexOf(pId, obj.ProductId.ToString()) >-1)
        //                DB.tblOfferDetails.Remove(obj);
        //            }
        //        }
        //        DB.SaveChanges();
        //        //Add Select Records
        //        foreach (Product p in Products)
        //        {
        //            DBLayer.tblOfferDetail tblOd = DB.tblOfferDetails.Where(u => u.ProductId == p.ProductId && u.OfferId == m.Offer).SingleOrDefault();
        //            if (tblOd == null)
        //            {
        //                DBLayer.tblProduct tblp = DB.tblProducts.Where(u => u.ProductId == p.ProductId).SingleOrDefault();
        //                tblOd = new DBLayer.tblOfferDetail();
        //                tblOd.OfferDetailId = Guid.NewGuid();
        //                tblOd.ProductId = p.ProductId;
        //                tblOd.OfferId = m.Offer;
        //                tblOd.ProductName = tblp.Name;
        //                tblOd.ProductPrice = tblp.Price;
        //                tblOd.ProductStock = tblp.ProductStock;
        //                tblOd.History = this.GetProductHistory(p.ProductId);
        //                tblOd.StatusId = new Guid(Utilities.Status_Active);
        //                tblOd.CreateBy = User.Identity.Name;
        //                tblOd.CreationDate = DateTime.Now;
        //                DB.tblOfferDetails.Add(tblOd);
        //            }
        //        }
        //        DB.SaveChanges();
        //    }
        //}

        //private string GetProductHistory(Guid ProductId)
        //{
        //    try
        //    {
        //        string strHistory = "";
        //        using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
        //        {
        //            List<DBLayer.tblProductHistory> listph = DB.tblProductHistories.Where(x => x.ProductId  == ProductId && x.StatusId.ToString() != Utilities.Status_Delete).ToList();
        //            foreach(var ph in listph)
        //            {
        //                strHistory += "Customer : " + ph.tblCustomer.Name + ", ";
        //                strHistory += "Price : " + ph.Price + ", ";
        //                strHistory += "Qty : " + ph.Qty + ", ";
        //                strHistory += "Sale Date : " + ph.SaleDate + "   ";
        //            }
        //        }
        //            return strHistory;
        //    } catch(Exception ex)
        //    {
        //        throw ex;
        //    }

        //}
        //#endregion

        #region AddProduct
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
                    return RedirectToAction("Index", "Offers");
                }
            }
            catch
            {
                return View();
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
                    return RedirectToAction("Create", "Offers", new { id = m.Offer });
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
                    return RedirectToAction("ProductSearch", "Offers", new { id = m.Offer, page = m.page, count = m.count, ProductName = m.ProductName, UPC_code = m.UPC_code, Brand = m.Brand, Category = m.Category, Supplier = m.Supplier, OfferName = m.OfferName, Search = true, });
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
                    return RedirectToAction("ProductSearch", "Offers", new { id = m.Offer, page = m.page, count = m.count, ProductName = m.ProductName, UPC_code = m.UPC_code, Brand = m.Brand, Category = m.Category, Supplier = m.Supplier, OfferName = m.OfferName, Search = true, });
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
                List<DBLayer.tblOfferDetail> listod = DB.tblOfferDetails.Where(x => x.OfferId == m.Offer).ToList();
                foreach (DBLayer.tblOfferDetail obj in listod)
                {
                    if (Products.Where(u => u.ProductId == obj.ProductId).FirstOrDefault() == null)
                    {
                        if (Array.IndexOf(pId, obj.ProductId.ToString()) > -1)
                            DB.tblOfferDetails.Remove(obj);
                    }
                }
                DB.SaveChanges();
                //Add Select Records
                foreach (Product p in Products)
                {
                    DBLayer.tblOfferDetail tblOd = DB.tblOfferDetails.Where(u => u.ProductId == p.ProductId && u.OfferId == m.Offer).SingleOrDefault();
                    if (tblOd == null)
                    {
                        DBLayer.tblProduct tblp = DB.tblProducts.Where(u => u.ProductId == p.ProductId).SingleOrDefault();
                        tblOd = new DBLayer.tblOfferDetail();
                        tblOd.OfferDetailId = Guid.NewGuid();
                        tblOd.ProductId = p.ProductId;
                        tblOd.OfferId = m.Offer;
                        tblOd.ProductName = tblp.Name;
                        tblOd.ProductPrice = tblp.Price;
                        tblOd.ProductStock = tblp.ProductStock;
                        tblOd.History = this.GetProductHistory(p.ProductId);
                        tblOd.StatusId = new Guid(Utilities.Status_Active);
                        tblOd.CreateBy = User.Identity.Name;
                        tblOd.CreationDate = DateTime.Now;
                        DB.tblOfferDetails.Add(tblOd);
                    }
                }
                DB.SaveChanges();
            }
        }

        private string GetProductHistory(Guid ProductId)
        {
            try
            {
                string strHistory = "";
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    List<DBLayer.tblProductHistory> listph = DB.tblProductHistories.Where(x => x.ProductId == ProductId && x.StatusId.ToString() != Utilities.Status_Delete).ToList();
                    foreach (var ph in listph)
                    {
                        strHistory += "Customer : " + ph.tblCustomer.Name + ", ";
                        strHistory += "Price : " + ph.Price + ", ";
                        strHistory += "Qty : " + ph.Qty + ", ";
                        strHistory += "Sale Date : " + ph.SaleDate + "   ";
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

        #region Offer
        public ActionResult Index()
        {
            try
            {
                //Get All roles
                var UserRoles = this.GetRoles();
                ViewBag.UserRoles = UserRoles;
                Collection<Offer> myColl = new Collection<Offer>();
                IEnumerable<Offer> items = null;
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    var C = (from c in DB.tblOffers
                             join status in DB.tblStatus
                             on c.StatusId equals status.StatusId
                             join cus in DB.tblCustomers
                             on c.CustomerId equals cus.CustomerId
                             where c.StatusId != new Guid(Utilities.Status_Delete)
                             let Status = status.Name
                             let StatusId = status.StatusId
                             let Customer = cus.Name
                             select new { cus.UserName ,c.CreateBy, c.OfferId, c.Name, Customer, c.CreationDate, Status, StatusId, c.OfferAcceptanceDate, c.OfferApprovalDate, c.OfferDate }).OrderBy(x => x.CreationDate);

                    foreach (var ele in C)
                    {
                        if (UserRoles.Where(u => u.RoleId.ToString().ToUpper() == Utilities.Role_Sales_Representative).FirstOrDefault() != null)
                        {
                            if (ele.CreateBy == User.Identity.Name)
                            {
                                myColl.Add(new Offer()
                                {
                                    OfferId = ele.OfferId,
                                    Name = ele.Name,
                                    myCustomer = ele.Customer,
                                    OfferAcceptanceDate = ele.OfferAcceptanceDate,
                                    OfferApprovalDate = ele.OfferApprovalDate,
                                    OfferDate = ele.OfferDate,
                                    myStatus = ele.Status,
                                    StatusId = ele.StatusId
                                });
                            }
                        }
                        else if (UserRoles.Where(u => u.RoleId.ToString().ToUpper() == Utilities.Role_Sales_Manager).FirstOrDefault() != null)
                        {
                            if (ele.StatusId.ToString() == Utilities.Status_Initially_in_Process || ele.StatusId.ToString() == Utilities.Status_Finally_in_Process)
                            {
                                myColl.Add(new Offer()
                                {
                                    OfferId = ele.OfferId,
                                    Name = ele.Name,
                                    myCustomer = ele.Customer,
                                    OfferAcceptanceDate = ele.OfferAcceptanceDate,
                                    OfferApprovalDate = ele.OfferApprovalDate,
                                    OfferDate = ele.OfferDate,
                                    myStatus = ele.Status,
                                    StatusId = ele.StatusId
                                });
                            }
                        }
                        else if (UserRoles.Where(u => u.RoleId.ToString().ToUpper() == Utilities.Role_Customer).FirstOrDefault() != null)
                        {
                            if (ele.UserName == User.Identity.Name)
                            {
                                if (ele.StatusId.ToString() == Utilities.Status_Initially_Approved || ele.StatusId.ToString() == Utilities.Status_Customer_Accepted || ele.StatusId.ToString() == Utilities.Status_Customer_Rejected || ele.StatusId.ToString() == Utilities.Status_Finally_in_Process || ele.StatusId.ToString() == Utilities.Status_Finally_Approved || ele.StatusId.ToString() == Utilities.Status_Finally_Rejected)
                                {
                                    myColl.Add(new Offer()
                                    {
                                        OfferId = ele.OfferId,
                                        Name = ele.Name,
                                        myCustomer = ele.Customer,
                                        OfferAcceptanceDate = ele.OfferAcceptanceDate,
                                        OfferApprovalDate = ele.OfferApprovalDate,
                                        OfferDate = ele.OfferDate,
                                        myStatus = ele.Status,
                                        StatusId = ele.StatusId
                                    });
                                }
                            }
                        }
                    }
                    items = myColl as IEnumerable<Offer>;
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

                OfferModel om = new OfferModel();
                Offer o = new Offer();
                List<OfferDetail> odList = new List<OfferDetail>(); 
                if (Id != null)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        Guid OfferId = Guid.Parse(Id);
                        DBLayer.tblOffer tbl = (from g in DB.tblOffers
                                                where g.OfferId == OfferId
                                                select g).SingleOrDefault();
                        o.OfferId = tbl.OfferId;
                        o.Name = tbl.Name;
                        o.Description = tbl.Description;
                        o.myStatus = tbl.StatusId.ToString();
                        o.CustomerId = tbl.CustomerId;

                       var tblOfferDetail = (from g in DB.tblOfferDetails 
                                                where g.OfferId == OfferId &
                                                g.StatusId != new Guid(Utilities.Status_Delete)

                                                select g).ToList();
                        foreach(var i in tblOfferDetail)
                        {
                            odList.Add(new OfferDetail()
                            {
                                CustomerPrice = i.CustomerPrice,
                                CustomerQty = i.CustomerQty,
                                CustomerRemarks = i.CustomerRemarks,
                                FinalPrice = i.FinalPrice,
                                FinalQty = i.FinalQty,
                                FinalRemarks = i.FinalRemarks,
                                History = i.History,
                                myProduct = i.tblProduct.Name,
                                myStatus = i.tblStatu.Name,
                                OfferDetailId = i.OfferDetailId,
                                OfferId = i.OfferId,
                                OfferPrice = i.OfferPrice,
                                OfferQty = i.OfferQty,
                                OfferRemarks = i.OfferRemarks,
                                ProductId = i.ProductId,
                                ProductName = i.ProductName,
                                ProductPrice = i.ProductPrice,
                                ProductStock = i.ProductStock,
                                StatusId = i.StatusId
                            });
                        }
                    }
                }
                om.Offer = o;
                om.OfferDetails = odList;
                return View(om);
            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
                return View(new OfferModel());
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Add Product")]
        public ActionResult AddProductOffer(OfferModel om)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(om.Offer.OfferId != Guid.Empty)
                    {
                        return RedirectToAction("ProductSearch", "Offers",new { Id = om.Offer.OfferId, OfferName = om.Offer.Name });
                    }else
                    {
                        using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                        {
                            var OfferId = Guid.NewGuid();
                            var tbl = new DBLayer.tblOffer();
                            tbl.StatusId = new Guid(Utilities.Status_Initialize);
                            tbl.CreationDate = DateTime.Now;
                            tbl.CreateBy = User.Identity.Name;
                            tbl.CustomerId = om.Offer.CustomerId;
                            tbl.Description = om.Offer.Description;
                            tbl.IsVISMA = false;
                            tbl.Name = om.Offer.Name;
                            tbl.OfferId = OfferId;
                            tbl.OfferDate = DateTime.Now;
                            this.SaveOfferLog(tbl);
                            DB.tblOffers.Add(tbl);
                            DB.SaveChanges();
                            return RedirectToAction("ProductSearch", "Offers", new { Id = OfferId ,OfferName = om.Offer.Name} );
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Create Offer")]
        public ActionResult Create(OfferModel om)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblOffer t = new DBLayer.tblOffer();
                        var NewOfferId = Guid.NewGuid();
                        t.CreateBy = User.Identity.Name;
                        t.CreationDate = DateTime.Now;
                        t.CustomerId = om.Offer.CustomerId;
                        t.Description = om.Offer.Description;
                        t.IsVISMA = false;
                        t.Name = om.Offer.Name;
                        t.OfferDate = DateTime.Now;
                        t.OfferId = NewOfferId;
                        t.StatusId = new Guid(Utilities.Status_Initialize);
                        this.SaveOfferLog(t);
                        DB.tblOffers.Add(t);
                        DB.SaveChanges();
                        return RedirectToAction("Create", "Offers", new { Id = NewOfferId } );
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Edit Offer")]
        public ActionResult Edit(OfferModel om, FormCollection fc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string[] OfferPrice = fc["item.OfferPrice"].ToString().Split(',');
                    string[] OfferRemarks = fc["item.OfferRemarks"].ToString().Split(',');
                    string[] OfferDetailId = fc["item.OfferDetailId"].ToString().Split(',');
                    string[] OfferQty = fc["item.OfferQty"].ToString().Split(',');
                   

                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblOffer t = (from g in DB.tblOffers
                                              where g.OfferId == om.Offer.OfferId
                                              select g).SingleOrDefault();

                        t.ModifyBy = User.Identity.Name;
                        t.ModifyDate = DateTime.Now;
                        t.CustomerId = om.Offer.CustomerId;
                        t.Description = om.Offer.Description;
                        t.Name = om.Offer.Name;
                        var OfferLogId =this.SaveOfferLog(t);
                        DB.SaveChanges();

                        for (int n = 0; n < OfferDetailId.Length; n++)
                        {
                            var Id = new Guid(OfferDetailId[n]);
                            DBLayer.tblOfferDetail tbl = (from g in DB.tblOfferDetails
                                                          where g.OfferDetailId ==Id 
                                                          select g).SingleOrDefault();
                            tbl.OfferPrice = String.IsNullOrWhiteSpace(OfferPrice[n]) ? 0 : System.Convert.ToDecimal(OfferPrice[n]);
                            tbl.OfferQty = String.IsNullOrWhiteSpace(OfferQty[n])?0: System.Convert.ToInt32(OfferQty[n]);
                            tbl.OfferRemarks = OfferRemarks[n];
                            tbl.ModifyBy = User.Identity.Name;
                            tbl.ModifyDate = DateTime.Now;
                            this.SaveOfferDetailLog(tbl,OfferLogId);
                            DB.SaveChanges();

                        }

                        return  RedirectToAction("Create", "Offers",  new { id = om.Offer.OfferId });
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Delete Offer")]
        public ActionResult Delete(OfferModel  om, FormCollection fc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string[] OfferDetailId = fc["item.OfferDetailId"].ToString().Split(',');
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblOffer t = (from g in DB.tblOffers
                                              where g.OfferId == om.Offer.OfferId
                                              select g).SingleOrDefault();

                        t.ModifyBy = User.Identity.Name;
                        t.ModifyDate = DateTime.Now;
                        t.StatusId = new Guid(Utilities.Status_Delete);
                        var OfferLogId = this.SaveOfferLog(t);
                        DB.SaveChanges();

                        for (int n = 0; n < OfferDetailId.Length; n++)
                        {
                            var Id = new Guid(OfferDetailId[n]);
                            DBLayer.tblOfferDetail tbl = (from g in DB.tblOfferDetails
                                                          where g.OfferDetailId == Id
                                                          select g).SingleOrDefault();
                            tbl.ModifyBy = User.Identity.Name;
                            tbl.ModifyDate = DateTime.Now;
                            tbl.StatusId = new Guid(Utilities.Status_Delete);
                            this.SaveOfferDetailLog(tbl, OfferLogId);
                            DB.SaveChanges();
                        }
                        return RedirectToAction("Index", "Offers");
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Initailly Submit")]
        public ActionResult InitaillySubmit(OfferModel om, FormCollection fc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string[] OfferDetailId = fc["item.OfferDetailId"].ToString().Split(',');
                    string[] OfferPrice = fc["item.OfferPrice"].ToString().Split(',');
                    string[] OfferRemarks = fc["item.OfferRemarks"].ToString().Split(',');
                    string[] OfferQty = fc["item.OfferQty"].ToString().Split(',');

                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblOffer t = (from g in DB.tblOffers
                                              where g.OfferId == om.Offer.OfferId
                                              select g).SingleOrDefault();

                        t.ModifyBy = User.Identity.Name;
                        t.ModifyDate = DateTime.Now;
                        t.StatusId = new Guid(Utilities.Status_Initially_in_Process);
                        var OfferLogId = this.SaveOfferLog(t);
                        DB.SaveChanges();

                        for (int n = 0; n < OfferDetailId.Length; n++)
                        {
                            var Id = new Guid(OfferDetailId[n]);
                            DBLayer.tblOfferDetail tbl = (from g in DB.tblOfferDetails
                                                          where g.OfferDetailId == Id
                                                          select g).SingleOrDefault();
                            tbl.OfferPrice = String.IsNullOrWhiteSpace(OfferPrice[n]) ? 0 : System.Convert.ToDecimal(OfferPrice[n]);
                            tbl.OfferQty = String.IsNullOrWhiteSpace(OfferQty[n]) ? 0 : System.Convert.ToInt32(OfferQty[n]);
                            tbl.OfferRemarks = OfferRemarks[n];
                            tbl.ModifyBy = User.Identity.Name;
                            tbl.ModifyDate = DateTime.Now;
                            tbl.StatusId = new Guid(Utilities.Status_Initially_in_Process);
                            this.SaveOfferDetailLog(tbl, OfferLogId);
                            DB.SaveChanges();
                        }
                        return RedirectToAction("Index", "Offers");
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Initailly Approved")]
        public ActionResult InitaillyApproved(OfferModel om, FormCollection fc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string[] OfferDetailId = fc["item.OfferDetailId"].ToString().Split(',');
                    string[] OfferPrice = fc["item.OfferPrice"].ToString().Split(',');
                    string[] OfferRemarks = fc["item.OfferRemarks"].ToString().Split(',');
                    string[] OfferQty = fc["item.OfferQty"].ToString().Split(',');
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblOffer t = (from g in DB.tblOffers
                                              where g.OfferId == om.Offer.OfferId
                                              select g).SingleOrDefault();

                        t.ModifyBy = User.Identity.Name;
                        t.ModifyDate = DateTime.Now;
                        t.StatusId = new Guid(Utilities.Status_Initially_Approved);
                        var OfferLogId = this.SaveOfferLog(t);
                        DB.SaveChanges();

                        for (int n = 0; n < OfferDetailId.Length; n++)
                        {
                            var Id = new Guid(OfferDetailId[n]);
                            DBLayer.tblOfferDetail tbl = (from g in DB.tblOfferDetails
                                                          where g.OfferDetailId == Id
                                                          select g).SingleOrDefault();
                            tbl.OfferPrice = String.IsNullOrWhiteSpace(OfferPrice[n]) ? 0 : System.Convert.ToDecimal(OfferPrice[n]);
                            tbl.OfferQty = String.IsNullOrWhiteSpace(OfferQty[n]) ? 0 : System.Convert.ToInt32(OfferQty[n]);
                            tbl.OfferRemarks = OfferRemarks[n];
                            tbl.ModifyBy = User.Identity.Name;
                            tbl.ModifyDate = DateTime.Now;
                            tbl.StatusId = new Guid(Utilities.Status_Initially_Approved);
                            tbl.CustomerPrice = tbl.OfferPrice;
                            tbl.CustomerQty = tbl.OfferQty;
                            this.SaveOfferDetailLog(tbl, OfferLogId);
                            DB.SaveChanges();
                        }
                        return RedirectToAction("Index", "Offers");
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Initailly Rejected")]
        public ActionResult InitaillyRejected(OfferModel om, FormCollection fc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string[] OfferDetailId = fc["item.OfferDetailId"].ToString().Split(',');
                    string[] OfferPrice = fc["item.OfferPrice"].ToString().Split(',');
                    string[] OfferRemarks = fc["item.OfferRemarks"].ToString().Split(',');
                    string[] OfferQty = fc["item.OfferQty"].ToString().Split(',');
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblOffer t = (from g in DB.tblOffers
                                              where g.OfferId == om.Offer.OfferId
                                              select g).SingleOrDefault();

                        t.ModifyBy = User.Identity.Name;
                        t.ModifyDate = DateTime.Now;
                        t.StatusId = new Guid(Utilities.Status_Initially_Rejected);
                        var OfferLogId = this.SaveOfferLog(t);
                        DB.SaveChanges();

                        for (int n = 0; n < OfferDetailId.Length; n++)
                        {
                            var Id = new Guid(OfferDetailId[n]);
                            DBLayer.tblOfferDetail tbl = (from g in DB.tblOfferDetails
                                                          where g.OfferDetailId == Id
                                                          select g).SingleOrDefault();
                            tbl.OfferPrice = String.IsNullOrWhiteSpace(OfferPrice[n]) ? 0 : System.Convert.ToDecimal(OfferPrice[n]);
                            tbl.OfferQty = String.IsNullOrWhiteSpace(OfferQty[n]) ? 0 : System.Convert.ToInt32(OfferQty[n]);
                            tbl.OfferRemarks = OfferRemarks[n];
                            tbl.ModifyBy = User.Identity.Name;
                            tbl.ModifyDate = DateTime.Now;
                            tbl.StatusId = new Guid(Utilities.Status_Initially_Rejected);
                            this.SaveOfferDetailLog(tbl, OfferLogId);
                            DB.SaveChanges();
                        }
                        return RedirectToAction("Index", "Offers");
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
        public ActionResult CustomerApproved(OfferModel om, FormCollection fc)
        {
            try
            {
                    string[] CustomerPrice = fc["item.CustomerPrice"].ToString().Split(',');
                    string[] CustomerRemarks = fc["item.CustomerRemarks"].ToString().Split(',');
                    string[] OfferDetailId = fc["item.OfferDetailId"].ToString().Split(',');
                    string[] CustomerQty = fc["item.CustomerQty"].ToString().Split(',');

                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblOffer t = (from g in DB.tblOffers
                                              where g.OfferId == om.Offer.OfferId
                                              select g).SingleOrDefault();

                        t.ModifyBy = User.Identity.Name;
                        t.ModifyDate = DateTime.Now;
                        t.StatusId = new Guid(Utilities.Status_Customer_Accepted);
                    var OfferLogId = this.SaveOfferLog(t);
                    DB.SaveChanges();

                        for (int n = 0; n < OfferDetailId.Length; n++)
                        {
                            var Id = new Guid(OfferDetailId[n]);
                            DBLayer.tblOfferDetail tbl = (from g in DB.tblOfferDetails
                                                          where g.OfferDetailId == Id
                                                          select g).SingleOrDefault();
                            tbl.CustomerPrice = String.IsNullOrWhiteSpace(CustomerPrice[n]) ? 0 : System.Convert.ToDecimal(CustomerPrice[n]);
                            tbl.CustomerQty = String.IsNullOrWhiteSpace(CustomerQty[n]) ? 0 : System.Convert.ToInt32(CustomerQty[n]);
                            tbl.CustomerRemarks = CustomerRemarks[n];
                            tbl.ModifyBy = User.Identity.Name;
                            tbl.ModifyDate = DateTime.Now;
                            tbl.StatusId = new Guid(Utilities.Status_Customer_Accepted);
                        this.SaveOfferDetailLog(tbl, OfferLogId);
                        DB.SaveChanges();
                        }
                        return RedirectToAction("Index", "Offers");
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Deny")]
        public ActionResult CustomerRejected(OfferModel om, FormCollection fc)
        {
            try
            {
                    string[] CustomerPrice = fc["item.CustomerPrice"].ToString().Split(',');
                    string[] CustomerRemarks = fc["item.CustomerRemarks"].ToString().Split(',');
                    string[] OfferDetailId = fc["item.OfferDetailId"].ToString().Split(',');
                    string[] CustomerQty = fc["item.CustomerQty"].ToString().Split(',');
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblOffer t = (from g in DB.tblOffers
                                              where g.OfferId == om.Offer.OfferId
                                              select g).SingleOrDefault();

                        t.ModifyBy = User.Identity.Name;
                        t.ModifyDate = DateTime.Now;
                    t.StatusId = new Guid(Utilities.Status_Customer_Rejected);
                    var OfferLogId = this.SaveOfferLog(t);
                    DB.SaveChanges();

                        for (int n = 0; n < OfferDetailId.Length; n++)
                        {
                            var Id = new Guid(OfferDetailId[n]);
                            DBLayer.tblOfferDetail tbl = (from g in DB.tblOfferDetails
                                                          where g.OfferDetailId == Id
                                                          select g).SingleOrDefault();
                            tbl.CustomerPrice = String.IsNullOrWhiteSpace(CustomerPrice[n]) ? 0 : System.Convert.ToDecimal(CustomerPrice[n]);
                            tbl.CustomerQty = String.IsNullOrWhiteSpace(CustomerQty[n]) ? 0 : System.Convert.ToInt32(CustomerQty[n]);
                            tbl.CustomerRemarks = CustomerRemarks[n];
                            tbl.ModifyBy = User.Identity.Name;
                            tbl.ModifyDate = DateTime.Now;
                            tbl.StatusId = new Guid(Utilities.Status_Customer_Rejected);
                        this.SaveOfferDetailLog(tbl, OfferLogId);
                        DB.SaveChanges();
                        }
                        return RedirectToAction("Index", "Offers");
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Finally Submit")]
        public ActionResult FinallySubmit(OfferModel om, FormCollection fc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string[] FinalPrice = fc["item.FinalPrice"].ToString().Split(',');
                    string[] FinalRemarks = fc["item.FinalRemarks"].ToString().Split(',');
                    string[] OfferDetailId = fc["item.OfferDetailId"].ToString().Split(',');
                    string[] FinalQty = fc["item.FinalQty"].ToString().Split(',');
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblOffer t = (from g in DB.tblOffers
                                              where g.OfferId == om.Offer.OfferId
                                              select g).SingleOrDefault();


                        t.ModifyBy = User.Identity.Name;
                        t.ModifyDate = DateTime.Now;
                        t.StatusId = new Guid(Utilities.Status_Finally_in_Process);
                        var OfferLogId = this.SaveOfferLog(t);
                        DB.SaveChanges();

                        for (int n = 0; n < OfferDetailId.Length; n++)
                        {
                            var Id = new Guid(OfferDetailId[n]);
                            DBLayer.tblOfferDetail tbl = (from g in DB.tblOfferDetails
                                                          where g.OfferDetailId == Id
                                                          select g).SingleOrDefault();
                            tbl.FinalPrice = String.IsNullOrWhiteSpace(FinalPrice[n]) ? 0 : System.Convert.ToDecimal(FinalPrice[n]);
                            tbl.FinalQty = String.IsNullOrWhiteSpace(FinalQty[n]) ? 0 : System.Convert.ToInt32(FinalQty[n]);
                            tbl.FinalRemarks = FinalRemarks[n];

                            tbl.ModifyBy = User.Identity.Name;
                            tbl.ModifyDate = DateTime.Now;
                            tbl.StatusId = new Guid(Utilities.Status_Finally_in_Process);
                            this.SaveOfferDetailLog(tbl, OfferLogId);
                            DB.SaveChanges();
                        }
                        return RedirectToAction("Index", "Offers");
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Finally Approved")]
        public async System.Threading.Tasks.Task<ActionResult> FinallyApproved(OfferModel om, FormCollection fc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var col = new Collection<DBLayer.tblOfferDetail>();
                    string[] FinalPrice = fc["item.FinalPrice"].ToString().Split(',');
                    string[] FinalRemarks = fc["item.FinalRemarks"].ToString().Split(',');
                    string[] OfferDetailId = fc["item.OfferDetailId"].ToString().Split(',');
                    string[] FinalQty = fc["item.FinalQty"].ToString().Split(',');
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblOffer t = (from g in DB.tblOffers
                                              where g.OfferId == om.Offer.OfferId
                                              select g).SingleOrDefault();

                        t.ModifyBy = User.Identity.Name;
                        t.ModifyDate = DateTime.Now;
                        t.StatusId = new Guid(Utilities.Status_Finally_Approved);
                        var OfferLogId = this.SaveOfferLog(t);
                        DB.SaveChanges();
                        var OrderId = this.SaveOrder(t);
                         
                        for (int n = 0; n < OfferDetailId.Length; n++)
                        {
                            var Id = new Guid(OfferDetailId[n]);
                            DBLayer.tblOfferDetail tbl = (from g in DB.tblOfferDetails
                                                          where g.OfferDetailId == Id
                                                          select g).SingleOrDefault();
                            tbl.FinalPrice = String.IsNullOrWhiteSpace(FinalPrice[n]) ? 0 : System.Convert.ToDecimal(FinalPrice[n]);
                            tbl.FinalQty = String.IsNullOrWhiteSpace(FinalQty[n]) ? 0 : System.Convert.ToInt32(FinalQty[n]);
                            tbl.FinalRemarks = FinalRemarks[n];
                            tbl.ModifyBy = User.Identity.Name;
                            tbl.ModifyDate = DateTime.Now;
                            tbl.StatusId = new Guid(Utilities.Status_Finally_Approved);
                            this.SaveOfferDetailLog(tbl, OfferLogId);
                            DB.SaveChanges();
                            this.SaveOrderDetail(tbl, OrderId);
                            col.Add(tbl);

                            // Save History 
                            var ph = new DBLayer.tblProductHistory();
                            ph.CreateBy = User.Identity.Name;
                            ph.CreationDate = DateTime.Now;
                            ph.CustomerId = t.CustomerId;
                            ph.Price = Convert.ToDecimal(tbl.FinalPrice);
                            ph.ProductHistoryId = Guid.NewGuid();
                            ph.ProductId = tbl.ProductId;
                            ph.ProductName = tbl.ProductName;
                            ph.Qty = Convert.ToInt32(tbl.FinalQty);
                            ph.Remarks = tbl.FinalRemarks;
                            ph.SaleDate = DateTime.Now;
                            ph.StatusId = new Guid(Utilities.Status_Active);
                            DB.tblProductHistories.Add(ph);
                            DB.SaveChanges();                              
                        }

                        //Update VISMA
                        var OrderNo = await this.UpdateSalesOrders(t,col);
                        if (!String.IsNullOrEmpty(OrderNo))
                        {
                            DBLayer.tblOrder order = (from g in DB.tblOrders
                                                      where g.OrderId  == OrderId
                                                      select g).SingleOrDefault();
                            order.OrderNo = OrderNo;
                            DB.SaveChanges();
                            return RedirectToAction("Index", "Offers");
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Finally Rejected")]
        public ActionResult FinallyRejected(OfferModel om, FormCollection fc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string[] FinalPrice = fc["item.FinalPrice"].ToString().Split(',');
                    string[] FinalRemarks = fc["item.FinalRemarks"].ToString().Split(',');
                    string[] OfferDetailId = fc["item.OfferDetailId"].ToString().Split(',');
                    string[] FinalQty = fc["item.FinalQty"].ToString().Split(',');
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblOffer t = (from g in DB.tblOffers
                                              where g.OfferId == om.Offer.OfferId
                                              select g).SingleOrDefault();

                        t.ModifyBy = User.Identity.Name;
                        t.ModifyDate = DateTime.Now;
                        t.StatusId = new Guid(Utilities.Status_Finally_Rejected);
                        var OfferLogId = this.SaveOfferLog(t);
                        DB.SaveChanges();

                        for (int n = 0; n < OfferDetailId.Length; n++)
                        {
                            var Id = new Guid(OfferDetailId[n]);
                            DBLayer.tblOfferDetail tbl = (from g in DB.tblOfferDetails
                                                          where g.OfferDetailId == Id
                                                          select g).SingleOrDefault();
                            tbl.FinalPrice = String.IsNullOrWhiteSpace(FinalPrice[n]) ? 0 : System.Convert.ToDecimal(FinalPrice[n]);
                            tbl.FinalQty = String.IsNullOrWhiteSpace(FinalQty[n]) ? 0 : System.Convert.ToInt32(FinalQty[n]);
                            tbl.FinalRemarks = FinalRemarks[n];
                            tbl.ModifyBy = User.Identity.Name;
                            tbl.ModifyDate = DateTime.Now;
                            tbl.StatusId = new Guid(Utilities.Status_Finally_Rejected);
                            this.SaveOfferDetailLog(tbl, OfferLogId);
                            DB.SaveChanges();
                        }
                        return RedirectToAction("Index", "Offers");

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

        #region UpdateVisma
        //{
        //  "Lines": [
        //    {
        //      "OrderDate": "2017-05-10T06:59:13.544Z",
        //      "Amount": 100,
        //      "ArticleNo": "999999790026",
        //      "DeliveryDate": "2017-05-10T06:59:13.544Z",
        //      "DiscountI": 0,
        //      "DiscountII": 0,
        //      "DistributionFormulaNo": 0,
        //      "EmployeeNo": 0,
        //      "ExchangeAmount": 0,
        //      "ExchangeRate": 0,
        //      "ExchangeSalesPrice": 0,
        //      "FullCost": 0,
        //      "GLSalesAccountNo": 3000,
        //      "GrossPrice": 0,
        //      "IntermediateGroupNo": 0,
        //      "MainGroupNo": 0,
        //      "Name": "Test",
        //      "NetDeliveryAmount": 0,
        //      "NetPrice": 0,
        //      "ProductNo": 0,
        //      "ProjectNo": 0,
        //      "Quantity": 10,
        //    }
        //  ],
        //  "CustomerName": "Testkunde",
        //  "OrderDate": "2017-05-10T06:59:13.544Z",
        //  "DeliveryDate": "2017-05-10T06:59:13.544Z",
        //  "TotalAmount": 10000,
        //  "CustomerNo": 10343,
        //  "OrderType": 100
        //}

        private async Task<string> UpdateSalesOrders(DBLayer.tblOffer o,Collection<DBLayer.tblOfferDetail> od)
        {
            using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
            {
                var obj = new JObject();
                int nTotal = 0;
                var arrayLines = new JArray();
                foreach (DBLayer.tblOfferDetail objOd in od)
                {
                    var lines = new JObject();
                    lines["Amount"] = Convert.ToInt32(objOd.FinalPrice);
                    lines["ArticleNo"] = objOd.tblProduct.ArticleNo;
                    lines["DeliveryDate"] = DateTime.Now.AddDays(10);
                    lines["DiscountI"] = 0;
                    lines["DiscountII"] = 0;
                    lines["DistributionFormulaNo"] = 0;
                    lines["EmployeeNo"] = 0;
                    lines["ExchangeAmount"] = 0;
                    lines["ExchangeRate"] = 0;
                    lines["ExchangeSalesPrice"] = 0;
                    lines["FullCost"] = 0;
                    lines["GLSalesAccountNo"] = 3000;
                    lines["GrossPrice"] = 0;
                    lines["IntermediateGroupNo"] = 0;
                    lines["MainGroupNo"] = 0;
                    lines["Name"] = objOd.ProductName;
                    lines["NetDeliveryAmount"] = 0;
                    lines["NetPrice"] = 0;
                    lines["ProductNo"] = 0;
                    lines["Quantity"] = Convert.ToInt32(objOd.FinalQty);
                    arrayLines.Add(lines);
                    nTotal = nTotal + Convert.ToInt32(objOd.FinalPrice);
                }
                obj["Lines"] = arrayLines;
                obj["CustomerName"] = o.tblCustomer.Name;
                obj["OrderDate"] = DateTime.Now;
                obj["DeliveryDate"] = DateTime.Now.AddDays(10);
                obj["TotalAmount"] = nTotal;
                obj["CustomerNo"] = Convert.ToInt32(o.tblCustomer.CustomerNo);
                obj["OrderType"] = 100;

                return await this.AddSalesOrder(obj);
            }
        }
        private async Task<string> AddSalesOrder(JObject model)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var uri = new Uri(Utilities.URL + "SalesOrders");
                    var json = JsonConvert.SerializeObject(model);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(uri, stringContent);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var content = JObject.Parse(await response.Content.ReadAsStringAsync());
                        if (content["OrderNo"] is JValue)
                        {
                            return content["OrderNo"].ToString();
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

        private Guid SaveOrder(DBLayer.tblOffer o)
        {
            try
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    var tbl = new DBLayer.tblOrder();
                    tbl.CreateBy = User.Identity.Name;
                    tbl.CreationDate = DateTime.Now;
                    tbl.CustomerId = o.CustomerId;
                    tbl.Description = o.Description;
                    tbl.IsVISMA = o.IsVISMA;
                    tbl.Name = o.Name;
                    tbl.OfferId = o.OfferId;
                    tbl.OrderDate = DateTime.Now;
                    tbl.OrderId = Guid.NewGuid();
                    tbl.StatusId = new Guid(Utilities.Order_Initialized);
                    DB.tblOrders.Add(tbl);
                    DB.SaveChanges();
                    return tbl.OrderId;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void SaveOrderDetail(DBLayer.tblOfferDetail od, Guid OrderId)
        {
            try
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    var tbl = new DBLayer.tblOrderDetail();
                    tbl.CreateBy = User.Identity.Name;
                    tbl.CreationDate = DateTime.Now;
                    tbl.OfferDetailId = od.OfferDetailId;
                    tbl.OrderDetailId = Guid.NewGuid();
                    tbl.OrderId = OrderId;
                    tbl.OrderPrice = od.FinalPrice;
                    tbl.OrderQty = od.FinalQty;
                    tbl.OrderRemarks = od.FinalRemarks;
                    tbl.ProductId = od.ProductId;
                    tbl.ProductName = od.ProductName;
                    tbl.ProductPrice = od.ProductPrice;
                    tbl.ProductStock = od.ProductStock;
                    tbl.ProductUCPCode =od.tblProduct.UPC_code;
                    tbl.StatusId = new Guid(Utilities.Order_Initialized);
                    DB.tblOrderDetails.Add(tbl);
                    DB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
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

        #region OfferLog
        private  Guid SaveOfferLog(DBLayer.tblOffer obj)
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
            } catch ( Exception ex )
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

        //private List<Product> GetProducts(ProductSearch m, string Id, int start, int end)
        //{
        //    var myColl = new List<Product>();
        //    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
        //    {
        //        var tblProduct = (from p in DB.tblProducts
        //                          join s in DB.tblStatus
        //                          on p.StatusId equals s.StatusId
        //                          where p.StatusId != new Guid(Utilities.Status_Delete)
        //                          let Status = s.Name
        //                          let StatusId = s.StatusId
        //                          select new { p.ProductId, p.Name, Status, StatusId, p.MainGroupId, p.IntermediateGroupId, p.SubGroupId, p.SupplierId, p.UPC_code }).OrderBy(x => x.Name).Skip(start).Take(end); 
        //        if (!String.IsNullOrWhiteSpace(m.ProductName))
        //            tblProduct = tblProduct.Where(p => p.Name.Contains(m.ProductName));
        //        if (!String.IsNullOrWhiteSpace(m.UPC_code))
        //            tblProduct = tblProduct.Where(p => p.UPC_code.Contains(m.UPC_code)); 
        //        if (m.MainGroup!=Guid.Empty)
        //            tblProduct = tblProduct.Where(p => p.MainGroupId.ToString().Contains(m.MainGroup.ToString()));
        //        if (m.IntermediateGroup != Guid.Empty)
        //            tblProduct = tblProduct.Where(p => p.IntermediateGroupId.ToString().Contains(m.IntermediateGroup.ToString()));
        //        if (m.SubGroup != Guid.Empty)
        //            tblProduct = tblProduct.Where(p => p.SubGroupId.ToString().Contains(m.SubGroup.ToString()));
        //        if (m.Supplier != Guid.Empty)
        //            tblProduct = tblProduct.Where(p => p.SupplierId.ToString().Contains(m.Supplier.ToString()));

        //        foreach (var ele in tblProduct)
        //        {
        //            myColl.Add(new Product()
        //            {
        //                ProductId = ele.ProductId,
        //                Name = ele.Name,
        //                UPC_code = ele.UPC_code,
        //                myStatus = ele.Status,
        //                StatusId = ele.StatusId
        //            });
        //        }

        //        var od = DB.tblOfferDetails.Where(u => u.OfferId.ToString() == Id).ToList();
        //        foreach (Product p in myColl)
        //        {
        //            if (od.Where(u => u.ProductId == p.ProductId && u.OfferId.ToString() == Id).FirstOrDefault() != null)
        //                p.IsAllow = true;
        //        }
        //    }
        //    return myColl;
        //}

        private List<Product> GetProducts(ProductSearch m, string Id, int start, int end)
        {
            var myColl = new List<Product>();
            using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
            {
                //Search by Brand
                if (m.Supplier == Guid.Empty && string.IsNullOrWhiteSpace(m.ProductName) && string.IsNullOrWhiteSpace(m.UPC_code))
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
                            StatusId = ele.StatusId
                            //,
                            //IsAllow = DB.tblOfferDetails.Where(u => u.ProductId == ele.ProductId && u.OfferId.ToString() == Id).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Supplier != Guid.Empty  && string.IsNullOrWhiteSpace(m.ProductName) && string.IsNullOrWhiteSpace(m.UPC_code))
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
                                      select new { p.ProductId, p.Name, Status, StatusId, p.UPC_code }).OrderBy(x => x.Name).Skip(start).Take(end); ;
                    foreach (var ele in tblProduct)
                    {
                        myColl.Add(new Product()
                        {
                            ProductId = ele.ProductId,
                            Name = ele.Name,
                            UPC_code = ele.UPC_code,
                            myStatus = ele.Status,
                            StatusId = ele.StatusId
                            //,
                            //IsAllow = DB.tblOfferDetails.Where(u => u.ProductId == ele.ProductId && u.OfferId.ToString() == Id).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Supplier != Guid.Empty  && !string.IsNullOrWhiteSpace(m.ProductName) && string.IsNullOrWhiteSpace(m.UPC_code))
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
                                      select new { p.ProductId, p.Name, Status, StatusId, p.UPC_code }).OrderBy(x => x.Name).Skip(start).Take(end); ;
                    foreach (var ele in tblProduct)
                    {
                        myColl.Add(new Product()
                        {
                            ProductId = ele.ProductId,
                            Name = ele.Name,
                            myStatus = ele.Status,
                            UPC_code = ele.UPC_code,
                            StatusId = ele.StatusId
                            //,
                            //IsAllow = DB.tblOfferDetails.Where(u => u.ProductId == ele.ProductId && u.OfferId.ToString() == Id).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Supplier != Guid.Empty && string.IsNullOrWhiteSpace(m.ProductName) && !string.IsNullOrWhiteSpace(m.UPC_code))
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
                                      select new { p.ProductId, p.Name, Status, StatusId, p.UPC_code }).OrderBy(x => x.Name).Skip(start).Take(end); ;
                    foreach (var ele in tblProduct)
                    {
                        myColl.Add(new Product()
                        {
                            ProductId = ele.ProductId,
                            Name = ele.Name,
                            myStatus = ele.Status,
                            UPC_code = ele.UPC_code,
                            StatusId = ele.StatusId
                            //,
                            //IsAllow = DB.tblOfferDetails.Where(u => u.ProductId == ele.ProductId && u.OfferId.ToString() == Id).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Supplier != Guid.Empty && !string.IsNullOrWhiteSpace(m.ProductName) && !string.IsNullOrWhiteSpace(m.UPC_code))
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
                                      select new { p.ProductId, p.Name, Status, StatusId, p.UPC_code }).OrderBy(x => x.Name).Skip(start).Take(end); ;
                    foreach (var ele in tblProduct)
                    {
                        myColl.Add(new Product()
                        {
                            ProductId = ele.ProductId,
                            Name = ele.Name,
                            myStatus = ele.Status,
                            UPC_code = ele.UPC_code,
                            StatusId = ele.StatusId
                            //,
                            //IsAllow = DB.tblOfferDetails.Where(u => u.ProductId == ele.ProductId && u.OfferId.ToString() == Id).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Supplier == Guid.Empty  && !string.IsNullOrWhiteSpace(m.ProductName) && string.IsNullOrWhiteSpace(m.UPC_code) )
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join s in DB.tblStatus
                                      on p.StatusId equals s.StatusId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (p.Name == m.ProductName || p.Name.Contains(m.ProductName))
                                      let Status = s.Name
                                      let StatusId = s.StatusId
                                      select new { p.ProductId, p.Name, Status, StatusId, p.UPC_code }).OrderBy(x => x.Name).Skip(start).Take(end); ;
                    foreach (var ele in tblProduct)
                    {
                        myColl.Add(new Product()
                        {
                            ProductId = ele.ProductId,
                            Name = ele.Name,
                            UPC_code = ele.UPC_code,
                            myStatus = ele.Status,
                            StatusId = ele.StatusId
                            //,
                            //IsAllow = DB.tblOfferDetails.Where(u => u.ProductId == ele.ProductId && u.OfferId.ToString() == Id).FirstOrDefault() == null ? false : true
                        });
                    }

                }
                else if (m.Supplier == Guid.Empty  && string.IsNullOrWhiteSpace(m.ProductName) && !string.IsNullOrWhiteSpace(m.UPC_code))
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join s in DB.tblStatus
                                      on p.StatusId equals s.StatusId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (p.UPC_code == m.UPC_code || p.UPC_code.Contains(m.UPC_code))
                                      let Status = s.Name
                                      let StatusId = s.StatusId
                                      select new { p.ProductId, p.Name, Status, StatusId, p.UPC_code }).OrderBy(x => x.Name).Skip(start).Take(end); ;
                    foreach (var ele in tblProduct)
                    {
                        myColl.Add(new Product()
                        {
                            ProductId = ele.ProductId,
                            Name = ele.Name,
                            UPC_code = ele.UPC_code,
                            myStatus = ele.Status,
                            StatusId = ele.StatusId
                            //,
                            //IsAllow = DB.tblOfferDetails.Where(u => u.ProductId == ele.ProductId && u.OfferId.ToString() == Id).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                else if (m.Supplier == Guid.Empty && !string.IsNullOrWhiteSpace(m.ProductName) && !string.IsNullOrWhiteSpace(m.UPC_code) )
                {
                    var tblProduct = (from p in DB.tblProducts
                                      join s in DB.tblStatus
                                      on p.StatusId equals s.StatusId
                                      where p.StatusId != new Guid(Utilities.Status_Delete)
                                     && (p.Name == m.ProductName || p.Name.Contains(m.ProductName))
                                     && (p.UPC_code == m.UPC_code || p.UPC_code.Contains(m.UPC_code))
                                      let Status = s.Name
                                      let StatusId = s.StatusId
                                      select new { p.ProductId, p.Name, Status, StatusId, p.UPC_code }).OrderBy(x => x.Name).Skip(start).Take(end); ;
                    foreach (var ele in tblProduct)
                    {
                        myColl.Add(new Product()
                        {
                            ProductId = ele.ProductId,
                            Name = ele.Name,
                            UPC_code = ele.UPC_code,
                            myStatus = ele.Status,
                            StatusId = ele.StatusId
                            //,
                            //IsAllow = DB.tblOfferDetails.Where(u => u.ProductId == ele.ProductId && u.OfferId.ToString() == Id).FirstOrDefault() == null ? false : true
                        });
                    }
                }
                var od = DB.tblOfferDetails.Where(u => u.OfferId.ToString() == Id).ToList();
                foreach (Product p in myColl)
                {
                    if (od.Where(u => u.ProductId == p.ProductId && u.OfferId.ToString() == Id).FirstOrDefault() != null)
                        p.IsAllow = true;
                }
            }
            return myColl;
        }
    }

    #endregion
}

