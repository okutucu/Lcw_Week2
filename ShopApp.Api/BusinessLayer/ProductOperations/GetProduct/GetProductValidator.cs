using FluentValidation;

namespace ShopApp.Api.BusinessLayer.ProductOperations.GetProduct
{
    public class GetProductValidator : AbstractValidator<GetProductValidator>
    {
        public GetProductValidator()
        {
            RuleFor(query => query.ProductId).GreaterThan(0);
        }
        

    }
       
    
}
