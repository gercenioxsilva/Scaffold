namespace Scaffold.Application.UseCases.Products.GetProductById;

public class GetProductByIdResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
}