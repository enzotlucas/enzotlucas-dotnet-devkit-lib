using enzotlucas.DevKit.Core.Exceptions;
using enzotlucas.DevKit.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System.Collections.ObjectModel;
using System.Net;

namespace enzotlucas.DevKit.Tests.Fixtures
{
    [CollectionDefinition(nameof(LibraryFixtureCollection))]
    public class LibraryFixtureCollection : ICollectionFixture<LibraryFixture> { }

    public class LibraryFixture : IDisposable
    {
        public const string DEFAULT_TEST_REQUEST_URI = "/";
        private readonly IReadOnlyDictionary<Type, HttpStatusCode> _errorsStatusCode;

        public IHostBuilder TestServer { get; private set; }
        public IHost TestServerInstance { get; private set; }

        public LibraryFixture()
        {
            _errorsStatusCode = new Dictionary<Type, HttpStatusCode>()
            {
                {typeof(BusinessException), HttpStatusCode.BadRequest },
                {typeof(NotFoundException), HttpStatusCode.NotFound },
                {typeof(InfrastructureException), HttpStatusCode.InternalServerError },
                {typeof(Exception), HttpStatusCode.InternalServerError }
            };

            TestServer = CreateTestServer();
        }

        private static IHostBuilder CreateTestServer()
        {
            return new HostBuilder().ConfigureWebHost(webBuilder => webBuilder.UseTestServer());
        }

        public void AddMiddleware<TMiddleware>()
        {
            TestServer.ConfigureWebHost(webBuilder =>
            {
                webBuilder.Configure(app =>
                {
                    app.UseMiddleware<TMiddleware>();
                });
            });
        }

        public async Task StartTestServer()
        {
            TestServerInstance = await TestServer.StartAsync();
        }

        public Task DefineMockErrorResponseForTestRequest<T>(T error)
        {
            if (TestServerInstance is null)
            {
                throw new InvalidOperationException("Server instance is not up");
            }

            return Task.CompletedTask;
        }



        public void Dispose()
        {
            TestServerInstance.Dispose();
        }
    }
}
