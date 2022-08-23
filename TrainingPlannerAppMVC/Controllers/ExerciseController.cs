using Microsoft.AspNetCore.Mvc;
using TrainingPlannerAppMVC.Application.Interfaces;
using TrainingPlannerAppMVC.Application.ViewModels.ExerciseVm;

namespace TrainingPlannerAppMVC.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet]
        public IActionResult Index(Guid userId)
        {
            var exercises = _exerciseService.GetExercisesByUserId(userId, 5, 1, "");
            return View(exercises);
        }
        
        [HttpPost]
        public IActionResult Index(Guid userId, int pageSize, int pageNumber, string searchString)
        {
            if(pageNumber == null)
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
        public IActionResult AddExercise(Guid userId)
        {
            return View(new NewExerciseVm() { UserId = userId });
        }
        
        [HttpPost]
        public IActionResult AddExercise(NewExerciseVm exercise)
        {
            if(ModelState.IsValid)
            {
                _exerciseService.AddExercise(exercise);
                return RedirectToAction("Index", new { userId = exercise.UserId });
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
                _exerciseService.UpdateExercise(exercise);
                return RedirectToAction("Index", new { userId = exercise.UserId });
            }

            return View(exercise);
        }
        
        [HttpGet]
        public IActionResult Delete(Guid userId, int exerciseId)
        {
            _exerciseService.DeleteExercise(exerciseId);
            return RedirectToAction("Index", new { userId = userId });
        }
    }
}
