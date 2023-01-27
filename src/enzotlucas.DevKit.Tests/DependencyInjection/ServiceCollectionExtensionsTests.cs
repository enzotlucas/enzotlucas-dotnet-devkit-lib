using enzotlucas.DevKit.Core.Providers;
using enzotlucas.DevKit.DependencyInjection;
using enzotlucas.DevKit.Logger;
using enzotlucas.DevKit.Logger.LoggerManagers;
using enzotlucas.DevKit.Logger.Loggers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace enzotlucas.DevKit.Tests.DependencyInjection
{
    public class ServiceCollectionExtensionsTests
    {
        [Fact]
        public void AddDevKit_ConfigureAllServicesWithDefaultLogging_ShouldReturnServiceCollection()
        {
            //Arrange
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddDevKit();
            var app = builder.Build();
            using var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope();

            //Act
            var loggerService = serviceScope.ServiceProvider.GetRequiredService<ILoggerManager>();
            var dateTimeProvider = serviceScope.ServiceProvider.GetRequiredService<IDateTimeProvider>();
            var swaggerOptions = serviceScope.ServiceProvider.GetRequiredService<IConfigureOptions<SwaggerGenOptions>>();

            //Assert
            loggerService.Should().NotBeNull();
            dateTimeProvider.Should().NotBeNull();
            dateTimeProvider.Should().BeAssignableTo<DateTimeProvider>();
            swaggerOptions.Should().NotBeNull();
        }

        [Fact]
        public void AddDevKit_ConfigureAllServicesWithSpecifiedLogging_ShouldReturnServiceCollection()
        {
            //Arrange
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddDevKit(LoggerProvider.Console);
            var app = builder.Build();
            using var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope();

            //Act
            var loggerService = serviceScope.ServiceProvider.GetRequiredService<ILoggerManager>();
            var dateTimeProvider = serviceScope.ServiceProvider.GetRequiredService<IDateTimeProvider>();
            var swaggerOptions = serviceScope.ServiceProvider.GetRequiredService<IConfigureOptions<SwaggerGenOptions>>();

            //Assert
            loggerService.Should().NotBeNull();
            loggerService.Should().BeAssignableTo<ConsoleLoggerManager>();
            dateTimeProvider.Should().NotBeNull();
            dateTimeProvider.Should().BeAssignableTo<DateTimeProvider>();
            swaggerOptions.Should().NotBeNull();
        }
    }
}
