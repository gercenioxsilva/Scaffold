using MediatR;
using Scaffold.Domain.Interfaces;

namespace Scaffold.Application.Handlers
{
    public class UseCaseHandler : IRequestHandler<UseCaseRequest, UseCaseResponse>
    {

        public ICustomerRepository _customerRepository;

        public UseCaseHandler(ICustomerRepository customerRepository) => _customerRepository = customerRepository;

        public Task<UseCaseResponse> Handle(UseCaseRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
