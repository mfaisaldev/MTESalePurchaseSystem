using Admin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class EmployeesController : Controller
    {
        #region Employee
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            try
            {
                Collection<Employee> myColl = new Collection<Employee>();
                IEnumerable<Employee> items = null;
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    var C = (from g in DB.tblEmployees
                             join status in DB.tblStatus
                             on g.StatusId equals status.StatusId
                             where g.StatusId != new Guid(Utilities.Status_Delete)
                             let Status = status.Name
                             let StatusId = status.StatusId
                             select new { g.EmployeeId, g.Name,g.Title,g.MobileTelephone,g.Email,g.DisplayOrder, Status, StatusId, g.FileId }).OrderBy(x => x.DisplayOrder);

                    foreach (var ele in C)
                    {
                        myColl.Add(new Employee()
                        {
                            EmployeeId = ele.EmployeeId,
                            Name = ele.Name,
                            Title = ele.Title,
                            MobileTelephone = ele.MobileTelephone,
                            Email=ele.Email,   
                            DisplayOrder = ele.DisplayOrder,
                            myStatus = ele.Status,
                            StatusId = ele.StatusId,
                            FileId = ele.FileId
                        });
                    }
                    items = myColl as IEnumerable<Employee>;
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
                        Guid EmployeeId = Guid.Parse(Id);
                        DBLayer.tblEmployee tbl = (from g in DB.tblEmployees
                                                where g.EmployeeId == EmployeeId
                                                select g).SingleOrDefault();
                        Employee m = new Employee();
                        m.EmployeeId = tbl.EmployeeId;
                        m.Name = tbl.Name;
                        m.Address1 = tbl.Address1;
                        m.Address2 = tbl.Address2;
                        m.Address3 = tbl.Address3;

                        m.BankAccount = tbl.BankAccount;
                        m.CountryId = tbl.CountryId;
                        m.DisplayOrder = tbl.DisplayOrder;
                        m.Email = tbl.Email;
                        m.EmployeeNo = tbl.EmployeeNo;
                        m.FamilyName = tbl.FamilyName;
                        m.HireDate = tbl.HireDate;
                        m.InternalTelephone = tbl.InternalTelephone;
                        m.MiddleName = tbl.MiddleName;
                        m.MobileTelephone = tbl.MobileTelephone;
                        m.NickName = tbl.NickName;
                        m.PostAccount = tbl.PostAccount;
                        m.PostCode = tbl.PostCode;
                        m.PostOffice = tbl.PostOffice;
                        m.Sex = tbl.Sex;
                        m.StatusId = tbl.StatusId;
                        m.Title = tbl.Title;
                        m.FileId = tbl.FileId;
                        m.myStatus = tbl.StatusId.ToString();
                        ViewBag.FileId = tbl.FileId;
                        return View(m);
                    }
                }
                else
                {
                    Employee m = new Employee();
                    m.myStatus = Utilities.Status_Online;
                    m.StatusId = new Guid(Utilities.Status_Online);
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Create Employee")]
        public ActionResult Create(Employee m, HttpPostedFileBase upload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblEmployee tbl = DB.tblEmployees.Where(u => u.Name.ToLower() == m.Name.ToLower() && u.StatusId != new Guid(Utilities.Status_Delete)).FirstOrDefault();
                        if (tbl == null)
                        {
                            var NewFileId = Guid.NewGuid();
                            tbl = new DBLayer.tblEmployee();
                            tbl.EmployeeId = Guid.NewGuid();
                            tbl.Name = m.Name;
                            tbl.DisplayOrder = m.DisplayOrder;
                            tbl.Name = m.Name;
                            tbl.Address1 = m.Address1;
                            tbl.Address2 = m.Address2;
                            tbl.Address3 = m.Address3;
                            tbl.BankAccount = m.BankAccount;
                            tbl.CountryId = m.CountryId;
                            tbl.DisplayOrder = m.DisplayOrder;
                            tbl.Email = m.Email;
                            tbl.EmployeeNo = m.EmployeeNo;
                            tbl.FamilyName = m.FamilyName;
                            tbl.HireDate = m.HireDate;
                            tbl.InternalTelephone = m.InternalTelephone;
                            tbl.MiddleName = m.MiddleName;
                            tbl.MobileTelephone = m.MobileTelephone;
                            tbl.NickName = m.NickName;
                            tbl.PostAccount = m.PostAccount;
                            tbl.PostCode = m.PostCode;
                            tbl.PostOffice = m.PostOffice;
                            tbl.Sex = m.Sex;
                            tbl.Title = m.Title;
                            tbl.StatusId = new Guid(m.myStatus);
                            tbl.CreationDate = DateTime.Now;
                            tbl.CreateBy = User.Identity.Name;
                            tbl.IsVISMA = false;
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

                            DB.tblEmployees.Add(tbl);
                            DB.SaveChanges();
                            return RedirectToAction("Index", "Employees");
                        }
                        else
                        {
                            ViewBag.Error = "Employee Name Already Exists";
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Edit Employee")]
        public ActionResult Edit(Employee m, HttpPostedFileBase upload)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblEmployee tblcheck = DB.tblEmployees.Where(u => u.Name.ToLower() == m.Name.ToLower() && u.StatusId != new Guid(Utilities.Status_Delete) && u.EmployeeId != m.EmployeeId).FirstOrDefault();
                        if (tblcheck == null)
                        {
                            DBLayer.tblEmployee tbl = (from g in DB.tblEmployees
                                                    where g.EmployeeId == m.EmployeeId
                                                    select g).SingleOrDefault();
                            tbl.Name = m.Name;
                            tbl.DisplayOrder = m.DisplayOrder;
                            tbl.Name = m.Name;
                            tbl.Address1 = m.Address1;
                            tbl.Address2 = m.Address2;
                            tbl.Address3 = m.Address3;
                            tbl.BankAccount = m.BankAccount;
                            tbl.CountryId = m.CountryId;
                            tbl.Email = m.Email;
                            tbl.EmployeeNo = m.EmployeeNo;
                            tbl.FamilyName = m.FamilyName;
                            tbl.HireDate = m.HireDate;
                            tbl.InternalTelephone = m.InternalTelephone;
                            tbl.MiddleName = m.MiddleName;
                            tbl.MobileTelephone = m.MobileTelephone;
                            tbl.NickName = m.NickName;
                            tbl.PostAccount = m.PostAccount;
                            tbl.PostCode = m.PostCode;
                            tbl.PostOffice = m.PostOffice;
                            tbl.Sex = m.Sex;
                            tbl.Title = m.Title;
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
                            return RedirectToAction("Index", "Employees");
                        }
                        else
                        {
                            ViewBag.Error = "Employee Name Already Exists";
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Delete Employee")]
        public ActionResult Delete(Employee m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblEmployee tbl = (from g in DB.tblEmployees
                                                where g.EmployeeId == m.EmployeeId
                                                select g).SingleOrDefault();
                        tbl.StatusId = new Guid(Utilities.Status_Delete);
                        tbl.ModifyDate = DateTime.Now;
                        tbl.ModifyBy = User.Identity.Name;
                        //Delete File
                        DBLayer.tblFile tblFile = (from g in DB.tblFiles
                                                   where g.FileId == m.FileId
                                                   select g).SingleOrDefault();
                        if(tblFile!=null)
                            DB.tblFiles.Remove(tblFile);
                        DB.SaveChanges();
                        return RedirectToAction("Index", "Employees");
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