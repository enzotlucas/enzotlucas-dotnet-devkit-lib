using Microsoft.Extensions.Logging;

namespace enzotlucas.DevKit.Logger.LoggerManagers
{
    /// <summary>
    /// Provides a custom logger manager
    /// </summary>
    public interface ILoggerManager
    {
        /// <summary>
        /// Saves the log
        /// </summary>
        /// <param name="logLevel">Log severity level.</param>
        /// <param name="message">Specified log message.</param>
        /// <param name="correlationId">The request correlation id.</param>
        /// <param name="body">Custom log object.</param>
        public void Log(LogLevel logLevel,
                        string message,
                        Guid? correlationId = null,
                        object body = null);

        /// <summary>
        /// Saves the log
        /// </summary>
        /// <param name="logLevel">Log severity level.</param>
        /// <param name="ex">Custom log error.</param>
        /// <param name="correlationId">The request correlation id.</param>
        /// <param name="body">Custom log object.</param>
        public void Log(LogLevel logLevel,
                        Exception ex,
                        Guid? correlationId = null,
                        object body = null);

        /// <summary>
        /// Saves the log
        /// </summary>
        /// <param name="logLevel">Log severity level.</param>
        /// <param name="message">Specified log message.</param>
        /// <param name="ex">Custom log error.</param>
        /// <param name="correlationId">The request correlation id.</param>
        /// <param name="body">Custom log object.</param>
        public void Log(LogLevel logLevel,
                        string message,
                        Exception ex,
                        Guid? correlationId = null,
                        object body = null);

        /// <summary>
        /// Saves the log
        /// </summary>
        /// <param name="log">The log that will be saved</param>
        public void Log(Log log);
    }
}
