namespace shopapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblSubGroup")]
    public partial class tblSubGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblSubGroup()
        {
            tblProducts = new HashSet<tblProduct>();
        }

        [Key]
        public Guid SubGroupId { get; set; }

        public int? SubGroupNo { get; set; }

        public Guid? IntermediateGroupId { get; set; }

        public int? IntermediateGroupNo { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int? DisplayOrder { get; set; }

        public Guid StatusId { get; set; }

        [Required]
        [StringLength(250)]
        public string CreateBy { get; set; }

        public DateTime CreationDate { get; set; }

        [StringLength(250)]
        public string ModifyBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ModifyDate { get; set; }

        public Guid? FileId { get; set; }

        public bool IsVISMA { get; set; }

        public virtual tblFile tblFile { get; set; }

        public virtual tblIntermediateGroup tblIntermediateGroup { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProduct> tblProducts { get; set; }

        public virtual tblStatu tblStatu { get; set; }
    }
}
