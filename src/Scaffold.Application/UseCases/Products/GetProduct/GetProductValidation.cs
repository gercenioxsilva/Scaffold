using FluentValidation;

namespace Scaffold.Application.UseCases.Products.GetProduct;

public class GetProductValidation : AbstractValidator<GetProductRequest>
{
    public GetProductValidation()
    {
    }
}