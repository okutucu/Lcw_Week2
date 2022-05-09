using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShopApp.Api.EntityLayer.Models;

namespace ShopApp.Api.AccessLayer
{
    public class ShopAppDbContext : DbContext
    {
        public ShopAppDbContext(DbContextOptions<ShopAppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>()
                 .HasKey(au => au.ID);


        }


        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppUserProfile> AppUserProfiles { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }
    }
}
