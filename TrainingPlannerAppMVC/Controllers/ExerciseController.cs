using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingPlannerAppMVC.Application.Interfaces;
using TrainingPlannerAppMVC.Application.ViewModels.ExerciseVm;
using TrainingPlannerAppMVC.Application.ViewModels.ExerciseVm.UserExerciseVm;

namespace TrainingPlannerAppMVC.Controllers
{
    [Authorize]
    public class ExerciseController : Controller
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var userId = Guid.Parse(HttpContext.User.Identity.GetUserId());
            var exercises = _exerciseService.GetExercisesByUserId(userId, 5, 1, "");
            return View(exercises);
        }
        
        [HttpPost]
        public IActionResult Index(int pageSize, int pageNumber, string searchString)
        {
            var userId = Guid.Parse(HttpContext.User.Identity.GetUserId());
            if (pageNumber == null)
            {
                pageNumber = 1;
            }
            
            if(searchString == null)
            {
                searchString = string.Empty;
            }
            
            var exercises = _exerciseService.GetExercisesByUserId(userId, pageSize, pageNumber, searchString);
            return View(exercises);
        }

        [HttpGet]
        public IActionResult AddExercise()
        {
            return View(new NewExerciseVm());
        }
        
        [HttpPost]
        public IActionResult AddExercise(NewExerciseVm exercise)
        {
            if(ModelState.IsValid)
            {
                var userId = Guid.Parse(HttpContext.User.Identity.GetUserId());
                exercise.UserId = userId;
                _exerciseService.AddExercise(exercise);
                return RedirectToAction("Index");
            }

            return View(exercise);
        }
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var exercise = _exerciseService.GetExerciseForEdit(id);
            return View(exercise);
        }
        
        [HttpPost]
        public IActionResult Edit(NewExerciseVm exercise)
        {
            if(ModelState.IsValid)
            {
                var userId = Guid.Parse(HttpContext.User.Identity.GetUserId());
                exercise.UserId = userId;
                _exerciseService.UpdateExercise(exercise);
                return RedirectToAction("Index");
            }

            return View(exercise);
        }
        
        [HttpGet]
        public IActionResult Delete(int exerciseId)
        {
            _exerciseService.DeleteExercise(exerciseId);
            return RedirectToAction("Index");
        }
    }
}
