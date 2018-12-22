using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Admin.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Admin.Controllers
{
    public class CustomersController : Controller
    {
        #region Customer 

        private ApplicationUserManager _userManager;

        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            try
            {
                Collection<Customer> myColl = new Collection<Customer>();
                IEnumerable<Customer> items = null;
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    var C = (from c in DB.tblCustomers
                             join status in DB.tblStatus
                             on c.StatusId equals status.StatusId
                             where c.StatusId != new Guid(Utilities.Status_Delete)
                             let Status = status.Name
                             let StatusId = status.StatusId
                             select new { c.CustomerId, c.Name, c.Email, c.OrganizationName, c.Phone, c.CreationDate, Status, StatusId, c.FileId }).OrderBy(x => x.CreationDate);

                    foreach (var ele in C)
                    {
                        myColl.Add(new Customer()
                        {
                            CustomerId = ele.CustomerId,
                            Name = ele.Name,
                            Email = ele.Email,
                            OrganizationName = ele.OrganizationName,
                            Phone = ele.Phone,
                            myStatus = ele.Status,
                            StatusId = ele.StatusId,
                            FileId = ele.FileId
                        });
                    }
                    items = myColl as IEnumerable<Customer>;
                    return View(items);
                }
            }
            catch
            {
                IEnumerable<Customer> items = null;
                return View(items);
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create(string Id)
        {
            try
            {
                Customer m = new Customer();
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    if (Id != null)
                    {
                        Guid CustomerId = Guid.Parse(Id);
                        DBLayer.tblCustomer t = (from g in DB.tblCustomers
                                                 where g.CustomerId == CustomerId
                                                 select g).SingleOrDefault();
                        m.Address1 = t.Address1;
                        m.Address2 = t.Address2;
                        m.BankAccount = t.BankAccount;
                        m.City = t.City;
                        m.ContactNoConfirmOrder = t.ContactNoConfirmOrder;
                        m.CountryId = t.CountryId;
                        m.CreateBy = t.CreateBy;
                        m.CreationDate = t.CreationDate;
                        m.CreditLimit = t.CreditLimit;
                        m.CustomerId = t.CustomerId;
                        m.Email = t.Email;
                        m.IBAN = t.IBAN;
                        m.IsVISMA = t.IsVISMA;
                        m.Kommune = t.Kommune;
                        m.Name = t.Name;
                        m.OrganizationName = t.OrganizationName;
                        m.OrganizationNumber = t.OrganizationNumber;
                        m.Phone = t.Phone;
                        m.PostOffice = t.PostOffice;
                        m.SwiftCode = t.SwiftCode;
                        m.StatusId = t.StatusId;
                        m.userName = t.UserName;
                        m.FileId = t.FileId;
                        m.myStatus = t.StatusId.ToString();
                        m.CurrencyId = t.CurrencyId;
                        m.EmployeeId = t.EmployeeId;
                        ViewBag.FileId = t.FileId;
                    }
                }
                return View(m);
            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
                Customer m = new Customer();
                return View(m);
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Create Customer")]
        public async System.Threading.Tasks.Task<ActionResult> Create(Customer m, HttpPostedFileBase upload, FormCollection fc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        var CustomerId = Guid.NewGuid();

                        var user = new ApplicationUser()
                        {
                            UserName = m.Email,
                            Email = m.Email,
                            CustomerId = CustomerId,
                            StatusId = new Guid(m.myStatus)
                        };
                        var result = await UserManager.CreateAsync(user, m.Password);
                        if (result.Succeeded)
                        {
                            DBLayer.tblCustomer t;

                            List<RoleUser> RoleUsers = new List<RoleUser>();
                            string[] isAllow = fc["item.IsAllow"].ToString().Split(',');
                            string[] RoleId = fc["item.RoleId"].ToString().Split(',');

                            int count = 0;
                            for (int n = 0; n < isAllow.Length; n++)
                            {
                                if (isAllow[n] == "true")
                                {
                                    RoleUser roleUser = new RoleUser();
                                    roleUser.RoleId = new Guid(RoleId[count]);
                                    roleUser.UserName = m.Email;
                                    RoleUsers.Add(roleUser);
                                    n++;
                                }
                                count++;
                            }

                            var NewFileId = Guid.NewGuid();
                            t = new DBLayer.tblCustomer();
                            t.Address1 = m.Address1;
                            t.Address2 = m.Address2;
                            t.BankAccount = m.BankAccount;
                            t.City = m.City;
                            t.ContactNoConfirmOrder = m.ContactNoConfirmOrder;
                            t.CountryId = m.CountryId;
                            t.CreateBy = User.Identity.Name;
                            t.CreationDate = DateTime.Now;
                            t.CreditLimit = m.CreditLimit;
                            t.CustomerId = CustomerId;
                            t.Email = m.Email;
                            t.IBAN = m.IBAN;
                            t.IsVISMA = m.IsVISMA;
                            t.Kommune = m.Kommune;
                            t.Name = m.Name;
                            t.OrganizationName = m.OrganizationName;
                            t.OrganizationNumber = m.OrganizationNumber;
                            t.Phone = m.Phone;
                            t.PostOffice = m.PostOffice;
                            t.SwiftCode = m.SwiftCode;
                            t.StatusId = new Guid(m.myStatus);
                            t.UserName = m.Email;
                            t.CurrencyId = m.CurrencyId;
                            t.EmployeeId = m.EmployeeId;
                            t.IsVISMA = false;
                            if (RoleUsers.Where(u => u.RoleId == new Guid(Utilities.Role_Admin) || u.RoleId == new Guid(Utilities.Role_CFO) || u.RoleId == new Guid(Utilities.Role_Operations) || u.RoleId == new Guid(Utilities.Role_Sales_Manager) || u.RoleId == new Guid(Utilities.Role_Sales_Representative) || u.RoleId == new Guid(Utilities.Role_Supplier)).SingleOrDefault() == null)
                                t.IsUser = true;
                            else
                                t.IsUser = false;
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

                                t.FileId = NewFileId;
                            }

                            DB.tblCustomers.Add(t);
                            DB.SaveChanges();

                            //Delete All record 
                            List<DBLayer.tblRoleUser> listru = DB.tblRoleUsers.Where(u => u.UserName == m.userName).ToList();
                            foreach (DBLayer.tblRoleUser obj in listru)
                                DB.tblRoleUsers.Remove(obj);
                            DB.SaveChanges();
                            //Add Select Records
                            foreach (RoleUser ru in RoleUsers)
                            {
                                DBLayer.tblRoleUser tblru = new DBLayer.tblRoleUser();
                                tblru.RoleUserId = Guid.NewGuid();
                                tblru.RoleId = ru.RoleId;
                                tblru.UserName = ru.UserName;
                                tblru.CreateBy = User.Identity.Name;
                                tblru.CreationDate = DateTime.Now;
                                DB.tblRoleUsers.Add(tblru);
                            }
                            DB.SaveChanges();
                            var SupplierRole = RoleUsers.Where(u => u.RoleId.ToString().ToUpper() == Utilities.Role_Supplier).FirstOrDefault();
                            if (SupplierRole != null)
                            {
                                var tbl = new DBLayer.tblSupplier();
                                tbl.SupplierId = Guid.NewGuid();
                                tbl.Name = m.Name;
                                tbl.IsVISMA = false;
                                tbl.StatusId = new Guid(m.myStatus);
                                tbl.CreationDate = DateTime.Now;
                                tbl.CreateBy = User.Identity.Name;
                                tbl.Address1 = m.Address1;
                                tbl.Address2 = m.Address2;
                                tbl.BankAccount = m.BankAccount;
                                tbl.BankName = "";
                                tbl.City = m.City;
                                tbl.Contact = m.Phone;
                                tbl.CountryId = (Guid)m.CountryId;
                                tbl.CreditLimit = m.CreditLimit;
                                tbl.CurrencyId = m.CurrencyId;
                                tbl.Email = m.Email;
                                tbl.IBAN = m.IBAN;
                                tbl.Kommune = m.Kommune;
                                tbl.Phone = m.Phone;
                                tbl.PostAccount = "";
                                tbl.PostOffice = m.PostOffice;
                                tbl.RegistrationDate = DateTime.Now;
                                tbl.SwiftCode = m.SwiftCode;
                                tbl.Telefax = "";
                                tbl.UserName = m.Email;
                                if (upload != null && upload.ContentLength > 0)
                                {
                                    tbl.FileId = NewFileId;
                                }
                                DB.tblSuppliers.Add(tbl);
                                DB.SaveChanges();
                            }
                            //update Visma
                            var CustomerRole = RoleUsers.Where(u => u.RoleId.ToString().ToUpper() == Utilities.Role_Customer).FirstOrDefault();
                            if (CustomerRole != null)
                            {
                                t.CustomerNo = await this.UpdateCustomer(t);
                                if (t.CustomerNo > 0)
                                {
                                    DB.SaveChanges();
                                    return RedirectToAction("Index", "Customers");
                                }
                                else
                                {
                                    ViewBag.Error = "Records is successfull update in B2B but unable to update VISMA";
                                    return View(m);
                                }
                            }
                            else
                            {
                                return RedirectToAction("Index", "Customers");
                            }



                        }
                        else
                        {
                            ViewBag.Error = "Email Already Exists";
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

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Edit Customer")]
        public async System.Threading.Tasks.Task<ActionResult> Edit(Customer m, HttpPostedFileBase upload, FormCollection fc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var NewFileId = Guid.NewGuid();
                    List<RoleUser> RoleUsers = new List<RoleUser>();
                    string[] isAllow = fc["item.IsAllow"].ToString().Split(',');
                    string[] RoleId = fc["item.RoleId"].ToString().Split(',');

                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblCustomer t = (from g in DB.tblCustomers
                                                 where g.CustomerId == m.CustomerId
                                                 select g).SingleOrDefault();
                        int count = 0;
                        for (int n = 0; n < isAllow.Length; n++)
                        {
                            if (isAllow[n] == "true")
                            {
                                RoleUser roleUser = new RoleUser();
                                roleUser.RoleId = new Guid(RoleId[count]);
                                roleUser.UserName = t.UserName;
                                RoleUsers.Add(roleUser);
                                n++;
                            }
                            count++;
                        }
                        t.Address1 = m.Address1;
                        t.Address2 = m.Address2;
                        t.BankAccount = m.BankAccount;
                        t.City = m.City;
                        t.ContactNoConfirmOrder = m.ContactNoConfirmOrder;
                        t.CountryId = m.CountryId;
                        t.CreditLimit = m.CreditLimit;
                        t.Email = m.Email;
                        t.IBAN = m.IBAN;
                        t.IsVISMA = m.IsVISMA;
                        t.Kommune = m.Kommune;
                        t.Name = m.Name;
                        t.OrganizationName = m.OrganizationName;
                        t.OrganizationNumber = m.OrganizationNumber;
                        t.Phone = m.Phone;
                        t.PostOffice = m.PostOffice;
                        t.SwiftCode = m.SwiftCode;
                        t.StatusId = new Guid(m.myStatus);
                        t.UserName = m.Email;
                        if (RoleUsers.Where(u => u.RoleId == new Guid(Utilities.Role_Admin) || u.RoleId == new Guid(Utilities.Role_CFO) || u.RoleId == new Guid(Utilities.Role_Operations) || u.RoleId == new Guid(Utilities.Role_Sales_Manager) || u.RoleId == new Guid(Utilities.Role_Sales_Representative) || u.RoleId == new Guid(Utilities.Role_Supplier)).SingleOrDefault() == null)
                            t.IsUser = true;
                        else
                            t.IsUser = false;
                        t.ModifyDate = DateTime.Now;
                        t.ModifyBy = User.Identity.Name;
                        t.CurrencyId = m.CurrencyId;
                        t.EmployeeId = m.EmployeeId;

                        if (upload != null && upload.ContentLength > 0)
                        {
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
                                t.FileId = NewFileId;

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
                        //Delete All record 
                        List<DBLayer.tblRoleUser> listru = DB.tblRoleUsers.Where(u => u.UserName == m.Email).ToList();
                        foreach (DBLayer.tblRoleUser obj in listru)
                            DB.tblRoleUsers.Remove(obj);
                        DB.SaveChanges();
                        //Add Select Records
                        foreach (RoleUser ru in RoleUsers)
                        {
                            DBLayer.tblRoleUser tblru = new DBLayer.tblRoleUser();
                            tblru.RoleUserId = Guid.NewGuid();
                            tblru.RoleId = ru.RoleId;
                            tblru.UserName = ru.UserName;
                            tblru.CreateBy = User.Identity.Name;
                            tblru.CreationDate = DateTime.Now;
                            DB.tblRoleUsers.Add(tblru);
                        }
                        DB.SaveChanges();
                        // Update Supplier
                        bool IsSupplier = false;
                        var Supplier = DB.tblSuppliers.Where(u => u.UserName == t.UserName).FirstOrDefault();
                        if (RoleUsers.Where(u => u.RoleId.ToString().ToUpper() == Utilities.Role_Supplier).FirstOrDefault() != null)
                        {
                            if (Supplier == null)
                            {
                                Supplier = new DBLayer.tblSupplier();
                                IsSupplier = true;
                            }
                        }
                        else
                        {
                            if (Supplier != null)
                            {
                                Supplier.StatusId = new Guid(Utilities.Status_Delete);
                                Supplier.ModifyDate = DateTime.Now;
                                Supplier.ModifyBy = User.Identity.Name;
                                DB.SaveChanges();
                                Supplier = null;
                            }
                        }
                        if (Supplier != null)
                        {
                            Supplier.Name = m.Name;
                            Supplier.StatusId = new Guid(m.myStatus);
                            if (IsSupplier)
                            {
                                Supplier.CreationDate = DateTime.Now;
                                Supplier.CreateBy = User.Identity.Name;
                                Supplier.SupplierId = Guid.NewGuid();
                            }
                            else
                            {
                                Supplier.ModifyDate = DateTime.Now;
                                Supplier.ModifyBy = User.Identity.Name;
                            }
                            Supplier.IsVISMA = false;
                            Supplier.Address1 = m.Address1;
                            Supplier.Address2 = m.Address2;
                            Supplier.BankAccount = m.BankAccount;
                            Supplier.City = m.City;
                            Supplier.Contact = m.Phone;
                            Supplier.CountryId = (Guid)m.CountryId;
                            Supplier.CreditLimit = m.CreditLimit;
                            Supplier.CurrencyId = m.CurrencyId;
                            Supplier.Email = m.Email;
                            Supplier.IBAN = m.IBAN;
                            Supplier.Kommune = m.Kommune;
                            Supplier.Phone = m.Phone;
                            Supplier.PostOffice = m.PostOffice;
                            Supplier.RegistrationDate = DateTime.Now;
                            Supplier.SwiftCode = m.SwiftCode;
                            Supplier.FileId = NewFileId;
                            if (IsSupplier)
                                DB.tblSuppliers.Add(Supplier);
                            DB.SaveChanges();
                        }
                        var CustomerRole = RoleUsers.Where(u => u.RoleId.ToString().ToUpper() == Utilities.Role_Customer).FirstOrDefault();
                        if (CustomerRole != null)
                        {
                            t.CustomerNo = await this.UpdateCustomer(t);
                            if (t.CustomerNo > 0)
                            {
                                DB.SaveChanges();
                                return RedirectToAction("Index", "Customers");
                            }
                            else
                            {
                                ViewBag.Error = "Records is successfull update in B2B but unable to update VISMA";
                                return View(m);
                            }
                        }
                        else
                        {
                            return RedirectToAction("Index", "Customers");
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Delete Customer")]
        public ActionResult Delete(Customer m)
        {
            try
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    DBLayer.tblCustomer tbl = (from g in DB.tblCustomers
                                               where g.CustomerId == m.CustomerId
                                               select g).SingleOrDefault();
                    tbl.StatusId = new Guid(Utilities.Status_Delete);
                    tbl.ModifyDate = DateTime.Now;
                    tbl.ModifyBy = User.Identity.Name;
                    //Delete File
                    DBLayer.tblFile tblFile = (from g in DB.tblFiles
                                               where g.FileId == m.FileId
                                               select g).SingleOrDefault();
                    if (tblFile != null)
                        DB.tblFiles.Remove(tblFile);
                    //Delete User
                    DBLayer.AspNetUser tblUser = (from u in DB.AspNetUsers
                                                  where u.CustomerId == m.CustomerId
                                                  select u).SingleOrDefault();
                    DB.AspNetUsers.Remove(tblUser);

                    List<DBLayer.tblRoleUser> listru = DB.tblRoleUsers.Where(u => u.UserName == tblUser.UserName).ToList();
                    foreach (DBLayer.tblRoleUser obj in listru)
                        DB.tblRoleUsers.Remove(obj);
                    DB.SaveChanges();

                    var Supplier = DB.tblSuppliers.Where(u => u.UserName == tbl.UserName).FirstOrDefault();
                    if (Supplier != null)
                    {
                        Supplier.StatusId = new Guid(Utilities.Status_Delete);
                        Supplier.ModifyDate = DateTime.Now;
                        Supplier.ModifyBy = User.Identity.Name;
                        DB.SaveChanges();
                    }
                    return RedirectToAction("Index", "Customers");
                }
            }

            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
                return View();
            }

        }
        #endregion

        #region Approval
        [HttpGet]
        [Authorize]
        public ActionResult CustomerApproval()
        {
            try
            {
                Collection<Customer> myColl = new Collection<Customer>();
                IEnumerable<Customer> items = null;
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    var C = (from c in DB.tblCustomers
                             join ct in DB.tblCountries
                             on c.CountryId equals ct.CountryId
                             where c.StatusId == new Guid(Utilities.Status_Under_Porcess)
                             let Country = ct.Name
                             select new { c.CustomerId, c.Name, c.City, c.Email, c.OrganizationName, c.Phone, Country, c.CreationDate }).OrderBy(x => x.CreationDate);

                    foreach (var ele in C)
                    {
                        myColl.Add(new Customer()
                        {
                            CustomerId = ele.CustomerId,
                            Name = ele.Name,
                            Email = ele.Email,
                            OrganizationName = ele.OrganizationName,
                            Phone = ele.Phone,
                            City = ele.City,
                            myCountry = ele.Country
                        });
                    }
                    items = myColl as IEnumerable<Customer>;
                    return View(items);
                }
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult CustomerApprovalForm(string Id)
        {
            try
            {
                Customer m = new Customer();
                if (Id != null)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        Guid CustomerId = Guid.Parse(Id);
                        DBLayer.tblCustomer tbl = (from g in DB.tblCustomers
                                                   where g.CustomerId == CustomerId
                                                   select g).SingleOrDefault();
                        m.Address1 = tbl.Address1;
                        m.Address2 = tbl.Address2;
                        m.City = tbl.City;
                        m.myCountry = (from c in DB.tblCountries where c.CountryId == tbl.CountryId select c.Name).SingleOrDefault();
                        m.CreationDate = tbl.CreationDate;
                        m.CustomerId = tbl.CustomerId;
                        m.Email = tbl.Email;
                        m.Name = tbl.Name;
                        m.OrganizationName = tbl.OrganizationName;
                        m.OrganizationNumber = tbl.OrganizationNumber;
                        m.Phone = tbl.Phone;
                        m.PostOffice = tbl.PostOffice;
                        m.userName = tbl.UserName;

                        //var tblRole = (from r in DB.tblRoles
                        //               select new { r.RoleId, r.Name}).ToList();
                        //foreach (var ele in tblRole)
                        //{
                        //    m.Roles.Add(new Role()
                        //    {
                        //        RoleId = ele.RoleId,
                        //        Name = ele.Name,                               
                        //        IsAllow = DB.tblRoleUsers.Where(u => u.RoleId == ele.RoleId && u.UserName == tbl.UserName).FirstOrDefault() == null ? false : true
                        //    });
                        //}
                        return View(m);
                    }
                }
                return View(m);
            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
                return View();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult CustomerApprovalFormAdd(Customer m, FormCollection fc)
        {
            try
            {
                //if (ModelState.IsValid)
                //{

                List<RoleUser> RoleUsers = new List<RoleUser>();
                string[] isAllow = fc["item.IsAllow"].ToString().Split(',');
                string[] RoleId = fc["item.RoleId"].ToString().Split(',');

                int count = 0;
                for (int n = 0; n < isAllow.Length; n++)
                {
                    if (isAllow[n] == "true")
                    {
                        RoleUser roleUser = new RoleUser();
                        roleUser.RoleId = new Guid(RoleId[count]);
                        roleUser.UserName = m.userName;
                        RoleUsers.Add(roleUser);
                        n++;
                    }
                    count++;
                }

                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    //Delete All record 
                    List<DBLayer.tblRoleUser> listru = DB.tblRoleUsers.Where(u => u.UserName == m.userName).ToList();
                    foreach (DBLayer.tblRoleUser obj in listru)
                        DB.tblRoleUsers.Remove(obj);
                    DB.SaveChanges();
                    //Add Select Records
                    foreach (RoleUser ru in RoleUsers)
                    {
                        DBLayer.tblRoleUser tblru = new DBLayer.tblRoleUser();
                        tblru.RoleUserId = Guid.NewGuid();
                        tblru.RoleId = ru.RoleId;
                        tblru.UserName = ru.UserName;
                        tblru.CreateBy = User.Identity.Name;
                        tblru.CreationDate = DateTime.Now;
                        DB.tblRoleUsers.Add(tblru);
                    }
                    //Update Customer Status 
                    var tblc = DB.tblCustomers.Where(u => u.UserName == m.userName).SingleOrDefault();
                    tblc.StatusId = new Guid(Utilities.Status_Online);
                    //Udate User Status
                    var tblu = DB.AspNetUsers.Where(u => u.UserName == m.userName).SingleOrDefault();
                    if (RoleUsers.Where(u => u.RoleId == new Guid(Utilities.Role_Admin) || u.RoleId == new Guid(Utilities.Role_CFO) || u.RoleId == new Guid(Utilities.Role_Operations) || u.RoleId == new Guid(Utilities.Role_Sales_Manager) || u.RoleId == new Guid(Utilities.Role_Sales_Representative) || u.RoleId == new Guid(Utilities.Role_Supplier)).SingleOrDefault() == null)
                        tblc.IsUser = true;
                    else
                        tblc.IsUser = false;
                    tblu.StatusId = new Guid(Utilities.Status_Online);
                    DB.SaveChanges();
                    //If Supplier then Create
                    var SupplierRole = RoleUsers.Where(u => u.RoleId.ToString().ToUpper() == Utilities.Role_Supplier).FirstOrDefault();
                    if (SupplierRole != null)
                    {
                        var tbl = new DBLayer.tblSupplier();
                        tbl.SupplierId = Guid.NewGuid();
                        tbl.Name = m.Name;
                        tbl.IsVISMA = false;
                        tbl.StatusId = new Guid(Utilities.Status_Online);
                        tbl.CreationDate = DateTime.Now;
                        tbl.CreateBy = User.Identity.Name;
                        tbl.Address1 = m.Address1;
                        tbl.Address2 = m.Address2;
                        tbl.BankAccount = m.BankAccount;
                        tbl.BankName = "";
                        tbl.City = m.City;
                        tbl.Contact = m.Phone;
                        tbl.CountryId = (Guid)m.CountryId;
                        tbl.CreditLimit = m.CreditLimit;
                        tbl.CurrencyId = m.CurrencyId;
                        tbl.Email = m.Email;
                        tbl.IBAN = m.IBAN;
                        tbl.Kommune = m.Kommune;
                        tbl.Phone = m.Phone;
                        tbl.PostAccount = "";
                        tbl.PostOffice = m.PostOffice;
                        tbl.RegistrationDate = DateTime.Now;
                        tbl.SwiftCode = m.SwiftCode;
                        tbl.Telefax = "";
                        tbl.UserName = m.Email;
                        DB.tblSuppliers.Add(tbl);
                        DB.SaveChanges();
                    }


                    return RedirectToAction("CustomerApproval", "Customers");
                }
                //}
                //else
                //{
                //    return View(m);
                //}
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
        public new ActionResult Profile(Customer m, HttpPostedFileBase upload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var NewFileId = Guid.NewGuid();
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblCustomer t = (from g in DB.tblCustomers
                                                 where g.UserName == m.userName
                                                 select g).SingleOrDefault();
                        t.Address1 = m.Address1;
                        t.Address2 = m.Address2;
                        t.BankAccount = m.BankAccount;
                        t.City = m.City;
                        t.ContactNoConfirmOrder = m.ContactNoConfirmOrder;
                        t.CountryId = m.CountryId;
                        t.CreditLimit = m.CreditLimit;
                        t.Email = m.Email;
                        t.IBAN = m.IBAN;
                        t.Kommune = m.Kommune;
                        t.Name = m.Name;
                        t.OrganizationName = m.OrganizationName;
                        t.OrganizationNumber = m.OrganizationNumber;
                        t.Phone = m.Phone;
                        t.PostOffice = m.PostOffice;
                        t.SwiftCode = m.SwiftCode;
                        t.ModifyDate = DateTime.Now;
                        t.ModifyBy = User.Identity.Name;
                        if (upload != null && upload.ContentLength > 0)
                        {
                            if (t.FileId == Guid.Empty || t.FileId == null)
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
                                t.FileId = NewFileId;
                                DB.tblFiles.Add(tblFile);
                            }
                            else
                            {
                                DBLayer.tblFile tblFile = DB.tblFiles.Where(u => u.FileId == t.FileId).FirstOrDefault();
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
                        var Supplier = DB.tblSuppliers.Where(u => u.UserName == t.UserName).FirstOrDefault();
                        if (Supplier != null)
                        {
                            Supplier.Name = m.Name;
                            Supplier.StatusId = new Guid(m.myStatus);
                            Supplier.ModifyDate = DateTime.Now;
                            Supplier.ModifyBy = User.Identity.Name;
                            Supplier.IsVISMA = false;
                            Supplier.Address1 = m.Address1;
                            Supplier.Address2 = m.Address2;
                            Supplier.BankAccount = m.BankAccount;
                            Supplier.City = m.City;
                            Supplier.Contact = m.Phone;
                            Supplier.CountryId = (Guid)m.CountryId;
                            Supplier.CreditLimit = m.CreditLimit;
                            Supplier.CurrencyId = m.CurrencyId;
                            Supplier.Email = m.Email;
                            Supplier.IBAN = m.IBAN;
                            Supplier.Kommune = m.Kommune;
                            Supplier.Phone = m.Phone;
                            Supplier.PostOffice = m.PostOffice;
                            Supplier.RegistrationDate = DateTime.Now;
                            Supplier.SwiftCode = m.SwiftCode;
                            Supplier.FileId = NewFileId;
                            DB.SaveChanges();
                        }
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
        #endregion

        #region Shipping

        [HttpGet]
        [Authorize]
        public ActionResult Shipping(string CustomerId)
        {
            try
            {
                if (CustomerId != null)
                {
                    Collection<CustomerShipping> myColl = new Collection<CustomerShipping>();
                    IEnumerable<CustomerShipping> items = null;
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        var C = (from cs in DB.tblCustomerShippings
                                 join status in DB.tblStatus
                                 on cs.StatusId equals status.StatusId
                                 join country in DB.tblCountries
                                 on cs.CountryId equals country.CountryId
                                 where cs.StatusId != new Guid(Utilities.Status_Delete) &
                                 cs.CustomerId == new Guid(CustomerId)
                                 let Status = status.Name
                                 let Country = country.Name
                                 let StatusId = status.StatusId
                                 select new { cs.CustomerShippingId, cs.Name, cs.Email, cs.Phone, cs.City, Country, Status, StatusId, cs.CreationDate, cs.CustomerId }).OrderBy(x => x.CreationDate);

                        foreach (var ele in C)
                        {
                            myColl.Add(new CustomerShipping()
                            {
                                CustomerShippingId = ele.CustomerShippingId,
                                Name = ele.Name,
                                Email = ele.Email,
                                Phone = ele.Phone,
                                City = ele.City,
                                myCountry = ele.Country,
                                myStatus = ele.Status,
                                StatusId = ele.StatusId,
                                CustomerId = ele.CustomerId
                            });
                        }
                        items = myColl as IEnumerable<CustomerShipping>;
                        return View(items);
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult ShippingAdd(string Id, string CustomerId)
        {
            try
            {
                if (Id != null)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        Guid CustomerShippingId = Guid.Parse(Id);
                        DBLayer.tblCustomerShipping tbl = (from g in DB.tblCustomerShippings
                                                           where g.CustomerShippingId == CustomerShippingId
                                                           select g).SingleOrDefault();
                        CustomerShipping m = new CustomerShipping();
                        m.CustomerShippingId = tbl.CustomerShippingId;
                        m.Address1 = tbl.Address1;
                        m.Address2 = tbl.Address2;
                        m.City = tbl.City;
                        m.CountryId = tbl.CountryId;
                        m.CustomerId = tbl.CustomerId;
                        m.Email = tbl.Email;
                        m.Kommune = tbl.Kommune;
                        m.myCountry = tbl.CustomerId.ToString();
                        m.Name = tbl.Name;
                        m.Phone = tbl.Phone;
                        m.PostOffice = tbl.PostOffice;
                        m.StatusId = tbl.StatusId;
                        m.myStatus = tbl.StatusId.ToString();
                        return View(m);
                    }
                }
                else
                {
                    CustomerShipping m = new CustomerShipping();
                    m.CustomerId = new Guid(CustomerId);
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Create Customer Shipping")]
        public ActionResult ShippingAdd(CustomerShipping m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblCustomerShipping t = new DBLayer.tblCustomerShipping();
                        t.Address1 = m.Address1;
                        t.Address2 = m.Address2;
                        t.City = m.City;
                        t.CountryId = m.CountryId;
                        t.CreateBy = User.Identity.Name;
                        t.CreationDate = DateTime.Now;
                        t.CustomerId = m.CustomerId;
                        t.Email = m.Email;
                        t.IsVISMA = m.IsVISMA;
                        t.Kommune = m.Kommune;
                        t.Name = m.Name;
                        t.Phone = m.Phone;
                        t.PostOffice = m.PostOffice;
                        t.StatusId = new Guid(m.myStatus);
                        t.IsVISMA = false;
                        t.CustomerShippingId = Guid.NewGuid();

                        DB.tblCustomerShippings.Add(t);
                        DB.SaveChanges();
                        return RedirectToAction("Shipping", "Customers", new { CustomerId = m.CustomerId.ToString() });
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Edit Customer Shipping")]
        public ActionResult ShippingEdit(CustomerShipping m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblCustomerShipping t = (from g in DB.tblCustomerShippings
                                                         where g.CustomerShippingId == m.CustomerShippingId
                                                         select g).SingleOrDefault();
                        t.Address1 = m.Address1;
                        t.Address2 = m.Address2;
                        t.City = m.City;
                        t.CountryId = m.CountryId;
                        t.CustomerId = m.CustomerId;
                        t.Email = m.Email;
                        t.Kommune = m.Kommune;
                        t.Name = m.Name;
                        t.Phone = m.Phone;
                        t.PostOffice = m.PostOffice;
                        t.StatusId = new Guid(m.myStatus);
                        t.ModifyDate = DateTime.Now;
                        t.ModifyBy = User.Identity.Name;
                        t.CustomerShippingId = m.CustomerShippingId;
                        DB.SaveChanges();
                        return RedirectToAction("Shipping", "Customers", new { CustomerId = m.CustomerId.ToString() });

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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Delete Customer Shipping")]
        public ActionResult Delete(CustomerShipping m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblCustomerShipping tbl = (from g in DB.tblCustomerShippings
                                                           where g.CustomerShippingId == m.CustomerShippingId
                                                           select g).SingleOrDefault();
                        tbl.StatusId = new Guid(Utilities.Status_Delete);
                        tbl.ModifyDate = DateTime.Now;
                        tbl.ModifyBy = User.Identity.Name;
                        DB.SaveChanges();
                        return RedirectToAction("Shipping", "Customers", new { CustomerId = m.CustomerId.ToString() });
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

        #region UpdateVisma
//        {
//  "Name": "Test Customer",
//  "Address1": "Abc",
//  "EmailAddress": "abc@abc.com",
//  "PostCode": "7284",
//  "PostOffice": "Mausund",
//  "Phone": "123",
//  "InActiveYesNo": true,
//  "FormProfileCustNo": 2,
//  "CustomerProfileNo": 3,
//  "TermsOfPayCustNo": 2,
//  "CustomerGrpNo": 0,
//  "PriceCode": 1,
//  "CreditLimit": 99999999.99,
//  "CompanyNo": "123",
//  "BankAccount": "ABC",
//  "RemittanceProfileNo": 1,
//  "PrintProfileNo": 1
//}
        private async Task<int> UpdateCustomer(DBLayer.tblCustomer c)
        {
            using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
            {
                var obj = new JObject();
               

                obj["Name"] = c.Name == null ? "" : c.Name;
                obj["Address1"] = c.Address1 == null ? "" : c.Address1;
                obj["EmailAddress"] = c.Email == null ? "" : c.Email;
                obj["PostCode"] = "";
                obj["PostOffice"] = c.PostOffice == null ? "" : c.PostOffice;
                obj["Phone"] = c.Phone == null ? "" : c.Phone; 
                obj["InActiveYesNo"] = (c.StatusId.ToString() == Utilities.Status_Online) ? true : false;
                obj["FormProfileCustNo"] = 2;
                obj["CustomerProfileNo"] = 3;
                obj["TermsOfPayCustNo"] = 2;
                obj["CustomerGrpNo"] = 0;
                obj["PriceCode"] = 1;
                obj["CreditLimit"] = Convert.ToInt64(c.CreditLimit);
                obj["CompanyNo"] = Convert.ToInt64(c.OrganizationNumber);
                obj["BankAccount"] = c.BankAccount == null ? "" : c.BankAccount;
                obj["RemittanceProfileNo"]= 1;
                obj["PrintProfileNo"] = 1;
                obj["Address2"] = c.Address2 == null ? "" : c.Address2;
                obj["IBAN"] = c.IBAN == null ? "" : c.IBAN;
                //obj["SwiftCodeNo"] = Convert.ToInt32(c.SwiftCode);

                if (c.CustomerNo == null)
                    return await this.AddCustomer(obj);
                else
                {
                    obj["CustomerNo"] = c.CustomerNo;
                    return await this.UpdateCustomer(obj);
                }
            }
        }

        private async Task<int> AddCustomer(JObject model)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var uri = new Uri(Utilities.URL + "Customers");
                    var json = JsonConvert.SerializeObject(model);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(uri, stringContent);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var content = JObject.Parse(await response.Content.ReadAsStringAsync());
                        if (content["CustomerNo"] is JValue)
                        {
                            return (int)content["CustomerNo"];
                        }
                        else
                            return 0;
                    }
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        private async Task<int> UpdateCustomer(JObject model)
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
                        RequestUri = new Uri(Utilities.URL + "customers/" + model["CustomerNo"].ToString()),
                        Content = stringContent,
                    };
                    var response = await client.SendAsync(request);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        return Convert.ToInt32(model["CustomerNo"]);
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        #endregion

    }
}
