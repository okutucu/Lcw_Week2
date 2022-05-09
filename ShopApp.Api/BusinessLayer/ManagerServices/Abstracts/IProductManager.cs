using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShopApp.Api.EntityLayer.Models;

namespace ShopApp.Api.BusinessLayer.ManagerServices.Abstracts
{
    public interface IProductManager : IManager<Product>
    {
        Product SingleOrDefault(Func<object, bool> p);

       
    }
}
