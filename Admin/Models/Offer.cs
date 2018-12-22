using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Models
{
    public class OfferModel
    {
        public Offer Offer { get; set; }
        public List<OfferDetail> OfferDetails { get; set; }
    }

    public class Offer
    {
        public Guid OfferId { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Name cannot be longer than 250 characters.")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Display Order")]
        public bool IsVISMA { get; set; }
        public Guid StatusId { get; set; }
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
        public Guid CustomerId { get; set; }
        public String myCustomer { get; set; }
        public List<SelectListItem> customer = new List<SelectListItem>();
        public List<SelectListItem> Customer
        {
            get
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    Guid StatusType_CURD = new Guid(Utilities.StatusType_CURD);

                    var st = from g in DB.tblCustomers
                             join ru in DB.tblRoleUsers 
                             on g.UserName equals ru.UserName
                             where g.StatusId == new Guid(Utilities.Status_Online) &
                             ru.RoleId.ToString().ToUpper() == Utilities.Role_Customer  
                             select new { g.CustomerId, g.Name };

                    foreach (var q in st)
                    {
                        customer.Add(new SelectListItem() { Text = q.Name, Value = q.CustomerId.ToString() });
                    }
                    return customer;
                }
            }
        }

        public string CreateBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyDate { get; set; }
        public DateTime? OfferDate { get; set; }
        public DateTime? OfferAcceptanceDate { get; set; }
        public DateTime? OfferApprovalDate { get; set; }
    }

    public class OfferDetail{
        public Guid OfferDetailId { get; set; }
        public Guid OfferId { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Name cannot be longer than 250 characters.")]
        public string ProductName { get; set; }
        public string History { get; set; }
        [Display(Name = "Product Price")]
        [DataType(DataType.Currency)]
        public decimal? ProductPrice { get; set; }
        [Display(Name = "Product Stock")]
        public int? ProductStock { get; set; }
        [Display(Name = "Offer Remarks")]
        public string OfferRemarks { get; set; }
        [Display(Name = "Offer Price")]
        [DataType(DataType.Currency)]
        public decimal? OfferPrice { get; set; }
        [Display(Name = "Offer Qty")]
        public int? OfferQty { get; set; }
        [Display(Name = "Customer Remarks")]
        public string CustomerRemarks { get; set; }
        [Display(Name = "Customer Price")]
        [DataType(DataType.Currency)]
        public decimal? CustomerPrice { get; set; }
        [Display(Name = "Customer Qty")]
        public int? CustomerQty { get; set; }
        [Display(Name = "Final Remarks")]
        public string FinalRemarks { get; set; }
        [Display(Name = "Final Price")]
        [DataType(DataType.Currency)]
        public decimal? FinalPrice { get; set; }
        [Display(Name = "Final Qty")]
        public int? FinalQty { get; set; }
        public bool IsVISMA { get; set; }
        public Guid StatusId { get; set; }
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
        public Guid ProductId { get; set; }
        public String myProduct { get; set; }
        public List<SelectListItem> product = new List<SelectListItem>();
        public List<SelectListItem> Product
        {
            get
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    Guid StatusType_CURD = new Guid(Utilities.StatusType_CURD);

                    var st = from g in DB.tblProducts
                             where g.StatusId == new Guid(Utilities.Status_Active)
                             select new { g.ProductId, g.Name };

                    foreach (var q in st)
                    {
                        product.Add(new SelectListItem() { Text = q.Name, Value = q.ProductId.ToString() });
                    }
                    return product;
                }
            }
        }
        public string CreateBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyDate { get; set; }

    }
}