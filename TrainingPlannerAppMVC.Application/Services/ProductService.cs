using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Application.DTO.ViewModels.Product;
using TrainingPlannerAppMVC.Application.Interfaces;
using TrainingPlannerAppMVC.Domain.Interface;

namespace TrainingPlannerAppMVC.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public ProductEditDTO EditProductById(int id)
        {
            throw new NotImplementedException();
        }

        public ProductDetailsDTO GetProductDetailsById(int id)
        {
            throw new NotImplementedException();
        }

        public ProductForListDTO GetProductsByDayId(int dayId)
        {
            throw new NotImplementedException();
        }
    }
}
