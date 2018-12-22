using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Models
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Name cannot be longer than 250 characters.")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Display Order")]
        public int? DisplayOrder { get; set; }
        public Guid StatusId { get; set; }
        public Guid? FileId { get; set; }
        public bool IsVISMA { get; set; }
        [Display(Name = "Parent Category")]
        public Guid? ParentCategoryId { get; set; }
        public String myParentCategory { get; set; }
        public List<SelectListItem> parentCategory = new List<SelectListItem>();
        public List<SelectListItem> ParentCategory
        {
            get
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    parentCategory.Add(new SelectListItem() { Text = "No Parent Category", Value = Guid.Empty.ToString() });

                    var ct = (from c in DB.tblCategories
                              where c.StatusId != new Guid(Utilities.Status_Delete)
                              select new { c.CategoryId, c.Name, c.DisplayOrder }).OrderBy(x => x.DisplayOrder); ;

                    foreach (var q in ct)
                    {
                        if(q.CategoryId != this.CategoryId)
                            parentCategory.Add(new SelectListItem() { Text = q.Name, Value = q.CategoryId.ToString() });
                    }
                    return parentCategory;
                }
            }
        }

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
        public virtual Category Categories { get; set; }
    }
}