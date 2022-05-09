using System;
using AutoMapper;
using ShopApp.Api.BusinessLayer.ManagerServices.Abstracts;

namespace ShopApp.Api.BusinessLayer.ProductOperations.DeleteProduct
{
    public class DeleteProductCommand
    {
        public int Id { get; set; }

        IProductManager _pMAN;

        private readonly IMapper _mapper;
        public DeleteProductCommand(IProductManager productManager, IMapper mapper)
        {
            _pMAN = productManager;
            _mapper = mapper;
        }

        public void Handle()
        {
            
            var product = _pMAN.SingleOrDefault(x => x.Id == Id);

            if (product is null)
            {
                throw new InvalidOperationException("Id bulunamadı!");
            }
            else
            {
                _pMAN.Delete(product);
               
            }
        }
    }
}
