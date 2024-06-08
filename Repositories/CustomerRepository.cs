using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoicingSystemApp.Interfaces;
using InvoicingSystemApp.Models;

namespace InvoicingSystemApp.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private List<Customer> _customers = new List<Customer>();

        public IEnumerable<Customer> GetAll()
        {
            return _customers;
        }

        public Customer GetById(int id)
        {
            return _customers.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Customer customer)
        {
            customer.Id = _customers.Count + 1; // Assigning a simple incremental ID
            _customers.Add(customer);
        }

        public void Update(Customer customer)
        {
            var existingCustomer = GetById(customer.Id);
            if (existingCustomer != null)
            {
                existingCustomer.Name = customer.Name;
                existingCustomer.Email = customer.Email;
                existingCustomer.Address = customer.Address;
                // Update other properties as needed
            }
        }

        public void Delete(int id)
        {
            var customerToRemove = GetById(id);
            if (customerToRemove != null)
            {
                _customers.Remove(customerToRemove);
            }
        }
    }
}