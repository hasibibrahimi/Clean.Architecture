using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Architecture.Core.Dto_Classes
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public int UserRoleId { get; set; }
        public List<int> PostsId { get; set; }
    }
   
    public class UserwithPostDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserRoleName { get; set; }
        public List<string> PostsTitle { get; set; }
    }
}
