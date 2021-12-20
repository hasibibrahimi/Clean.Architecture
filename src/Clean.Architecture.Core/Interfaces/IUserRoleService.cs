using Clean.Architecture.Core.Dto_Classes;
using Clean.Architecture.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Architecture.Core.Interfaces
{
    public interface IUserRoleService
    {
         public void AddUserRole(UserRoleDTO userRole);
        public List<UserRoleWithUserDTO> GetUserRole();

        public void UpdateUserRole(int id, UserRoleDTO userRole);
        public UserRoleWithUserDTO GetUserRoleWithId(int id);
        public void DeleteUserRole(int id);
    }

}
