using System.Collections.Generic;
using System.Threading.Tasks;
using ShopApp.Api.EntityLayer.Models;

namespace ShopApp.Api.AccessLayer.Repositories.Abstracts
{
    public interface ICategoryRepository : IRepository<Category>
    {
        public Category GetSingleCategoryByProductAsync(int productId);
        public void SpecialCategoryCreation();

    }
}
