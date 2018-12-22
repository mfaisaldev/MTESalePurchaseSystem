namespace shopapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCustomerShipping")]
    public partial class tblCustomerShipping
    {
        [Key]
        public Guid CustomerShippingId { get; set; }

        public Guid CustomerId { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [StringLength(256)]
        public string Email { get; set; }

        [StringLength(256)]
        public string Phone { get; set; }

        [StringLength(1024)]
        public string Address1 { get; set; }

        [StringLength(1024)]
        public string Address2 { get; set; }

        [StringLength(256)]
        public string PostOffice { get; set; }

        [StringLength(256)]
        public string Kommune { get; set; }

        public Guid? CountryId { get; set; }

        [StringLength(256)]
        public string City { get; set; }

        public Guid? StatusId { get; set; }

        [StringLength(250)]
        public string CreateBy { get; set; }

        public DateTime? CreationDate { get; set; }

        [StringLength(250)]
        public string ModifyBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ModifyDate { get; set; }

        public bool IsVISMA { get; set; }

        public int AddressId { get; set; }

        public virtual tblCountry tblCountry { get; set; }

        public virtual tblCustomer tblCustomer { get; set; }

        public virtual tblStatu tblStatu { get; set; }
    }
}
