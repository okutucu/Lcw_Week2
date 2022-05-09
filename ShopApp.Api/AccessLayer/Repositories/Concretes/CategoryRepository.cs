using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopApp.Api.AccessLayer.Repositories.Abstracts;
using ShopApp.Api.EntityLayer.Models;

namespace ShopApp.Api.AccessLayer.Repositories.Concretes
{
    public class CategoryRepository : BaseRepository<Category>,ICategoryRepository
    {

       

        public CategoryRepository(ShopAppDbContext db) : base(db)
        {
           
        }

        public Category GetSingleCategoryByProductAsync(int productId)
        {
            using var c = new ShopAppDbContext();
            return c.Categories.Single(c => c.Products.Any(p => p.Id == productId));
        }


        public void SpecialCategoryCreation()
        {
            throw new System.NotImplementedException();
        }
    }
}
