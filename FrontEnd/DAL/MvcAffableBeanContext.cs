using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using FrontEnd.Models;
using System.Web.Configuration;

namespace FrontEnd.DAL
{


    public class MvcAffableBeanContext : WebContext

    {
        public MvcAffableBeanContext() : base("MvcAffableBean")
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<CustomerOrder> CustomerOrders { get; set; }

        public DbSet<OrderedProduct> Orderedproducts { get; set; }

        public DbSet<Cart> Carts { get; set; }

    }
}