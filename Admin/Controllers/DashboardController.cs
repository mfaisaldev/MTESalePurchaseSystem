using Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {

            //Get All roles
            var UserRoles = this.GetRoles();
            ViewBag.UserRoles = UserRoles;
            if (UserRoles.Where(u => u.RoleId.ToString().ToUpper() == Utilities.Role_Customer).FirstOrDefault() != null)
                return RedirectToAction("Customer", "Products");

            var obj = new Dashboard();

            using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
            {
                var customer = (from c in DB.tblCustomers
                          where c.StatusId.ToString() != Utilities.Status_Delete
                          select new { c.CustomerId });

                var suppliers = (from c in DB.tblSuppliers 
                                where c.StatusId.ToString() != Utilities.Status_Delete
                                select new { c.SupplierId });

                var products = (from c in DB.tblProducts 
                                 where c.StatusId.ToString() != Utilities.Status_Delete
                                 select new { c.ProductId });

                var offers = (from c in DB.tblOffers
                                where c.StatusId.ToString() != Utilities.Status_Delete
                                select new { c.OfferId, c.StatusId });

                var orders = (from c in DB.tblOrders 
                              where c.StatusId.ToString() != Utilities.Status_Delete
                              select new { c.OrderId, c.StatusId });

                var purchasOrders = (from c in DB.tblPurchasOrders
                              where c.StatusId.ToString() != Utilities.Status_Delete
                              select new { c.PurchasOrderId , c.StatusId });

                obj.Customers = customer.Count();
                obj.Offers = offers.Count();
                obj.Orders = orders.Count();
                obj.Products = products.Count();
                obj.Suppliers = suppliers.Count();
                obj.PruchaseOrders = purchasOrders.Count();

                obj.OfferCompleted = offers.Where(u => u.StatusId.ToString() == Utilities.Status_Finally_Approved).Count();
                try
                {
                    obj.OfferPersentage = Convert.ToInt32(Convert.ToDecimal(Convert.ToDecimal(obj.OfferCompleted) / Convert.ToDecimal(obj.Offers)) * 100) + "%";
                }
                catch
                {
                    obj.OfferPersentage = "0%";
                }

                obj.OrderCompleted = orders.Where(u => u.StatusId.ToString() == Utilities.Order_Delivered).Count();
                try
                {
                    obj.OrderPersentage = Convert.ToInt32(Convert.ToDecimal(Convert.ToDecimal(obj.OrderCompleted) / Convert.ToDecimal(obj.Orders)) * 100) + "%";
                }
                catch
                {
                    obj.OrderPersentage = "0%";
                }

                obj.POCompleted  = purchasOrders.Where(u => u.StatusId.ToString() == Utilities.Purchase_Order_Delivered).Count();
                try
                {
                    obj.POPersentage  = Convert.ToInt32(Convert.ToDecimal(Convert.ToDecimal(obj.POCompleted) / Convert.ToDecimal(obj.PruchaseOrders)) * 100) + "%";
                }
                catch
                {
                    obj.POPersentage = "0%";
                }

            }

            return View(obj);
        }
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
    }
}