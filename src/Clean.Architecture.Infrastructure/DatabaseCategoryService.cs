using Clean.Architecture.Core.Dto_Classes;
using Clean.Architecture.Core.Interfaces;
using Clean.Architecture.Core.Model;
using Clean.Architecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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
        public List<CategoryWithPostDTO> GetCategory()
        {
            var categorieslist = _context.Categories.Include(t => t.Category_Posts).ThenInclude(t => t.Post);
            var r = categorieslist;
            List<CategoryWithPostDTO> asd = new List<CategoryWithPostDTO>();
            foreach (var item in r)
            {
                var _dto = new CategoryWithPostDTO()
                {
                    Id=item.Id,
                    CategoryName = item.CategoryName,
                    Category_Posts = item.Category_Posts.Select(n=>n.Post.Title).ToList()
                };
                asd.Add(_dto);
            }
            return asd;
        }
        public CategoryWithPostDTO GetCategoryWithId(int id)
        {

            var _category = _context.Categories.Where(n => n.Id == id).Select(n => new CategoryWithPostDTO()
            {
                Id=n.Id,
                CategoryName = n.CategoryName,
                Category_Posts = n.Category_Posts.Select(n => n.Post.Title).ToList()
            }).FirstOrDefault();
            return _category;
        }
    }
}
