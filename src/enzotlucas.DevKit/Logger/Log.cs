using Microsoft.Extensions.Logging;

namespace enzotlucas.DevKit.Logger
{
    /// <summary>
    /// 
    /// </summary>
    public class Log
    {
        /// <summary>
        /// 
        /// </summary>
        public LogLevel LogLevel { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid CorrelationId { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public object Body { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public Exception Error { get; private set; }
                
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="message"></param>
        /// <param name="correlationId"></param>
        /// <param name="body"></param>
        public Log(LogLevel logLevel, 
                   string message, 
                   Guid? correlationId = null, 
                   object body = null)
        {
            LogLevel = logLevel;
            Message = message;
            CorrelationId = correlationId ?? correlationId.Value;
            Body = body;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        /// <param name="correlationId"></param>
        /// <param name="body"></param>
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
        /// 
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        /// <param name="correlationId"></param>
        /// <param name="body"></param>
        public Log(LogLevel logLevel,
                   Exception ex,
                   Guid? correlationId = null,
                   object body = null) :
            this(logLevel, ex?.InnerException?.Message ?? ex.Message, correlationId, body)
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
