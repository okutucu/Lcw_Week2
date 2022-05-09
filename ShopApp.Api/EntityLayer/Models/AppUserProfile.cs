namespace ShopApp.Api.EntityLayer.Models
{
    public class AppUserProfile : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AppUserID { get; set; }

        //Relational Properties
        public virtual AppUser AppUser { get; set; }
    }
}
