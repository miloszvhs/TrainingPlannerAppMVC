using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic;
using TrainingPlannerAppMVC.Application.Interfaces;
using TrainingPlannerAppMVC.Application.ViewModels.ExerciseVm;
using TrainingPlannerAppMVC.Application.ViewModels.ExerciseVm.DayExerciseVm;
using TrainingPlannerAppMVC.Application.ViewModels.ProductVm.DayProductVm;

namespace TrainingPlannerAppMVC.Controllers
{
    [Authorize]
    public class DayController : Controller
    {
        private readonly IDayService _dayService;

        public DayController(IDayService dayService)
        {
            _dayService = dayService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var userId = Guid.Parse(HttpContext.User.Identity.GetUserId());
            var model = _dayService.GetAllDaysByUserId(userId);
            
            return View(model);
        }
        
        [HttpGet]
        public IActionResult AddDay()
        {
            var userId = Guid.Parse(HttpContext.User.Identity.GetUserId());
            _dayService.AddDay(userId);
            return RedirectToAction("Index");
        }
        
        public IActionResult Details(Guid dayId)
        {
            var model = _dayService.GetDayById(dayId);
            return View(model);
        }
        
        [HttpGet]
        public IActionResult AddProduct(Guid dayId)
        {
            return View(new NewDayProductVm() { DayId = dayId });
        }
        
        [HttpPost]
        public IActionResult AddProduct(NewDayProductVm product)
        {
            if(ModelState.IsValid)
            {
                _dayService.AddProductToDay(product);
                return RedirectToAction("Details", new { dayId = product.DayId });
            }

            return View(product);
        }
        
        [HttpGet]
        public IActionResult AddExercise(Guid dayId)
        {
            var model = new NewDayExerciseVm()
            {
                DayId = dayId,
                ExerciseDetails = new()
                {
                    Sets = new()
                    {
                        new DayExerciseSetVm()
                    }
                },
            };
            return View(model);
        }
        
        [HttpPost]
        public IActionResult AddExercise(NewDayExerciseVm exercise)
        {
            if(ModelState.IsValid)
            {
                _dayService.AddExerciseToDay(exercise);
                return RedirectToAction("Details", new { dayId = exercise.DayId });
            }
            
            return View(exercise);
        }
        
        [HttpPost]
        public IActionResult BlankSet()
        {
            return PartialView("_DayExerciseSetEditor", new DayExerciseSetVm());
        }
        
        [HttpGet]
        public IActionResult EditExercise(int id)
        {
            var exercise = _dayService.GetExerciseById(id);
            return View(exercise);
        }
        
        [HttpPost]
        public IActionResult EditExercise(NewDayExerciseVm exercise)
        {
            if(ModelState.IsValid)
            {
                _dayService.UpdateExercise(exercise);
                return RedirectToAction("Details", new { dayId = exercise.DayId });
            }

            return View(exercise);
        }

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var product = _dayService.GetProductById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(NewDayProductVm product)
        {
            if (ModelState.IsValid)
            {
                _dayService.UpdateProduct(product);
                return RedirectToAction("Details", new { dayId = product.DayId });
            }

            return View(product);
        }
    }
}
