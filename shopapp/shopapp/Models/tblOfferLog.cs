namespace shopapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblOfferLog")]
    public partial class tblOfferLog
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblOfferLog()
        {
            tblOfferDetailLogs = new HashSet<tblOfferDetailLog>();
        }

        [Key]
        public Guid OfferlogId { get; set; }

        public Guid OfferId { get; set; }

        public Guid CustomerId { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

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

        public bool IsVISMA { get; set; }

        public DateTime? OfferDate { get; set; }

        public DateTime? OfferAcceptanceDate { get; set; }

        public DateTime? OfferApprovalDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblOfferDetailLog> tblOfferDetailLogs { get; set; }
    }
}
