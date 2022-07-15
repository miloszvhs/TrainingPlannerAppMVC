using Microsoft.AspNetCore.Mvc;
using TrainingPlannerAppMVC.Helpers;

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
    }
}
