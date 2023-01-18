using FluentValidation;

namespace Scaffold.Application.UseCases.Products.NewProduct;

public class NewProductValidation: AbstractValidator<NewProductRequest>
{
    public NewProductValidation() 
    {
        RuleFor(a => a.Name)
            .NotEmpty()
            .WithMessage("Field Name is not valid");
    }   
}