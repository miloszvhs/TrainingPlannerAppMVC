using Microsoft.AspNetCore.Mvc;
using TrainingPlannerAppMVC.Application.Interfaces;
using TrainingPlannerAppMVC.Application.ViewModels.UserVm;

namespace TrainingPlannerAppMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var users = _userService.GetAllUsers();
            return View(users);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View(new NewUserVm());
        }

        [HttpPost]
        public IActionResult AddUser(NewUserVm user)
        {
            var id = _userService.AddUser(user);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UserDetails(Guid userId)
        {
            var user = _userService.GetUserById(userId);
            return View(user);
        }
    }
}
