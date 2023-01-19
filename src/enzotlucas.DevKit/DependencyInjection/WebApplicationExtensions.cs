using enzotlucas.DevKit.ApiSpecification.Swagger;
using enzotlucas.DevKit.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace enzotlucas.DevKit.DependencyInjection
{
    public static class WebApplicationExtensions
    {
        /// <summary>
        /// Apply API documentation, adds correlationId middleware, error handler middleware and logging middleware to the <paramref name="app"/>.
        /// </summary>
        /// <param name="app">The web application used to configure the HTTP pipeline and routes.</param>
        /// <returns>The <see cref="IApplicationBuilder"/> instance.</returns>
        public static IApplicationBuilder UseDevKit(this IApplicationBuilder app)
        {
            app.UseMiddleware<DevKitCorrelationIdMiddleware>();

            app.UseMiddleware<DevKitErrorHandlerMiddleware>();

            app.UseMiddleware<DevKitLoggerMiddleware>();

            app.UseDevKitSwaggerConfiguration();

            return app;
        }
    }
}
