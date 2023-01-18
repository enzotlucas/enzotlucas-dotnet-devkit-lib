namespace enzotlucas.DevKit.Core.Exceptions
{
    /// <summary>
    /// Represents predictable infrastructure errors that occur during application execution
    /// </summary>
    public class InfrastructureException : Exception
    {
        public Guid CorrelationId { get; private set; }

        public InfrastructureException(string message, Exception innerException = null)
            : base(message, innerException)
        {
            CorrelationId = Guid.NewGuid();
        }

        public InfrastructureException(string message, Guid correlationId, Exception innerException = null)
            : base(message, innerException)
        {
            CorrelationId = correlationId;
        }
    }
}
