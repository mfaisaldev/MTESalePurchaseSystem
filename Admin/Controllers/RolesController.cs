using Admin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class RolesController : Controller
    {

        [HttpGet]
        [Authorize]
        public ActionResult MenuAccess()
        {
            try
            {
                List<MenuSearch> myColl = new List<MenuSearch>();
                List<RoleMenu> RoleMenu = new List<RoleMenu>();

                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    var tblMenu = (from m in DB.tblMenus
                                      select new { m.MenuId ,m.Name,m.ParentMenuId, m.DisplayOrder}).OrderBy( x => x.DisplayOrder);
                    var tblRoleMenu = (from m in DB.tblRoleMenus
                                   select new { m.MenuId, m.RoleId });

                    foreach (var ele in tblRoleMenu)
                    {
                        RoleMenu.Add(new RoleMenu()
                        {
                            MenuId = ele.MenuId,
                            RoleId =ele.RoleId
                        });
                    }

                    foreach (var ele in tblMenu)
                    {
                        myColl.Add(new MenuSearch()
                        {
                            MenuId = ele.MenuId,
                            MenuName = ele.Name,
                            ParentMenuId= ele.ParentMenuId,
                            isAdmin=  RoleMenu.Where(u => u.MenuId == ele.MenuId &&   u.RoleId.ToString().ToUpper() == Utilities.Role_Admin).FirstOrDefault() != null,
                            isCFO = RoleMenu.Where(u => u.MenuId == ele.MenuId && u.RoleId.ToString().ToUpper() == Utilities.Role_CFO).FirstOrDefault() != null,
                            isCustomer = RoleMenu.Where(u => u.MenuId == ele.MenuId && u.RoleId.ToString().ToUpper() == Utilities.Role_Customer).FirstOrDefault() != null,
                            isOperations = RoleMenu.Where(u => u.MenuId == ele.MenuId && u.RoleId.ToString().ToUpper() == Utilities.Role_Operations).FirstOrDefault() != null,
                            isSales_Manager = RoleMenu.Where(u => u.MenuId == ele.MenuId && u.RoleId.ToString().ToUpper() == Utilities.Role_Sales_Manager).FirstOrDefault() != null,
                            isSales_Representative = RoleMenu.Where(u => u.MenuId == ele.MenuId && u.RoleId.ToString().ToUpper() == Utilities.Role_Sales_Representative).FirstOrDefault() != null,
                            isSupplier = RoleMenu.Where(u => u.MenuId == ele.MenuId && u.RoleId.ToString().ToUpper() == Utilities.Role_Supplier).FirstOrDefault() != null
                        });
                    }
                }
                return View(myColl);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult MenuAccessAdd(MenuSearch m, FormCollection fc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    List<RoleMenu> RoleMenus = new List<RoleMenu>();
                    string[] isAdmin = fc["item.isAdmin"].ToString().Split(',');
                    string[] isCFO = fc["item.isCFO"].ToString().Split(',');
                    string[] isCustomer = fc["item.isCustomer"].ToString().Split(',');
                    string[] isOperations = fc["item.isOperations"].ToString().Split(',');
                    string[] isSales_Manager = fc["item.isSales_Manager"].ToString().Split(',');
                    string[] isSales_Representative = fc["item.isSales_Representative"].ToString().Split(',');
                    string[] isSupplier = fc["item.isSupplier"].ToString().Split(',');
                    string[] MenuId = fc["item.MenuId"].ToString().Split(',');

                    SetValue(ref RoleMenus, isAdmin, MenuId,Utilities.Role_Admin );
                    SetValue(ref RoleMenus, isCFO, MenuId, Utilities.Role_CFO);
                    SetValue(ref RoleMenus, isCustomer, MenuId, Utilities.Role_Customer);
                    SetValue(ref RoleMenus, isOperations, MenuId, Utilities.Role_Operations);
                    SetValue(ref RoleMenus, isSales_Manager, MenuId, Utilities.Role_Sales_Manager);
                    SetValue(ref RoleMenus, isSales_Representative, MenuId, Utilities.Role_Sales_Representative );
                    SetValue(ref RoleMenus, isSupplier, MenuId, Utilities.Role_Supplier);

                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        //Delete All record 
                        List<DBLayer.tblRoleMenu> listrm = DB.tblRoleMenus.ToList();
                        foreach (DBLayer.tblRoleMenu obj in listrm)
                            DB.tblRoleMenus.Remove(obj);
                        DB.SaveChanges();
                        //Add Select Records
                        foreach (RoleMenu rm in RoleMenus)
                        {
                            DBLayer.tblRoleMenu tblrm = new DBLayer.tblRoleMenu();
                            tblrm.RoleMenuId  = Guid.NewGuid();
                            tblrm.MenuId  = rm.MenuId;
                            tblrm.RoleId = rm.RoleId ;
                            tblrm.CreateBy = User.Identity.Name;
                            tblrm.CreationDate = DateTime.Now;
                            DB.tblRoleMenus.Add(tblrm);
                        }

                        DB.SaveChanges();
                        return RedirectToAction("Index", "Dashboard");
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


        private void SetValue(ref List<RoleMenu> RoleMenus, string[] chk, string[] MenuId , string Role)
        {
            int count = 0;
            for (int n = 0; n < chk.Length; n++)
            {
                if (chk[n] == "true")
                {
                    RoleMenu roleMenu = new RoleMenu();
                    roleMenu.MenuId = new Guid(MenuId[count]);
                    roleMenu.RoleId = new Guid(Role);
                    RoleMenus.Add(roleMenu);
                    n++;
                }
                count++;
            }
        }






        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            try
            {
                Collection<Role> myColl = new Collection<Role>();
                IEnumerable<Role> items = null;
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    var C = (from r in DB.tblRoles
                             join s in DB.tblStatus
                             on r.StatusId equals s.StatusId
                             where r.StatusId != new Guid(Utilities.Status_Delete)
                             let Status = s.Name
                             select new { r.RoleId, r.Name, r.Description, r.StatusId, Status }).OrderBy(x => x.Name);

                    foreach (var ele in C)
                    {
                        myColl.Add(new Role()
                        {
                            RoleId = ele.RoleId,
                            Name = ele.Name,
                            Description = ele.Description,
                            myStatus = ele.Status,
                            StatusId = ele.StatusId
                        });
                    }
                    items = myColl as IEnumerable<Role>;
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
                List<Status> Status = new List<Status>();
                Role r = new Role();
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    var st = from g in DB.tblStatus
                             where g.StatusTypeId == new Guid(Utilities.StatusType_CURD)
                             select new { g.StatusId, g.Name };

                    foreach (var q in st)
                    {
                        Status.Add(new Status()
                        { StatusId = q.StatusId, Name = q.Name });
                    }
                    r.Status = Status;
                    if (Id != null)
                    {
                        Guid RoleId = Guid.Parse(Id);
                        DBLayer.tblRole tbl = (from g in DB.tblRoles
                                               where g.RoleId == RoleId
                                               select g).SingleOrDefault();
                        r.RoleId = tbl.RoleId;
                        r.Name = tbl.Name;
                        r.Description = tbl.Description;
                        r.StatusId = tbl.StatusId;
                        return View(r);
                    }
                    else
                    {
                        return View(r);
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Create Role")]
        public ActionResult Create(Role m, HttpPostedFileBase upload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblRole tbl = DB.tblRoles.Where(u => u.Name.ToLower() == m.Name.ToLower() && u.StatusId != new Guid(Utilities.Status_Delete)).FirstOrDefault();
                        if (tbl == null)
                        {
                            tbl = new DBLayer.tblRole();
                            tbl.RoleId = Guid.NewGuid();
                            tbl.Name = m.Name;
                            tbl.Description = m.Description;
                            tbl.StatusId = m.StatusId ;
                            tbl.CreationDate = DateTime.Now;
                            tbl.CreateBy = User.Identity.Name;
                            DB.tblRoles.Add(tbl);
                            DB.SaveChanges();
                            return RedirectToAction("Index", "Roles");
                        }
                        else
                        {
                            ViewBag.Error = "Role Name Already Exists";
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Edit Role")]
        public ActionResult Edit(Role m, HttpPostedFileBase upload)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblRole tblcheck = DB.tblRoles.Where(u => u.Name.ToLower() == m.Name.ToLower() && u.StatusId != new Guid(Utilities.Status_Delete) && u.RoleId != m.RoleId).FirstOrDefault();
                        if (tblcheck == null)
                        {
                            DBLayer.tblRole tbl = (from g in DB.tblRoles
                                                    where g.RoleId == m.RoleId
                                                    select g).SingleOrDefault();
                            tbl.Name = m.Name;
                            tbl.Description = m.Description;
                            tbl.StatusId = m.StatusId;
                            tbl.ModifyDate = DateTime.Now;
                            tbl.ModifyBy = User.Identity.Name;
                            DB.SaveChanges();
                            return RedirectToAction("Index", "Roles");
                        }
                        else
                        {
                            ViewBag.Error = "Role Name Already Exists";
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Delete Role")]
        public ActionResult Delete(Role m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblRole tbl = (from g in DB.tblRoles
                                                where g.RoleId == m.RoleId
                                                select g).SingleOrDefault();
                        tbl.StatusId = new Guid(Utilities.Status_Delete);
                        tbl.ModifyDate = DateTime.Now;
                        tbl.ModifyBy = User.Identity.Name;
                        DB.SaveChanges();
                        return RedirectToAction("Index", "Roles");
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

    }
}