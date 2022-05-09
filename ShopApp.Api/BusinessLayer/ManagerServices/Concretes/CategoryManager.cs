using ShopApp.Api.AccessLayer.Repositories.Abstracts;
using ShopApp.Api.BusinessLayer.ManagerServices.Abstracts;
using ShopApp.Api.EntityLayer.Models;

namespace ShopApp.Api.BusinessLayer.ManagerServices.Concretes
{
    public class CategoryManager : BaseManager<Category>, ICategoryManager
    {
        ICategoryRepository _cRep;
        public CategoryManager(ICategoryRepository cRep) : base(cRep)
        {
            _cRep = cRep;
        }

        public override string Add(Category item)
        {
            if (item.CategoryName != null)
            {
                _cRep.Add(item);
                return "Kategori Eklendi";
            }

            return "Kategori ismi girilmemiş";

        }
    }
}
