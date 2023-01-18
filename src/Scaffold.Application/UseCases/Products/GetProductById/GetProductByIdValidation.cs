using FluentValidation;

namespace Scaffold.Application.UseCases.Products.GetProductById;

public class GetProductByIdValidation : AbstractValidator<GetProductByIdRequest>
{
    public GetProductByIdValidation()
    {
    }
}