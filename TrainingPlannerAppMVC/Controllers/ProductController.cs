using FluentValidation;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingPlannerAppMVC.Application.Interfaces;
using TrainingPlannerAppMVC.Application.ViewModels.ProductVm;
using TrainingPlannerAppMVC.Application.ViewModels.ProductVm.UserProductVm;
using TrainingPlannerAppMVC.Domain.Model;
using TrainingPlannerAppMVC.Models;

namespace TrainingPlannerAppMVC.Controllers
{    
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var userId = Guid.Parse(HttpContext.User.Identity.GetUserId());
            var products = _productService.GetAllProductsByUserId(userId, 5, 1, "");

            ViewBag.Title = "Calories and products";

            return View(products);
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
            
            var products = _productService.GetAllProductsByUserId(userId, pageSize, pageNumber, searchString);

            ViewBag.Title = "Calories and products";
            
            return View(products);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            return View(new NewProductVm());
        }

        [HttpPost]
        public IActionResult AddProduct(NewProductVm product)
        {
            if (ModelState.IsValid)
            {
                var userId = Guid.Parse(HttpContext.User.Identity.GetUserId());
                product.UserId = userId;
                _productService.AddProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _productService.GetProductForEdit(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(NewProductVm product)
        {
            if(ModelState.IsValid)
            {
                var userId = Guid.Parse(HttpContext.User.Identity.GetUserId());
                product.UserId = userId;
                _productService.UpdateProduct(product);
                return RedirectToAction("Index");    
            }
            return View(product);
        }
        
        [HttpGet]
        public IActionResult Delete(int productId)
        {
            _productService.DeleteProduct(productId);
            return RedirectToAction("Index");
        }
    }
}
