using System.Linq;
using System.Threading.Tasks;
using Clean.Architecture.Core;
using Clean.Architecture.Core.Dto_Classes;
using Clean.Architecture.Core.Interfaces;
using Clean.Architecture.Core.Model;
using Clean.Architecture.Core.ProjectAggregate;
using Clean.Architecture.Core.ProjectAggregate.Specifications;
using Clean.Architecture.SharedKernel.Interfaces;
using Clean.Architecture.Web.ApiModels;
using Clean.Architecture.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Architecture.Web.Controllers
{
    [Route("[controller]")]
    public class ProjectController : Controller
    {
        private readonly IRepository<Project> _projectRepository;
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;
        private readonly IUserRoleService _userRoleService;

        public ProjectController(IRepository<Project> projectRepository,
            IPostService postService,
            ICategoryService categoryService,
            IUserService userService,
            IUserRoleService userRoleService)
        {
            _projectRepository = projectRepository;
            _postService = postService;
            _categoryService = categoryService;
            _userService = userService;
            _userRoleService = userRoleService;
        }
        [HttpPost("UserRole")]
        public IActionResult AddUserRole(UserRoleDTO userRole)
        {
            _userRoleService.AddUserRole(userRole);
            return Ok();
        }
        [HttpGet("UserRole")]
        public IActionResult GetUserRole()
        {
            var temp = _userRoleService.GetUserRole();
            return Ok(temp);
        }
        [HttpGet("UserRole-with-id/{id}")]
        public IActionResult GetUserRoleWithId(int id)
        {
            var temp = _userRoleService.GetUserRoleWithId(id);
            return Ok(temp);
        }

        [HttpPost("User")]
        public IActionResult AddUser(UserDTO user)
        {
            _userService.AddUser(user);
            return Ok();
        }
        [HttpGet("User")]
        public IActionResult GetUser()
        {
         var temp=_userService.GetUser();
            return Ok(temp);
        }
        [HttpGet("User-with-id/{id}")]
        public IActionResult GetUserWithId(int id)
        {
            var _response = _userService.GetUserWithId(id);
            return Ok(_response);
        }
        [HttpPost("Category")]
        public IActionResult AddCategory(CategoryDTO category)
        {
            _categoryService.AddCategory(category);
            return Ok();
        }
        [HttpGet("Category")]
        public IActionResult GetCategory()
        {
            var temp = _categoryService.GetCategory();
            return Ok(temp);
        }
        [HttpGet("Category-with-id/{id}")]
        public IActionResult GetCategorywithId(int id)
        {
            var response = _categoryService.GetCategoryWithId(id);
            return Ok(response);
        }

        [HttpPost("Post")]
        public IActionResult PostPost(PostDTO post)
        {
            _postService.AddPost(post);
            return Ok();
        }
        [HttpGet("Post")]
        public IActionResult GetPost()
        {
             var temp=_postService.GetPost();
            return Ok(temp);
        }
        [HttpGet("Post-with-id/{id}")]
        public IActionResult GetPostWithId(int id)
        {
            var _response = _postService.GetPostWithId(id);
            return Ok(_response);
        }
        // GET project/{projectId?}
        /*[HttpGet("{projectId:int}")]
        public async Task<IActionResult> Index(int projectId = 1)
        {
            var spec = new ProjectByIdWithItemsSpec(projectId);
            var project = await _projectRepository.GetBySpecAsync(spec);

            var dto = new ProjectViewModel
            {
                Id = project.Id,
                Name = project.Name,
                Items = project.Items
                            .Select(item => ToDoItemViewModel.FromToDoItem(item))
                            .ToList()
            };
            return View(dto);
        }*/
    }
}
