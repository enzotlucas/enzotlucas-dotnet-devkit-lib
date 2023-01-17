using enzotlucas.DevKit.ApiSpecification;
using enzotlucas.DevKit.Logger;
using enzotlucas.DevKit.ApiSpecification.Swagger;
using Microsoft.Extensions.DependencyInjection;
using enzotlucas.DevKit.Core.Providers;
using enzotlucas.DevKit.Logger.Loggers;
using enzotlucas.DevKit.Logger.LoggerManagers;
using enzotlucas.DevKit.DependencyInjection.Validator;

namespace enzotlucas.DevKit.DependencyInjection
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        private static readonly IReadOnlyDictionary<LoggerProvider, Type> _loggers =
        new Dictionary<LoggerProvider, Type>
        {
            {LoggerProvider.Console, typeof(ConsoleLoggerManager) }
        };


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

            var logger = _loggers[loggerProvider];

            if (logger is not null)
            {
                services.AddTransient(typeof(ILoggerManager), logger);
            }

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
            services.AddApiVersioningConfiguration();

            services.AddSwaggerConfiguration();

            services.UseValidation();

            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            return services;
        }
    }
}
