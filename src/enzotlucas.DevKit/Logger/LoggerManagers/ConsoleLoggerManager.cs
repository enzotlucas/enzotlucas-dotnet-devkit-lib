using enzotlucas.DevKit.Core.Events;
using enzotlucas.DevKit.Extensions;
using enzotlucas.DevKit.Logger.LoggerManagers;
using Microsoft.Extensions.Logging;

namespace enzotlucas.DevKit.Logger.Loggers
{
    /// <summary>
    /// Console based logging, only for tests or debugging porpouse
    /// </summary>
    public sealed class ConsoleLoggerManager : ILoggerManager
    {
        public void Log(LogLevel logLevel, string message, Guid? correlationId = null, object body = null)
        {
            var log = new Log(logLevel, message, correlationId, body);

            Log(log);
        }

        public void Log(LogLevel logLevel, string message, Exception ex, Guid? correlationId = null, object body = null)
        {
            var log = new Log(logLevel, message, ex, correlationId, body);

            Log(log);
        }

        public void Log(LogLevel logLevel, Exception ex, Guid? correlationId = null, object body = null)
        {
            var log = new Log(logLevel, ex, correlationId, body);

            Log(log);
        }

        public void Log(Log log)
        {
            switch (log.LogLevel)
            {
                case LogLevel.Trace:
                case LogLevel.Debug:
                case LogLevel.Information:
                    LogInformation(log);
                    break;
                case LogLevel.None:
                    break;
                default:
                    LogError(log);
                    break;
            }
        }

        private static void LogError(Log log)
        {
            ConsoleExtensions.Print(log, log.LogLevel == LogLevel.Warning ? ConsoleColor.Yellow : ConsoleColor.Red);
        }

        private static void LogInformation(Log log)
        {
            ConsoleExtensions.Print(log, ConsoleColor.White);
        }

        public void Dispose()
        {

        }
    }
}
