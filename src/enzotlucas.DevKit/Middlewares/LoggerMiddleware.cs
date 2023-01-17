﻿using enzotlucas.DevKit.Core.Providers;
using enzotlucas.DevKit.Extensions;
using enzotlucas.DevKit.Logger;
using enzotlucas.DevKit.Logger.LoggerManagers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace enzotlucas.DevKit.Middlewares
{
    /// <summary>
    /// Middleware responsable for save a log of every request
    /// </summary>
    public sealed class LoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _logger;
        private Guid _correlationId;

        public LoggerMiddleware(RequestDelegate next,
                                ILoggerManager logger,
                                IDateTimeProvider dateTime)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await HandleLogsAsync(context);

            await _next(context);
        }

        private Task HandleLogsAsync(HttpContext context)
        {
            _correlationId = context.Request.GetCorrelationId();

            if (context.User is null || !context.User.Identity.IsAuthenticated)
            {
                _logger.Log(new Log(LogLevel.Information, "Anonymous request to route", _correlationId));

                return Task.CompletedTask;
            }

            var userId = context.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

            _logger.Log(new Log(LogLevel.Information, "Authenticated request to route", _correlationId, new { userId, context }));

            return Task.CompletedTask;
        }
    }
}
