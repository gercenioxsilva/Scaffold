namespace Scaffold.Domain.AggregatesModel.ProductAggregate;

public class Product : Entity, IAggregateRoot
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal? Amount { get; private set; }

    public Product()
    {
        
    }

    public Product(string name, string description, decimal? amount)
    {
        Name = name;
        Description = description;
        Amount = amount;
    }

    public void Update(string name)
    {
        Name = name;
    }
}