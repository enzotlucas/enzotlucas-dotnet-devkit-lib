namespace enzotlucas.DevKit.Core.Providers
{
    /// <summary>
    /// Interface used for DateTime dependency injection, making testing easy.
    /// </summary>
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
        DateTime Today { get; }
    }
}
