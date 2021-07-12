using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Architecture.Core.Model
{
   public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<Category_Post> Category_Posts { get; set; }

    }
}
