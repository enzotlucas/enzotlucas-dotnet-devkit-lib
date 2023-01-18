using enzotlucas.DevKit.Logger.Loggers;
using enzotlucas.DevKit.Logger;
using Microsoft.Extensions.DependencyInjection;
using enzotlucas.DevKit.Logger.LoggerManagers;
using Microsoft.Extensions.Logging;

namespace enzotlucas.DevKit.DependencyInjection.Logger
{
    public static class LoggerExtensions
    {
        private static readonly IReadOnlyDictionary<LoggerProvider, Type> _loggers =
        new Dictionary<LoggerProvider, Type>
        {
            {LoggerProvider.Console, typeof(ConsoleLoggerManager) }
        };

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
