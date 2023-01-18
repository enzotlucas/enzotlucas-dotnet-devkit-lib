using FluentValidation.Results;

namespace enzotlucas.DevKit.Core.Events
{
    /// <summary>
    /// Class for response messages definitions.
    /// </summary>
    public class ResponseMessage : Message
    {
        /// <summary>
        /// Get the validation result (FluentValidation) of the event.
        /// </summary>
        /// <returns><see cref="FluentValidation.Results.ValidationResult"/></returns>
        public ValidationResult ValidationResult { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseMessage"/> class with validation result, message type and correlation id.
        /// </summary>
        /// <param name="validationResult">Event validation result (FluentValidation).</param>
        /// <param name="correlationId">Request correlation id.</param>
        /// <returns><see cref="ResponseMessage"/></returns>
        public ResponseMessage(ValidationResult validationResult, Guid correlationId) : base(correlationId)
        {
            ValidationResult = validationResult;
        }
    }
}
