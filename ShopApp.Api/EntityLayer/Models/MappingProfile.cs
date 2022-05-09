using AutoMapper;
using ShopApp.Api.BusinessLayer.ProductOperations;
using ShopApp.Api.BusinessLayer.ProductOperations.GetProductDetail;
using static ShopApp.Api.BusinessLayer.ProductOperations.CreateProduct.CreateProductCommand;

namespace ShopApp.Api.EntityLayer.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductModel, Product>();
            CreateMap<Product, ProductDetailViewModel>().ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => (src.CategoryID).ToString()));
            CreateMap<Product, ProductViewModel>().ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => (src.CategoryID).ToString()));
        }
    }
}
