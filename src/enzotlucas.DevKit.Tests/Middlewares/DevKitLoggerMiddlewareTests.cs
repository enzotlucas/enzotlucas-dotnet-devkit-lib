using enzotlucas.DevKit.Logger.LoggerManagers;
using enzotlucas.DevKit.Middlewares;
using Microsoft.AspNetCore.Http;
using NSubstitute;

namespace enzotlucas.DevKit.Tests.Middlewares
{
    public class DevKitLoggerMiddlewareTests
    {
        [Fact]
        public void InvokeAsync_ValidRequest_ShouldNotThrow()
        {
            //Arrange
            var context = Substitute.For<HttpContext>();
            var next = Substitute.For<RequestDelegate>();
            var logger = Substitute.For<ILoggerManager>();
            var sut = new DevKitLoggerMiddleware(next, logger);

            //Act
            var response = () => sut.InvokeAsync(context);

            //Assert
            response.Should().NotThrowAsync();
        }
    }
}
