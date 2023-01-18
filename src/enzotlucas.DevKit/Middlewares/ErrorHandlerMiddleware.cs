using enzotlucas.DevKit.Core.Exceptions;
using enzotlucas.DevKit.Extensions;
using enzotlucas.DevKit.Logger;
using enzotlucas.DevKit.Logger.LoggerManagers;
using enzotlucas.DevKit.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace enzotlucas.DevKit.Middlewares
{
    /// <summary>
    /// Middleware responsable for handle exceptions of the application.
    /// </summary>
    public sealed class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _logger;
        private Guid _correlationId;

        public ErrorHandlerMiddleware(RequestDelegate next,
                                      ILoggerManager logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException ex)
            {
                _correlationId = context.Request.GetCorrelationId();

                _logger.Log(new Log(LogLevel.Warning, ex, _correlationId));

                await HandleExceptionAsync(context, ex);
            }
            catch (BusinessException ex)
            {
                _correlationId = context.Request.GetCorrelationId();

                _logger.Log(new Log(LogLevel.Warning, ex, _correlationId));

                await HandleExceptionAsync(context, ex);
            }
            catch (InfrastructureException ex)
            {
                _correlationId = context.Request.GetCorrelationId();

                _logger.Log(new Log(LogLevel.Error, ex, _correlationId));

                await HandleExceptionAsync(context, ex, _correlationId);
            }
            catch (Exception ex)
            {
                _correlationId = context.Request.GetCorrelationId();

                _logger.Log(new Log(LogLevel.Critical, "Something unexpected happened.", ex, _correlationId));

                await HandleExceptionAsync(context, ex, _correlationId);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, NotFoundException exception)
        {
            var code = HttpStatusCode.NotFound;

            return ErrorResponse(context, exception, code, exception.CorrelationId);
        }

        private static Task HandleExceptionAsync(HttpContext context, BusinessException exception)
        {
            var code = HttpStatusCode.BadRequest;

            var result = JsonConvert.SerializeObject(new ErrorResponseViewModel(exception));

            return ErrorResponse(context, result, code);
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, Guid correlationId)
        {
            var code = HttpStatusCode.InternalServerError;

            return ErrorResponse(context, exception, code, correlationId);
        }

        private static Task ErrorResponse(HttpContext context, Exception exception, HttpStatusCode code, Guid correlationId)
        {
            var result = JsonConvert.SerializeObject(new ErrorResponseViewModel(exception, correlationId));

            return ErrorResponse(context, result, code);
        }

        private static Task ErrorResponse(HttpContext context, string result, HttpStatusCode code)
        {
            context.Response.ContentType = "application/json";

            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }
}
