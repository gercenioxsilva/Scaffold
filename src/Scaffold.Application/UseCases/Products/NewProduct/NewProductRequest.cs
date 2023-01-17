namespace Scaffold.Application.UseCases.Products.NewProduct;

public class NewProductRequest : IRequest<ServiceResult<NewProductResponse>>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
}