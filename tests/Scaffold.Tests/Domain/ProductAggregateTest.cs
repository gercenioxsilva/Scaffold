using Scaffold.Domain.AggregatesModel.ProductAggregate;
using Xunit;

namespace Scaffold.Test.Domain;

public class ProductAggregateTest
{
    [Fact]
    public void Product_CreateNewProduct_ShouldReturnSuccess()
    {
        //Arrange && Act
        var product = new Product("Name", "Description", 100);

        //Assert
        Assert.NotNull(product);
    }
}