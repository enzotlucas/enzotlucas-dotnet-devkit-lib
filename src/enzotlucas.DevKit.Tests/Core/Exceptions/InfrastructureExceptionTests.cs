namespace enzotlucas.DevKit.Tests.Core.Exceptions
{
    public class InfrastructureExceptionTests
    {
        [Fact]
        public void Constructor_ExceptionWithMessageAndInnerException_ShouldThrow()
        {
            //Arrange
            var message = "Something is wrong";
            var innerExceptionMessage = "Generic exception message";

            //Act
            var act = () =>
            {
                try
                {
                    throw new Exception(innerExceptionMessage);
                }
                catch (Exception ex)
                {
                    ex.Message.Should().Be(innerExceptionMessage);
                    throw new InfrastructureException(message, ex);
                }
            };

            //Assert
            var assertion = act.Should().ThrowExactly<InfrastructureException>();
            assertion.WithMessage(message);
            assertion.WithInnerException<Exception>().Which.Message.Equals(innerExceptionMessage);
        }

        [Fact]
        public void Constructor_ExceptionWithMessageAndInnerExceptionAndCorrelationId_ShouldThrow()
        {
            //Arrange
            var message = "Something is wrong";
            var innerExceptionMessage = "Generic exception message";
            var correlationId = Guid.NewGuid();

            //Act
            var act = () =>
            {
                try
                {
                    throw new Exception(innerExceptionMessage);
                }
                catch (Exception ex)
                {
                    ex.Message.Should().Be(innerExceptionMessage);
                    throw new InfrastructureException(message, correlationId, ex);
                }
            };

            //Assert
            var assertion = act.Should().ThrowExactly<InfrastructureException>();
            assertion.WithMessage(message);
            assertion.WithInnerException<Exception>().Which.Message.Should().Be(innerExceptionMessage);
            assertion.Which.CorrelationId.Should().Be(correlationId);
        }
    }
}
