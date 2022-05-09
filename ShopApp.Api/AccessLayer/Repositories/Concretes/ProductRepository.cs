using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ShopApp.Api.AccessLayer.Repositories.Abstracts;
using ShopApp.Api.EntityLayer.Models;
using ShopApp.Api.EntityLayer.ProductOperations;

namespace ShopApp.Api.AccessLayer.Repositories.Concretes
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ShopAppDbContext db) : base(db)
        {
        }

        public List<Product> GetProductsWithCategory(int categoryID)
        {
            using var c = new ShopAppDbContext();

            return c.Products.Where(x => x.CategoryId == categoryId).ToList();
        }


    }
}
