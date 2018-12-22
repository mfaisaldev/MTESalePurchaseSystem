using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.Models
{
    public class Dashboard
    {
        public int Customers { get; set;}
        public int Suppliers { get; set; }
        public int Products { get; set; }
        public int Offers { get; set; }
        public int Orders { get; set; }
        public int PruchaseOrders { get; set; }
        public int OfferCompleted { get; set; }
        public int POCompleted { get; set; }
        public int OrderCompleted { get; set; }
        public string OfferPersentage { get; set; }
        public string POPersentage { get; set; }
        public string OrderPersentage { get; set; }

    }
}