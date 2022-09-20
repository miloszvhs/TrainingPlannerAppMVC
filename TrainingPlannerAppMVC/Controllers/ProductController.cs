using FluentValidation;
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
        public IActionResult Index(Guid userId)
        {
            var products = _productService.GetAllProductsByUserId(userId, 5, 1, "");

            ViewBag.Title = "Calories and products";

            return View(products);
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
            
            var products = _productService.GetAllProductsByUserId(userId, pageSize, pageNumber, searchString);

            ViewBag.Title = "Calories and products";
            
            return View(products);
        }

        [HttpGet]
        public ActionResult AddProduct(Guid userId)
        {
            return View(new NewProductVm() { UserId = userId });
        }

        [HttpPost]
        public IActionResult AddProduct(NewProductVm product)
        {
            if (ModelState.IsValid)
            {
                _productService.AddProduct(product);
                return RedirectToAction("Index", new { userId = product.UserId });
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
                _productService.UpdateProduct(product);
                return RedirectToAction("Index", new { userId = product.UserId});    
            }
            return View(product);
        }
        
        [HttpGet]
        public IActionResult Delete(Guid userId, int productId)
        {
            _productService.DeleteProduct(productId);
            return RedirectToAction("Index", new { userId = userId });
        }
    }
}
