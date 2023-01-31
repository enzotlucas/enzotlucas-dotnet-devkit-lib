using enzotlucas.DevKit.Extensions;
using enzotlucas.DevKit.Logger.LoggerManagers;
using enzotlucas.DevKit.Middlewares;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace enzotlucas.DevKit.Tests.Middlewares
{
    public class DevKitCorrelationIdMiddlewareTests
    {
        [Fact]
        public void InvokeAsync_ValidRequest_ShouldNotThrow()
        {
            //Arrange
            var context = Substitute.For<HttpContext>();
            var next = Substitute.For<RequestDelegate>();
            var logger = Substitute.For<ILoggerManager>();
            var sut = new DevKitCorrelationIdMiddleware(next, logger);

            //Act
            var response = () => sut.InvokeAsync(context);

            //Assert
            response.Should().NotThrowAsync();
        }
    }
}
