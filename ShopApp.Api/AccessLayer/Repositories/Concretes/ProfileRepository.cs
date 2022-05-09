using ShopApp.Api.AccessLayer.Repositories.Abstracts;
using ShopApp.Api.EntityLayer.Models;

namespace ShopApp.Api.AccessLayer.Repositories.Concretes
{
    public class ProfileRepository : BaseRepository<AppUserProfile>, IProfileRepository
    {
        public ProfileRepository(ShopAppDbContext db) : base(db)
        {

        }
    }
}
