using Microsoft.AspNetCore.Mvc;

namespace TrainingPlannerAppMVC.Controllers
{
    public class CaloriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowCaloriesByDayId(int id)
        {
            return View();
        }
    }
}
