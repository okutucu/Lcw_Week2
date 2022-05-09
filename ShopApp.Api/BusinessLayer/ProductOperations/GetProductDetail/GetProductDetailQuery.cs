using System;
using AutoMapper;
using ShopApp.Api.BusinessLayer.ManagerServices.Abstracts;

namespace ShopApp.Api.BusinessLayer.ProductOperations.GetProductDetail
{
    public class GetProductDetailQuery
    {
        private readonly IMapper _mapper;
        public int ProductId { get; set; }

        IProductManager _pMAN;

        public GetProductDetailQuery(IProductManager productManager, IMapper mapper)
        {
            _pMAN = productManager;
            _mapper = mapper;
        }

        public ProductDetailViewModel Handle()
        {
            var product = _pMAN.Products.Include(x => x.Genre).Where(x => x.Id == ProductId).SingleOrDefault();

            if (product is null)
            {
                throw new InvalidOperationException("Ürün bulunamadı");
            }
            ProductDetailViewModel vm = _mapper.Map<ProductDetailViewModel>(product);

        

            return vm;
        }
    }

    public class ProductDetailViewModel
    {
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
    }

}
}
