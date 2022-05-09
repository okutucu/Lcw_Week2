using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ShopApp.Api.EntityLayer.Models;
using ShopApp.Api.EntityLayer.ProductOperations;

namespace ShopApp.Api.AccessLayer.Repositories.Abstracts
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> GetProductsWithCategory(int categoryID);
    }
}
