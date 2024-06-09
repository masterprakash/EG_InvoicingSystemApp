using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoicingSystemApp.Controllers;
using InvoicingSystemApp.Models;

namespace InvoicingSystemApp.UI
{
    public class ConsoleUI
    {
        private readonly ProductController _productController;
        private readonly CategoryController _categoryController;
        private readonly CustomerController _customerController;
        private readonly InvoiceController _invoiceController;

        public ConsoleUI(
            ProductController productController,
            CategoryController categoryController,
            CustomerController customerController,
            InvoiceController invoiceController)
        {
            _productController = productController;
            _categoryController = categoryController;
            _customerController = customerController;
            _invoiceController = invoiceController;
        }

        public void Run()
        {
            while (true)
            {
                DisplayMainMenu();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ProductSubMenu();
                        break;
                    case "2":
                        CategorySubMenu();
                        break;
                    case "3":
                        CustomerSubMenu();
                        break;
                    case "4":
                        InvoicingSubMenu();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("\nInvalid choice. Please try again.\n");
                        break;
                }
            }
        }

        private void DisplayMainMenu()
        {
            Console.WriteLine("\n");
            Console.WriteLine("     Invoicing System Console Application");
            Console.WriteLine("     -------------------------------------");
            Console.WriteLine("     1. Product Management");
            Console.WriteLine("     2. Category Management");
            Console.WriteLine("     3. Customer Management");
            Console.WriteLine("     4. Invoicing");
            Console.WriteLine("     5. Exit");
            Console.Write("     Please enter your choice: ");
        }

