using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InvoicingSystemApp.Models;

namespace InvoicingSystemApp.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);

    }
}
