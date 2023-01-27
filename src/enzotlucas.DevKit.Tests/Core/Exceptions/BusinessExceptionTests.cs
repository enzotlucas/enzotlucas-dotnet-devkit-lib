using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace enzotlucas.DevKit.Tests.Core.Exceptions
{
    public class BusinessExceptionTests
    {
        [Fact]
        public void Constructor_ExceptionWithNoParameters_ShouldThrow()
        {
            //Arrange & Act
            var act = () => { throw new BusinessException(); };

            //Assert
            act.Should().ThrowExactly<BusinessException>();
        }

        [Fact]
        public void Constructor_ExceptionWithMessageAndInnerException_ShouldThrow()
        {
            //Arrange
            var message = "Bad request";
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
                    throw new BusinessException(message, ex);
                }
            };

            //Assert
            var assertion = act.Should().ThrowExactly<BusinessException>();
            assertion.WithMessage(message);
            assertion.WithInnerException<Exception>().Which.Message.Equals(innerExceptionMessage);
        }

        [Fact]
        public void Constructor_ExceptionWithMessageAndValidationErrors_ShouldThrow()
        {
            //Arrange
            var validationErrorValue = new[] { "'Field' must be informed" };
            var validationErrors = new Dictionary<string, string[]>()
            {
                {"Field",  validationErrorValue}
            };
            var message = "Invalid entity";
            var correlationId = Guid.NewGuid();

            //Act
            var act = () =>
            {
                try
                {
                    throw new BusinessException(validationErrors, message, correlationId);
                }
                catch (BusinessException ex)
                {
                    ex.ValidationErrors["Field"].Equals(validationErrorValue)
                                                .Should()
                                                .Be(true);
                    throw;
                }
            };

            //Assert
            var assertion = act.Should().ThrowExactly<BusinessException>();
            assertion.WithMessage(message);
            assertion.Which.ValidationErrors.Should().BeAssignableTo(validationErrors.GetType())
                                                     .And.NotBeNullOrEmpty()
                                                     .And.HaveCount(1)
                                                     .And.BeSameAs(validationErrors);
            assertion.Which.CorrelationId.Should().Be(correlationId);
        }

        [Fact]
        public void Constructor_ExceptionWithMessage_ShouldThrow()
        {
            //Arrange
            var message = "Invalid entity";

            //Act
            var act = () => { throw new BusinessException(message); };

            //Assert
            act.Should().ThrowExactly<BusinessException>()
                        .WithMessage(message);
        }

        [Fact]
        public void Constructor_ExceptionWithMessageAndCorrelationId_ShouldThrow()
        {
            //Arrange
            var message = "Invalid entity";
            var correlationId = Guid.NewGuid();

            //Act
            var act = () => { throw new BusinessException(message, correlationId); };

            //Assert
            act.Should().ThrowExactly<BusinessException>()
                        .WithMessage(message)
                        .Which.CorrelationId.Should().Be(correlationId);
        }
    }
}
