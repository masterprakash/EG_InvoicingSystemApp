using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoicingSystemApp.Models;

namespace InvoicingSystemApp.Interfaces
{
    public interface IInvoiceRepository
    {
        IEnumerable<Invoice> GetAll();
        Invoice GetById(int id);
        void Add(Invoice invoice);
        void Update(Invoice invoice);
        void Delete(int id);

    }
}