using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoicingSystemApp.Interfaces;
using InvoicingSystemApp.Models;

namespace InvoicingSystemApp.Controllers
{
    public class InvoiceController
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public void AddInvoice(int customerId, List<InvoiceItem> items)
        {
            if (items == null || items.Count == 0)
            {
                Console.WriteLine("Invoice must have at least one item.");
                return;
            }

            var invoice = new Invoice
            {
                CustomerId = customerId,
                InvoiceDate = DateTime.Now,
                Items = items
            };

            _invoiceService.AddInvoice(invoice);
            Console.WriteLine("Invoice added successfully.");
        }

        public void UpdateInvoice(int invoiceId, int customerId, List<InvoiceItem> items)
        {
            if (items == null || items.Count == 0)
            {
                Console.WriteLine("Invoice must have at least one item.");
                return;
            }

            var invoice = new Invoice
            {
                Id = invoiceId,
                CustomerId = customerId,
                InvoiceDate = DateTime.Now,
                Items = items
            };

            _invoiceService.UpdateInvoice(invoice);
            Console.WriteLine("Invoice updated successfully.");
        }

        public void DeleteInvoice(int invoiceId)
        {
            _invoiceService.DeleteInvoice(invoiceId);
            Console.WriteLine("Invoice deleted successfully.");
        }

        public void GetInvoiceById(int invoiceId)
        {
            var invoice = _invoiceService.GetInvoiceById(invoiceId);
            if (invoice != null)
            {
                Console.WriteLine($"Invoice ID: {invoice.Id}");
                Console.WriteLine($"Customer ID: {invoice.CustomerId}");
                Console.WriteLine($"Invoice Date: {invoice.InvoiceDate}");
                Console.WriteLine("Items:");
                foreach (var item in invoice.Items)
                {
                    Console.WriteLine($"Product ID: {item.ProductId}, Quantity: {item.Quantity}, Unit Price: {item.UnitPrice}, Total Price: {item.TotalPrice}");
                }
                Console.WriteLine($"Total Amount: {invoice.TotalAmount}");
            }
            else
            {
                Console.WriteLine("Invoice not found.");
            }
        }

        public void GetAllInvoices()
        {
            var invoices = _invoiceService.GetAllInvoices();
            if (invoices != null && invoices.Any())
            {
                foreach (var invoice in invoices)
                {
                    Console.WriteLine($"Invoice ID: {invoice.Id}");
                    Console.WriteLine($"Customer ID: {invoice.CustomerId}");
                    Console.WriteLine($"Invoice Date: {invoice.InvoiceDate}");
                    Console.WriteLine("Items:");
                    foreach (var item in invoice.Items)
                    {
                        Console.WriteLine($"Product ID: {item.ProductId}, Quantity: {item.Quantity}, Unit Price: {item.UnitPrice}, Total Price: {item.TotalPrice}");
                    }
                    Console.WriteLine($"Total Amount: {invoice.TotalAmount}");
                    Console.WriteLine("-----------------------------");
                }
            }
            else
            {
                Console.WriteLine("No invoices found.");
            }
        }
    }
}
