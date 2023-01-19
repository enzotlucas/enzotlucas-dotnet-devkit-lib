using enzotlucas.DevKit.Logger.Loggers;
using enzotlucas.DevKit.Logger;
using Microsoft.Extensions.DependencyInjection;
using enzotlucas.DevKit.Logger.LoggerManagers;

namespace enzotlucas.DevKit.DependencyInjection.Logger
{
    /// <summary>
    /// Class responsable for dependency injection of the custom logging configuration.
    /// </summary>
    public static class LoggerExtensions
    {
        private static readonly IReadOnlyDictionary<LoggerProvider, Type> _loggers =
        new Dictionary<LoggerProvider, Type>
        {
            { LoggerProvider.Console, typeof(ConsoleLoggerManager) }
        };

        /// <summary>
        /// Adds the custom logging configuration.
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        /// <param name="loggerProvider">Specifies the logging provider.</param>
        /// <returns>The <see cref="IServiceCollection"/> instance.</returns>
        public static IServiceCollection AddDevKitLoggingManagment(this IServiceCollection services, LoggerProvider loggerProvider)
        {
            var logger = _loggers[loggerProvider];

            if (logger is not null)
            {
                services.AddTransient(typeof(ILoggerManager), logger);
            }

            return services;
        }
    }
}
