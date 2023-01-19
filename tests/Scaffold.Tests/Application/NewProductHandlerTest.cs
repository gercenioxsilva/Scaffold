using Moq;
using Scaffold.Application.UseCases.Products.NewProduct;
using Scaffold.Domain.AggregatesModel.ProductAggregate;
using Xunit;

namespace Scaffold.Test.Application;

public class NewProductHandlerTest
{
    private readonly Mock<IProductRepository> _productRepositoryMock;

    public NewProductHandlerTest()
    {
        _productRepositoryMock = new Mock<IProductRepository>();
    }

    [Fact]
    public async Task Handler_CreateNewProduct_ShouldReturnSuccess()
    {
        //Arrange
        var newProduct = new NewProductRequest()
        {
            Amount = 100,
            Description = "Description Test",
            Name = "Name Test"
        };

        _productRepositoryMock
            .Setup(s => s.UnitOfWork.SaveChangesAsync(default(CancellationToken)))
            .Returns(Task.FromResult(true));

        //Act
        var handler = new NewProductHandler(_productRepositoryMock.Object);
        var cltToken = new CancellationToken();
        var result = await handler.Handle(newProduct, cltToken);

        //Assert
        Assert.True(result.Success);
    }
}