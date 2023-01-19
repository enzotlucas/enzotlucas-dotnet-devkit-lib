using enzotlucas.DevKit.ApiSpecification;
using enzotlucas.DevKit.Logger;
using enzotlucas.DevKit.ApiSpecification.Swagger;
using Microsoft.Extensions.DependencyInjection;
using enzotlucas.DevKit.Core.Providers;
using enzotlucas.DevKit.DependencyInjection.Validator;
using enzotlucas.DevKit.DependencyInjection.Logger;

namespace enzotlucas.DevKit.DependencyInjection
{
    /// <summary>
    /// Class responsable for dependency injection of the library.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// This extension configures the following topics: 
        /// <list type="bullet">
        /// <item>API versioning;</item>
        /// <item>API documentation;</item>
        /// <item>Request validation;</item>
        /// <item>Logging.</item>
        /// </list>
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        /// <param name="loggerProvider">Specifies the logging provider.</param>
        /// <returns>The <see cref="IServiceCollection"/> instance.</returns>
        public static IServiceCollection AddDevKit(this IServiceCollection services, LoggerProvider loggerProvider)
        {
            services.AddDefaultServices();

            services.AddDevKitLoggingManagment(loggerProvider);

            return services;
        }

        /// <summary>
        /// This extension configures the following topics: 
        /// <list type="bullet">
        /// <item>API versioning;</item>
        /// <item>API documentation;</item>
        /// <item>Request validation.</item>
        /// </list>
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        /// <returns>The <see cref="IServiceCollection"/> instance.</returns>
        public static IServiceCollection AddDevKit(this IServiceCollection services)
        {
            services.AddDefaultServices();

            services.AddDevKitLoggingManagment(LoggerProvider.Console);

            return services;
        }

        private static IServiceCollection AddDefaultServices(this IServiceCollection services)
        {
            services.AddDevKitApiVersioningConfiguration();

            services.AddDevKitSwaggerConfiguration();

            services.AddDevKitRequestValidation();

            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            return services;
        }
    }
}
