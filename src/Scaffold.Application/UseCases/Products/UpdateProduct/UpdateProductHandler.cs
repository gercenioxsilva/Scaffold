using System.Net;
using MediatR;
using Scaffold.Domain.AggregatesModel.ProductAggregate;
using Scaffold.Domain.Seedwork;

namespace Scaffold.Application.UseCases.Products.UpdateProduct;

public class UpdateProductHandler:
    IRequestHandler<UpdateProductRequest, ServiceResult<UpdateProductResponse>>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async Task<ServiceResult<UpdateProductResponse>> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
        if (product == null)
        {
            return new ServiceResult<UpdateProductResponse>(HttpStatusCode.NotFound, "NotFound",
                $"Product {request.Id} not found.");
        }

        product.Update(request.Name);
        
        _productRepository.Update(product);
        
        await _productRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return new ServiceResult<UpdateProductResponse>(HttpStatusCode.NoContent);
    }
}