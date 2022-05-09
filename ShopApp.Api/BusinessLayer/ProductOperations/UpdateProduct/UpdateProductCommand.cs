using System;
using AutoMapper;
using ShopApp.Api.BusinessLayer.ManagerServices.Abstracts;

namespace ShopApp.Api.BusinessLayer.ProductOperations.UpdateProduct
{
    public class UpdateProductCommand
    {
        public int ProductId { get; set; }
        public UpdateProductModel Model { get; set; }

        IProductManager _pMAN;
        private readonly IMapper _mapper;
        public UpdateProductCommand(IProductManager productManager, IMapper mapper)
        {
            _pMAN = productManager;
            _mapper = mapper;
        }

        public void Handle()
        {
            var product = _pMAN.SingleOrDefault(x => x.Id == ProductId);
          
            var checkIfTitleExist = _pMAN.SingleOrDefault(x => x.ProductName == Model.ProductName);

            
            if (product is null)
            {
                throw new InvalidOperationException("Ürün bulunamadı!");
            }


            if (checkIfTitleExist is null)
            
                product.ProductName = Model.ProductName != default ? Model.ProductName : product.ProductName;
                product.UnitPrice = Model.Price != default ? Model.Price : product.UnitPrice;
                _context.SaveChanges();
                // return Ok("Ürün başarıyla güncellendi!");
                System.Console.WriteLine("Ürün başarıyla güncellendi!");
            }
            else
            {
                throw private new InvalidOperationException("Ürün stokta mevcut!");
            }


        }

        public class UpdateProductModel
        {
            public string ProductName { get; set; }
            public double Price { get; set; }
        }
    }
