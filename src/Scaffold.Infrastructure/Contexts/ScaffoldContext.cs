using Scaffold.Domain.Seedwork;

namespace Scaffold.Infrastructure.Contexts;

public class ScaffoldContext : DbContext, IUnitOfWork
{
    public const string DEFAULT_SCHEMA = "dbo";

    public DbSet<Product> Products { get; set; }


    public ScaffoldContext(DbContextOptions options) : base(options)
    {
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "SQL_ACHE");

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                     .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ScaffoldContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public async Task<bool> CommitAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is Entity && (
                e.State == EntityState.Added
                || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            ((Entity)entityEntry.Entity).UpdatedAt = DateTime.Now;

            if (entityEntry.State == EntityState.Added)
            {
                ((Entity)entityEntry.Entity).CreatedAt = DateTime.Now;
            }
        }

        return await base.SaveChangesAsync(cancellationToken) > 0;
    }
}