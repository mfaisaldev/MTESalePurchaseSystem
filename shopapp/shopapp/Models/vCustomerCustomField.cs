namespace shopapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vCustomerCustomField
    {
        [Key]
        public Guid CustomField { get; set; }

        public int? CustomerNo { get; set; }

        public int? Id { get; set; }

        [StringLength(300)]
        public string Name { get; set; }

        [StringLength(300)]
        public string Value { get; set; }

        public bool IsUpdated { get; set; }
    }
}
