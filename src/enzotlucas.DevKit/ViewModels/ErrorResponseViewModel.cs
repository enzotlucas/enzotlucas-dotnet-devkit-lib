using enzotlucas.DevKit.Core.Exceptions;
using Newtonsoft.Json;

namespace enzotlucas.DevKit.ViewModels
{
    /// <summary>
    /// ViewModel responsable for default errors messages
    /// </summary>
    public sealed class ErrorResponseViewModel
    {
        /// <summary>
        /// Get the error message
        /// </summary>
        /// <returns>The error message</returns>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Get the validation errors
        /// </summary>
        /// <returns>A <see cref="IDictionary{TKey, TValue}"/> that contains validation errors</returns>
        [JsonProperty("errors")]
        public IDictionary<string, string[]> Errors { get; set; }

        /// <summary>
        /// Get the request correlation id
        /// </summary>
        /// <returns>A <see cref="Guid"/> that represants the request correlation id</returns>
        [JsonProperty("correlationId")]
        public Guid CorrelationId { get; set; }

        public ErrorResponseViewModel(Exception exception, Guid correlationId)
        {
            Message = exception.Message;
            Errors = new Dictionary<string, string[]>();
            CorrelationId = correlationId;
        }

        public ErrorResponseViewModel(BusinessException exception)
        {
            Message = exception.Message;
            Errors = exception.ValidationErrors;
            CorrelationId = exception.CorrelationId;
        }
    }
}
