using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoicingSystemApp.Models;

namespace InvoicingSystemApp.Data
{
    public  class InMemoryDatabase
    {
        public static List<Product> Products { get; set; }
        public static List<Category> Categories { get; set; }
        public static List<Customer> Customers { get; set; }
        public static List<Invoice> Invoices { get; set; }

        public  InMemoryDatabase()
        {
            // Initialize lists
            Products = new List<Product>();
            Categories = new List<Category>();
            Customers = new List<Customer>();
            Invoices = new List<Invoice>();

            // Initialize database
            DatabaseInitializer.Initialize();
        }
    }
}
