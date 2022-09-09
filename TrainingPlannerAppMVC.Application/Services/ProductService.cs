using AutoMapper;
using AutoMapper.QueryableExtensions;
using TrainingPlannerAppMVC.Application.Interfaces;
using TrainingPlannerAppMVC.Application.ViewModels.ProductVm.UserProductVm;
using TrainingPlannerAppMVC.Domain.Interface;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Application.Services;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

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

    public ListProductForListVm GetAllProductsByUserId(Guid userId, int pageSize, int pageNumber, string searchString)
    {
        var products = _productRepository.GetProductsByUserId(userId)
            .Where(x => x.Details.Name.StartsWith(searchString))
            .ProjectTo<ProductForListVm>(_mapper.ConfigurationProvider).ToList();

        var productsToShow = products.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
        var productList = new ListProductForListVm
        {
            Products = productsToShow,
            Count = products.Count,
            UserId = userId,
            PageSize = pageSize,
            CurrentPage = pageNumber,
            SearchString = searchString
        };

        return productList;
    }

    public NewProductVm GetProductForEdit(int id)
    {
        var product = _productRepository.GetProductById(id);
        var productVm = _mapper.Map<NewProductVm>(product);
        return productVm;
    }

    public int DeleteProduct(int productId)
    {
        var result = _productRepository.DeleteProduct(productId);
        return result;
    }

    public int UpdateProduct(NewProductVm model)
    {
        var product = _mapper.Map<Product>(model);
        _productRepository.UpdateProduct(product);
        return product.Id;
    }
}