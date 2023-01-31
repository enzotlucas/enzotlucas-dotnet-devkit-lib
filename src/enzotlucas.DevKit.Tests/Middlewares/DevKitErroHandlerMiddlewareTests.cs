using enzotlucas.DevKit.Logger.LoggerManagers;
using enzotlucas.DevKit.Middlewares;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace enzotlucas.DevKit.Tests.Middlewares
{
    public class DevKitErroHandlerMiddlewareTests
    {
        [Fact]
        public void InvokeAsync_ThrowsBusinessException_ShouldReturnErrorViewModel()
        {
            //Arrange
            var context = Substitute.For<HttpContext>();
            var next = Substitute.For<RequestDelegate>();
            next(context).Throws<BusinessException>();
            var logger = Substitute.For<ILoggerManager>();
            var sut = new DevKitErrorHandlerMiddleware(next, logger);

            //Act
            _ = sut.InvokeAsync(context);

            //Assert
            context.Response.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        }

        [Fact]
        public void InvokeAsync_ThrowsNotFoundException_ShouldReturnErrorViewModel()
        {
            //Arrange
            var context = Substitute.For<HttpContext>();
            var next = Substitute.For<RequestDelegate>();
            next(context).Throws<NotFoundException>();
            var logger = Substitute.For<ILoggerManager>();
            var sut = new DevKitErrorHandlerMiddleware(next, logger);

            //Act
            _ = sut.InvokeAsync(context);

            //Assert
            context.Response.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public void InvokeAsync_ThrowsInfrastructureException_ShouldReturnErrorViewModel()
        {
            //Arrange
            var context = Substitute.For<HttpContext>();
            var next = Substitute.For<RequestDelegate>();
            next(context).Throws<InfrastructureException>();
            var logger = Substitute.For<ILoggerManager>();
            var sut = new DevKitErrorHandlerMiddleware(next, logger);

            //Act
            _ = sut.InvokeAsync(context);

            //Assert
            context.Response.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
        }

        [Fact]
        public void InvokeAsync_ThrowsException_ShouldReturnErrorViewModel()
        {
            //Arrange
            var context = Substitute.For<HttpContext>();
            var next = Substitute.For<RequestDelegate>();
            next(context).Throws<Exception>();
            var logger = Substitute.For<ILoggerManager>();
            var sut = new DevKitErrorHandlerMiddleware(next, logger);

            //Act
            _ = sut.InvokeAsync(context);

            //Assert
            context.Response.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
        }
    }
}
