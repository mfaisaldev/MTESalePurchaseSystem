using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Admin.Models
{
    public class SupplierOrders
    {
        public string SupplierOrderNo { get; set; }
        public string SupplierName { get; set; }
        public string SupplierOrderDate { get; set; }
        public string SupplierNo { get; set; }
        public string OrderType { get; set; }
        public Collection<SupplierOrderLines> Lines { get; set; }
    }
    public class SupplierOrderLines
    {
        public int Amount { get; set; }
        public string ArticleNo { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
