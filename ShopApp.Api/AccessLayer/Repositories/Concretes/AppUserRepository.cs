using System.Threading.Tasks;
using ShopApp.Api.AccessLayer.Repositories.Abstracts;
using ShopApp.Api.EntityLayer.Models;

namespace ShopApp.Api.AccessLayer.Repositories.Concretes
{
    public class AppUserRepository : BaseRepository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(ShopAppDbContext db) : base(db)
        {
        }

      
    }
}
