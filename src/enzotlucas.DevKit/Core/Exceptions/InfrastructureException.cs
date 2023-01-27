using System.Runtime.Serialization;

namespace enzotlucas.DevKit.Core.Exceptions
{
    /// <summary>
    /// Represents predictable infrastructure errors that occur during application execution
    /// </summary>
    [Serializable]
    public class InfrastructureException : Exception
    {
        /// <summary>
        /// Get the request correlation id.
        /// </summary>
        /// <returns><see cref="Guid"/></returns>
        public Guid CorrelationId { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InfrastructureException"/> class.
        /// </summary>
        /// <returns><see cref="InfrastructureException"/></returns>
        public InfrastructureException() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InfrastructureException"/> class with a specified error message and a reference to 
        /// the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">Error custom message.</param>
        /// <param name="innerException">The reference of the cause of this exception.</param>
        /// <returns><see cref="InfrastructureException"/></returns>
        public InfrastructureException(string message, Exception innerException = null)
            : base(message, innerException)
        {
            CorrelationId = Guid.NewGuid();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InfrastructureException"/> class with a specified error message, the request correlation id 
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">Error custom message.</param>
        /// <param name="correlationId">The request correlation id.</param>
        /// <param name="innerException">The reference of the cause of this exception.</param>
        /// <returns><see cref="InfrastructureException"/></returns>
        public InfrastructureException(string message, Guid correlationId, Exception innerException = null)
            : base(message, innerException)
        {
            CorrelationId = correlationId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InfrastructureException"/> class with serialized data.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="SerializationException"></exception>
        /// <returns><see cref="InfrastructureException"/></returns>
        protected InfrastructureException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        { }
    }
}