        private void ProductSubMenu()
        {
            while (true)
            {
                DisplayProductMenu();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        UpdateProduct();
                        break;
                    case "3":
                        DeleteProduct();
                        break;
                    case "4":
                        GetProductById();
                        break;
                    case "5":
                        GetAllProducts();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("\nInvalid choice. Please try again.\n");
                        break;
                }
            }
        }

        private void DisplayProductMenu()
        {
            Console.WriteLine("\n");
            Console.WriteLine("     Product Management");
            Console.WriteLine("     ------------------");
            Console.WriteLine("     1. Add Product");
            Console.WriteLine("     2. Update Product");
            Console.WriteLine("     3. Delete Product");
            Console.WriteLine("     4. Get Product by ID");
            Console.WriteLine("     5. Get All Products");
            Console.WriteLine("     6. Back to Main Menu");
            Console.Write("     Please enter your choice: ");
        }

        private void AddProduct()
        {
            Console.WriteLine("Enter product name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter product description:");
            string description = Console.ReadLine();
            decimal price;
            while (true)
            {
                Console.WriteLine("Enter product price:");
                if (decimal.TryParse(Console.ReadLine(), out price) && price > 0)
                {
                    break;
                }
                Console.WriteLine("Invalid price. Please enter a valid positive decimal value.");
            }
            int categoryId;
            while (true)
            {
                Console.WriteLine("Enter product category ID:");
                if (int.TryParse(Console.ReadLine(), out categoryId))
                {
                    break;
                }
                Console.WriteLine("Invalid category ID. Please enter a valid integer value.");
            }

            _productController.AddProduct(name, description, price, categoryId);
        }

        private void UpdateProduct()
        {
            Console.WriteLine(" Enter product ID to update:");
            int productId;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out productId) && productId > 0)
                {
                    break;
                }
                Console.WriteLine(" Invalid product ID. Please enter a valid positive integer value.");
            }

            Console.WriteLine(" Enter new product name:");
            string name = Console.ReadLine();
            Console.WriteLine(" Enter new product description:");
            string description = Console.ReadLine();
            decimal price;
            while (true)
            {
                Console.WriteLine(" Enter new product price:");
                if (decimal.TryParse(Console.ReadLine(), out price) && price > 0)
                {
                    break;
                }
                Console.WriteLine(" Invalid price. Please enter a valid positive decimal value.");
            }
            int categoryId;
            while (true)
            {
                Console.WriteLine(" Enter new product category ID:");
                if (int.TryParse(Console.ReadLine(), out categoryId))
                {
                    break;
                }
                Console.WriteLine(" Invalid category ID. Please enter a valid integer value.");
            }

            _productController.UpdateProduct(productId, name, description, price, categoryId);
        }

        private void DeleteProduct()
        {
            Console.WriteLine("Enter product ID to delete:");
            int productId;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out productId) && productId > 0)
                {
                    break;
                }
                Console.WriteLine("Invalid product ID. Please enter a valid positive integer value.");
            }

            _productController.DeleteProduct(productId);
        }

        private void GetProductById()
        {
            Console.WriteLine("Enter product ID to retrieve:");
            int productId;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out productId) && productId > 0)
                {
                    break;
                }
                Console.WriteLine("Invalid product ID. Please enter a valid positive integer value.");
            }

            _productController.GetProductById(productId);
        }

        private void GetAllProducts()
        {
            _productController.GetAllProducts();
        }

        private void CategorySubMenu()
        {
            while (true)
            {
                DisplayCategoryMenu();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddCategory();
                        break;
                    case "2":
                        UpdateCategory();
                        break;
                    case "3":
                        DeleteCategory();
                        break;
                    case "4":
                        GetCategoryById();
                        break;
                    case "5":
                        GetAllCategories();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("\nInvalid choice. Please try again.\n");
                        break;
                }
            }
        }

        private void DisplayCategoryMenu()
        {
            Console.WriteLine("\n");
            Console.WriteLine("     Category Management");
            Console.WriteLine("     -------------------");
            Console.WriteLine("     1. Add Category");
            Console.WriteLine("     2. Update Category");
            Console.WriteLine("     3. Delete Category");
            Console.WriteLine("     4. Get Category by ID");
            Console.WriteLine("     5. Get All Categories");
            Console.WriteLine("     6. Back to Main Menu");
            Console.Write("     Please enter your choice: ");
        }

        private void AddCategory()
        {
            Console.WriteLine("Enter category name:");
            string name = Console.ReadLine();

            _categoryController.AddCategory(name);
        }
        private void UpdateCategory()
        {
            Console.WriteLine("Enter category ID to update:");
            int categoryId;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out categoryId) && categoryId > 0)
                {
                    break;
                }
                Console.WriteLine("Invalid category ID. Please enter a valid positive integer value.");
            }

            Console.WriteLine("Enter new category name:");
            string name = Console.ReadLine();
            _categoryController.UpdateCategory(categoryId, name);
        }

        private void DeleteCategory()
        {
            Console.WriteLine("Enter category ID to delete:");
            int categoryId;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out categoryId) && categoryId > 0)
                {
                    break;
                }
                Console.WriteLine("Invalid category ID. Please enter a valid positive integer value.");
            }

            _categoryController.DeleteCategory(categoryId);
        }

        private void GetCategoryById()
        {
            Console.WriteLine("Enter category ID to retrieve:");
            int categoryId;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out categoryId) && categoryId > 0)
                {
                    break;
                }
                Console.WriteLine("Invalid category ID. Please enter a valid positive integer value.");
            }

            _categoryController.GetCategoryById(categoryId);
        }

        private void GetAllCategories()
        {
            _categoryController.GetAllCategories();
        }

        private void CustomerSubMenu()
        {
            while (true)
            {
                DisplayCustomerMenu();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddCustomer();
                        break;
                    case "2":
                        UpdateCustomer();
                        break;
                    case "3":
                        DeleteCustomer();
                        break;
                    case "4":
                        GetCustomerById();
                        break;
                    case "5":
                        GetAllCustomers();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("\nInvalid choice. Please try again.\n");
                        break;
                }
            }
        }

        private void DisplayCustomerMenu()
        {
            Console.WriteLine("\n");
            Console.WriteLine("     Customer Management");
            Console.WriteLine("     -------------------");
            Console.WriteLine("     1. Add Customer");
            Console.WriteLine("     2. Update Customer");
            Console.WriteLine("     3. Delete Customer");
            Console.WriteLine("     4. Get Customer by ID");
            Console.WriteLine("     5. Get All Customers");
            Console.WriteLine("     6. Back to Main Menu");
            Console.Write("     Please enter your choice: ");
        }

        private void AddCustomer()
        {
            Console.WriteLine("Enter customer name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter customer address:");
            string address = Console.ReadLine();
            Console.WriteLine("Enter customer phone number:");
            string phoneNumber = Console.ReadLine();

            _customerController.AddCustomer(name, address, phoneNumber);
        }

        private void UpdateCustomer()
        {
            Console.WriteLine("Enter customer ID to update:");
            int customerId;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out customerId) && customerId > 0)
                {
                    break;
                }
                Console.WriteLine("Invalid customer ID. Please enter a valid positive integer value.");
            }

            Console.WriteLine("Enter new customer name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter new customer address:");
            string address = Console.ReadLine();
            Console.WriteLine("Enter new customer phone number:");
            string phoneNumber = Console.ReadLine();

            _customerController.UpdateCustomer(customerId, name, address, phoneNumber);
        }

        private void DeleteCustomer()
        {
            Console.WriteLine("Enter customer ID to delete:");
            int customerId;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out customerId) && customerId > 0)
                {
                    break;
                }
                Console.WriteLine("Invalid customer ID. Please enter a valid positive integer value.");
            }

            _customerController.DeleteCustomer(customerId);
        }

        private void GetCustomerById()
        {
            Console.WriteLine("Enter customer ID to retrieve:");
            int customerId;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out customerId) && customerId > 0)
                {
                    break;
                }
                Console.WriteLine("Invalid customer ID. Please enter a valid positive integer value.");
            }

            _customerController.GetCustomerById(customerId);
        }

        private void GetAllCustomers()
        {
            _customerController.GetAllCustomers();
        }

        private void InvoicingSubMenu()
        {
            while (true)
            {
                DisplayInvoicingMenu();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddInvoice();
                        break;
                    case "2":
                        UpdateInvoice();
                        break;
                    case "3":
                        DeleteInvoice();
                        break;
                    case "4":
                        GetInvoiceById();
                        break;
                    case "5":
                        GetAllInvoices();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("\nInvalid choice. Please try again.\n");
                        break;
                }
            }
        }

        private void DisplayInvoicingMenu()
        {
            Console.WriteLine("\n");
            Console.WriteLine("     Invoicing");
            Console.WriteLine("     ---------");
            Console.WriteLine("     1. Add Invoice");
            Console.WriteLine("     2. Update Invoice");
            Console.WriteLine("     3. Delete Invoice");
            Console.WriteLine("     4. Get Invoice by ID");
            Console.WriteLine("     5. Get All Invoices");
            Console.WriteLine("     6. Back to Main Menu");
            Console.Write("     Please enter your choice: ");
        }

        private void AddInvoice()
        {
            Console.WriteLine("Enter customer ID:");
            int customerId;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out customerId) && customerId > 0)
                {
                    break;
                }
                Console.WriteLine("Invalid customer ID. Please enter a valid positive integer value.");
            }

            var items = new List<InvoiceItem>();
            while (true)
            {
                Console.WriteLine("Enter product ID to add to the invoice (enter 0 to finish):");
                if (int.TryParse(Console.ReadLine(), out int productId) && productId > 0)
                {
                    var product = _productController.GetProductById(productId);
                    if (product != null)
                    {
                        Console.WriteLine($"Enter quantity for product {product.Name}:");
                        int quantity;
                        while (true)
                        {
                            if (int.TryParse(Console.ReadLine(), out quantity) && quantity > 0)
                            {
                                break;
                            }
                            Console.WriteLine("Invalid quantity. Please enter a valid positive integer value.");
                        }

                        var invoiceItem = new InvoiceItem
                        {
                            ProductId = productId,
                            Quantity = quantity,
                            UnitPrice = product.Price,
                            TotalPrice = product.Price * quantity
                        };

                        items.Add(invoiceItem);
                        Console.WriteLine($"Added item: {product.Name}, Quantity: {quantity}, Unit Price: {product.Price}, Total Price: {invoiceItem.TotalPrice}");
                    }
                    else
                    {
                        Console.WriteLine("Product not found.");
                    }
                }
                else if (productId == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid product ID. Please enter a valid positive integer value.");
                }
            }

            _invoiceController.AddInvoice(customerId, items);
        }


        private void UpdateInvoice()
        {
            Console.WriteLine("Enter invoice ID to update:");
            int invoiceId;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out invoiceId) && invoiceId > 0)
                {
                    break;
                }
                Console.WriteLine("Invalid invoice ID. Please enter a valid positive integer value.");
            }

            Console.WriteLine("Enter new customer ID:");
            int customerId;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out customerId) && customerId > 0)
                {
                    break;
                }
                Console.WriteLine("Invalid customer ID. Please enter a valid positive integer value.");
            }

            var items = new List<InvoiceItem>();
            while (true)
            {
                Console.WriteLine("Enter product ID to add to the invoice (enter 0 to finish):");
                if (int.TryParse(Console.ReadLine(), out int productId) && productId > 0)
                {
                    var product = _productController.GetProductById(productId);
                    if (product != null)
                    {
                        Console.WriteLine($"Enter quantity for product {product.Name}:");
                        int quantity;
                        while (true)
                        {
                            if (int.TryParse(Console.ReadLine(), out quantity) && quantity > 0)
                            {
                                break;
                            }
                            Console.WriteLine("Invalid quantity. Please enter a valid positive integer value.");
                        }

                        var invoiceItem = new InvoiceItem
                        {
                            ProductId = productId,
                            Quantity = quantity,
                            UnitPrice = product.Price,
                            TotalPrice = product.Price * quantity
                        };

                        items.Add(invoiceItem);
                        Console.WriteLine($"Added item: {product.Name}, Quantity: {quantity}, Unit Price: {product.Price}, Total Price: {invoiceItem.TotalPrice}");
                    }
                    else
                    {
                        Console.WriteLine("Product not found.");
                    }
                }
                else if (productId == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid product ID. Please enter a valid positive integer value.");
                }
            }

            _invoiceController.UpdateInvoice(invoiceId, customerId, items);
        }


        private void DeleteInvoice()
        {
            Console.WriteLine("Enter invoice ID to delete:");
            int invoiceId;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out invoiceId) && invoiceId > 0)
                {
                    break;
                }
                Console.WriteLine("Invalid invoice ID. Please enter a valid positive integer value.");
            }

            _invoiceController.DeleteInvoice(invoiceId);
        }

        private void GetInvoiceById()
        {
            Console.WriteLine("Enter invoice ID to retrieve:");
            int invoiceId;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out invoiceId) && invoiceId > 0)
                {
                    break;
                }
                Console.WriteLine("Invalid invoice ID. Please enter a valid positive integer value.");
            }

            _invoiceController.GetInvoiceById(invoiceId);
        }

        private void GetAllInvoices()
        {
            _invoiceController.GetAllInvoices();
        }
    }
}
