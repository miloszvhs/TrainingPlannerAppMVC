using TrainingPlannerAppMVC.Application.ViewModels.ProductVm;

namespace TrainingPlannerAppMVC.Application.Interfaces;

public interface IProductService
{
    ListProductForListVm GetAllProductsByUserId(Guid userId, int pageSize, int pageNumber, string searchString);
    int AddProduct(NewProductVm product);
    int DeleteProduct(int productId);
    int UpdateProduct(NewProductVm product);
    NewProductVm GetProductForEdit(int id);
}