using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Application.DTO.ViewModels.Product;

namespace TrainingPlannerAppMVC.Application.Interfaces
{
    public interface IProductService
    {
        ProductForListDTO GetProductsByDayId(int dayId);
        ProductDetailsDTO GetProductDetailsById(int id);
        ProductEditDTO EditProductById(int id);
    }
}
