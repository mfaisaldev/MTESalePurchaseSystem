using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Models
{
    public class OrderModel
    {
        public Order Order { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }

    public class Order
    {
        public Guid OrderId { get; set; }
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
        public DateTime? OrderDate { get; set; }
        [Display(Name = "Expected Delivery Date")]
        public DateTime? AcceptanceDeliveryDate { get; set; }
        [Display(Name = "Actual Delivery Date")]
        public DateTime? ActualDeliveryDate { get; set; }
        public Guid OfferId { get; set; }
    }

    public class OrderDetail
    {
        public Guid OrderDetailId { get; set; }
        public Guid OrderId { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Name cannot be longer than 250 characters.")]
        public string ProductName { get; set; }
        [Display(Name = "Product Price")]
        [DataType(DataType.Currency)]
        public decimal? ProductPrice { get; set; }
        [Display(Name = "Product Stock")]
        public int? ProductStock { get; set; }
        [Display(Name = "Order Remarks")]
        public string OrderRemarks { get; set; }
        [Display(Name = "Order Price")]
        [DataType(DataType.Currency)]
        public decimal? OrderPrice { get; set; }
        [Display(Name = "Order Qty")]
        public int? OrderQty { get; set; }
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
        public string ProductUCPCode { get; set; }
        public Guid? OfferDetailId { get; set; }
    }

    public class vOrder
    {
        public string CustomerName { get; set; }
        public int ContactNoInvoice { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string OurRef { get; set; }
        public int CustomerGrpNo { get; set; }
        public int DepNo { get; set; }
        public int ProjectNo { get; set; }
        public int VATCode { get; set; }
        public int CurrencyNo { get; set; }
        public string InvoicePostOffice { get; set; }
        public string InvoiceAddress1 { get; set; }
        public string DeliveryPostOffice { get; set; }
        public string InvoicePostCode { get; set; }
        public int CustomerNo { get; set; }
        public int DeliveryCountryNo { get; set; }
        public int EmployeeNo { get; set; }
        public string DeliveryAddress1 { get; set; }
        public DateTime DueDate { get; set; }
        public int OrderStatus { get; set; }
        public string CompanyNo { get; set; }
        public int TotalWeight { get; set; }
        public decimal TotalVAT { get; set; }
        public string DeliveryPostCode { get; set; }
        public int ExchangeAmount { get; set; }
        public int ExchangeRate { get; set; }
        public int PurchaseNo { get; set; }
        public int ProductNo { get; set; }
        public int ContactNoDelivery { get; set; }
        public string InvoiceAddress2 { get; set; }
        public string DeliveryAddress2 { get; set; }
        public int FactNo { get; set; }
        public int TotalWeightDelivered { get; set; }
        public string FactCustomerNo { get; set; }
        public string OriginalOrderNo { get; set; }
        public int AgreedAmount { get; set; }
        public int TermsOfDeliveryNo { get; set; }
        public int PaymentTypeNo { get; set; }
        public int TermsOfPayCustNo { get; set; }
        public bool CashPaymentYesNo { get; set; }
        public string InvoiceEmailAddress { get; set; }
        public string YourReference { get; set; }
        public int HandlingCharge { get; set; }
        public int Postage { get; set; }
        public int FreightcostPer { get; set; }
        public int DeliveryMethodsNo { get; set; }
        public int OrderType { get; set; }
    }

    public class vOrderLine
    {
        public string AltArtNo { get; set; }
        public int OrderStatus { get; set; }
        public int DepNo { get; set; }
        public string EANNo { get; set; }
        public DateTime OrderDate { get; set; }
        public string PLUNo { get; set; }
        public int PostingTemplateNo { get; set; }
        public int PurchasePrice { get; set; }
        public int TotalDelivered { get; set; }
        public decimal Amount { get; set; }
        public string ArticleNo { get; set; }
        public int CurrencyNo { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int DiscountI { get; set; }
        public int DiscountII { get; set; }
        public int DistributionFormulaNo { get; set; }
        public int EmployeeNo { get; set; }
        public int ExchangeAmount { get; set; }
        public int ExchangeRate { get; set; }
        public int ExchangeSalesPrice { get; set; }
        public int FullCost { get; set; }
        public int GLSalesAccountNo { get; set; }
        public int GrossPrice { get; set; }
        public int IntermediateGroupNo { get; set; }
        public int Invoiced { get; set; }
        public int MainGroupNo { get; set; }
        public string Name { get; set; }
        public int NetDeliveryAmount { get; set; }
        public int NetPrice { get; set; }
        public int ProductNo { get; set; }
        public int ProjectNo { get; set; }
        public int Quantity { get; set; }
        public int Remainder { get; set; }
        public int SubGroupNo { get; set; }
        public int TaxClassNo { get; set; }
        public int VATCode { get; set; }
        public int WareHouseNo { get; set; }
        public int Weight { get; set; }
        public int UniqueId { get; set; }
        public int PartDelivered { get; set; }
        public int UnitHeight { get; set; }
        public int UnitWidth { get; set; }
        public int UnitLength { get; set; }
        public int UnitTypeNo { get; set; }
    }
}