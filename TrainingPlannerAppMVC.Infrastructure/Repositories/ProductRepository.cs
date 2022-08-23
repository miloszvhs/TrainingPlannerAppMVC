using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Interface;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public int AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product.Id;
        }

        public int DeleteProduct(int productId)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == productId);

            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return product.Id;
            }
            return -1;
        }

        public void UpdateProduct(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();
        }

        public IQueryable<Product> GetAllProducts()
        {
            var products = _context.Products.Include(x => x.Details);
            return products;
        }

        public IQueryable<Product> GetProductsByUserId(Guid userId)
        {
            var products = _context.Products.Where(x => x.UserId == userId);
            return products;
        }

        public Product GetProductById(int id)
        {
            var product = GetAllProducts().FirstOrDefault(x => x.Id == id);
            return product;
        }
    }
}
