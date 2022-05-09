using System;
using AutoMapper;
using ShopApp.Api.AccessLayer;
using ShopApp.Api.BusinessLayer.ManagerServices.Abstracts;
using ShopApp.Api.EntityLayer.Models;

namespace ShopApp.Api.BusinessLayer.ProductOperations.CreateProduct
{
    public class CreateProductCommand
    {
        public CreateProductModel Model { get; set; }

       

        IProductManager _pMAN;
        private readonly IMapper _mapper;
        public CreateProductCommand(IProductManager productManager, IMapper mapper)
        {
            _pMAN = productManager;
            _mapper = mapper;
        }

        public void Handle()
        {

            var product = _pMAN.SingleOrDefault(x => x.product == Model.ProductName);

            if (product is not null)
            {
                
                throw new InvalidOperationException("Ürün Mevcut!");
            }
            product = _mapper.Map<Product>(Model);


            _pMAN.Add(product);
           
        }

        public class CreateProductModel
        {
            public string ProductName { get; set; }
            public int GenreId { get; set; }
            public double Price { get; set; }
        }
    }
}
