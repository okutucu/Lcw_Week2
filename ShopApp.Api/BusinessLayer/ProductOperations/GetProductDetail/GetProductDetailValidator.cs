using FluentValidation;

namespace ShopApp.Api.BusinessLayer.ProductOperations.GetProductDetail
{
    public class GetProductDetailValidator : AbstractValidator<GetProductDetailQuery>
    {
        public GetProductDetailValidator()
        {
            RuleFor(query => query.ProductId).GreaterThan(0);
        }
    }
}
