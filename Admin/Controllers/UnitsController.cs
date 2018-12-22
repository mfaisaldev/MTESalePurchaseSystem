using Admin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class UnitsController : Controller
    {
        #region Unit
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            try
            {
                Collection<Unit> myColl = new Collection<Unit>();
                IEnumerable<Unit> items = null;
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    var C = (from g in DB.tblUnits
                             join status in DB.tblStatus
                             on g.StatusId equals status.StatusId
                             where g.StatusId != new Guid(Utilities.Status_Delete)
                             let Status = status.Name
                             let StatusId = status.StatusId
                             select new { g.UnitId, g.Name,g.EDIName,  g.DisplayOrder, Status, StatusId }).OrderBy(x => x.DisplayOrder);

                    foreach (var ele in C)
                    {
                        myColl.Add(new Unit()
                        {
                            UnitId = ele.UnitId,
                            Name = ele.Name,
                            DisplayOrder = ele.DisplayOrder,
                            myStatus = ele.Status,
                            StatusId = ele.StatusId,
                            EDIName = ele.EDIName
                        });
                    }
                    items = myColl as IEnumerable<Unit>;
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
                        Guid UnitId = Guid.Parse(Id);
                        DBLayer.tblUnit tbl = (from g in DB.tblUnits
                                                where g.UnitId == UnitId
                                                select g).SingleOrDefault();
                        Unit m = new Unit();
                        m.UnitId = tbl.UnitId;
                        m.DisplayOrder = tbl.DisplayOrder;
                        m.Name = tbl.Name;
                        m.EDIName  = tbl.EDIName;
                        m.myStatus = tbl.StatusId.ToString();
                        return View(m);
                    }
                }
                else
                {
                    Unit m = new Unit();
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Create Unit")]
        public ActionResult Create(Unit m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblUnit tbl = DB.tblUnits.Where(u => u.Name.ToLower() == m.Name.ToLower() && u.StatusId != new Guid(Utilities.Status_Delete)).FirstOrDefault();
                        if (tbl == null)
                        {
                            var NewFileId = Guid.NewGuid();
                            tbl = new DBLayer.tblUnit();
                            tbl.UnitId = Guid.NewGuid();
                            tbl.Name = m.Name;
                            tbl.EDIName  = m.EDIName;
                            tbl.DisplayOrder = m.DisplayOrder;
                            tbl.StatusId = new Guid(m.myStatus);
                            tbl.CreationDate = DateTime.Now;
                            tbl.CreateBy = User.Identity.Name;
                            DB.tblUnits.Add(tbl);
                            DB.SaveChanges();
                            return RedirectToAction("Index", "Units");
                        }
                        else
                        {
                            ViewBag.Error = "Unit Name Already Exists";
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Edit Unit")]
        public ActionResult Edit(Unit m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblUnit tblcheck = DB.tblUnits.Where(u => u.Name.ToLower() == m.Name.ToLower() && u.StatusId != new Guid(Utilities.Status_Delete) && u.UnitId != m.UnitId).FirstOrDefault();
                        if (tblcheck == null)
                        {
                            DBLayer.tblUnit tbl = (from g in DB.tblUnits
                                                    where g.UnitId == m.UnitId
                                                    select g).SingleOrDefault();
                            tbl.Name = m.Name;
                            tbl.DisplayOrder = m.DisplayOrder;
                            tbl.EDIName  = m.EDIName;
                            tbl.StatusId = new Guid(m.myStatus);
                            tbl.ModifyDate = DateTime.Now;
                            tbl.ModifyBy = User.Identity.Name;
                            tbl.IsVISMA = false;
                            DB.SaveChanges();
                            return RedirectToAction("Index", "Units");
                        }
                        else
                        {
                            ViewBag.Error = "Unit Name Already Exists";
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Delete Unit")]
        public ActionResult Delete(Unit m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblUnit tbl = (from g in DB.tblUnits
                                                where g.UnitId == m.UnitId
                                                select g).SingleOrDefault();
                        tbl.StatusId = new Guid(Utilities.Status_Delete);
                        tbl.ModifyDate = DateTime.Now;
                        tbl.ModifyBy = User.Identity.Name;
                        DB.SaveChanges();
                        return RedirectToAction("Index", "Units");
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