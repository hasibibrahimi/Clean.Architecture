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
    public class DatabaseUserService:IUserService
    {
        private AppDbContext _context;

        public DatabaseUserService(AppDbContext context)
        {
            _context = context;
        }
        public void AddUser(UserDTO user)
        {
            var _user = new User()
            {
                UserName = user.UserName,
                UserEmail = user.UserEmail,
                UserPassword = user.UserPassword,
                UserRoleId=user.UserRoleId
            };
            _context.Users.Add(_user);
            _context.SaveChanges();
        }
        public List<UserwithPostDTO> GetUser()
        {
            // return _context.Users.ToList();
            var userPost = _context.Posts.Include(t => t.User).ThenInclude(t=>t.UserRole);
            var r = userPost;
            List<UserwithPostDTO> test = new List<UserwithPostDTO>();
            foreach (var item in r)
            {
                var _response = new UserwithPostDTO()
                {
                    Id=item.User.Id,
                    UserName = item.User.UserName,
                    UserEmail = item.User.UserEmail,
                    UserPassword = item.User.UserPassword,
                    UserRoleName = item.User.UserRole.UserRoleName,
                    PostsTitle=item.User.Posts.Select(n=>n.Title).ToList()
                };
                test.Add(_response);
            }
            return test;
        }
        public UserwithPostDTO GetUserWithId(int id)
        {
            var _response = _context.Users.Where(n => n.Id == id).Select(n => new UserwithPostDTO()
            {
                Id=n.Id,
                UserName = n.UserName,
                UserEmail = n.UserEmail,
                UserPassword = n.UserPassword,
                UserRoleName = n.UserRole.UserRoleName,
                PostsTitle = n.Posts.Select(n => n.Title).ToList()


            }).FirstOrDefault();
            return _response;
        }
    }
}
