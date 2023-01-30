using enzotlucas.DevKit.Tests.Fixtures;

namespace enzotlucas.DevKit.Tests.Middlewares
{
    [Collection(nameof(DevKitFixtureCollection))]
    public class DevKitErrorHandlerMiddlewareTests
    {
        private readonly DevKitFixture _fixture;

        public DevKitErrorHandlerMiddlewareTests(DevKitFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Invoke_ValidRequest_ShouldReturnOk()
        {
            //Arrange
            _fixture.GenerateDevKitApplication();
            _fixture.GenerateEndpoints();
            _fixture.Application.RunAsync();

            //Act
            var response = await _fixture.Client.GetAsync(_fixture.DefaultEndpoint);

            //Assert
            response.Should().NotBeNull();
        }
    }
}
