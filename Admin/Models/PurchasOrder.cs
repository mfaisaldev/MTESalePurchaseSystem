using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Models
{
    public class PurchasOrderModel
    {
        public PurchasOrder PurchasOrder { get; set; }
        public List<PurchasOrderDetail> PurchasOrderDetails { get; set; }
    }

    public class PurchasOrder
    {
        public Guid PurchasOrderId { get; set; }
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
        public Guid SupplierId { get; set; }
        public String mySupplier { get; set; }
        public List<SelectListItem> supplier = new List<SelectListItem>();
        public List<SelectListItem> Supplier
        {
            get
            {
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    var st = from g in DB.tblSuppliers
                             where g.StatusId == new Guid(Utilities.Status_Online)
                             select new { g.SupplierId, g.Name };

                    foreach (var q in st)
                    {
                        supplier.Add(new SelectListItem() { Text = q.Name, Value = q.SupplierId.ToString() });
                    }
                    return supplier;
                }
            }
        }
        public string CreateBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyDate { get; set; }
        public DateTime? PurchasOrderDate { get; set; }
        public DateTime? ExpectDeliveryDate { get; set; }
        public DateTime? ActualDeliveryDate { get; set; }
        public bool IsAllItemReceive { get; set; }
    }
    public class PurchasOrderDetail
    {
        public Guid PurchasOrderDetailId { get; set; }
        public Guid PurchasOrderId { get; set; }
        public Guid ProductId { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        [StringLength(250, ErrorMessage = "Name cannot be longer than 250 characters.")]
        public string ProductName { get; set; }
        [Display(Name = "Product UCP Code")]
        [Required]
        [StringLength(250, ErrorMessage = "Product UCP Code cannot be longer than 250 characters.")]
        public string ProductUCPCode { get; set; }
        [Display(Name = "PO History")]
        public string PurchaseOrderHistory { get; set; }
        [Display(Name = "PO Price")]
        [DataType(DataType.Currency)]
        public decimal? PurchaseOrderPrice { get; set; }
        [Display(Name = "PO Qty")]
        public int? PurchaseOrderQty { get; set; }
        [Display(Name = "Receive Qty")]
        public int? ReceiveQty { get; set; }
        [Display(Name = "Receive Date")]
        public DateTime? ReceiveDate { get; set; }
        [Display(Name = "PO Remark")]
        public string PurchaseOrderRemark { get; set; }
        [Display(Name = "Is All Items Received")]
        public bool IsAllItemReceive { get; set; }
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

        public Guid? CustomerId { get; set; }
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
                             where g.StatusId == new Guid(Utilities.Status_Active)
                             select new { g.CustomerId, g.Name };

                    foreach (var q in st)
                    {
                        customer.Add(new SelectListItem() { Text = q.Name, Value = q.CustomerId.ToString() });
                    }
                    return customer;
                }
            }
        }
        [Display(Name = "Order Qty")]
        public int? OrderQty { get; set; }
        public Guid? OrderId { get; set; }
        public Guid? OrderDetailId { get; set; }
        [Display(Name = "Order Price")]
        [DataType(DataType.Currency)]
        public decimal? OrderPrice { get; set; }
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

    }

    public class vPurchasOrder
    {
        public string SupplierName { get; set; }
        public DateTime SupplierOrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int TotalAmount { get; set; }
        public string OurRef { get; set; }
        public int ContactNo { get; set; }
        public string NameContactNo { get; set; }
        public int SupplierNo { get; set; }
        public int TermsOfPaySupplNo { get; set; }
        public int WareHouseNo { get; set; }
        public int ProductNo { get; set; }
        public int DepNo { get; set; }
        public int ProjectNo { get; set; }
        public int VATCode { get; set; }
        public int TaxClassNo { get; set; }
        public int CurrencyNo { get; set; }
        public string Telephone { get; set; }
        public int DeliveredYesNo { get; set; }
        public string Address1 { get; set; }
        public string PostOffice { get; set; }
        public string PostCode { get; set; }
        public int CountryNo { get; set; }
        public int EmployeeNo { get; set; }
        public int DeliveryMethodsNo { get; set; }
        public int TermsOfDeliveryNo { get; set; }
        public int TotalDelivery { get; set; }
        public int InvoiceFee { get; set; }
        public int HandlingCharge { get; set; }
        public int Postage { get; set; }
        public int PurchaseDiscount { get; set; }
        public int PurchaseDiscountTaxFree { get; set; }
        public int PostageTaxFree { get; set; }
        public int CashDiscount { get; set; }
        public int CashDiscountTaxFree { get; set; }
        public DateTime DueDate { get; set; }
        public int ExchangeAmount { get; set; }
        public int ExchangeRate { get; set; }
        public string CompanyNo { get; set; }
        public int TotalVAT { get; set; }
        public DateTime VoucherDate { get; set; }
        public int DeliveryAddressNo { get; set; }
        public int DeliveryCountryNo { get; set; }
        public string DeliveryPostOffice { get; set; }
        public string DeliveryAddress1 { get; set; }
        public string DeliveryPostCode { get; set; }
        public string DeliveryAddress2 { get; set; }
        public string Address2 { get; set; }
        public DateTime OrderConfirmationDate { get; set; }
        public string SuppliersOrderNoRef { get; set; }
        public int TotalAmountFromInvoice { get; set; }
        public int FreightCost { get; set; }
        public int OrderType { get; set; }
    }

    public class vPurchasOrderLine
    {
        public string AltArtNo { get; set; }
        public int Amount { get; set; }
        public string ArticleNo { get; set; }
        public int CurrencyNo { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int DepNo { get; set; }
        public string Description { get; set; }
        public int DiscountGrpArtNo { get; set; }
        public int DiscountI { get; set; }
        public string EANNo { get; set; }
        public int EmployeeNo { get; set; }
        public int ExchangeAmount { get; set; }
        public int ExchangePurchasePrice { get; set; }
        public int ExchangeRate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int FullCost { get; set; }
        public int Invoiced { get; set; }
        public int InvoicePrice { get; set; }
        public string Name { get; set; }
        public int NetDeliveryAmount { get; set; }
        public int NetRemainderAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatus { get; set; }
        public int OrderType { get; set; }
        public int OriginalLineNo { get; set; }
        public int OriginalPrice { get; set; }
        public int OriginalQuantity { get; set; }
        public int PartReceived { get; set; }
        public int PostingTemplateNo { get; set; }
        public int PriceCalculationNo { get; set; }
        public int ProductNo { get; set; }
        public int ProjectNo { get; set; }
        public int Quantity { get; set; }
        public int Remainder { get; set; }
        public int StockProfileNo { get; set; }
        public int SupplierNo { get; set; }
        public string SupplierOrderNo { get; set; }
        public int TaxClassNo { get; set; }
        public int VATCode { get; set; }
        public int WareHouseNo { get; set; }
        public int Weight { get; set; }
        public int SuppliersOrderLineNo { get; set; }
        public int TotalInvoiced { get; set; }
        public int UnitTypeNo { get; set; }
    }

}