namespace enzotlucas.DevKit.Tests.Core.Exceptions
{
    public class NotFoundExceptionTests
    {
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
