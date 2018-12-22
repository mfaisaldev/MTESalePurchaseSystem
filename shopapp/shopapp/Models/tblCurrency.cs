namespace shopapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCurrency")]
    public partial class tblCurrency
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblCurrency()
        {
            tblCustomers = new HashSet<tblCustomer>();
            tblProducts = new HashSet<tblProduct>();
            tblSuppliers = new HashSet<tblSupplier>();
        }

        [Key]
        public Guid CurrencyId { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public int? DisplayOrder { get; set; }

        public Guid StatusId { get; set; }

        [StringLength(250)]
        public string Symbol { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCustomer> tblCustomers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProduct> tblProducts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSupplier> tblSuppliers { get; set; }
    }
}
