using MediatR;

namespace Scaffold.Application.UseCases.Products.GetProduct;

public class GetProductHandler : IRequestHandler<GetProductRequest, GetProductResponse>
{
    public async Task<GetProductResponse> Handle(GetProductRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}