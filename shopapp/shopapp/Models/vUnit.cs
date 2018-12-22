namespace shopapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vUnit")]
    public partial class vUnit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UnitNo { get; set; }

        public DateTime? LastUpdate { get; set; }

        public int? LastUpdatedBy { get; set; }

        public DateTime? Created { get; set; }

        public int? CreatedBy { get; set; }

        [StringLength(300)]
        public string UnitName { get; set; }

        [StringLength(300)]
        public string EDIName { get; set; }

        public bool IsUpdated { get; set; }
    }
}
