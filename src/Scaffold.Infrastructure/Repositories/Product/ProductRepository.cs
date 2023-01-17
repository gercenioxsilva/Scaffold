using Scaffold.Domain.Seedwork;

namespace Scaffold.Infrastructure.Repositories.Product;

public class ProductRepository : IProductRepository
{
    private readonly ScaffoldContext _context;

    public IUnitOfWork UnitOfWork => _context;

    public ProductRepository(ScaffoldContext context)
    {
        _context = context;
    }
    
    public void Add(Domain.AggregatesModel.ProductAggregate.Product product)
    {
        _context.Products.Add(product);
    }

    public void Update(Domain.AggregatesModel.ProductAggregate.Product product)
    {
        _context.Products.Update(product);
    }

    public void Remove(Domain.AggregatesModel.ProductAggregate.Product product)
    {
        _context.Products.Remove(product);
    }

    public Task<Domain.AggregatesModel.ProductAggregate.Product?> GetByIdAsync(Guid id,
        CancellationToken cancellationToken)
    {
        return _context.Products
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<PagedModel<Domain.AggregatesModel.ProductAggregate.Product>> GetAsync(
        int page = 0,
        int limit = 50,
        CancellationToken cancellationToken = default(CancellationToken))
    {
        var query = _context.Products;

        var paged = new PagedModel<Domain.AggregatesModel.ProductAggregate.Product>();

        page = (page <= 0) ? 1 : page;

        paged.CurrentPage = page;
        paged.PageSize = limit;

        var totalItemCountTask = await query.CountAsync(cancellationToken);

        var startRow = (page - 1) * limit;

        paged.Items = await query.Skip(startRow).Take(limit).ToListAsync(cancellationToken);
        paged.TotalItems = totalItemCountTask;
        paged.TotalPages = (int)Math.Ceiling(paged.TotalItems / (double)limit);

        return paged;
    }
}