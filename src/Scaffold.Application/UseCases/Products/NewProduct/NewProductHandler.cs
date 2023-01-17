using Scaffold.Domain.AggregatesModel.ProductAggregate;

namespace Scaffold.Application.UseCases.Products.NewProduct;

public class NewProductHandler
    : IRequestHandler<NewProductRequest, ServiceResult<NewProductResponse>>
{
    private readonly IProductRepository _productRepository;

    public NewProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ServiceResult<NewProductResponse>> Handle(NewProductRequest request,
        CancellationToken cancellationToken)
    {
        var product = new Product(request.Name, request.Description, request.Amount);

        _productRepository.Add(product);

        await _productRepository.UnitOfWork.CommitAsync(cancellationToken);

        return new ServiceResult<NewProductResponse>(HttpStatusCode.Created,
            new NewProductResponse(product.Id));
    }
}