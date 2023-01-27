using enzotlucas.DevKit.Extensions;
using Microsoft.AspNetCore.Http;
using NSubstitute;

namespace enzotlucas.DevKit.Tests.Extensions
{
    public class RequestExtensionsTests
    {
        [Fact]
        public void GetCorrelationId_ExistingCorrelationId_ShouldReturnExistingCorrelationId()
        {
            //Arrange
            var correlationId = Guid.NewGuid();
            var request = Substitute.For<HttpRequest>();
            request.Headers["x-correlation-id"] = correlationId.ToString();

            //Act
            var response = request.GetCorrelationId();

            //Assert
            response.Should().Be(correlationId);
        }

        [Fact]
        public void GetCorrelationId_NonExistingCorrelationId_ShouldReturnEmptyGuid()
        {
            //Arrange
            var request = Substitute.For<HttpRequest>();

            //Act
            var response = request.GetCorrelationId();

            //Assert
            response.Should().BeEmpty();
        }
    }
}
