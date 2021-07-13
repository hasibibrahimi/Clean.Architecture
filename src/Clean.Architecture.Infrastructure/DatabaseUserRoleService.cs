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
   public class DatabaseUserRoleService:IUserRoleService
    {
        private AppDbContext _context;

        public DatabaseUserRoleService(AppDbContext context)
        {
            _context = context;
        }
        public void AddUserRole(UserRoleDTO userRole)
        {
            var _userRole = new UserRole()
            {
                UserRoleName = userRole.UserRoleName
            };
            _context.UserRoles.Add(_userRole);
            _context.SaveChanges();
        }
        public List<UserRole> GetUserRole()
        {
            return _context.UserRoles.ToList();
        }
    }
}
