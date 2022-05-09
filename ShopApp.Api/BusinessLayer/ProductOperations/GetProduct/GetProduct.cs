using System.Collections.Generic;
using AutoMapper;
using ShopApp.Api.BusinessLayer.ManagerServices.Abstracts;
using ShopApp.Api.EntityLayer.Models;

namespace ShopApp.Api.BusinessLayer.ProductOperations
{
    public class GetProduct
    {

        IProductManager _pMAN;
        private readonly IMapper _mapper;
        public GetProduct(IProductManager productManager, IMapper mapper)
        {
            _pMAN = productManager;
            _mapper = mapper;
        }

        public List<ProductViewModel> Handle()
        {
           
            var productList = _pMAN.Products.Include(x => x.Genre).OrderBy(x => x.Id).ToList<Product>();
            List<ProductViewModel> vm = _mapper.Map<List<ProductViewModel>>(productList);
          
            return vm;
        }
    }

    public class ProductViewModel
    {
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
  
    }
}
}
