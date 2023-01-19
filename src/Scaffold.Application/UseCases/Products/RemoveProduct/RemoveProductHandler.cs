using System.Net;
using MediatR;
using Scaffold.Domain.AggregatesModel.ProductAggregate;
using Scaffold.Domain.Seedwork;

namespace Scaffold.Application.UseCases.Products.RemoveProduct;

public class RemoveProductHandler :
    IRequestHandler<RemoveProductRequest, ServiceResult<RemoveProductResponse>>
{
    private readonly IProductRepository _productRepository;

    public RemoveProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ServiceResult<RemoveProductResponse>> Handle(RemoveProductRequest request,
        CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
        if (product == null)
        {
            return new ServiceResult<RemoveProductResponse>(HttpStatusCode.NotFound, "NotFound",
                $"Product {request.Id} not found.");
        }

        _productRepository.Remove(product);
        await _productRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return new ServiceResult<RemoveProductResponse>(HttpStatusCode.NoContent);
    }
}