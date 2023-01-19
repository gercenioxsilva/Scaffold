namespace Scaffold.Application.UseCases.Products.NewProduct;

public class NewProductResponse
{
    public Guid Id { get; set; }

    public NewProductResponse(Guid id)
    {
        Id = id;
    }
}