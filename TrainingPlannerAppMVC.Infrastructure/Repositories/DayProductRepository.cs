﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrainingPlannerAppMVC.Domain.Interface;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Infrastructure.Repositories
{
    internal class DayProductRepository : IDayProductRepository
    {
        private readonly Context _context;

        public DayProductRepository(Context context)
        {
            _context = context;
        }

        public int AddProduct(DayProduct product)
        {
            _context.Add(product);
            _context.SaveChanges();
            return product.Id;
        }

        public int DeleteProduct(int productId)
        {
            var product = _context.DayProducts.FirstOrDefault(x => x.Id == productId);
            if (product != null)
            {
                _context.DayProducts.Remove(product);
                _context.SaveChanges();
                return productId;
            }
            return -1;
        }

        public int UpdateProduct(DayProduct product)
        {
            var entity = _context.DayProducts.FirstOrDefault(x => x.Id == product.Id);
            if (entity != null)
            {
                entity = product;
                _context.SaveChanges();
                return product.Id;
            }
            return -1;
        }

        public IQueryable<DayProduct> GetAllProducts()
        {
            var products = _context.DayProducts;
            return products;
        }

        public DayProduct GetProductById(int productId)
        {
            var product = _context.DayProducts.FirstOrDefault(x => x.Id == productId);
            return product;
        }

        public IQueryable<DayProduct> GetProductsByDayId(Guid dayId)
        {
            var products = _context.DayProducts.Include(x => x.ProductDetails).Where(x => x.DayId == dayId);
            return products;
        }
    }
}
