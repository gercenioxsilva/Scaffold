using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Scaffold.Api.Controllers.V1;
using Scaffold.Application.Handlers;
using Xunit;

namespace Scaffold.Test.Api
{
    public class UseCaseControllerTest
    {

        private readonly Mock<IMediator> _meditorMock;

        public UseCaseControllerTest() => _meditorMock = new Mock<IMediator>();


        [Fact]
        public async Task UseCaseController_CreatedAsync_Should_Return_201Ok() 
        {
            // arrange

            var request = new UseCaseRequest 
            {
                Name = "Test",
            };

            _meditorMock.Setup(x => x.Send(request, default(CancellationToken)))
                .ReturnsAsync(It.IsAny<UseCaseResponse>())
                .Verifiable();

            var _sut = new UseCaseController(_meditorMock.Object);

            // act

            var result = await _sut.CreateAsync(request);

            // assert
            Assert.IsType<OkObjectResult>(result);
            _meditorMock.VerifyAll();
        }
    }
}
