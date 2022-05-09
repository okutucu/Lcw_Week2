using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Api.EntityLayer.Models;

namespace ShopApp.Api.AccessLayer.ShopAppDbContext
{
    public class ProductGenerator : IEntityTypeConfiguration<Product>
    {
      
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasOne(m => m.Category).
               WithMany(c => c.Products).
               HasForeignKey(s => s.CategoryID).
               OnDelete(DeleteBehavior.Restrict);

            entity.HasData(new Product { ID = 1, CategoryID = 1, ProductName = "Hırka", UnitPrice = 17000, UnitsInStock = 150 },
                new Product { ID = 2, CategoryID = 1, ProductName = "Ayakkabı", UnitPrice = 12000, UnitsInStock = 10 },
                new Product { ID = 3, CategoryID = 2, ProductName = "Mont", UnitPrice = 11000, UnitsInStock = 45 },
                new Product { ID = 4, CategoryID = 2, ProductName = "Gömlek", UnitPrice = 13000, UnitsInStock = 80 },
                new Product { ID = 5, CategoryID = 3, ProductName = "Çorap", UnitPrice = 500, UnitsInStock = 25 });
                
        }
    }
}
