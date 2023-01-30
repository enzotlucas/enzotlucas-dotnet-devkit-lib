using enzotlucas.DevKit.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace enzotlucas.DevKit.Tests.Fixtures
{
    [CollectionDefinition(nameof(DevKitFixtureCollection))]
    public class DevKitFixtureCollection : ICollectionFixture<DevKitFixture> { }

    public class DevKitFixture : IDisposable
    {
        public string BaseAddress { get; set; }
        public string DefaultEndpoint { get; set; }
        public string BusinessExceptionEndpoint { get; set; }
        public string NotFoundExceptionEndpoint { get; set; }
        public string InfrastructureExceptionEndpoint { get; set; }
        public string ExceptionEndpoint { get; set; }

        public WebApplication Application { get; set; }
        public WebApplicationBuilder WebApplicationBuilder { get; set; }
        public HttpClient Client { get; set; }

        public DevKitFixture()
        {
            BaseAddress = "http://localhost";
            DefaultEndpoint = "/";
            BusinessExceptionEndpoint = "/business-error/";
            NotFoundExceptionEndpoint = "/not-found-error/";
            InfrastructureExceptionEndpoint = "/infrastructure-error/";
            ExceptionEndpoint = "/error/";

            WebApplicationBuilder = WebApplication.CreateBuilder();
            Client = new HttpClient
            {
                BaseAddress = new Uri(BaseAddress)
            };
        }

        public void GenerateDefaultDevKitApplication()
        {
            WebApplicationBuilder.Services.AddDevKit();

            WebApplicationBuilder.Services.AddRouting();

            Application = WebApplicationBuilder.Build();
        }

        public void GenerateDevKitApplication()
        {
            GenerateDefaultDevKitApplication();

            Application.UseDevKit();

            Application.UseCors(c => c.AllowAnyOrigin());

            Application.UseRouting();
        }

        public void GenerateEndpoints()
        {
            Application.UseEndpoints(configure =>
            {
                configure.MapGet(DefaultEndpoint, () =>
                {
                    return Results.Ok("Success");
                });

                configure.MapGet(BusinessExceptionEndpoint, () =>
                {
                    throw new BusinessException();
                });

                configure.MapGet(NotFoundExceptionEndpoint, () =>
                {
                    throw new NotFoundException();
                });

                configure.MapGet(InfrastructureExceptionEndpoint, () =>
                {
                    throw new InfrastructureException();
                });

                configure.MapGet(ExceptionEndpoint, () =>
                {
                    throw new Exception();
                });
            });
        }

        public void Dispose()
        {
            if (Application is not null)
            {
                Application.StopAsync();
                Application.DisposeAsync();
            }

            Client.Dispose();
        }
    }
}
