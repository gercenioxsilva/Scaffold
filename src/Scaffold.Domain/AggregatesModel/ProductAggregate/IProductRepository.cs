using System.Linq.Expressions;
using Scaffold.Domain.Seedwork;

namespace Scaffold.Domain.AggregatesModel.ProductAggregate;

public interface IProductRepository : IRepository<Product>
{
    void Add(Product product);
    void Update(Product product);
    void Remove(Product product);
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<PagedModel<Product>> GetAsync(
        int page = 0,
        int limit = 50,
        CancellationToken cancellationToken = default(CancellationToken));
}