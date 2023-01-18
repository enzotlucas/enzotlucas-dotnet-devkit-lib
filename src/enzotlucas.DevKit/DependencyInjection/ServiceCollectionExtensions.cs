using enzotlucas.DevKit.ApiSpecification;
using enzotlucas.DevKit.Logger;
using enzotlucas.DevKit.ApiSpecification.Swagger;
using Microsoft.Extensions.DependencyInjection;
using enzotlucas.DevKit.Core.Providers;
using enzotlucas.DevKit.Logger.Loggers;
using enzotlucas.DevKit.Logger.LoggerManagers;
using enzotlucas.DevKit.DependencyInjection.Validator;
using enzotlucas.DevKit.DependencyInjection.Logger;

namespace enzotlucas.DevKit.DependencyInjection
{
    /// <summary>
    /// Class responsable for dependency injection of the library
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// This extension configures the following topics: 
        /// <list type="bullet">
        /// <item>API versioning</item>
        /// <item>API documentation</item>
        /// <item>Request validation</item>
        /// <item>Logging</item>
        /// </list>
        /// </summary>
        /// <param name="services"></param>
        /// <returns>The service collection</returns>
        public static IServiceCollection AddDevKit(this IServiceCollection services, LoggerProvider loggerProvider)
        {
            services.AddDevKit();

            services.AddDevKitLoggingManagment(loggerProvider);

            return services;
        }

        /// <summary>
        /// This extension configures the following topics: 
        /// <list type="bullet">
        /// <item>API versioning</item>
        /// <item>API documentation</item>
        /// <item>Request validation</item>
        /// </list>
        /// </summary>
        /// <param name="services"></param>
        /// <returns>The service collection</returns>
        public static IServiceCollection AddDevKit(this IServiceCollection services)
        {
            services.AddDevKitApiVersioningConfiguration();

            services.AddDevKitSwaggerConfiguration();

            services.AddDevKitValidation();

            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            return services;
        }
    }
}
