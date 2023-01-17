using enzotlucas.DevKit.ApiSpecification.Swagger;
using enzotlucas.DevKit.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace enzotlucas.DevKit.DependencyInjection
{
    public static class WebApplicationExtensions
    {
        /// <summary>
        /// Adds correlationId middleware, error handler middleware and logging middleware to the <paramref name="app"/>
        /// </summary>
        /// <param name="app"></param>
        /// <returns>The web application</returns>
        public static WebApplication UseDevKit(this WebApplication app)
        {
            app.UseMiddleware<CorrelationIdMiddleware>();

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseMiddleware<LoggerMiddleware>();

            app.UseSwaggerConfiguration();

            return app;
        }
    }
}
