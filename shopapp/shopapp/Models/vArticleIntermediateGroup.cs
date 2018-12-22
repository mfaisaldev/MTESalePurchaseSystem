namespace shopapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vArticleIntermediateGroup")]
    public partial class vArticleIntermediateGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IntermediateGroupNo { get; set; }

        [StringLength(300)]
        public string Name { get; set; }

        public int? MainGroupNo { get; set; }

        [StringLength(300)]
        public string SortName { get; set; }

        public DateTime? LastUpdate { get; set; }

        public int? LastUpdatedBy { get; set; }

        public DateTime? Created { get; set; }

        public int? CreatedBy { get; set; }

        public int? InActiveYesNo { get; set; }

        public bool IsUpdated { get; set; }
    }
}