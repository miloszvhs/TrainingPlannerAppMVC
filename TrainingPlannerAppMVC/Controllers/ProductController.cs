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

        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.Id = ListOfProducts.list.Last().Id + 1;
                ListOfProducts.list.Add(product);

                return RedirectToAction("Index");
            }

            return View(product);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = ListOfProducts.list.FirstOrDefault(x => x.Id == id);
            
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            var output = ListOfProducts.list.FirstOrDefault(x => x.Id == product.Id);

            ListOfProducts.list.Remove(output);
            ListOfProducts.list.Add(product);

            return RedirectToAction("Index");
        }
    }
}
