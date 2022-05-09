using System;
using ShopApp.Api.AccessLayer.Repositories.Abstracts;
using ShopApp.Api.BusinessLayer.ManagerServices.Abstracts;
using ShopApp.Api.EntityLayer.Models;

namespace ShopApp.Api.BusinessLayer.ManagerServices.Concretes
{
    public class ProductManager : BaseManager<Product>, IProductManager
    {
        IProductRepository _proRep;
        public ProductManager(IProductRepository proRep) : base(proRep)
        {
            _proRep = proRep;
        }
        public Product SingleOrDefault(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
