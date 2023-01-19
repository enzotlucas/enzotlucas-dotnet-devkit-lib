using MediatR;

namespace enzotlucas.DevKit.Core.UseCases
{
    /// <summary>
    /// Marker interface to represent a use case using MediatR library (mandatory for custom logging pipeline) with no response.
    /// </summary>
    /// <returns><see cref="IUseCase"/></returns>
    public interface IUseCase : IRequest
    {
        /// <summary>
        /// Get the request correlation id.
        /// </summary>
        /// <returns><see cref="Guid"/></returns>
        Guid CorrelationId { get; }
    }

    /// <summary>
    /// Marker interface to represent a use case using MediatR library (mandatory for custom logging pipeline) with a response.
    /// </summary>
    /// <typeparam name="T">The custom return of the use case.</typeparam>
    /// <returns><see cref="IUseCase{T}"/> response is <see cref="T"/></returns>
    public interface IUseCase<T> : IRequest<T>
    {
        /// <summary>
        /// Get the request correlation id.
        /// </summary>
        /// <returns><see cref="Guid"/></returns>
        Guid CorrelationId { get; }
    }
}
