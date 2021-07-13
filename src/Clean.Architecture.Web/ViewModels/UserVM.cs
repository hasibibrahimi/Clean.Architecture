using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean.Architecture.Web.ViewModels
{
    public class UserVM
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public int UserRoleId { get; set; }
        public List<int> PostsId { get; set; }
    }
    public class UserwithPostVM
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserRoleName { get; set; }
        public List<string> PostsTitle { get; set; }
    }
}
