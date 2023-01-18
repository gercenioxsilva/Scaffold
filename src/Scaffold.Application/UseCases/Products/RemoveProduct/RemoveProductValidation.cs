using FluentValidation;

namespace Scaffold.Application.UseCases.Products.RemoveProduct;

public class RemoveProductValidation : AbstractValidator<RemoveProductRequest>
{
    public RemoveProductValidation()
    {
        RuleFor(a => a.Id)
            .NotEmpty()
            .WithMessage("Field Id is not valid");
    }
}