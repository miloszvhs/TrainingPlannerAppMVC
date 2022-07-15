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
            ViewData["Title"] = "Exercise list";

            return View(ListOfExercises.list);
        }

        // GET: ExerciseController/Details/5
        public ActionResult Details(int id)
        {
            var exercise = ListOfExercises.list.FirstOrDefault(x => x.Id == id);

            return View(exercise);
        }

        // GET: ExerciseController/Create
        public ActionResult Create(Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                exercise.Id = ListOfExercises.list.Last().Id + 1;
                ListOfExercises.list.Add(exercise);

                return RedirectToAction("Index");
            }
            else
            {
                return View(exercise);

            }
        }

        // GET: ExerciseController/Edit/5
        public ActionResult Edit(int id)
        {
            var exercise = ListOfExercises.list.FirstOrDefault(x => x.Id == id);

            return View(exercise);
        }

        [HttpPost]
        public ActionResult Edit(Exercise exer)
        {
            //update student in DB using EntityFramework in real-life application

            //update list by removing old student and adding updated student for demo purpose
            var exercise = ListOfExercises.list.FirstOrDefault(x => x.Id == exer.Id);
            ListOfExercises.list.Remove(exercise);
            ListOfExercises.list.Add(exer);

            return RedirectToAction("Index");
        }

        // GET: ExerciseController/Delete/5
        public ActionResult Delete(int id)
        {
            var exercise = ListOfExercises.list.FirstOrDefault(x => x.Id == id);
            
            if (exercise != null)
            {
                ListOfExercises.list.Remove(exercise);
            }

            return RedirectToAction("Index");
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
