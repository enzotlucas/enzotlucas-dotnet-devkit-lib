namespace enzotlucas.DevKit.Core.Providers
{
    internal sealed class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.Now;

        public DateTime Today => DateTime.Today;
    }
}
