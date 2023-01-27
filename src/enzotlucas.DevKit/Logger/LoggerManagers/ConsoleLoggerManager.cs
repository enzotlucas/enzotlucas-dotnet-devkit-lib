using enzotlucas.DevKit.Logger.LoggerManagers;
using Microsoft.Extensions.Logging;

namespace enzotlucas.DevKit.Logger.Loggers
{
    /// <summary>
    /// Console based logging, only for tests or debugging porpouse
    /// </summary>
    public sealed class ConsoleLoggerManager : ILoggerManager
    {
        private readonly ILogger<ConsoleLoggerManager> _logger;

        public ConsoleLoggerManager(ILogger<ConsoleLoggerManager> logger)
        {
            _logger = logger;
        }

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
            _logger.Log(log.LogLevel, log.Message, log);
        }
    }
}
