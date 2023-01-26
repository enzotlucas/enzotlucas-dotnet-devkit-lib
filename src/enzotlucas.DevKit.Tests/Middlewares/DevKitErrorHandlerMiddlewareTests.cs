using enzotlucas.DevKit.Core.Exceptions;
using enzotlucas.DevKit.Middlewares;
using enzotlucas.DevKit.Tests.Fixtures;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;

namespace enzotlucas.DevKit.Tests.Middlewares
{
    [Collection(nameof(LibraryFixtureCollection))]
    public class DevKitErrorHandlerMiddlewareTests
    {
        private readonly LibraryFixture _fixture;

        public DevKitErrorHandlerMiddlewareTests(LibraryFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task InvokeAsync_BusinessException_ShouldReturnBadRequestWithErrorResponse()
        {
            //Arrange
            _fixture.AddMiddleware<DevKitErrorHandlerMiddleware>();
            await _fixture.StartTestServer();
            var response = new BusinessException("Bad request");
            await _fixture.DefineMockErrorResponseForTestRequest(response);

            //Act

            //Assert
        }
    }
}
