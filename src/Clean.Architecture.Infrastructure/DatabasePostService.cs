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
            foreach (var id in post.CategorysId)
            {
                var _category_post = new Category_Post()
                {
                    PostId = _post.Id ,
                    CategoryId = id
                };
                _context.Category_Posts.Add(_category_post);
                _context.SaveChanges();

            }
        }
        public List<PostwithCategoryDTO> GetPost()
        {
            // return _context.Posts.ToList();
            var temp = _context.Posts.Include(n => n.User);
            
            List<PostwithCategoryDTO> test = new List<PostwithCategoryDTO>();
            foreach (var item in temp.Include(n=>n.Category_Posts).ThenInclude(n=>n.Category))
            {
                var _dto = new PostwithCategoryDTO()
                {
                    Id=item.Id,
                    Title = item.Title,
                    Content = item.Content,
                    DatePublished = item.DatePublished,
                    UserName = item.User.UserName,
                    Category_Posts=item.Category_Posts.Select(n=>n.Category.CategoryName).ToList()
                };
                test.Add(_dto);
            }
            return test;
        }
        public PostwithCategoryDTO GetPostWithId(int id)
        {
            var temp = _context.Posts.Include(n => n.Category_Posts).ThenInclude(n => n.Category);
            var _response = temp.Where(n => n.Id == id).Select(n => new PostwithCategoryDTO()
            {
                Id=n.Id,
                Title = n.Title,
                Content = n.Content,
                DatePublished = n.DatePublished,
                UserName = n.User.UserName,
                Category_Posts = n.Category_Posts.Select(n => n.Category.CategoryName).ToList()
            }).FirstOrDefault();
            return _response;

        }
    }
}
