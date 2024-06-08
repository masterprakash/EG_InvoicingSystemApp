using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoicingSystemApp.Interfaces;
using InvoicingSystemApp.Models;

namespace InvoicingSystemApp.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private List<Category> _categories = new List<Category>();

        public IEnumerable<Category> GetAll()
        {
            return _categories;
        }

        public Category GetById(int id)
        {
            return _categories.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Category category)
        {
            category.Id = _categories.Count + 1; // Assigning a simple incremental ID
            _categories.Add(category);
        }

        public void Update(Category category)
        {
            var existingCategory = GetById(category.Id);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                // Update other properties as needed
            }
        }

        public void Delete(int id)
        {
            var categoryToRemove = GetById(id);
            if (categoryToRemove != null)
            {
                _categories.Remove(categoryToRemove);
            }
        }
    }
}