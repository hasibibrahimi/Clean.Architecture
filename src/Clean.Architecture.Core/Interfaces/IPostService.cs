using Clean.Architecture.Core.Dto_Classes;
using Clean.Architecture.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Clean.Architecture.Core.Interfaces
{
   public interface IPostService
    {
       public  void AddPost(PostDTO post);
        public List<PostwithCategoryDTO> GetPost();

        public void UpdatePost(int id, PostDTO post);
        public PostwithCategoryDTO GetPostWithId(int id);
        public void DeletePost(int id);

    }
}
