namespace shopapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vCustomerAddress")]
    public partial class vCustomerAddress
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(300)]
        public string Name { get; set; }

        [StringLength(300)]
        public string InvoiceAdress1 { get; set; }

        [StringLength(300)]
        public string InvoiceAdress2 { get; set; }

        [StringLength(300)]
        public string InvoiceAdress3 { get; set; }

        [StringLength(300)]
        public string PostCode { get; set; }

        [StringLength(300)]
        public string PostOffice { get; set; }

        public bool IsUpdated { get; set; }

        public int CustomerNo { get; set; }
    }
}
