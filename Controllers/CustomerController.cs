using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoicingSystemApp.Interfaces;
using InvoicingSystemApp.Models;

namespace InvoicingSystemApp.Controllers
{
    public class CustomerController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public void AddCustomer(string name, string email, string address)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Customer name cannot be empty.");
                return;
            }

            var customer = new Customer
            {
                Name = name,
                Email = email,
                Address = address
            };
            _customerService.AddCustomer(customer);
            Console.WriteLine("Customer added successfully.");
        }

        public void UpdateCustomer(int customerId, string name, string email, string address)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Customer name cannot be empty.");
                return;
            }

            var customer = new Customer
            {
                Id = customerId,
                Name = name,
                Email = email,
                Address = address
            };
            _customerService.UpdateCustomer(customer);
            Console.WriteLine("Customer updated successfully.");
        }

        public void DeleteCustomer(int customerId)
        {
            _customerService.DeleteCustomer(customerId);
            Console.WriteLine("Customer deleted successfully.");
        }

        public void GetCustomerById(int customerId)
        {
            var customer = _customerService.GetCustomerById(customerId);
            if (customer != null)
            {
                Console.WriteLine($"Customer ID: {customer.Id}");
                Console.WriteLine($"Name: {customer.Name}");
                Console.WriteLine($"Email: {customer.Email}");
                Console.WriteLine($"Address: {customer.Address}");
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
        }

        public void GetAllCustomers()
        {
            var customers = _customerService.GetAllCustomers();
            if (customers != null && customers.Any())
            {
                foreach (var customer in customers)
                {
                    Console.WriteLine($"Customer ID: {customer.Id}");
                    Console.WriteLine($"Name: {customer.Name}");
                    Console.WriteLine($"Email: {customer.Email}");
                    Console.WriteLine($"Address: {customer.Address}");
                    Console.WriteLine("-----------------------------");
                }
            }
            else
            {
                Console.WriteLine("No customers found.");
            }
        }
    }
}

