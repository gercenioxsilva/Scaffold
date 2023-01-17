namespace Scaffold.Application.UseCases.Products.GetAllProducts;

public class GetAllProductsRequest :
    BaseQueryParameters, IRequest<ServiceResult<PagedModel<GetAllProductsResponse>>>
{
}