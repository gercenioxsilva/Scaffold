namespace Scaffold.Application.UseCases.Products.UpdateProduct;

public class UpdateProductValidation : AbstractValidator<UpdateProductRequest>
{
    public UpdateProductValidation()
    {
        RuleFor(a => a.Id)
            .NotEmpty()
            .WithMessage("Field Id is not valid");

        RuleFor(a => a.Name)
            .NotEmpty()
            .WithMessage("Field Name is not valid");
    }
}