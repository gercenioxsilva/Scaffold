using MediatR;

namespace Scaffold.Application.Handlers
{
    public class UseCaseRequest : IRequest<UseCaseResponse>
    {
        public string Name { get; private set; }
    }
}
