using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingPlannerAppMVC.Application.Interfaces;
using TrainingPlannerAppMVC.Application.ViewModels.UserVm;
using TrainingPlannerAppMVC.Filters;

namespace TrainingPlannerAppMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var users = _userService.GetAllUsers();
            return View(users);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddUser()
        {
            return View(new NewUserVm());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddUser(NewUserVm user)
        {
            var id = _userService.AddUser(user);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult UserDetails(Guid userId)
        {
            var user = _userService.GetUserById(userId);
            return View(user);
        }
    }
}
