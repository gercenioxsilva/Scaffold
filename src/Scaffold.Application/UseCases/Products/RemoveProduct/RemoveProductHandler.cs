using Scaffold.Domain.AggregatesModel.ProductAggregate;

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
        await _productRepository.UnitOfWork.CommitAsync(cancellationToken);

        return new ServiceResult<RemoveProductResponse>(HttpStatusCode.NoContent);
    }
}