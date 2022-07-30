using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingPlannerAppMVC.Helpers;
using TrainingPlannerAppMVC.Models;

namespace TrainingPlannerAppMVC.Controllers
{
    public class ExerciseController : Controller
    {

        // GET: ExerciseController
        [Route("exercise/list")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: ExerciseController/Details/5
        public ActionResult Details(int id)
        {
            var exercise = ListOfExercises.list.FirstOrDefault(x => x.Id == id);

            return View(exercise);
        }

        public IActionResult AddExercise(int id)
        {
            return View();
        }

        // GET: ExerciseController/Create
        public ActionResult Create(Exercise exercise)
        {
            return View();
        }

        // GET: ExerciseController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {

            return View();
        }

        [HttpPost]
        public ActionResult Edit(Exercise exer)
        {
            return RedirectToAction("Index");
        }

        // GET: ExerciseController/Delete/5
        public ActionResult Delete(int id)
        {
            return RedirectToAction("Index");
        }
    }
}
