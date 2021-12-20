using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Architecture.Core.Model
{
    public class UserRole
    {
        public int Id { get; set; }
        public string UserRoleName { get; set; }
        public List<User> Users { get; set; }
    }
}

