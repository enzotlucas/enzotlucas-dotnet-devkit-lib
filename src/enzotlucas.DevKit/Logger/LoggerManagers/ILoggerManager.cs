using Microsoft.Extensions.Logging;

namespace enzotlucas.DevKit.Logger.LoggerManagers
{
    /// <summary>
    /// Provides a custom logger manager
    /// </summary>
    public interface ILoggerManager : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="message"></param>
        /// <param name="correlationId"></param>
        /// <param name="body"></param>
        public void Log(LogLevel logLevel,
                        string message,
                        Guid? correlationId = null,
                        object body = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="ex"></param>
        /// <param name="correlationId"></param>
        /// <param name="body"></param>
        public void Log(LogLevel logLevel,
                        Exception ex,
                        Guid? correlationId = null,
                        object body = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        /// <param name="correlationId"></param>
        /// <param name="body"></param>
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
