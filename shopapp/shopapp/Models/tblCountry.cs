namespace shopapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCountry")]
    public partial class tblCountry
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblCountry()
        {
            tblCustomers = new HashSet<tblCustomer>();
            tblCustomerShippings = new HashSet<tblCustomerShipping>();
            tblSuppliers = new HashSet<tblSupplier>();
        }

        [Key]
        public Guid CountryId { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public int? DisplayOrder { get; set; }

        public Guid StatusId { get; set; }

        public virtual tblStatu tblStatu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCustomer> tblCustomers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCustomerShipping> tblCustomerShippings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSupplier> tblSuppliers { get; set; }
    }
}
