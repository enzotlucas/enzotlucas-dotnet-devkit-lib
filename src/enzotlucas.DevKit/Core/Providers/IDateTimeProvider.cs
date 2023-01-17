namespace enzotlucas.DevKit.Core.Providers
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
        DateTime Today { get; }
    }
}
