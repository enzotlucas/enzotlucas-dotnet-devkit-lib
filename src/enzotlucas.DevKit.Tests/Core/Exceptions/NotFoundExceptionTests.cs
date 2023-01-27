namespace enzotlucas.DevKit.Tests.Core.Exceptions
{
    public class NotFoundExceptionTests
    {
        [Fact]
        public void Constructor_ExceptionWithMessageAndInnerException_ShouldThrow()
        {
            //Arrange
            var message = "Not found";
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
                    throw new NotFoundException(message, ex);
                }
            };

            //Assert
            var assertion = act.Should().ThrowExactly<NotFoundException>();
            assertion.WithMessage(message);
            assertion.WithInnerException<Exception>().Which.Message.Equals(innerExceptionMessage);
        }

        [Fact]
        public void Constructor_DefaultMessage_ShouldThrow()
        {
            //Arrange & Act
            var act = () => { throw new NotFoundException(); };

            //Assert
            act.Should().ThrowExactly<NotFoundException>()
                        .WithMessage("Not found");
        }

        [Fact]
        public void Constructor_CustomMessage_ShouldThrow()
        {
            //Arrange
            var message = "Not found custom";

            //Act
            var act = () => { throw new NotFoundException(message); };

            //Assert
            act.Should().ThrowExactly<NotFoundException>()
                        .WithMessage(message);
        }

        [Fact]
        public void Constructor_CustomMessageAndCorrelationId_ShouldThrow()
        {
            //Arrange
            var correlationId = Guid.NewGuid();
            var message = "Not found custom";

            //Act
            var act = () => { throw new NotFoundException(correlationId, message); };

            //Assert
            act.Should().ThrowExactly<NotFoundException>()
                        .WithMessage(message)
                        .Which.CorrelationId.Should().Be(correlationId);
        }

        [Fact]
        public void Constructor_DefaultMessageAndCorrelationId_ShouldThrow()
        {
            //Arrange
            var correlationId = Guid.NewGuid();

            //Act
            var act = () => { throw new NotFoundException(correlationId); };

            //Assert
            act.Should().ThrowExactly<NotFoundException>()
                        .WithMessage("Not found")
                        .Which.CorrelationId.Should().Be(correlationId);
        }
    }
}
