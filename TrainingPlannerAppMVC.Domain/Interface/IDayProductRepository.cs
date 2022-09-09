using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Domain.Interface
{
    public interface IDayProductRepository
    {
        int AddProduct(DayProduct product);
        int DeleteProduct(int productId);
        void UpdateProduct(DayProduct product);
        IQueryable<DayProduct> GetProductsByDayId(Guid dayId);
        IQueryable<DayProduct> GetAllProducts();
        DayProduct GetProductById(int productId);
    }
}
