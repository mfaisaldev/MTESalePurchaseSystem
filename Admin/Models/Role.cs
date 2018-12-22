using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Admin.Models
{
    public class Role
    {
        public Guid RoleId { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Name cannot be longer than 250 characters.")]
        public string Name { get; set; }
        [StringLength(1024, ErrorMessage = "Name cannot be longer than 1024 characters.")]
        public string Description { get; set; }
        public Guid StatusId { get; set; }
        public List<Status> Status { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyDate { get; set; }

        public string myStatus { get; set; }
        public bool IsAllow { get; set; }
    }
    public class Menu
    {
        public Guid MenuId { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public int? DisplayOrder { get; set; }
        public Guid? ParentMenuId { get; set; }
        public string CSSClass { get; set; }
    }
    public class RoleMenu
    {
        public Guid RoleMenuId { get; set; }
        public Guid RoleId { get; set; }
        public Guid MenuId { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreationDate { get; set; }
    }
    public class RoleUser
    {
        public Guid RoleUserId { get; set; }
        public Guid RoleId { get; set; }
        public string UserName { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreationDate { get; set; }
    }

    public class MenuSearch
    {
        public Guid MenuId { get; set; }
        [Display(Name = "Menu Name")]
        public String MenuName { get; set; }
        public String UserName { get; set; }
        public Guid? ParentMenuId { get; set; }
//Roles
        public bool isCFO { get; set; }
        public bool isAdmin { get; set; }
        public bool isSales_Representative { get; set; }
        public bool isSupplier { get; set; }
        public bool isSales_Manager { get; set; }
        public bool isCustomer { get; set; }
        public bool isOperations { get; set; }

    }

}