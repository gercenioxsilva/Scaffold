using System.Net;
using MediatR;
using Scaffold.Domain.AggregatesModel.ProductAggregate;
using Scaffold.Domain.Seedwork;

namespace Scaffold.Application.UseCases.Products.GetProductById;

public class GetProductByIdHandler : BaseQueryParameters,
    IRequestHandler<GetProductByIdRequest, ServiceResult<GetProductByIdResponse>>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ServiceResult<GetProductByIdResponse>> Handle(GetProductByIdRequest request,
        CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
        if (product == null)
        {
            return new ServiceResult<GetProductByIdResponse>(HttpStatusCode.NotFound, "NotFound",
                $"Product {request.Id} not found.");
        }

        var mapped = new GetProductByIdResponse()
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Amount = product.Amount.Value
        };

        return new ServiceResult<GetProductByIdResponse>(HttpStatusCode.OK, mapped);
    }
}