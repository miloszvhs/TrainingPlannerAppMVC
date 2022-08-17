using Microsoft.AspNetCore.Mvc;
using TrainingPlannerAppMVC.Application.Interfaces;

namespace TrainingPlannerAppMVC.Controllers
{
    public class DayController : Controller
    {
        private readonly IDayService _dayService;

        public DayController(IDayService dayService)
        {
            _dayService = dayService;
        }

        [HttpGet]
        public IActionResult Index(Guid userId)
        {
            var model = _dayService.GetAllDaysByUserId(userId);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(Guid userId, int pageSize, int pageNumber)
        {
            var model = _dayService.GetAllDaysByUserId(userId);
            return View(model);
        }

        public IActionResult Details(Guid userId)
        {
            var model = _dayService.GetDayDetailsByUserId(userId);
            return View(model);
        }
    }
}
