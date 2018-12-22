namespace shopapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblMainGroup")]
    public partial class tblMainGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblMainGroup()
        {
            tblIntermediateGroups = new HashSet<tblIntermediateGroup>();
            tblProducts = new HashSet<tblProduct>();
        }

        [Key]
        public Guid MainGroupId { get; set; }

        public int? MainGroupNo { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblIntermediateGroup> tblIntermediateGroups { get; set; }

        public virtual tblStatu tblStatu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProduct> tblProducts { get; set; }
    }
}
