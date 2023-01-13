namespace Scaffold.Infrastructure.Repositories.Product;

public class ProductConfiguration : IEntityTypeConfiguration<Domain.AggregatesModel.ProductAggregate.Product>
{
    public void Configure(EntityTypeBuilder<Domain.AggregatesModel.ProductAggregate.Product> builder)
    {
        builder.ToTable("Products", ScaffoldContext.DEFAULT_SCHEMA);

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired(true);

        builder.Property(x => x.Description)
            .HasMaxLength(5000)
            .IsRequired(false);

        builder.Property(x => x.Amount)
            .HasMaxLength(5000)
            .IsRequired(false);
    }
}