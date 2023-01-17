using Scaffold.Domain.AggregatesModel.ProductAggregate;

namespace Scaffold.Application.UseCases.Products.GetAllProducts;

public class GetAllProductsHandler :
    IRequestHandler<GetAllProductsRequest, ServiceResult<PagedModel<GetAllProductsResponse>>>
{
    private readonly IProductRepository _productRepository;

    public GetAllProductsHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }


    public async Task<ServiceResult<PagedModel<GetAllProductsResponse>>> Handle(GetAllProductsRequest request,
        CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAsync(request.Page, request.Limit, cancellationToken);
        if (!products.Items.Any())
        {
            return new ServiceResult<PagedModel<GetAllProductsResponse>>(HttpStatusCode.NotFound, "NotFound",
                $"Products not found.");
        }

        var mapped = products.Items.Select(x => new GetAllProductsResponse()
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Amount = x.Amount.Value
        });

        return new ServiceResult<PagedModel<GetAllProductsResponse>>(HttpStatusCode.OK,
            new PagedModel<GetAllProductsResponse>(products.CurrentPage, products.TotalItems,
                products.TotalPages,
                mapped));
    }
}