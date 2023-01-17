namespace Scaffold.Application.UseCases.Products.GetAllProducts;

public class GetAllProductsResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
}