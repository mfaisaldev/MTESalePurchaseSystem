namespace shopapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblRole")]
    public partial class tblRole
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblRole()
        {
            tblRoleMenus = new HashSet<tblRoleMenu>();
            tblRoleUsers = new HashSet<tblRoleUser>();
        }

        [Key]
        public Guid RoleId { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        public Guid StatusId { get; set; }

        [Required]
        [StringLength(250)]
        public string CreateBy { get; set; }

        public DateTime CreationDate { get; set; }

        [StringLength(250)]
        public string ModifyBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ModifyDate { get; set; }

        public virtual tblStatu tblStatu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblRoleMenu> tblRoleMenus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblRoleUser> tblRoleUsers { get; set; }
    }
}
