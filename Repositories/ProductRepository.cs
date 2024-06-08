using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoicingSystemApp.Interfaces;
using InvoicingSystemApp.Models;

namespace InvoicingSystemApp.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products = new List<Product>();

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product product)
        {
            product.Id = _products.Count + 1; // Assigning a simple incremental ID, replace with your own ID generation logic
            _products.Add(product);
        }

        public void Update(Product product)
        {
            var existingProduct = GetById(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.CategoryId = product.CategoryId;
                // Update other properties as needed
            }
        }

        public void Delete(int id)
        {
            var productToRemove = GetById(id);
            if (productToRemove != null)
            {
                _products.Remove(productToRemove);
            }
        }
    }
}

