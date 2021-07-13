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
       public string UserRoleName { get; set; }
        public List<User> Users { get; set; }
    }
}
