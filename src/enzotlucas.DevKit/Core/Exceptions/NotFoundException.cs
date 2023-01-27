namespace enzotlucas.DevKit.Core.Exceptions
{
    /// <summary>
    /// Represents business logic errors of objects not found that occur during application execution.
    /// </summary>
    [Serializable]
    public sealed class NotFoundException : BusinessException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">Error custom message.</param>
        /// <returns><see cref="NotFoundException"/></returns>
        public NotFoundException(string message = "Not found") : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class with the request correlation id and a specified error message.
        /// </summary>
        /// <param name="correlationId">The request correlation id.</param>
        /// <param name="message">Error custom message.</param>
        /// <returns><see cref="NotFoundException"/></returns>
        public NotFoundException(Guid correlationId, string message = "Not found") : base(message, correlationId)
        {
        }
    }
}
