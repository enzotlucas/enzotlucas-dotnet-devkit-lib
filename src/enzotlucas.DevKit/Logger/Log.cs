using Microsoft.Extensions.Logging;

namespace enzotlucas.DevKit.Logger
{
    /// <summary>
    /// The log model used to save logs on logging manager.
    /// </summary>
    public class Log
    {
        /// <summary>
        /// Get the logging severity level.
        /// </summary>
        /// <returns><see cref="Microsoft.Extensions.Logging.LogLevel"/></returns>
        public LogLevel LogLevel { get; private set; }

        /// <summary>
        /// Get the request correlation id.
        /// </summary>
        /// <returns><see cref="Guid"/></returns>
        public Guid CorrelationId { get; private set; }

        /// <summary>
        /// Get the specified log message.
        /// </summary>
        /// <returns><see cref="string"/></returns>
        public string Message { get; private set; }

        /// <summary>
        /// Get the custom log object.
        /// </summary>
        /// <returns><see cref="object"/></returns>
        public object Body { get; private set; }

        /// <summary>
        /// Get the custom log error.
        /// </summary>
        /// <returns><see cref="Exception"/></returns>
        public Exception Error { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Log"/> class with the logging severity level, specified log message, 
        /// request correlation id and custom log object defined.
        /// </summary>
        /// <param name="logLevel">Log severity level.</param>
        /// <param name="message">Specified log message.</param>
        /// <param name="correlationId">The request correlation id.</param>
        /// <param name="body">Custom log object.</param>
        /// <returns><see cref="Log"/></returns>
        public Log(LogLevel logLevel,
                   string message, 
                   Guid? correlationId = null, 
                   object body = null)
        {
            LogLevel = logLevel;
            Message = message;
            CorrelationId = correlationId ?? Guid.Empty;
            Body = body;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Log"/> class with the logging severity level, specified log message, custom log error, 
        /// request correlation id and custom log object defined.
        /// </summary>
        /// <param name="logLevel">Log severity level.</param>
        /// <param name="message">Specified log message.</param>
        /// <param name="ex">Custom log error.</param>
        /// <param name="correlationId">The request correlation id.</param>
        /// <param name="body">Custom log object.</param>
        /// <returns><see cref="Log"/></returns>
        public Log(LogLevel logLevel,
                   string message, 
                   Exception ex, 
                   Guid? correlationId = null, 
                   object body = null) : 
            this(logLevel, message, correlationId, body)
        {
            Error = ex;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Log"/> class with the logging severity level, specified log message, custom log error, 
        /// request correlation id and custom log object defined.
        /// </summary>
        /// <param name="logLevel">Log severity level.</param>
        /// <param name="ex">Custom log error.</param>
        /// <param name="correlationId">The request correlation id.</param>
        /// <param name="body">Custom log object.</param>
        /// <returns><see cref="Log"/></returns>
        public Log(LogLevel logLevel,
                   Exception ex,
                   Guid? correlationId = null,
                   object body = null) :
            this(logLevel, string.IsNullOrWhiteSpace(ex?.InnerException?.Message) ? ex.Message : ex?.InnerException?.Message, correlationId, body)
        {
            Error = ex;
        }

        public override string ToString()
        {
            return "{" + Environment.NewLine +
                   $"   logLevel: {Enum.GetName(LogLevel)},{Environment.NewLine}" +
                   $"   message: {Message},{Environment.NewLine}" +
                   $"   correlationId: {CorrelationId},{Environment.NewLine}" +
                   $"   body: {Body},{Environment.NewLine}" +
                   $"   error: {Error},{Environment.NewLine}" +
                   "}";
        }
    }
}
