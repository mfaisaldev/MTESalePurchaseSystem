using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Index(string Id)
        {
            if (!String.IsNullOrEmpty(Id))
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    Guid FileId = Guid.Parse(Id);
                    DBLayer.tblFile tbl = (from g in DB.tblFiles
                                           where g.FileId == FileId
                                           select g).SingleOrDefault();
                    return File(tbl.ContentData, tbl.ContentType, null);
                }
            }
            else
                return null;
        }

        [HttpGet]
        public ActionResult DeleteFile(string Id)
        {
            if (!String.IsNullOrEmpty(Id))
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    Guid FileId = Guid.Parse(Id);
                    DBLayer.tblFile tbl = (from g in DB.tblFiles
                                           where g.FileId == FileId
                                           select g).SingleOrDefault();
                    DB.tblFiles.Remove(tbl); 
                    return null;
                }
            }
            else
                return null;
        }

        [HttpGet]
        public ActionResult DeleteFile(string Id,string FileName)
        {
            if ((!String.IsNullOrEmpty(FileName)) && (!String.IsNullOrEmpty(Id)))
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    Guid productId = Guid.Parse(Id);

                    var tbl = (from g in DB.tblProductFiles
                               join f in DB.tblFiles
                                      on g.FileId  equals f.FileId 
                               where g.ProductId == productId
                               && f.FileName == FileName
                               select g).ToList();
                    foreach (var t in tbl)
                    {
                        DB.tblProductFiles.Remove(t);

                        var f = DB.tblFiles.Where(u => u.FileId == t.FileId).FirstOrDefault();
                        DB.tblFiles.Remove(f);
                    }
                    return null;
                }
            }
            else
                return null;
        }

        public ActionResult GetPicture()
        {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    DBLayer.tblFile tbl = (from g in DB.tblFiles
                                           join c in DB.tblCustomers
                                           on g.FileId  equals c.FileId
                                           where c.UserName == User.Identity.Name 
                                           select g).SingleOrDefault();
                if (tbl != null)
                    return File(tbl.ContentData, tbl.ContentType, null);
                else
                {
                    DBLayer.tblFile tblfile = (from g in DB.tblFiles
                                             where g.FileId.ToString()  == Utilities.Default_Image
                                           select g).SingleOrDefault();
                    if (tblfile != null)
                        return File(tblfile.ContentData, tblfile.ContentType, null);
                    else
                        return null;
                }
            }
            
        }
      
    }
}