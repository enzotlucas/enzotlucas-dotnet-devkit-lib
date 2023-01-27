using enzotlucas.DevKit.Extensions;

namespace enzotlucas.DevKit.Tests.Extensions
{
    public class ConsoleExtensionsTests
    {
        [Fact]
        public void PrintError_ShouldPrintErrorMessage()
        {
            //Arrange
            var errorMessage = "Error message";
            var writer = new StringWriter();
            Console.SetOut(writer);

            //Act
            ConsoleExtensions.PrintError(errorMessage);

            //Assert
            var response = writer.ToString().Replace(Environment.NewLine, string.Empty);
            response.Should().Be(errorMessage);
            Console.ForegroundColor.Should().Be(ConsoleColor.Gray);
        }

        [Fact]
        public void PrintInformation_ShouldPrintInformationMessage()
        {
            //Arrange
            var informationMessage = "Information message";
            var writer = new StringWriter();
            Console.SetOut(writer);

            //Act
            ConsoleExtensions.PrintInformation(informationMessage);

            //Assert
            var response = writer.ToString().Replace(Environment.NewLine, string.Empty);
            response.Should().Be(informationMessage);
            Console.ForegroundColor.Should().Be(ConsoleColor.Gray);
        }

        [Fact]
        public void PrintSuccess_ShouldPrintSuccessMessage()
        {
            //Arrange
            var successMessage = "Success message";
            var writer = new StringWriter();
            Console.SetOut(writer);

            //Act
            ConsoleExtensions.PrintSuccess(successMessage);

            //Assert
            var response = writer.ToString().Replace(Environment.NewLine, string.Empty);
            response.Should().Be(successMessage);
            Console.ForegroundColor.Should().Be(ConsoleColor.Gray);
        }

        [Fact]
        public void Print_ValidObject_ShouldPrintObject()
        {
            //Arrange
            var customObject = new { Id = Guid.NewGuid(), Name = "Object name" };
            var writer = new StringWriter();
            Console.SetOut(writer);

            //Act
            ConsoleExtensions.Print(customObject, ConsoleColor.Gray);

            //Assert
            var response = writer.ToString().Replace(Environment.NewLine, string.Empty);
            response.Should().Be(customObject.ToString());
            Console.ForegroundColor.Should().Be(ConsoleColor.Gray);
        }

        [Fact]
        public void Print_ValidMessageAndColor_ShouldPrintMessage()
        {
            //Arrange
            var message = "Custom message";
            var writer = new StringWriter();
            Console.SetOut(writer);

            //Act
            ConsoleExtensions.Print(message, ConsoleColor.Blue);

            //Assert
            var response = writer.ToString().Replace(Environment.NewLine, string.Empty);
            response.Should().Be(message);
            Console.ForegroundColor.Should().Be(ConsoleColor.Gray);
        }
    }
}
