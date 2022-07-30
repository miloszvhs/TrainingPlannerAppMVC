using Microsoft.AspNetCore.Mvc;
using TrainingPlannerAppMVC.Helpers;
using TrainingPlannerAppMVC.Models;

namespace TrainingPlannerAppMVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var products = ListOfProducts.list;

            ViewBag.Title = "Calories and products";

            return View(products);
        }

        [HttpGet]
        public ActionResult AddProduct(int id)
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            return RedirectToAction("Index");
        }
    }
}
