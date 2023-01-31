using enzotlucas.DevKit.Logger;
using enzotlucas.DevKit.Logger.Loggers;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace enzotlucas.DevKit.Tests.Logger
{
    public class ConsoleLoggerManagerTests
    {
        [Fact]
        public void Log_WithLogLevelAndMessage_ShouldPrintLog()
        {
            //Arrange
            var logger = Substitute.For<ILogger<ConsoleLoggerManager>>();
            var sut = new ConsoleLoggerManager(logger);

            var logLevel = LogLevel.Information;
            var message = "Log message";

            //Act
            var act = () => sut.Log(logLevel, message);

            //Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void Log_WithLogLevelMessageAndCorrelationId_ShouldPrintLog()
        {
            //Arrange
            var logger = Substitute.For<ILogger<ConsoleLoggerManager>>();
            var sut = new ConsoleLoggerManager(logger);

            var logLevel = LogLevel.Information;
            var message = "Log message";
            var correlationId = Guid.NewGuid();

            //Act
            var act = () => sut.Log(logLevel, message, correlationId);

            //Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void Log_WithLogLevelMessageAndBody_ShouldPrintLog()
        {
            //Arrange
            var logger = Substitute.For<ILogger<ConsoleLoggerManager>>();
            var sut = new ConsoleLoggerManager(logger);

            var logLevel = LogLevel.Information;
            var message = "Log message";
            var body = new { Id = Guid.NewGuid(), Name = "log name" };

            //Act
            var act = () => sut.Log(logLevel, message, body: body);

            //Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void Log_WithLogLevelMessageCorrelationIdAndBody_ShouldPrintLog()
        {
            //Arrange
            var logger = Substitute.For<ILogger<ConsoleLoggerManager>>();
            var sut = new ConsoleLoggerManager(logger);

            var logLevel = LogLevel.Information;
            var message = "Log message";
            var correlationId = Guid.NewGuid();
            var body = new { Id = Guid.NewGuid(), Name = "log name" };

            //Act
            var act = () => sut.Log(logLevel, message, correlationId, body);

            //Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void Log_WithLogLevelMessageAndException_ShouldPrintLog()
        {
            //Arrange
            var logger = Substitute.For<ILogger<ConsoleLoggerManager>>();
            var sut = new ConsoleLoggerManager(logger);

            var logLevel = LogLevel.Information;
            var message = "Log message";
            var exception = new Exception();

            //Act
            var act = () => sut.Log(logLevel, message, exception);

            //Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void Log_WithLogLevelMessageExceptionAndCorrelationId_ShouldPrintLog()
        {
            //Arrange
            var logger = Substitute.For<ILogger<ConsoleLoggerManager>>();
            var sut = new ConsoleLoggerManager(logger);

            var logLevel = LogLevel.Information;
            var message = "Log message";
            var exception = new Exception();
            var correlationId = Guid.NewGuid();

            //Act
            var act = () => sut.Log(logLevel, message, exception, correlationId);

            //Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void Log_WithLogLevelMessageExceptionAndBody_ShouldPrintLog()
        {
            //Arrange
            var logger = Substitute.For<ILogger<ConsoleLoggerManager>>();
            var sut = new ConsoleLoggerManager(logger);

            var logLevel = LogLevel.Information;
            var message = "Log message";
            var exception = new Exception();
            var body = new { Id = Guid.NewGuid(), Name = "log name" };

            //Act
            var act = () => sut.Log(logLevel, message, exception, body: body);

            //Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void Log_WithLogLevelMessageExceptionCorrelationIdAndBody_ShouldPrintLog()
        {
            //Arrange
            var logger = Substitute.For<ILogger<ConsoleLoggerManager>>();
            var sut = new ConsoleLoggerManager(logger);

            var logLevel = LogLevel.Information;
            var message = "Log message";
            var exception = new Exception();
            var correlationId = Guid.NewGuid();
            var body = new { Id = Guid.NewGuid(), Name = "log name" };

            //Act
            var act = () => sut.Log(logLevel, message, exception, correlationId, body);

            //Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void Log_WithLogLevelAndException_ShouldPrintLog()
        {
            //Arrange
            var logger = Substitute.For<ILogger<ConsoleLoggerManager>>();
            var sut = new ConsoleLoggerManager(logger);

            var logLevel = LogLevel.Information;
            var exception = new Exception("Error message");

            //Act
            var act = () => sut.Log(logLevel, exception);

            //Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void Log_WithLogLevelExceptionAndInnerException_ShouldPrintLog()
        {
            //Arrange
            var logger = Substitute.For<ILogger<ConsoleLoggerManager>>();
            var sut = new ConsoleLoggerManager(logger);

            var logLevel = LogLevel.Information;
            var innerException = new Exception("Inner error message");
            var exception = new Exception("Error message", innerException);

            //Act
            var act = () => sut.Log(logLevel, exception);

            //Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void Log_WithLogLevelExceptionAndCorrelationId_ShouldPrintLog()
        {
            //Arrange
            var logger = Substitute.For<ILogger<ConsoleLoggerManager>>();
            var sut = new ConsoleLoggerManager(logger);

            var logLevel = LogLevel.Information;
            var exception = new Exception("Error message");
            var correlationId = Guid.NewGuid();

            //Act
            var act = () => sut.Log(logLevel, exception, correlationId);

            //Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void Log_WithLogLevelExceptionInnerExceptionAndCorrelationId_ShouldPrintLog()
        {
            //Arrange
            var logger = Substitute.For<ILogger<ConsoleLoggerManager>>();
            var sut = new ConsoleLoggerManager(logger);

            var logLevel = LogLevel.Information;
            var innerException = new Exception("Inner error message");
            var exception = new Exception("Error message", innerException);
            var correlationId = Guid.NewGuid();

            //Act
            var act = () => sut.Log(logLevel, exception, correlationId);

            //Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void Log_WithLogLevelExceptionAndBody_ShouldPrintLog()
        {
            //Arrange
            var logger = Substitute.For<ILogger<ConsoleLoggerManager>>();
            var sut = new ConsoleLoggerManager(logger);

            var logLevel = LogLevel.Information;
            var exception = new Exception("Error message");
            var body = new { Id = Guid.NewGuid(), Name = "log name" };

            //Act
            var act = () => sut.Log(logLevel, exception, body: body);

            //Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void Log_WithLogLevelExceptionInnerExceptionAndBody_ShouldPrintLog()
        {
            //Arrange
            var logger = Substitute.For<ILogger<ConsoleLoggerManager>>();
            var sut = new ConsoleLoggerManager(logger);

            var logLevel = LogLevel.Information;
            var innerException = new Exception("Inner error message");
            var exception = new Exception("Error message", innerException);
            var body = new { Id = Guid.NewGuid(), Name = "log name" };

            //Act
            var act = () => sut.Log(logLevel, exception, body: body);

            //Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void Log_WithLogLevelExceptionCorrelationIdAndBody_ShouldPrintLog()
        {
            //Arrange
            var logger = Substitute.For<ILogger<ConsoleLoggerManager>>();
            var sut = new ConsoleLoggerManager(logger);

            var logLevel = LogLevel.Information;
            var exception = new Exception("Error message");
            var correlationId = Guid.NewGuid();
            var body = new { Id = Guid.NewGuid(), Name = "log name" };

            //Act
            var act = () => sut.Log(logLevel, exception, correlationId, body);

            //Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void Log_WithLogLevelExceptionInnerExceptionCorrelationIdAndBody_ShouldPrintLog()
        {
            //Arrange
            var logger = Substitute.For<ILogger<ConsoleLoggerManager>>();
            var sut = new ConsoleLoggerManager(logger);

            var logLevel = LogLevel.Information;
            var innerException = new Exception("Inner error message");
            var exception = new Exception("Error message", innerException);
            var correlationId = Guid.NewGuid();
            var body = new { Id = Guid.NewGuid(), Name = "log name" };

            //Act
            var act = () => sut.Log(logLevel, exception, correlationId, body);

            //Assert
            act.Should().NotThrow();
        }
    }
}
