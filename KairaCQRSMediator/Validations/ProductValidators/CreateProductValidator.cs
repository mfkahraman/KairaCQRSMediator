using FluentValidation;
using KairaCQRSMediator.Features.Mediator.Commands.ProductCommands;

namespace KairaCQRSMediator.Validations.ProductValidators
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ürün adı boş bırakılamaz")
                .MinimumLength(3).WithMessage("Ürün adı en az 3 karakter olmalıdır")
                .MaximumLength(100).WithMessage("Ürün adı en fazla 100 karakter olmalıdır");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Ürün fiyatı boş bırakılamaz")
                .InclusiveBetween(10, 10000).WithMessage("Ürün fiyatı 10 ile 10000 arasında olmalıdır");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Ürün görseli boş bırakılamaz");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Ürün kategorisi boş bırakılamaz");
        }
    }
}
