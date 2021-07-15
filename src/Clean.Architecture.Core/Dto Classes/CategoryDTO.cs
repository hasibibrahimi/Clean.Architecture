using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Architecture.Core.Dto_Classes
{
    public class CategoryDTO
    {
        public string CategoryName { get; set; }
    }
    public class CategoryWithPostDTO
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<string> Category_Posts { get; set; }
    }
}
