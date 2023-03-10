using MediatR;
using Scaffold.Domain.Seedwork;

namespace Scaffold.Application.UseCases.Products.GetProductById;

public class GetProductByIdRequest : IRequest<ServiceResult<GetProductByIdResponse>>
{
    public Guid Id { get; set; }
}