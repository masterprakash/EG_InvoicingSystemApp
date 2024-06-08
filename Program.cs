using InvoicingSystemApp.Controllers;
using InvoicingSystemApp.Data;
using InvoicingSystemApp.Interfaces;
using InvoicingSystemApp.Repositories;
using InvoicingSystemApp.Services;
using InvoicingSystemApp.UI;
using InvoicingSystemApp.Utilities;
using System;

namespace InvoicingSystemApp
{
    class Program
    {
        static void Main(string[] args)
        {

            // Initialize services with appropriate repositories
            IProductRepository productRepository = new ProductRepository();
            ICategoryRepository categoryRepository = new CategoryRepository();
            ICustomerRepository customerRepository = new CustomerRepository();
            IInvoiceRepository invoiceRepository = new InvoiceRepository();

            IProductService productService = new ProductService(productRepository);
            ICategoryService categoryService = new CategoryService(categoryRepository);
            ICustomerService customerService = new CustomerService(customerRepository);
            IInvoiceService invoiceService = new InvoiceService(invoiceRepository);

            // Initialize controllers
            ProductController productController = new ProductController(productService);
            CategoryController categoryController = new CategoryController(categoryService);
            CustomerController customerController = new CustomerController(customerService);
            InvoiceController invoiceController = new InvoiceController(invoiceService);

            // Initialize utilities
            IDiscountStrategy discountStrategy = new PercentageDiscount(10); // Example: 10% discount
            IPaymentStrategy paymentStrategy = new CreditCardPayment();

            // Initialize UI
            ConsoleUI consoleUI = new ConsoleUI(productController, categoryController, customerController, invoiceController);

            // Run the application
            consoleUI.Run();
        }
    }
}
