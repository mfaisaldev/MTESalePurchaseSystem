﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace Admin.Models
{
    public class IntermediateGroup
    {
        public Guid IntermediateGroupId { get; set; }
        public int IntermediateGroupNo { get; set; }
        public Guid? MainGroupId { get; set; }
        public String myMainGroup { get; set; }
        public List<SelectListItem> maingroup = new List<SelectListItem>();
        public List<SelectListItem> MainGroup
        {
            get
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {

                    var ct = (from c in DB.tblMainGroups
                              where c.StatusId != new Guid(Utilities.Status_Delete)
                              select new { c.MainGroupId, c.Name, c.DisplayOrder }).OrderBy(x => x.DisplayOrder); ;
                    maingroup.Add(new SelectListItem() { Text = "", Value = Guid.Empty.ToString() });

                    foreach (var q in ct)
                    {
                        maingroup.Add(new SelectListItem() { Text = q.Name, Value = q.MainGroupId.ToString() });
                    }
                    return maingroup;
                }
            }
        }

        public int MainGroupNo { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Name cannot be longer than 250 characters.")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Display Order")]
        public int? DisplayOrder { get; set; }
        public Guid StatusId { get; set; }
        public Guid? FileId { get; set; }
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