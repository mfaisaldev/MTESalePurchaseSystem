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
    public class OrdersController : Controller
    {
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

        #region Order
        public ActionResult Index()
        {
            try
            {
                //Get All roles
                var UserRoles = this.GetRoles();
                ViewBag.UserRoles = UserRoles;
                Collection<Order> myColl = new Collection<Order>();
                IEnumerable<Order> items = null;
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    var C = (from c in DB.tblOrders
                             join status in DB.tblStatus
                             on c.StatusId equals status.StatusId
                             join cus in DB.tblCustomers
                             on c.CustomerId equals cus.CustomerId
                             where c.StatusId != new Guid(Utilities.Status_Delete)
                             let Status = status.Name
                             let StatusId = status.StatusId
                             let Customer = cus.Name
                             select new { cus.UserName , c.OrderId, c.Name, Customer, c.CreationDate, Status, StatusId, c.OrderDate, c.ActualDeliveryDate, c.AcceptanceDeliveryDate }).OrderBy(x => x.CreationDate);

                    foreach (var ele in C)
                    {
                        if (UserRoles.Where(u => u.RoleId.ToString().ToUpper() == Utilities.Role_Customer).FirstOrDefault() != null)
                        {
                            if (ele.UserName == User.Identity.Name)
                            {
                                myColl.Add(new Order()
                                {
                                    OrderId = ele.OrderId,
                                    Name = ele.Name,
                                    myCustomer = ele.Customer,
                                    ActualDeliveryDate = ele.ActualDeliveryDate,
                                    AcceptanceDeliveryDate = ele.AcceptanceDeliveryDate,
                                    OrderDate = ele.OrderDate,
                                    myStatus = ele.Status,
                                    StatusId = ele.StatusId
                                });
                            }
                        }
                        else
                        {
                            myColl.Add(new Order()
                            {
                                OrderId = ele.OrderId,
                                Name = ele.Name,
                                myCustomer = ele.Customer,
                                ActualDeliveryDate = ele.ActualDeliveryDate,
                                AcceptanceDeliveryDate = ele.AcceptanceDeliveryDate,
                                OrderDate = ele.OrderDate,
                                myStatus = ele.Status,
                                StatusId = ele.StatusId
                            });
                        }
                    }
                    items = myColl as IEnumerable<Order>;
                    return View(items);
                }
            }
            catch
            {
                IEnumerable<Order> items = null;
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

                OrderModel om = new OrderModel();
                Order o = new Order();
                List<OrderDetail> odList = new List<OrderDetail>();
                if (Id != null)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        Guid OrderId = Guid.Parse(Id);
                        DBLayer.tblOrder tbl = (from g in DB.tblOrders
                                                where g.OrderId == OrderId
                                                select g).SingleOrDefault();
                        o.OrderId = tbl.OrderId;
                        o.Name = tbl.Name;
                        o.Description = tbl.Description;
                        o.myStatus = tbl.StatusId.ToString();
                        o.CustomerId = tbl.CustomerId;
                        o.OrderDate  = tbl.OrderDate;
                        o.ActualDeliveryDate  = tbl.ActualDeliveryDate;
                        o.AcceptanceDeliveryDate  = tbl.AcceptanceDeliveryDate;
                        o.myCustomer = tbl.tblCustomer.Name;
                        o.StatusId = tbl.StatusId;
                        var tblOrderDetail = (from g in DB.tblOrderDetails
                                              where g.OrderId == OrderId &
                                              g.StatusId != new Guid(Utilities.Status_Delete)

                                              select g).ToList();
                        foreach (var i in tblOrderDetail)
                        {
                            odList.Add(new OrderDetail()
                            {
                                myProduct = i.tblProduct.Name,
                                myStatus = i.tblStatu.Name,
                                OrderDetailId = i.OrderDetailId,
                                OrderId = i.OrderId,
                                OrderPrice = i.OrderPrice,
                                OrderQty = i.OrderQty,
                                OrderRemarks = i.OrderRemarks,
                                ProductId = i.ProductId,
                                ProductName = i.ProductName,
                                ProductPrice = i.ProductPrice,
                                ProductStock = i.ProductStock,
                                ProductUCPCode = i.ProductUCPCode,  
                                StatusId = i.StatusId
                            });
                        }
                    }
                }
                om.Order = o;
                om.OrderDetails = odList;
                return View(om);
            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
                return View(new OrderModel());
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Create Order")]
        public ActionResult Create(OrderModel om)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblOrder t = new DBLayer.tblOrder();
                        var NewOrderId = Guid.NewGuid();
                        t.CreateBy = User.Identity.Name;
                        t.CreationDate = DateTime.Now;
                        t.CustomerId = om.Order.CustomerId;
                        t.Description = om.Order.Description;
                        t.IsVISMA = false;
                        t.Name = om.Order.Name;
                        t.OrderDate = om.Order.OrderDate;
                        t.ActualDeliveryDate  = om.Order.ActualDeliveryDate;
                        t.AcceptanceDeliveryDate  = om.Order.AcceptanceDeliveryDate;
                        t.OrderId = NewOrderId;
                        t.StatusId = new Guid(Utilities.Status_Initialize);
                        DB.tblOrders.Add(t);
                        DB.SaveChanges();
                        return RedirectToAction("Create", "Orders", new { Id = NewOrderId });
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Edit Order")]
        public async Task<ActionResult> Edit(OrderModel om, FormCollection fc)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                string[] OrderRemarks = fc["item.OrderRemarks"].ToString().Split(',');
                string[] OrderDetailId = fc["item.OrderDetailId"].ToString().Split(',');


                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    DBLayer.tblOrder t = (from g in DB.tblOrders
                                          where g.OrderId == om.Order.OrderId
                                          select g).SingleOrDefault();

                    t.ModifyBy = User.Identity.Name;
                    t.ModifyDate = DateTime.Now;
                    t.AcceptanceDeliveryDate = om.Order.AcceptanceDeliveryDate;
                    DB.SaveChanges();
                    var odlst = new Collection<DBLayer.tblOrderDetail>();

                    for (int n = 0; n < OrderDetailId.Length; n++)
                    {
                        var Id = new Guid(OrderDetailId[n]);
                        DBLayer.tblOrderDetail tbl = (from g in DB.tblOrderDetails
                                                      where g.OrderDetailId == Id
                                                      select g).SingleOrDefault();
                        tbl.OrderRemarks = OrderRemarks[n];
                        tbl.ModifyBy = User.Identity.Name;
                        tbl.ModifyDate = DateTime.Now;
                        DB.SaveChanges();
                        odlst.Add(tbl);
                    }

                    //Update VISMA
                    //bool isUpdate = await this.UpdateOrder(o, odlst);
                    //return RedirectToAction("Index", "Orders");
                    var OrderNo = await this.UpdateSalesOrders(t, odlst, false);
                    if (!String.IsNullOrEmpty(OrderNo))
                    {
                        return RedirectToAction("Index", "Orders");
                    }
                    else
                    {
                        ViewBag.Error = "Records is successfull update in B2B but unable to update VISMA";
                        return View(om);
                    }
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Order Delivered")]
        public async Task<ActionResult> OrderDelivered(OrderModel om, FormCollection fc)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                string[] OrderRemarks = fc["item.OrderRemarks"].ToString().Split(',');
                string[] OrderDetailId = fc["item.OrderDetailId"].ToString().Split(',');


                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    DBLayer.tblOrder t = (from g in DB.tblOrders
                                          where g.OrderId == om.Order.OrderId
                                          select g).SingleOrDefault();

                    t.ModifyBy = User.Identity.Name;
                    t.ModifyDate = DateTime.Now;
                    t.AcceptanceDeliveryDate = om.Order.AcceptanceDeliveryDate;
                    t.AcceptanceDeliveryDate = om.Order.ActualDeliveryDate;
                    t.StatusId = new Guid(Utilities.Order_Delivered);
                    DB.SaveChanges();
                    var odlst = new Collection<DBLayer.tblOrderDetail>();

                    for (int n = 0; n < OrderDetailId.Length; n++)
                    {
                        var Id = new Guid(OrderDetailId[n]);
                        DBLayer.tblOrderDetail tbl = (from g in DB.tblOrderDetails
                                                      where g.OrderDetailId == Id
                                                      select g).SingleOrDefault();
                        tbl.OrderRemarks = OrderRemarks[n];
                        tbl.ModifyBy = User.Identity.Name;
                        tbl.ModifyDate = DateTime.Now;
                        tbl.StatusId = new Guid(Utilities.Order_Delivered);
                        DB.SaveChanges();
                        odlst.Add(tbl);

                    }

                    //Update VISMA
                    //bool isUpdate = await this.UpdateOrder(o, odlst);
                    //return RedirectToAction("Index", "Orders");
                    var OrderNo = await this.UpdateSalesOrders(t, odlst, false);
                    if (!String.IsNullOrEmpty(OrderNo))
                    {
                        return RedirectToAction("Index", "Orders");
                    }
                    else
                    {
                        ViewBag.Error = "Records is successfull update in B2B but unable to update VISMA";
                        return View(om);
                    }

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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Order")]
        public async Task<ActionResult> CustomerOrder(Product p)
        {
            try
            {
                var UserRoles = this.GetRoles();

                if (UserRoles.Where(u => u.RoleId.ToString().ToUpper() == Utilities.Role_Customer).FirstOrDefault() != null)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        var OrderId= Guid.NewGuid();
                        var c = DB.tblCustomers.Where(u => u.UserName == User.Identity.Name && u.StatusId.ToString() != Utilities.Status_Delete).SingleOrDefault();
                        var o = new DBLayer.tblOrder();
                        o.CreateBy = User.Identity.Name;
                        o.CreationDate = DateTime.Now;
                        o.CustomerId = c.CustomerId; 
                        o.Description = "";
                        o.IsVISMA = false;
                        o.Name = "Order by Customer " + o.Name;
                        o.OrderDate = DateTime.Now;
                        o.StatusId = new Guid(Utilities.Order_Initialized);
                        o.OrderId = OrderId;
                        DB.tblOrders.Add(o);  
                        DB.SaveChanges();

                        var od = new DBLayer.tblOrderDetail();
                        od.CreateBy = User.Identity.Name;
                        od.CreationDate = DateTime.Now;
                        od.OrderDetailId = Guid.NewGuid();
                        od.OrderId = o.OrderId;
                        od.OrderPrice = p.Price;
                        od.OrderQty = p.OrderQty;
                        od.ProductId = p.ProductId;
                        od.ProductName = p.Name;
                        od.ProductPrice = p.Price;
                        od.ProductStock = p.ProductStock;
                        od.ProductUCPCode = p.UPC_code;
                        od.StatusId  = new Guid(Utilities.Order_Initialized);
                        DB.tblOrderDetails.Add(od); 
                        DB.SaveChanges();

                        var odlst = new Collection<DBLayer.tblOrderDetail>();
                        odlst.Add(od);

                        //Update VISMA
                        //bool isUpdate = await this.UpdateOrder(o, odlst);
                        //return RedirectToAction("Index", "Orders");
                        var OrderNo = await this.UpdateSalesOrders(o, odlst,true);
                        if (!String.IsNullOrEmpty(OrderNo))
                        {
                            DBLayer.tblOrder
                                order = (from g in DB.tblOrders
                                                      where g.OrderId == OrderId
                                                      select g).SingleOrDefault();
                            order.OrderNo = OrderNo;
                            DB.SaveChanges();
                            return RedirectToAction("Index", "Orders");
                        }
                        else
                        {
                            ViewBag.Error = "Records is successfull update in B2B but unable to update VISMA";
                            return View(o);
                        }
                    }
                }
                else
                    return RedirectToAction("Customer", "Products");
            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
                return View(p);
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Delete Order")]
        public ActionResult Delete(OrderModel om, FormCollection fc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string[] OrderDetailId = fc["item.OrderDetailId"].ToString().Split(',');
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblOrder t = (from g in DB.tblOrders
                                              where g.OrderId == om.Order.OrderId
                                              select g).SingleOrDefault();

                        t.ModifyBy = User.Identity.Name;
                        t.ModifyDate = DateTime.Now;
                        t.StatusId = new Guid(Utilities.Status_Delete);
                        DB.SaveChanges();

                        for (int n = 0; n < OrderDetailId.Length; n++)
                        {
                            var Id = new Guid(OrderDetailId[n]);
                            DBLayer.tblOrderDetail tbl = (from g in DB.tblOrderDetails
                                                          where g.OrderDetailId == Id
                                                          select g).SingleOrDefault();
                            tbl.ModifyBy = User.Identity.Name;
                            tbl.ModifyDate = DateTime.Now;
                            tbl.StatusId = new Guid(Utilities.Status_Delete);
                            DB.SaveChanges();
                        }
                        return RedirectToAction("Index", "Orders");
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
        #endregion

        #region UpdateVisma
        private async Task<string> UpdateSalesOrders(DBLayer.tblOrder  o,Collection<DBLayer.tblOrderDetail> ColOd,bool IsAdd)
        {
            using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
            {
                var obj = new JObject();
                int nTotal = 0;
                var arrayLines = new JArray();
                foreach (DBLayer.tblOrderDetail od in ColOd)
                {
                    var lines = new JObject();
                    lines["Amount"] = Convert.ToInt32(od.OrderPrice);
                    lines["ArticleNo"] = od.tblProduct.ArticleNo;
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
                    lines["Name"] = od.ProductName;
                    lines["NetDeliveryAmount"] = 0;
                    lines["NetPrice"] = 0;
                    lines["ProductNo"] = 0;
                    lines["Quantity"] = Convert.ToInt32(od.OrderQty);
                    arrayLines.Add(lines);
                    nTotal = nTotal + Convert.ToInt32(od.OrderQty);
                }
                obj["Lines"] = arrayLines;
                obj["CustomerName"] = o.tblCustomer.Name;
                obj["OrderDate"] = DateTime.Now;
                obj["DeliveryDate"] = DateTime.Now.AddDays(10);
                obj["TotalAmount"] = nTotal;
                obj["CustomerNo"] = Convert.ToInt32(o.tblCustomer.CustomerNo);
                obj["OrderType"] = 100;
                if(IsAdd)
                {
                    return await this.AddSalesOrder(obj);
                }
                else
                {
                    obj["OrderNo"] = o.OrderNo;
                    return await this.UpdateSalesOrder(obj);
                }
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
        private async Task<string> UpdateSalesOrder(JObject model)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(model);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpRequestMessage request = new HttpRequestMessage
                    {
                        Method = new HttpMethod("PATCH"),
                        RequestUri = new Uri(Utilities.URL + "SalesOrders/" + model["OrderNo"].ToString()),
                        Content = stringContent,
                    };
                    var response = await client.SendAsync(request);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        return model["OrderNo"].ToString();
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //private const string Lines = "Lines";
        //private async Task<bool> UpdateOrder(DBLayer.tblOrder o, List<DBLayer.tblOrderDetail> odList)
        //{
        //    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
        //    {
        //        var lst = new List<vOrderLine>();
        //        var c = DB.tblCustomers.Where(u => u.CustomerId == o.CustomerId).FirstOrDefault();
        //        var vc = DB.vCustomers.Where(u => u.CustomerNo  ==c.CustomerNo).FirstOrDefault();

        //        var obj = new vOrder();
        //        obj.CustomerNo = Convert.ToInt32(c.CustomerNo);
        //        obj.TotalAmount = Convert.ToDecimal(o.TotalAcount);
        //        obj.YourReference = o.OrderId.ToString();
        //        obj.CashPaymentYesNo = o.OfferId == null ? true : false;
        //        try
        //        {
        //            obj.ContactNoDelivery = Convert.ToInt32(c.ContactNoConfirmOrder);
        //            obj.ContactNoInvoice = Convert.ToInt32(c.ContactNoConfirmOrder);
        //        }
        //        catch (Exception)
        //        {
        //            obj.ContactNoDelivery = 0;
        //            obj.ContactNoInvoice = 0;
        //        }
        //        obj.CustomerName = c.Name;
        //        obj.CompanyNo = c.OrganizationNumber;
        //        obj.DeliveryAddress1 = c.Address1;
        //        obj.DeliveryAddress2 = c.Address2;
        //        obj.DeliveryPostCode = "";
        //        obj.DeliveryPostOffice = c.PostOffice;
        //        if (o.EmployeeId != null)
        //            obj.EmployeeNo = Convert.ToInt32(DB.tblEmployees.Where(u => u.EmployeeId == o.EmployeeId).FirstOrDefault().EmployeeNo);
        //        obj.InvoiceAddress1 = c.Address1;
        //        obj.InvoiceAddress2 = c.Address2;
        //        obj.InvoiceEmailAddress = c.Email;
        //        obj.InvoicePostOffice = c.PostOffice;
        //        obj.OrderDate = Convert.ToDateTime(o.OrderDate);
        //        obj.CustomerGrpNo = Convert.ToInt32(vc.CustomerGrpNo);
        //        obj.DepNo =  Convert.ToInt32(vc.DepNo);

        //        obj.OrderType = 100;
        //        obj.OurRef = ""; 
        //        obj.InvoicePostCode = "";
        //        obj.FactCustomerNo = "";
        //        obj.OriginalOrderNo = "";
        //        obj.OrderStatus = 1000;
        //        obj.VATCode = 1;
        //        obj.TermsOfPayCustNo = 1;

        //        int count = 1;
        //        foreach (var od in odList)
        //        {
        //            var p = DB.tblProducts.Where(u => u.ProductId == od.ProductId).FirstOrDefault();
        //            var vod = new vOrderLine();
        //            vod.Amount = Convert.ToDecimal(od.OrderPrice);
        //            vod.ArticleNo = p.UPC_code;
        //            vod.EmployeeNo = obj.EmployeeNo;
        //            if (!(p.IntermediateGroupId == Guid.Empty || p.IntermediateGroupId ==null) )
        //                vod.IntermediateGroupNo = Convert.ToInt32(DB.tblIntermediateGroups.Where(u => u.IntermediateGroupId == p.IntermediateGroupId).FirstOrDefault().IntermediateGroupNo);
        //            if (!(p.MainGroupId != Guid.Empty || p.MainGroupId != null))
        //                vod.MainGroupNo = Convert.ToInt32(DB.tblMainGroups.Where(u => u.MainGroupId == p.MainGroupId).FirstOrDefault().MainGroupNo);
        //            vod.Name = p.Name;
        //            vod.OrderDate = obj.OrderDate;
        //            vod.Quantity = Convert.ToInt32(od.OrderQty);
        //            if (!(p.SubGroupId != Guid.Empty || p.SubGroupId != null))
        //                vod.SubGroupNo = Convert.ToInt32(DB.tblSubGroups.Where(u => u.SubGroupId == p.SubGroupId).FirstOrDefault().SubGroupNo);
        //            vod.PostingTemplateNo = 1;
        //            vod.GLSalesAccountNo = 3000;
        //            vod.AltArtNo = ""; 
        //            vod.EANNo = "";
        //            vod.PLUNo = "";
        //            vod.OrderStatus = 1000;
        //            vod.TaxClassNo = 1;
        //            vod.VATCode = 1;
        //            vod.WareHouseNo = 3;
        //            vod.UniqueId = count;
        //            lst.Add(vod);
        //            count = count + 1;
        //            obj.TotalVAT = Convert.ToDecimal(p.Price);
        //            obj.TotalAmount = Convert.ToDecimal(p.Price);

        //        }
        //        bool isUpdate = await this.AddOrder(obj, lst);
        //        return isUpdate;
        //    }
        //}
        //private async Task<bool> AddOrder(vOrder model, List<vOrderLine> lst)
        //{
        //    try
        //    {
        //        var ar = new JArray(); 
        //        foreach(var vol in lst)
        //            ar.Add(JObject.Parse(new JavaScriptSerializer().Serialize(vol)));

        //        var obj = JObject.Parse(new JavaScriptSerializer().Serialize(model));
        //        obj[Lines] = ar;
        //        var json = JsonConvert.SerializeObject(obj);
        //        using (var client = new HttpClient())
        //        {
        //            var uri = new Uri(Utilities.URL + "salesorders");
        //            var stringContent = new StringContent(json,  Encoding.UTF8, "application/json");
        //            var response = await client.PostAsync(uri, stringContent);
        //            if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //                return true;
        //            else
        //                return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        #endregion

    }
}