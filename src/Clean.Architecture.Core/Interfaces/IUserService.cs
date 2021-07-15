using Clean.Architecture.Core.Dto_Classes;
using Clean.Architecture.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Architecture.Core.Interfaces
{
    public interface IUserService
    {
        public void AddUser(UserDTO user);
        public List<UserwithPostDTO> GetUser();
        public UserwithPostDTO GetUserWithId(int id);
        public void DeleteUser(int id);

    }
}
