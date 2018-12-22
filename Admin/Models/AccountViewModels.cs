using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [RegularExpression("([a-z]|[A-Z]|[0-9]|[\\W]){4}[a-zA-Z0-9\\W]{3,11}", ErrorMessage = "Minimum 6 characters in length Contains 1 /2 of the following items:<br>-Uppercase Letters<br>- Lowercase Letters<br>- Numbers<br>- Symbols")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        [Display(Name = "Name")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Organization Name")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string OrganizationName { get; set; }
        [Required]
        [Display(Name = "Organization Number")]
        [StringLength(260, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string OrganizationNumber { get; set; }
        [StringLength(1024, ErrorMessage = "The {0} must be at least {2} characters long.")]
        [Display(Name = "Address line 1")]
        public string Address1 { get; set; }
        [StringLength(1024, ErrorMessage = "The {0} must be at least {2} characters long.")]
        [Display(Name = "Address line 1")]
        public string Address2 { get; set; }
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string City { get; set; }
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        [Display(Name = "Post Office")]
        public string PostOffice { get; set; }
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Kommune { get; set; }
        public List<Country> Countries  = new List<Country>();
        public Guid CountryId { get; set; }
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Phone { get; set; }

    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [RegularExpression("([a-z]|[A-Z]|[0-9]|[\\W]){4}[a-zA-Z0-9\\W]{3,11}", ErrorMessage = "Minimum 6 characters in length Contains 1 /2 of the following items:<br>-Uppercase Letters<br>- Lowercase Letters<br>- Numbers<br>- Symbols")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
