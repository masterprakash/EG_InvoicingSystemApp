using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoicingSystemApp.Interfaces;
using InvoicingSystemApp.Models;

namespace InvoicingSystemApp.Controllers
{
    public class CategoryController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public void AddCategory(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Category name cannot be empty.");
                return;
            }

            var category = new Category
            {
                Name = name
            };
            _categoryService.AddCategory(category);
            Console.WriteLine("Category added successfully.");
        }

        public void UpdateCategory(int categoryId, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Category name cannot be empty.");
                return;
            }

            var category = new Category
            {
                Id = categoryId,
                Name = name
            };
            _categoryService.UpdateCategory(category);
            Console.WriteLine("Category updated successfully.");
        }

        public void DeleteCategory(int categoryId)
        {
            _categoryService.DeleteCategory(categoryId);
            Console.WriteLine("Category deleted successfully.");
        }

        public void GetCategoryById(int categoryId)
        {
            var category = _categoryService.GetCategoryById(categoryId);
            if (category != null)
            {
                Console.WriteLine($"Category ID: {category.Id}");
                Console.WriteLine($"Name: {category.Name}");
            }
            else
            {
                Console.WriteLine("Category not found.");
            }
        }

        public void GetAllCategories()
        {
            var categories = _categoryService.GetAllCategories();
            if (categories != null && categories.Any())
            {
                foreach (var category in categories)
                {
                    Console.WriteLine($"Category ID: {category.Id}");
                    Console.WriteLine($"Name: {category.Name}");
                    Console.WriteLine("-----------------------------");
                }
            }
            else
            {
                Console.WriteLine("No categories found.");
            }
        }
    }
}
