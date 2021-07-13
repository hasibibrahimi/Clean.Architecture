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
        public List<User> GetUser()
        {
            return _context.Users.ToList();
        }
    }
}
