using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Architecture.Core.Model
{
    public class Category_Post
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int PostId { get; set; }
        public Category Category { get; set; }
        public Post Post { get; set; }
    }

}
