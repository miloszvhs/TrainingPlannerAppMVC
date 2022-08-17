using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Application.ViewModels.ProductVm;

namespace TrainingPlannerAppMVC.Application.Interfaces
{
    public interface IProductService
    {
        ListProductForListVm GetAllProductsByUserId(Guid userId);
        int AddProduct(NewProductVm product);
        ProductDetailsVm GetProductById(int productId);

    }
}
