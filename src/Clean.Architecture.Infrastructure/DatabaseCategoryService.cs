using Clean.Architecture.Core.Dto_Classes;
using Clean.Architecture.Core.Interfaces;
using Clean.Architecture.Core.Model;
using Clean.Architecture.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Architecture.Infrastructure
{
   public class DatabaseCategoryService:ICategoryService
    {
        private AppDbContext _context;

        public DatabaseCategoryService(AppDbContext context)
        {
            _context = context;
        }
        public void AddCategory(CategoryDTO category)
        {
            var _cateogry = new Category()
            {
                CategoryName = category.CategoryName
            };
            _context.Categories.Add(_cateogry);
            _context.SaveChanges();
        }
        public List<Category> GetCategory()
        {
            return _context.Categories.ToList();
        }
    }
}
