using MediatR;

namespace enzotlucas.DevKit.Core.Events
{
    /// <summary>
    /// Class for event definitions.
    /// </summary>
    public class Event : Message, INotification
    {
        /// <summary>
        /// Get the event timestamp, that represents the event creation date.
        /// </summary>
        /// <returns><see cref="DateTime"/></returns>
        public DateTime Timestamp { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Event"/> class.
        /// </summary>
        /// <param name="correlationId">The request correlation id.</param>
        /// <returns><see cref="Event"/></returns>
        protected Event(Guid correlationId) : base(correlationId)
        {
            Timestamp = DateTime.Now;
        }
    }
}
