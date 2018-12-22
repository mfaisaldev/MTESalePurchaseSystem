using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Models
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public int? EmployeeNo { get; set; }
        [Required]
        [StringLength(300, ErrorMessage = "Name cannot be longer than 300 characters.")]
        public string Name { get; set; }
        [StringLength(300, ErrorMessage = "Title cannot be longer than 300 characters.")]
        public string Title { get; set; }
        [Display(Name = "Internal Telephone")]
        [StringLength(300, ErrorMessage = "Internal Telephone cannot be longer than 300 characters.")]
        public string InternalTelephone { get; set; }
        [Display(Name = "Mobile Telephone")]
        [StringLength(300, ErrorMessage = "Mobile Telephone cannot be longer than 300 characters.")]
        public string MobileTelephone { get; set; }
        public Guid? CountryId { get; set; }
        [Display(Name = "Internal Telephone")]
        [StringLength(300, ErrorMessage = "Internal Telephone cannot be longer than 300 characters.")]
        public string PostOffice { get; set; }
        [Display(Name = "Post Code")]
        [StringLength(300, ErrorMessage = "Post Code cannot be longer than 300 characters.")]
        public string PostCode { get; set; }
        [StringLength(300, ErrorMessage = "Address1 cannot be longer than 300 characters.")]
        public string Address1 { get; set; }
        [Display(Name = "Hire Date")]
        public DateTime? HireDate { get; set; }
        public Guid? ReportsToId { get; set; }
        [Required]
        [Display(Name = "Bank Account")]
        [StringLength(300, ErrorMessage = "Bank Account cannot be longer than 300 characters.")]
        public string BankAccount { get; set; }
        [Display(Name = "Post Account")]
        [StringLength(300, ErrorMessage = "Post Account cannot be longer than 300 characters.")]
        public string PostAccount { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(300, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Email { get; set; }
        [StringLength(300, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Address3 { get; set; }
        [StringLength(300, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Address2 { get; set; }
        [Display(Name = "Nick Name")]
        [StringLength(300, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string NickName { get; set; }
        public int? Sex { get; set; }
        [Display(Name = "Middle Name")]
        [StringLength(300, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string MiddleName { get; set; }
        [StringLength(300, ErrorMessage = "The {0} must be at least {2} characters long.")]
        [Display(Name = "Family Name")]
        public string FamilyName { get; set; }
        [Display(Name = "Display Order")]
        public int? DisplayOrder { get; set; }
        public Guid StatusId { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyDate { get; set; }
        public Guid? FileId { get; set; }
        public bool IsVISMA { get; set; }
        public String myStatus { get; set; }
        public List<SelectListItem> status = new List<SelectListItem>();
        public List<SelectListItem> Status
        {
            get
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    var st = from g in DB.tblStatus
                             where g.StatusTypeId == new Guid(Utilities.StatusType_CURD)
                             select new { g.StatusId, g.Name };

                    foreach (var q in st)
                    {
                        status.Add(new SelectListItem() { Text = q.Name, Value = q.StatusId.ToString() });
                    }
                    return status;
                }
            }
        }

        public String myCountry { get; set; }
        public List<SelectListItem> country = new List<SelectListItem>();
        public List<SelectListItem> Country
        {
            get
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {

                    var ct = (from c in DB.tblCountries
                              where c.StatusId != new Guid(Utilities.Status_Delete)
                              select new { c.CountryId, c.Name, c.DisplayOrder }).OrderBy(x => x.DisplayOrder); ;

                    foreach (var q in ct)
                    {
                        country.Add(new SelectListItem() { Text = q.Name, Value = q.CountryId.ToString() });
                    }
                    return country;
                }
            }
        }
        public List<SelectListItem> sex = new List<SelectListItem>();
        public List<SelectListItem> Gender
        {
            get
            {
                sex.Add(new SelectListItem() { Text = "Male", Value = "0" });
                sex.Add(new SelectListItem() { Text = "Female", Value = "1" });
                return sex;
                
            }
        }
    }
}