using Microsoft.AspNetCore.Mvc;

namespace TrainingPlannerAppMVC.Controllers
{
    public class CaloriesController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Calories";

            return View();
        }
    }
}
