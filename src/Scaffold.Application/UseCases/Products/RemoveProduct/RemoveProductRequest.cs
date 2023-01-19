using MediatR;
using Scaffold.Domain.Seedwork;

namespace Scaffold.Application.UseCases.Products.RemoveProduct;

public class RemoveProductRequest : IRequest<ServiceResult<RemoveProductResponse>>
{
    public Guid Id { get; set; }
}