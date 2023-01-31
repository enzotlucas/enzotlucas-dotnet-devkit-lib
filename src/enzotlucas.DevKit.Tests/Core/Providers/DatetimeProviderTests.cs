using enzotlucas.DevKit.Core.Providers;

namespace enzotlucas.DevKit.Tests.Core.Providers
{
    public class DatetimeProviderTests
    {
        [Fact]
        public void Now_ShouldReturnDatetimeNow()
        {
            //Arrange
            var dateTimeProvider = new DateTimeProvider();

            //Act
            var date = dateTimeProvider.Now;

            //Assert
            date.ToString("yyyy-MM-ddThh").Should().Be(DateTime.Now.ToString("yyyy-MM-ddThh"));
        }

        [Fact]
        public void Today_ShouldReturnDatetimeToday()
        {
            //Arrange
            var dateTimeProvider = new DateTimeProvider();

            //Act
            var date = dateTimeProvider.Today;

            //Assert
            date.ToString("yyyy-MM-ddThh").Should().Be(DateTime.Today.ToString("yyyy-MM-ddThh"));
        }
    }
}
