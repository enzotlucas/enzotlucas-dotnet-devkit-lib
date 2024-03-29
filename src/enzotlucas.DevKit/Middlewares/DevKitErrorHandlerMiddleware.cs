﻿using enzotlucas.DevKit.Core.Exceptions;
using enzotlucas.DevKit.Extensions;
using enzotlucas.DevKit.Logger;
using enzotlucas.DevKit.Logger.LoggerManagers;
using enzotlucas.DevKit.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mime;

namespace enzotlucas.DevKit.Middlewares
{
    /// <summary>
    /// Middleware responsable for handle exceptions of the application.
    /// </summary>
    public sealed class DevKitErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _logger;

        public DevKitErrorHandlerMiddleware(RequestDelegate next,
                                            ILoggerManager logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var correlationId = context.Request.GetCorrelationId();

            try
            {
                await _next(context);
            }
            catch (NotFoundException ex)
            {
                _logger.Log(new Log(LogLevel.Warning, ex, correlationId));

                await HandleExceptionAsync(context, ex);
            }
            catch (BusinessException ex)
            {
                _logger.Log(new Log(LogLevel.Warning, ex, correlationId));

                await HandleExceptionAsync(context, ex);
            }
            catch (InfrastructureException ex)
            {
                _logger.Log(new Log(LogLevel.Error, ex, correlationId));

                await HandleExceptionAsync(context, ex, correlationId);
            }
            catch (Exception ex)
            {
                _logger.Log(new Log(LogLevel.Critical, "Something unexpected happened.", ex, correlationId));

                await HandleExceptionAsync(context, ex, correlationId);
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
            context.Response.ContentType = MediaTypeNames.Application.Json;

            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }
}
