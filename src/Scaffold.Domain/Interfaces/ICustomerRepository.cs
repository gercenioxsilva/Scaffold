
using Scaffold.Domain.Entities;

namespace Scaffold.Domain.Interfaces
{
    public interface ICustomerRepository
    {

        Task<long> AddAsync(Customer entity);
    }

}
