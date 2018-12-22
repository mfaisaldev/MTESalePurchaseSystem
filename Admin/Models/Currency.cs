using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Admin.Models
{
    public class Currency
    {
        public Guid CurrencyId { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Name cannot be longer than 250 characters.")]
        public string Name { get; set; }

        [Display(Name = "Display Order")]
        public int? DisplayOrder { get; set; }
        public Guid StatusId { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Symbol cannot be longer than 250 characters.")]
        public string Symbol { get; set; }
        
    }
}