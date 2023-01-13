namespace Scaffold.Domain.Seedwork;

public interface IUnitOfWork : IDisposable
{
    Task<bool> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
}