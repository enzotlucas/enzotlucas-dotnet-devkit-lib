using enzotlucas.DevKit.ViewModels;

namespace enzotlucas.DevKit.Tests.ViewModels
{
    public class ErrorResponseViewModelTests
    {
        [Fact]
        public void Constructor_WithExceptionAndCorrelationId_ShouldCreateViewModel()
        {
            //Arrange
            var message = "Error message";
            var exception = new Exception(message);
            var correlationId = Guid.NewGuid();

            //Act
            var viewModel = new ErrorResponseViewModel(exception, correlationId);

            //Assert
            viewModel.Errors.Should().BeEmpty();
            viewModel.Errors.Should().NotBeNull();
            viewModel.Message.Should().Be(message);
            viewModel.CorrelationId.Should().Be(correlationId);
        }

        [Fact]
        public void Constructor_WithBusinessException_ShouldCreateViewModel()
        {
            //Arrange
            var validationErrors = new Dictionary<string, string[]>
            {
                {"Error", new string[1]{"Error description"} }
            };
            var message = "Error message";
            var correlationId = Guid.NewGuid();
            var exception = new BusinessException(validationErrors, message, correlationId);

            //Act
            var viewModel = new ErrorResponseViewModel(exception);

            //Assert
            viewModel.Errors.Should().NotBeNullOrEmpty();
            viewModel.Errors.Count.Should().Be(1);
            viewModel.Errors.First().Should().Be(validationErrors.First());
            viewModel.Message.Should().Be(message);
            viewModel.CorrelationId.Should().Be(correlationId);
        }
    }
}
