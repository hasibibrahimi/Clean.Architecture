using Clean.Architecture.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean.Architecture.Web.ViewModels
{
    public class PostVM
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DatePublished { get; set; }
        public List<int> Category_PostId { get; set; }
        public int UserId { get; set; }
    }
    public class PostwithCategoryVM
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DatePublished { get; set; }
        public List<string> Category_Posts { get; set; }
        public string UserName { get; set; }
    }
}
