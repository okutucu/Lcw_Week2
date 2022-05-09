using FluentValidation;

namespace ShopApp.Api.BusinessLayer.ProductOperations.UpdateProduct
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(command => command.ProductId).GreaterThan(0);
            RuleFor(command => command.Model.CategoryId).GreaterThan(0);
            RuleFor(command => command.Model.ProductName).NotEmpty().MinimumLength(4);
        }
    }
}
