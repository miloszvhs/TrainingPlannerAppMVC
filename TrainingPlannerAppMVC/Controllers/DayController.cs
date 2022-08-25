using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic;
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
        
        [HttpGet]
        public IActionResult AddDay(Guid userId)
        {
            _dayService.AddDay(userId);
            return RedirectToAction("Index", new { userId = userId});
        }
        
        public IActionResult Details(Guid dayId)
        {
            var model = _dayService.GetDayById(dayId);
            return View(model);
        }
    }
}
