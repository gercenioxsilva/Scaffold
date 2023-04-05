using AutoMapper;
using Scaffold.Domain.Entities;
using Scaffold.Domain.Interfaces;

namespace Scaffold.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private IMapper _mapper;

        public CustomerRepository(IMapper mapper) => _mapper = mapper;

        public Task<long> AddAsync(Customer entity)
        {

            var entityModel = _mapper.Map<Customer>(entity);

            // TODO Save data 

            throw new NotImplementedException();
        }
    }
}
