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
    
    public partial class tblUnit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblUnit()
        {
            this.tblProducts = new HashSet<tblProduct>();
            this.tblProductUnitTypes = new HashSet<tblProductUnitType>();
        }
    
        public System.Guid UnitId { get; set; }
        public string Name { get; set; }
        public string EDIName { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public System.Guid StatusId { get; set; }
        public string CreateBy { get; set; }
        public System.DateTime CreationDate { get; set; }
        public string ModifyBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public bool IsVISMA { get; set; }
        public Nullable<int> UnitNo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProduct> tblProducts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProductUnitType> tblProductUnitTypes { get; set; }
        public virtual tblStatu tblStatu { get; set; }
    }
}
