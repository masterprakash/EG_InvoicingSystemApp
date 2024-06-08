using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoicingSystemApp.Interfaces;
using InvoicingSystemApp.Models;

namespace InvoicingSystemApp.Controllers
{
    public class ProductController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public void AddProduct(string name, string description, decimal price, int categoryId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Product name cannot be empty.");
                return;
            }

            if (price <= 0)
            {
                Console.WriteLine("Price must be greater than zero.");
                return;
            }

            var product = new Product
            {
                Name = name,
                Description = description,
                Price = price,
                CategoryId = categoryId
            };
            _productService.AddProduct(product);
            Console.WriteLine("Product added successfully.");
        }


        public void UpdateProduct(int productId, string name, string description, decimal price, int categoryId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Product name cannot be empty.");
                return;
            }

            if (price <= 0)
            {
                Console.WriteLine("Price must be greater than zero.");
                return;
            }

            var product = new Product
            {
                Id = productId,
                Name = name,
                Description = description,
                Price = price,
                CategoryId = categoryId
            };
            _productService.UpdateProduct(product);
            Console.WriteLine("Product updated successfully.");
        }


        public void DeleteProduct(int productId)
        {
            _productService.DeleteProduct(productId);
            Console.WriteLine("Product deleted successfully.");
        }

        public Product GetProductById(int productId)
        {
            var product = _productService.GetProductById(productId);
            if (product != null)
            {
                return product;
            }
            else
            {
                Console.WriteLine("Product not found.");
                return null;
            }
        }

        public void GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            if (products != null && products.Any())
            {
                foreach (var product in products)
                {
                    Console.WriteLine($"Product ID: {product.Id}");
                    Console.WriteLine($"Name: {product.Name}");
                    Console.WriteLine($"Price: {product.Price}");
                    Console.WriteLine($"Category ID: {product.CategoryId}");
                    Console.WriteLine("-----------------------------");
                }
            }
            else
            {
                Console.WriteLine("No products found.");
            }
        }
    }
}

