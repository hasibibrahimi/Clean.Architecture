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
        public List<UserRoleWithUserDTO> GetUserRole()
        {
            var userRoles = _context.UserRoles.Include(t => t.Users);
            var r = userRoles;
            List<UserRoleWithUserDTO> asd = new List<UserRoleWithUserDTO>();
            foreach (var item in r)
            {
                var _dto = new UserRoleWithUserDTO()
                {
                    Id=item.Id,
                    UserRoleName=item.UserRoleName,
                    Users = item.Users.Select(n => new UserWithRoleDTO()
                    {
                        Id=n.Id,
                        UserName = n.UserName,
                        UserEmail = n.UserEmail,
                        UserPassword = n.UserPassword
                    }).ToList()
                };
                asd.Add(_dto);
            }
            return asd;
        }

        public UserRoleWithUserDTO GetUserRoleWithId(int id)
        {
            var _userRole = _context.UserRoles.Where(n => n.Id == id).Select(n => new UserRoleWithUserDTO()
            {
                UserRoleName = n.UserRoleName,
                Users = n.Users.Select(n => new UserWithRoleDTO()
                {
                    Id=n.Id,
                    UserName = n.UserName,
                    UserEmail=n.UserEmail,
                    UserPassword=n.UserPassword          
                }).ToList()
            }).FirstOrDefault();
            return _userRole;
        }
        public void DeleteUserRole(int id)
        {
            var _response = _context.UserRoles.FirstOrDefault(n => n.Id == id);
            if (_response != null)
            {
                _context.UserRoles.Remove(_response);
                _context.SaveChanges();
            }
        }

    }

}
