using Microsoft.AspNetCore.Http;

namespace enzotlucas.DevKit.Extensions
{
    /// <summary>
    /// Extension responsable for <see cref="HttpRequest"/> help methods 
    /// </summary>
    public static class RequestExtensions
    {
        /// <summary>
        /// Request correlation id header name
        /// </summary>
        public const string CORRELATION_ID = "x-correlation-id";

        /// <summary>
        /// Get the current request http correlation id header value, if is empty, create a new correlation id
        /// </summary>
        /// <param name="request">Current http request</param>
        /// <returns>A <see cref="Guid"/> that represants the request correlation id</returns>
        public static Guid GetCorrelationId(this HttpRequest request)
        {
            if (request?.Headers[CORRELATION_ID] is null || !Guid.TryParse(request.Headers[CORRELATION_ID], out var correlationId))
            {
                return Guid.Empty;
            }

            return correlationId;
        }
    }
}
