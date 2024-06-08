using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoicingSystemApp.Models;

namespace InvoicingSystemApp.Data
{
    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            // Initialize database with sample data
            InMemoryDatabase.Products = new List<Product>
            {
                new Product { Id = 1, Name = "Television", Price = 499.99m, CategoryId = 1 },
                new Product { Id = 2, Name = "Phone", Price = 799.99m, CategoryId = 1 },
                new Product { Id = 3, Name = "Laptop", Price = 1299.99m, CategoryId = 2 }
            };

            InMemoryDatabase.Categories = new List<Category>
            {
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Computers" }
            };

            InMemoryDatabase.Customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Customer 1", Email = "customer1@example.com", Address = "Address 1" },
                new Customer { Id = 2, Name = "Customer 2", Email = "customer2@example.com", Address = "Address 2" }
            };

            InMemoryDatabase.Invoices = new List<Invoice>
            {
                new Invoice
                {
                    Id = 1,
                    CustomerId = 1,
                    InvoiceDate = DateTime.Now,
                    Items = new List<InvoiceItem>
                    {
                        new InvoiceItem { Id = 1, ProductId = 1, Quantity = 2, UnitPrice = 499.99m, TotalPrice = 999.98m },
                        new InvoiceItem { Id = 2, ProductId = 2, Quantity = 1, UnitPrice = 799.99m, TotalPrice = 799.99m }
                    },
                    TotalAmount = 1799.97m
                }
            };
        }
    }
}
