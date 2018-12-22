using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin.Models;

namespace Admin.Controllers
{
    public class IntermediateGroupsController : Controller
    {
 #region IntermediateGroup
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            try
            {
                Collection<IntermediateGroup> myColl = new Collection<IntermediateGroup>();
                IEnumerable<IntermediateGroup> items = null;
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    var C = (from g in DB.tblIntermediateGroups
                             where g.StatusId != new Guid(Utilities.Status_Delete)
                             select g).OrderBy(x => x.DisplayOrder);

                    foreach (var ele in C)
                    {
                        myColl.Add(new IntermediateGroup()
                        {
                            IntermediateGroupId = ele.IntermediateGroupId,
                            Name = ele.Name,
                            myMainGroup = (ele.MainGroupId == null || ele.MainGroupId == Guid.Empty) ?"": ele.tblMainGroup.Name,  
                            DisplayOrder = ele.DisplayOrder,
                            myStatus = ele.tblStatu.Name,
                            StatusId = ele.StatusId,
                            FileId =ele.FileId
                        });
                    }
                    items = myColl as IEnumerable<IntermediateGroup>;
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
                        Guid IntermediateGroupId = Guid.Parse(Id);
                        DBLayer.tblIntermediateGroup tbl = (from g in DB.tblIntermediateGroups
                                                  where g.IntermediateGroupId == IntermediateGroupId
                                                  select g).SingleOrDefault();
                        IntermediateGroup m = new IntermediateGroup();
                        m.IntermediateGroupId = tbl.IntermediateGroupId;
                        m.DisplayOrder = tbl.DisplayOrder;
                        m.Name = tbl.Name;
                        m.Description  = tbl.Description;
                        m.FileId = tbl.FileId;
                        m.MainGroupId = tbl.MainGroupId; 
                        m.myStatus = tbl.StatusId.ToString();
                        ViewBag.FileId = tbl.FileId;
                        return View(m);
                    }
                }
                else
                {
                    IntermediateGroup m = new IntermediateGroup();
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Create IntermediateGroup")]
        public ActionResult Create(IntermediateGroup m,  HttpPostedFileBase upload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblIntermediateGroup tbl = DB.tblIntermediateGroups.Where(u => u.Name.ToLower() == m.Name.ToLower() && u.StatusId != new Guid(Utilities.Status_Delete)).FirstOrDefault();
                        if (tbl == null)
                        {
                            var NewFileId = Guid.NewGuid();
                            tbl = new DBLayer.tblIntermediateGroup();
                            tbl.IntermediateGroupId = Guid.NewGuid();
                            tbl.Name = m.Name;
                            tbl.Description = m.Description;
                            tbl.DisplayOrder = m.DisplayOrder;
                            tbl.StatusId = new Guid(m.myStatus);
                            tbl.CreationDate = DateTime.Now;
                            tbl.CreateBy = User.Identity.Name;
                            if (m.MainGroupId != Guid.Empty)
                                tbl.MainGroupId = m.MainGroupId;
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

                            DB.tblIntermediateGroups.Add(tbl);
                            DB.SaveChanges();
                            return RedirectToAction("Index", "IntermediateGroups");
                        }
                        else
                        {
                            ViewBag.Error = "IntermediateGroup Name Already Exists";
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Edit IntermediateGroup")]
        public ActionResult Edit(IntermediateGroup m, HttpPostedFileBase upload)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblIntermediateGroup tblcheck = DB.tblIntermediateGroups.Where(u => u.Name.ToLower() == m.Name.ToLower() && u.StatusId != new Guid(Utilities.Status_Delete) && u.IntermediateGroupId != m.IntermediateGroupId).FirstOrDefault();
                        if (tblcheck == null)
                        {
                            DBLayer.tblIntermediateGroup tbl = (from g in DB.tblIntermediateGroups
                                                    where g.IntermediateGroupId == m.IntermediateGroupId
                                                    select g).SingleOrDefault();
                            tbl.Name = m.Name;
                            tbl.DisplayOrder = m.DisplayOrder;
                            tbl.Description = m.Description;
                            tbl.StatusId = new Guid(m.myStatus);
                            tbl.ModifyDate = DateTime.Now;
                            tbl.ModifyBy = User.Identity.Name;
                            tbl.IsVISMA = false;
                            if (m.MainGroupId != Guid.Empty)
                                tbl.MainGroupId = m.MainGroupId;

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
                            return RedirectToAction("Index", "IntermediateGroups");
                        }
                        else
                        {
                            ViewBag.Error = "IntermediateGroup Name Already Exists";
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Delete IntermediateGroup")]
        public ActionResult Delete(IntermediateGroup m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblIntermediateGroup tbl = (from g in DB.tblIntermediateGroups
                                                where g.IntermediateGroupId == m.IntermediateGroupId
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
                        return RedirectToAction("Index", "IntermediateGroups");
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