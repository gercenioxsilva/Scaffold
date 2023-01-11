using MediatR;

namespace Scaffold.Application.Handlers
{
    public class UseCaseHandler : IRequestHandler<UseCaseRequest, UseCaseResponse>
    {
        public Task<UseCaseResponse> Handle(UseCaseRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
