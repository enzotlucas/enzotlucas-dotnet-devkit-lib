namespace enzotlucas.DevKit.Core.Events
{
    public class Message
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }
        public Guid CorrelationId { get; protected set; }

        public Message(Guid correlationId)
        {
            MessageType = GetType().Name;
            CorrelationId = correlationId;
        }
    }
}
