using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Domain.Interface
{
    public interface IUserProductRepository
    {
        int AddProduct(UserProduct product);
        int DeleteProduct(int productId);
        int UpdateProduct(UserProduct product);
        IQueryable<UserProduct> GetProductsByUserId(Guid userId);
        UserProduct GetProductById(int productId);
        IQueryable<UserProduct> GetAllProducts();
    }
}
