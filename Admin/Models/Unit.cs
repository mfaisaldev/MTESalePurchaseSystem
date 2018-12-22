using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Models
{
    public class Unit
    {
        public Guid UnitId { get; set; }
        [Required]
        [Display(Name = "Unit Name")]
        [StringLength(300, ErrorMessage = "Unit Name cannot be longer than 300 characters.")]
        public string Name { get; set; }
        [Display(Name = "EDI Name")]
        [StringLength(300, ErrorMessage = "EDI Name cannot be longer than 300 characters.")]
        public string EDIName { get; set; }
        [Display(Name = "Display Order")]
        public int? DisplayOrder { get; set; }
        [Required]
        public Guid StatusId { get; set; }
        public bool IsVISMA { get; set; }
        public String myStatus { get; set; }
        public List<SelectListItem> status = new List<SelectListItem>();
        public List<SelectListItem> Status
        {
            get
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    Guid StatusType_CURD = new Guid(Utilities.StatusType_CURD);
                    var st = from g in DB.tblStatus
                             where g.StatusTypeId == StatusType_CURD
                             select new { g.StatusId, g.Name };
                    foreach (var q in st)
                    {
                        status.Add(new SelectListItem() { Text = q.Name, Value = q.StatusId.ToString() });
                    }
                    return status;
                }
            }
        }
        public string CreateBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyDate { get; set; }
    }

}