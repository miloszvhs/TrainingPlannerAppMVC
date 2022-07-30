using Microsoft.AspNetCore.Mvc;

namespace TrainingPlannerAppMVC.Controllers
{
    public class DayController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowAllDaysByUserId(int userId)
        {
            return View();
        }

        public IActionResult ShowDayDetailsByUserId(int userId)
        {
            return View();
        }
    }
}
