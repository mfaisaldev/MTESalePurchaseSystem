//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Scheduler
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblRoleMenu
    {
        public System.Guid RoleMenuId { get; set; }
        public System.Guid RoleId { get; set; }
        public System.Guid MenuId { get; set; }
        public string CreateBy { get; set; }
        public System.DateTime CreationDate { get; set; }
    
        public virtual tblMenu tblMenu { get; set; }
        public virtual tblRole tblRole { get; set; }
    }
}
