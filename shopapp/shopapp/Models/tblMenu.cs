namespace shopapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblMenu")]
    public partial class tblMenu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblMenu()
        {
            tblRoleMenus = new HashSet<tblRoleMenu>();
        }

        [Key]
        public Guid MenuId { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string URL { get; set; }

        public int? DisplayOrder { get; set; }

        public Guid? ParentMenuId { get; set; }

        [StringLength(250)]
        public string CSSClass { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblRoleMenu> tblRoleMenus { get; set; }
    }
}
