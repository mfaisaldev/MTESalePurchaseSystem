//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Admin.DBLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblProductBrand
    {
        public System.Guid ProductBrandId { get; set; }
        public System.Guid ProductId { get; set; }
        public System.Guid BrandId { get; set; }
        public string CreateBy { get; set; }
        public System.DateTime CreationDate { get; set; }
    
        public virtual tblBrand tblBrand { get; set; }
        public virtual tblProduct tblProduct { get; set; }
    }
}
