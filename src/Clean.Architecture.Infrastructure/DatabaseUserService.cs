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
            var userPost = _context.Users.Include(t => t.UserRole);
            var r = userPost;
            List<UserwithPostDTO> test = new List<UserwithPostDTO>();
            foreach (var item in r.Include(n=>n.Posts))
            {
                var _response = new UserwithPostDTO()
                {
                    Id=item.Id,
                    UserName = item.UserName,
                    UserEmail = item.UserEmail,
                    UserPassword = item.UserPassword,
                    UserRoleName = item.UserRole.UserRoleName,
                    PostsTitle=item.Posts.Select(n=>n.Title).ToList()
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
        public void DeleteUser(int id)
        {
            var _response = _context.Users.FirstOrDefault(n => n.Id == id);
            if (_response != null)
            {
                _context.Users.Remove(_response);
                _context.SaveChanges();
            }

        }
    }
}
