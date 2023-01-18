using enzotlucas.DevKit.Core.Exceptions;
using Newtonsoft.Json;

namespace enzotlucas.DevKit.ViewModels
{
    /// <summary>
    /// ViewModel responsable for default errors messages.
    /// </summary>
    public sealed class ErrorResponseViewModel
    {
        /// <summary>
        /// Get the error message.
        /// </summary>
        /// <returns><see cref="string"/></returns>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Get the validation errors.
        /// </summary>
        /// <returns><see cref="IDictionary{TKey, TValue}"/></returns>
        [JsonProperty("errors")]
        public IDictionary<string, string[]> Errors { get; set; }

        /// <summary>
        /// Get the request correlation id.
        /// </summary>
        /// <returns><see cref="Guid"/></returns>
        [JsonProperty("correlationId")]
        public Guid CorrelationId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorResponseViewModel"/> class with the request correlation id and a specified error message.
        /// </summary>
        /// <param name="exception">The error.</param>
        /// <param name="correlationId">The request correlation id.</param>
        public ErrorResponseViewModel(Exception exception, Guid correlationId)
        {
            Message = exception.Message;
            Errors = new Dictionary<string, string[]>();
            CorrelationId = correlationId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorResponseViewModel"/> class with the request correlation id, a specified error message and validation errors.
        /// </summary>
        /// <param name="exception">The business logic error.</param>
        /// <returns><see cref="ErrorResponseViewModel"/></returns>
        public ErrorResponseViewModel(BusinessException exception)
        {
            Message = exception.Message;
            Errors = exception.ValidationErrors;
            CorrelationId = exception.CorrelationId;
        }
    }
}
