namespace shopapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblRoleMenu")]
    public partial class tblRoleMenu
    {
        [Key]
        public Guid RoleMenuId { get; set; }

        public Guid RoleId { get; set; }

        public Guid MenuId { get; set; }

        [Required]
        [StringLength(250)]
        public string CreateBy { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual tblMenu tblMenu { get; set; }

        public virtual tblRole tblRole { get; set; }
    }
}
