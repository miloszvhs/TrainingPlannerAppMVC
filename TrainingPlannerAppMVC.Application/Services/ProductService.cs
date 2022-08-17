using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Application.Interfaces;
using TrainingPlannerAppMVC.Application.ViewModels.ProductVm;
using TrainingPlannerAppMVC.Domain.Interface;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public int AddProduct(NewProductVm product)
        {
            var productModel = _mapper.Map<Product>(product);
            var result = _productRepository.AddProduct(productModel);
            return result;
        }

        public ListProductForListVm GetAllProductsByUserId(Guid userId)
        {
            var products = _productRepository.GetProductsByUserId(userId)
                .ProjectTo<ProductForListVm>(_mapper.ConfigurationProvider).ToList();

            var productList = new ListProductForListVm()
            {
                Products = products,
                Count = products.Count,
                UserId = userId
            };

            return productList;
        }

        public ProductDetailsVm GetProductById(int productId)
        {
            var product = _mapper.Map<ProductDetailsVm>(_productRepository.GetProductById(productId));
            return product;
        }
    }
}
