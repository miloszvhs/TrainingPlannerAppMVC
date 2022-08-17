using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TrainingPlannerAppMVC.Application.Interfaces;
using TrainingPlannerAppMVC.Application.ViewModels.ProductVm;
using TrainingPlannerAppMVC.Domain.Model;
using TrainingPlannerAppMVC.Models;

namespace TrainingPlannerAppMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IValidator<NewProductVm> _validator;
        public ProductController(IProductService productService, IValidator<NewProductVm> validator)
        {
            _productService = productService;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult Index(Guid userId)
        {
            var products = _productService.GetAllProductsByUserId(userId);

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
            var result = _validator.Validate(product);
            if (result.IsValid)
            {
                _productService.AddProduct(product);
                return RedirectToAction("Index", new { userId = product.UserId });
            }
            return View(product);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _productService.GetProductById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(ProductDetailsVm product)
        {
            return RedirectToAction("Index");
        }
    }
}
