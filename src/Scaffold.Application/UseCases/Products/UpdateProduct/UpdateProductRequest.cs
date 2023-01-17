namespace Scaffold.Application.UseCases.Products.UpdateProduct;

public class UpdateProductRequest: IRequest<ServiceResult<UpdateProductResponse>>
{
    public Guid Id { get; private set; }
    public string Name { get; set; }

    public void SetId(Guid id) =>
        Id = id;
}