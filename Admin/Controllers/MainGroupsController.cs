using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin.Models;

namespace Admin.Controllers
{
    public class MainGroupsController : Controller
    {
        #region MainGroup
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            try
            {
                Collection<MainGroup> myColl = new Collection<MainGroup>();
                IEnumerable<MainGroup> items = null;
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    var C = (from g in DB.tblMainGroups
                             join status in DB.tblStatus
                             on g.StatusId equals status.StatusId
                             where g.StatusId != new Guid(Utilities.Status_Delete)
                             let Status = status.Name
                             let StatusId = status.StatusId
                             select new { g.MainGroupId, g.Name, g.DisplayOrder, Status, StatusId, g.FileId }).OrderBy(x => x.DisplayOrder);

                    foreach (var ele in C)
                    {
                        myColl.Add(new MainGroup()
                        {
                            MainGroupId = ele.MainGroupId,
                            Name = ele.Name,
                            DisplayOrder = ele.DisplayOrder,
                            myStatus = ele.Status,
                            StatusId = ele.StatusId,
                            FileId = ele.FileId
                        });
                    }
                    items = myColl as IEnumerable<MainGroup>;
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
                        Guid MainGroupId = Guid.Parse(Id);
                        DBLayer.tblMainGroup tbl = (from g in DB.tblMainGroups
                                                where g.MainGroupId == MainGroupId
                                                select g).SingleOrDefault();
                        MainGroup m = new MainGroup();
                        m.MainGroupId = tbl.MainGroupId;
                        m.DisplayOrder = tbl.DisplayOrder;
                        m.Name = tbl.Name;
                        m.Description = tbl.Description;
                        m.FileId = tbl.FileId;
                        m.myStatus = tbl.StatusId.ToString();
                        ViewBag.FileId = tbl.FileId;
                        return View(m);
                    }
                }
                else
                {
                    MainGroup m = new MainGroup();
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Create MainGroup")]
        public ActionResult Create(MainGroup m, HttpPostedFileBase upload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblMainGroup tbl = DB.tblMainGroups.Where(u => u.Name.ToLower() == m.Name.ToLower() && u.StatusId != new Guid(Utilities.Status_Delete)).FirstOrDefault();
                        if (tbl == null)
                        {
                            var NewFileId = Guid.NewGuid();
                            tbl = new DBLayer.tblMainGroup();
                            tbl.MainGroupId = Guid.NewGuid();
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

                            DB.tblMainGroups.Add(tbl);
                            DB.SaveChanges();
                            return RedirectToAction("Index", "MainGroups");
                        }
                        else
                        {
                            ViewBag.Error = "MainGroup Name Already Exists";
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Edit MainGroup")]
        public ActionResult Edit(MainGroup m, HttpPostedFileBase upload)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblMainGroup tblcheck = DB.tblMainGroups.Where(u => u.Name.ToLower() == m.Name.ToLower() && u.StatusId != new Guid(Utilities.Status_Delete) && u.MainGroupId != m.MainGroupId).FirstOrDefault();
                        if (tblcheck == null)
                        {
                            DBLayer.tblMainGroup tbl = (from g in DB.tblMainGroups
                                                    where g.MainGroupId == m.MainGroupId
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
                            return RedirectToAction("Index", "MainGroups");
                        }
                        else
                        {
                            ViewBag.Error = "MainGroup Name Already Exists";
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Delete MainGroup")]
        public ActionResult Delete(MainGroup m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblMainGroup tbl = (from g in DB.tblMainGroups
                                                where g.MainGroupId == m.MainGroupId
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
                        return RedirectToAction("Index", "MainGroups");
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