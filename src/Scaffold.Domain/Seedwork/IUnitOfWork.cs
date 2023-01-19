namespace Scaffold.Domain.Seedwork;

public interface IUnitOfWork : IDisposable
{
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
}