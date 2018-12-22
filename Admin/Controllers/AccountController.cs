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

namespace Admin.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager )
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
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

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    Session["ScreenLock"] = null;
                    Session["RoleId"] = null; 
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        if(DB.AspNetUsers.Where(u => u.UserName == model.Email && u.StatusId == new Guid(Utilities.Status_Online)).FirstOrDefault() ==null)
                        {
                            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                            ModelState.AddModelError("", "Your Account is not Activate.");
                            return View(model);
                        }
                        else
                        {
                            return RedirectToLocal(returnUrl);
                        }
                    }
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LockScreen(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    Session["ScreenLock"] = null;
                    Session["RoleId"] = null;
                    return RedirectToLocal(returnUrl);
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }


        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent:  model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        //
       // // GET: /Account/Register
       // [AllowAnonymous]
       // public ActionResult Register()
       // {

       //     var rvm = new RegisterViewModel();
       //     List<Country> myColl = new List<Country>();
       //     using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
       //     {
       //         var C = (from g in DB.tblCountries
       //                  join status in DB.tblStatus
       //                  on g.StatusId equals status.StatusId
       //                  where g.StatusId == new Guid(Utilities.Status_Active)
       //                  select new { g.CountryId, g.Name, g.DisplayOrder }).OrderBy(x => x.DisplayOrder);
       //         foreach (var ele in C)
       //         {
       //             myColl.Add(new Country()
       //             {
       //                 CountryId = ele.CountryId,
       //                 Name = ele.Name,
       //                 DisplayOrder = ele.DisplayOrder
       //             });
       //         }
       //         rvm.Countries = myColl;
       //     }
       //         return View(rvm);
       //}

        [AllowAnonymous]
        public ActionResult Register()
        {
            try
            {
                Registration m = new Registration();
                return View(m);
            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
                Registration m = new Registration();
                return View(m);
            }
        }

        //
        //// POST: /Account/Register
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Register(RegisterViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var CustomerId = Guid.NewGuid();

        //        var user = new ApplicationUser()
        //        {
        //            UserName = model.Email,
        //            Email = model.Email,
        //            CustomerId = CustomerId,
        //            StatusId = new Guid(Utilities.Status_Under_Porcess)
        //        };
        //        var result = await UserManager.CreateAsync(user, model.Password);
        //        if (result.Succeeded)
        //        {
        //            await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);

        //            // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
        //            // Send an email with this link
        //            // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
        //            // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
        //            // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
        //            using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
        //            {
        //                DBLayer.tblCustomer  tbl =new  DBLayer.tblCustomer();
        //                tbl.CustomerId = CustomerId;
        //                tbl.Address1 = model.Address1;
        //                tbl.Address2 = model.Address2;
        //                tbl.City = model.City;
        //                tbl.CountryId = model.CountryId;
        //                tbl.Email = model.Email;
        //                tbl.IsUser = false;
        //                tbl.Name = model.Name;
        //                tbl.OrganizationName = model.OrganizationName;
        //                tbl.OrganizationNumber = model.OrganizationNumber;
        //                tbl.Phone = model.Phone;
        //                tbl.PostOffice = model.PostOffice;
        //                tbl.StatusId = new Guid(Utilities.Status_Under_Porcess);
        //                tbl.CreationDate  = DateTime.Now;
        //                tbl.CreateBy  = model.Email;
        //                tbl.IsVISMA = false;
        //                tbl.UserName = model.Email;
        //                DB.tblCustomers.Add(tbl);
        //                DB.SaveChanges();
        //            }
        //                return RedirectToAction("AccountConfirm", "Account");
        //        }
        //        AddErrors(result);
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(Registration m)
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
                            StatusId = new Guid(Utilities.Status_Under_Porcess)
                        };
                        var result = await UserManager.CreateAsync(user, m.Password);
                        if (result.Succeeded)
                        {
                            await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);

                            DBLayer.tblCustomer t = new DBLayer.tblCustomer();
                            t.Address1 = m.Address1;
                            t.Address2 = m.Address2;
                            t.City = m.City;
                            t.CountryId = m.CountryId;
                            t.CreateBy = User.Identity.Name;
                            t.CreationDate = DateTime.Now;
                            t.CustomerId = CustomerId;
                            t.Email = m.Email;
                            t.IsVISMA = false;
                            t.Name = m.Name;
                            t.OrganizationName = m.OrganizationName;
                            t.OrganizationNumber = m.OrganizationNumber;
                            t.Phone = m.Phone;
                            t.PostOffice = m.PostOffice;
                            t.StatusId = new Guid(Utilities.Status_Under_Porcess);
                            t.UserName = m.Email;
                            DB.tblCustomers.Add(t);
                            DB.SaveChanges();

                            return RedirectToAction("AccountConfirm", "Account");
                        }
                        else
                        {
                            AddErrors(result);
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
                return View(m);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult AccountConfirm()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return View();
        }


        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                // await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                // return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        //[AllowAnonymous]
        //public ActionResult ResetPassword(string code)
        //{
        //    return code == null ? View("Error") : View();
        //}

        [HttpGet]
        [Authorize]
        public new ActionResult ResetPassword()
        {
            try
            {
                ResetPasswordViewModel r = new ResetPasswordViewModel();

                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {

                    DBLayer.tblCustomer t = (from g in DB.tblCustomers
                                             where g.UserName == User.Identity.Name.ToString()
                                             select g).SingleOrDefault();
                    r.Email = t.Email;

                }
                return View(r);
            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
                ResetPasswordViewModel r = new ResetPasswordViewModel();
                return View(r);
            }
        }


        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            var code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
            
            if (user != null)
            {
                var result = await UserManager.ResetPasswordAsync(user.Id, code, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Profile", "Account");
                }
            }
            return View(model);
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpGet]
        [Authorize]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            Session["RoleId"] = null;
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        [Authorize]
        public ActionResult LockScreen()
        {
            Session["ScreenLock"] = true;
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return View();
        }


        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }


        [HttpGet]
        [Authorize]
        public new ActionResult Profile()
        {
            try
            {
              
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {

                    DBLayer.tblCustomer t = (from g in DB.tblCustomers
                                             where g.UserName == User.Identity.Name.ToString()
                                            select g).SingleOrDefault();
                    Customer m = new Customer();
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
                    m.myCountry = t.tblCountry.Name;  
                        ViewBag.FileId = t.FileId;
                    return View(m);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
                var pm = new Customer();
                return View(pm);
            }
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "AllahisGreat";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Dashboard");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion

        #region Role
        public List<RoleUser> GetRoles()
        {
            if (Session == null)
            {

                List<RoleUser> lst = new List<RoleUser>();
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    var rs = (from c in DB.tblRoleUsers
                             where c.UserName == User.Identity.Name.ToString()
                             select new { c.RoleId});
                  
                   
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