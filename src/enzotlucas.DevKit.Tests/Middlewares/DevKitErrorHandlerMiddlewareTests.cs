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
    }
}
