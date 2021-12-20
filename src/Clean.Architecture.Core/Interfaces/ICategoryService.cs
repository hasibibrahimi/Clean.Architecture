using Clean.Architecture.Core.Dto_Classes;
using Clean.Architecture.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Architecture.Core.Interfaces
{
    public interface ICategoryService
    {
        public void AddCategory(CategoryDTO category);
        public List<CategoryWithPostDTO> GetCategory();

        public void UpdateCategory(int id, CategoryDTO category);
        public CategoryWithPostDTO GetCategoryWithId(int id);
        public void DeleteCategory(int id);
    }
}
