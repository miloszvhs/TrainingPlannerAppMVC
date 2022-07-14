using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingPlannerAppMVC.Helpers;
using TrainingPlannerAppMVC.Models;

namespace TrainingPlannerAppMVC.Controllers
{
    public class ExerciseController : Controller
    {
        // GET: ExerciseController
        [Route("exercises")]
        public ActionResult Index()
        {
            List<Exercise> exerciseList = new List<Exercise>()
            {
                new Exercise() { Id = 1, Title = "Przysiady", Description = "Przysiady ze sztangą na plecach", Category = MuscleCategory.Legs},
                new Exercise() { Id = 2, Title = "Podciąganie", Description = "Podciąganie podchwytem", Category = MuscleCategory.Chest},
                new Exercise() { Id = 3, Title = "Uginanie gryfa prostego stojąc", Description = "Stojąc uginasz gryfa do maksymalnego spięcią", Category = MuscleCategory.Arms}
            };

            return View(exerciseList);
        }

        // GET: ExerciseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExerciseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExerciseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExerciseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExerciseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExerciseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExerciseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
