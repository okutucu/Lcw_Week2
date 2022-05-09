using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Api.EntityLayer.Models;

namespace ShopApp.Api.AccessLayer.ShopAppDbContext
{
    public class CategoryGenerator : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasData(
                new Category { ID = 1, CategoryName = "Erkek" },
                new Category { ID = 2, CategoryName = "Kadın" },
                new Category { ID = 3, CategoryName = "UniSex" }
                );
              
        }
    }
}
