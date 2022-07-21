using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Domain.Interface
{
    public interface IProductRepository
    {
        int AddProduct(Product product);
        int DeleteProduct(int productId);
        int UpdateProduct(Product product);
        IQueryable<Product> GetProductsByDayId(int dayId);
        Product GetProductById(int productId);
    }
}
