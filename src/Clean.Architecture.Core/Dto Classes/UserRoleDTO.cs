using Clean.Architecture.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Architecture.Core.Dto_Classes
{
    public class UserRoleDTO
    {
        public string UserRoleName { get; set; }
    }
    public class UserRoleWithUserDTO
    {
        public int Id { get; set; }
        public string UserRoleName { get; set; }
        public List<UserWithRoleDTO> Users { get; set; }
    }
    public class UserWithRoleDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
    }

}
