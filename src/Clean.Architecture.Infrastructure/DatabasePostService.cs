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
   public class DatabasePostService:IPostService
    {
        private AppDbContext _context;

        public DatabasePostService(AppDbContext context)
        {
            _context = context;
        }
        public void AddPost(PostDTO post)
        {
            var _post = new Post()
            {
                Title = post.Title,
                Content = post.Content,
                DatePublished=post.DatePublished,
                UserId=post.UserId
               
            };
            _context.Posts.Add(_post);
            _context.SaveChanges();
        }
        public List<Post> GetPost()
        {
            return _context.Posts.ToList();
        }
    }
}
