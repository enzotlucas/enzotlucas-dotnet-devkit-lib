using enzotlucas.DevKit.Extensions;
using enzotlucas.DevKit.Logger;
using enzotlucas.DevKit.Logger.LoggerManagers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace enzotlucas.DevKit.Middlewares
{
    /// <summary>
    /// Middleware responsable for validating if the request have a correlation id, if don't, it creates a new one
    /// </summary>
    public sealed class CorrelationIdMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _logger;

        public CorrelationIdMiddleware(RequestDelegate next,
                                       ILoggerManager logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request?.Headers?[RequestExtensions.CORRELATION_ID] is null || !Guid.TryParse(context.Request?.Headers?[RequestExtensions.CORRELATION_ID], out _))
            {
                context.Request.Headers.Add(RequestExtensions.CORRELATION_ID, Guid.NewGuid().ToString());

                _logger.Log(new Log(LogLevel.Information, "Request correlation id is set", context.Request.GetCorrelationId()));
            }

            await _next(context);
        }
    }
}
