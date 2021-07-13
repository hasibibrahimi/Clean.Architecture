using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean.Architecture.Web.ViewModels
{
    public class CategoryVM
    {
        public string CategoryName { get; set; }
    }
    public class CategoryWithPostVM
    {
        public string CategoryName { get; set; }
        public List<string> Category_Posts { get; set; }
    }
}
