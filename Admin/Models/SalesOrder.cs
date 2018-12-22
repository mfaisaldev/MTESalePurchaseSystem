using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Admin.Models
{
    public class SalesOrder
    {
        public string OrderNo { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int TotalAmount { get; set; }
        public int CustomerNo { get; set; }
        public int OrderType { get; set; }
        public Collection<Lines> Lines { get; set; }
    }

    public class Lines
    {
        public DateTime OrderDate { get; set; }
        public int Amount { get; set; }
        public string ArticleNo { get; set; }
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
        public int MainGroupNo { get; set; }
        public string Name { get; set; }
        public int NetDeliveryAmount { get; set; }
        public int NetPrice { get; set; }
        public int ProductNo { get; set; }
        public int ProjectNo { get; set; }
        public int Quantity { get; set; }
    }
}