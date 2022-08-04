/*using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Interface;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Infrastructure.Repositories
{
    public class UserProductRepository : IUserProductRepository
    {
        private readonly Context _context;

        public UserProductRepository(Context context)
        {
            _context = context;
        }

        public int AddProduct(UserProduct product)
        {
            _context.UserProducts.Add(product);
            _context.SaveChanges();
            return product.UserProductId;
        }

        public int DeleteProduct(int productId)
        {
            var product = _context.Products.FirstOrDefault(x => x.ProductId == productId);

            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return product.ProductId;
            }

            return -1;
        }

        public IQueryable<Product> GetAllProducts()
        {
            var products = _context.Products;
            return products;
        }

        public Product GetProductById(int productId)
        {
            var product = _context.Products.FirstOrDefault(x => x.ProductId == productId);
            return product;
        }

        public IQueryable<Product> GetProductsByDayId(Guid dayId)
        {
            var products = _context.Days.FirstOrDefault(x => x.DayId == dayId).Products.AsQueryable();
            return products;
        }

        public IQueryable<UserProduct> GetProductsByUserId(Guid userId)
        {
            var products = _context.Users.FirstOrDefault(x => x.Id == userId).UserProducts.AsQueryable();
            return products;
        }

        public int UpdateProduct(Product product)
        {
            var entity = _context.Products.FirstOrDefault(x => x.ProductId == product.ProductId);

            if (entity != null)
            {
                entity = product;
                _context.SaveChangesAsync();
                return entity.ProductId;
            }
            return -1;
        }
    }
}
*/