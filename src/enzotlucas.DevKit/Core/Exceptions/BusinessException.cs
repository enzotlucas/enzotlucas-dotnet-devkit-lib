namespace enzotlucas.DevKit.Core.Exceptions
{
    /// <summary>
    /// Represents business logic errors that occur during application execution.
    /// </summary>
    public class BusinessException : Exception
    {
        /// <summary>
        /// Get the exception custom validation errors.
        /// </summary>
        /// <returns>
        /// <para> <see cref="IDictionary{TKey, TValue}"/></para> 
        /// <para> <see cref="{TKey}"/> is <see cref="string"/></para> 
        /// <para> <see cref="{TValue}"/> is <see cref="string"/>[]</para> 
        /// </returns>
        public IDictionary<string, string[]> ValidationErrors { get; private set; }

        /// <summary>
        /// Get the request correlation id.
        /// </summary>
        /// <returns><see cref="Guid"/></returns>
        public Guid CorrelationId { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">Error custom message.</param>
        /// <returns><see cref="BusinessException"/></returns>
        public BusinessException(string message) : base(message)
        {
            ValidationErrors = new Dictionary<string, string[]>();
            CorrelationId = Guid.NewGuid();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessException"/> class with a specified error message and request correlation id.
        /// </summary>
        /// <param name="message">Error custom message.</param>
        /// <param name="correlationId">The request correlation id.</param>
        /// <returns><see cref="BusinessException"/></returns>
        public BusinessException(string message, Guid correlationId) : base(message)
        {
            ValidationErrors = new Dictionary<string, string[]>();
            CorrelationId = correlationId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessException"/> class with custom validation errors,
        /// a specified error message and request correlation id.
        /// </summary>
        /// <param name="validationErrors">Custom validation errors.</param>
        /// <param name="message">Error custom message.</param>
        /// <param name="correlationId">The request correlation id.</param>
        /// <returns><see cref="BusinessException"/></returns>
        public BusinessException(IDictionary<string, string[]> validationErrors, string message, Guid correlationId)
            : base(message)
        {
            ValidationErrors = validationErrors;
            CorrelationId = correlationId;
        }
    }
}
