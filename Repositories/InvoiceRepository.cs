using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoicingSystemApp.Interfaces;
using InvoicingSystemApp.Models;

namespace InvoicingSystemApp.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private List<Invoice> _invoices = new List<Invoice>();

        public IEnumerable<Invoice> GetAll()
        {
            return _invoices;
        }

        public Invoice GetById(int id)
        {
            return _invoices.FirstOrDefault(i => i.Id == id);
        }

        public void Add(Invoice invoice)
        {
            invoice.Id = _invoices.Count + 1; // Assigning a simple incremental ID
            _invoices.Add(invoice);
        }

        public void Update(Invoice invoice)
        {
            var existingInvoice = GetById(invoice.Id);
            if (existingInvoice != null)
            {
                existingInvoice.CustomerId = invoice.CustomerId;
                existingInvoice.InvoiceDate = invoice.InvoiceDate;
                existingInvoice.Items = invoice.Items;
                existingInvoice.TotalAmount = invoice.TotalAmount;
                // Update other properties as needed
            }
        }

        public void Delete(int id)
        {
            var invoiceToRemove = GetById(id);
            if (invoiceToRemove != null)
            {
                _invoices.Remove(invoiceToRemove);
            }
        }
    }
}
