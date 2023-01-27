using System.Runtime.Serialization;

namespace enzotlucas.DevKit.Core.Exceptions
{
    /// <summary>
    /// Represents business logic errors of objects not found that occur during application execution.
    /// </summary>
    [Serializable]
    public sealed class NotFoundException : BusinessException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class with a specified error message and a reference to 
        /// the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">Error custom message.</param>
        /// <param name="innerException">The reference of the cause of this exception.</param>
        /// <returns><see cref="NotFoundException"/></returns>
        public NotFoundException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class with a default error message ("Not found").
        /// </summary>
        /// <param name="message">Error default message ("Not found").</param>
        /// <returns><see cref="NotFoundException"/></returns>
        public NotFoundException() : base("Not found") { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">Error custom message.</param>
        /// <returns><see cref="NotFoundException"/></returns>
        public NotFoundException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class with the request correlation id and a specified error message.
        /// </summary>
        /// <param name="correlationId">The request correlation id.</param>
        /// <param name="message">Error custom message.</param>
        /// <returns><see cref="NotFoundException"/></returns>
        public NotFoundException(Guid correlationId, string message = "Not found") : base(message, correlationId) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class with serialized data.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="SerializationException"></exception>
        /// <returns><see cref="NotFoundException"/></returns>
        protected NotFoundException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            :base(serializationInfo, streamingContext)
        { }
    }
}
