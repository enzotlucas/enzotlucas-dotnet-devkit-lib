using MediatR;

namespace enzotlucas.DevKit.Core.Events
{
    public class Event : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected Event(Guid correlationId) : base(correlationId)
        {
            Timestamp = DateTime.Now;
        }
    }
}
