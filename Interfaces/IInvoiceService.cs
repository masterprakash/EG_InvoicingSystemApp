using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoicingSystemApp.Models;

namespace InvoicingSystemApp.Interfaces
{
    public interface IInvoiceService
    {
        IEnumerable<Invoice> GetAllInvoices();
        Invoice GetInvoiceById(int id);
        void AddInvoice(Invoice invoice);
        void UpdateInvoice(Invoice invoice);
        void DeleteInvoice(int id);

    }
}