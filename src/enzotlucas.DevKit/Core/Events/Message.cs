using System.Diagnostics.CodeAnalysis;

namespace enzotlucas.DevKit.Core.Events
{
    /// <summary>
    /// Class for messages definitions
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Message
    {
        /// <summary>
        /// Get the message type
        /// </summary>
        /// <returns>The message type</returns>
        public string MessageType { get; protected set; }

        /// <summary>
        /// Get the message aggregate id
        /// </summary>
        /// <returns>A <see cref="Guid"/> that represents the domain aggregate id</returns>
        public Guid AggregateId { get; protected set; }

        /// <summary>
        /// Get the request correlation id
        /// </summary>
        /// <returns>A <see cref="Guid"/> that represents the request correlation id</returns>
        public Guid CorrelationId { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/>
        /// </summary>
        /// <param name="correlationId">The request correlation id</param>
        /// <returns>A <see cref="Message"/> with message type and correlation id</returns>
        public Message(Guid correlationId)
        {
            MessageType = GetType().Name;
            CorrelationId = correlationId;
        }
    }
}
