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
    
    public partial class tblCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblCategory()
        {
            this.tblProductCategories = new HashSet<tblProductCategory>();
        }
    
        public System.Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public System.Guid StatusId { get; set; }
        public string CreateBy { get; set; }
        public System.DateTime CreationDate { get; set; }
        public string ModifyBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public Nullable<System.Guid> FileId { get; set; }
        public bool IsVISMA { get; set; }
        public Nullable<System.Guid> ParentCategoryId { get; set; }
        public Nullable<int> MainGroupNo { get; set; }
        public Nullable<int> IntermediateGroupNo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProductCategory> tblProductCategories { get; set; }
    }
}
