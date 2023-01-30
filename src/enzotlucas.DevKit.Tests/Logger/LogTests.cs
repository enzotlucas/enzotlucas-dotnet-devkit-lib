using enzotlucas.DevKit.Logger;
using Microsoft.Extensions.Logging;
using System;

namespace enzotlucas.DevKit.Tests.Logger
{
    public class LogTests
    {
        [Fact]
        public void Constructor_WithLogLevelMessageCorrelationIdAndBody_ShouldCreateLog()
        {
            //Arrange
            var logLevel = LogLevel.Information;
            var message = "Log message";
            var correlationId = Guid.NewGuid();
            var body = new { Id = Guid.NewGuid(), Name = "log name" };

            //Act
            var log = new Log(logLevel, message, correlationId, body);

            //Assert
            log.LogLevel.Should().Be(logLevel);
            log.Message.Should().Be(message);
            log.CorrelationId.Should().Be(correlationId);
            log.Body.Should().Be(body);
            log.Error.Should().BeNull();
        }

        [Fact]
        public void Constructor_WithLogLevelMessageAndCorrelationId_ShouldCreateLog()
        {
            //Arrange
            var logLevel = LogLevel.Information;
            var message = "Log message";
            var correlationId = Guid.NewGuid();

            //Act
            var log = new Log(logLevel, message, correlationId);

            //Assert
            log.LogLevel.Should().Be(logLevel);
            log.Message.Should().Be(message);
            log.CorrelationId.Should().Be(correlationId);
            log.Body.Should().BeNull();
            log.Error.Should().BeNull();
        }

        [Fact]
        public void Constructor_WithLogLevelAndMessage_ShouldCreateLog()
        {
            //Arrange
            var logLevel = LogLevel.Information;
            var message = "Log message";

            //Act
            var log = new Log(logLevel, message);

            //Assert
            log.LogLevel.Should().Be(logLevel);
            log.Message.Should().Be(message);
            log.CorrelationId.Should().BeEmpty();
            log.Body.Should().BeNull();
            log.Error.Should().BeNull();
        }

        [Fact]
        public void Constructor_WithLogLevelMessageAndBody_ShouldCreateLog()
        {
            //Arrange
            var logLevel = LogLevel.Information;
            var message = "Log message";
            var body = new { Id = Guid.NewGuid(), Name = "log name" };

            //Act
            var log = new Log(logLevel, message, body: body);

            //Assert
            log.LogLevel.Should().Be(logLevel);
            log.Message.Should().Be(message);
            log.CorrelationId.Should().BeEmpty();
            log.Body.Should().Be(body);
            log.Error.Should().BeNull();
        }

        [Fact]
        public void Constructor_WithLogLevelMessageAndException_ShouldCreateLog()
        {
            //Arrange
            var logLevel = LogLevel.Warning;
            var message = "Log message";
            var exception = new Exception();

            //Act
            var log = new Log(logLevel, message, exception);

            //Assert
            log.LogLevel.Should().Be(logLevel);
            log.Message.Should().Be(message);
            log.CorrelationId.Should().BeEmpty();
            log.Body.Should().BeNull();
            log.Error.Should().Be(exception);
        }

        [Fact]
        public void Constructor_WithLogLevelMessageExceptionAndCorrelationId_ShouldCreateLog()
        {
            //Arrange
            var logLevel = LogLevel.Warning;
            var message = "Log message";
            var exception = new Exception();
            var correlationId = Guid.NewGuid();

            //Act
            var log = new Log(logLevel, message, exception, correlationId);

            //Assert
            log.LogLevel.Should().Be(logLevel);
            log.Message.Should().Be(message);
            log.CorrelationId.Should().Be(correlationId);
            log.Body.Should().BeNull();
            log.Error.Should().Be(exception);
        }

        [Fact]
        public void Constructor_WithLogLevelMessageExceptionAndBody_ShouldCreateLog()
        {
            //Arrange
            var logLevel = LogLevel.Warning;
            var message = "Log message";
            var exception = new Exception();
            var body = new { Id = Guid.NewGuid(), Name = "log name" };

            //Act
            var log = new Log(logLevel, message, exception, body: body);

            //Assert
            log.LogLevel.Should().Be(logLevel);
            log.Message.Should().Be(message);
            log.CorrelationId.Should().BeEmpty();
            log.Body.Should().Be(body);
            log.Error.Should().Be(exception);
        }

        [Fact]
        public void Constructor_WithLogLevelMessageExceptionCorrelationIdAndBody_ShouldCreateLog()
        {
            //Arrange
            var logLevel = LogLevel.Warning;
            var message = "Log message";
            var exception = new Exception();
            var correlationId = Guid.NewGuid();
            var body = new { Id = Guid.NewGuid(), Name = "log name" };

            //Act
            var log = new Log(logLevel, message, exception, correlationId, body);

            //Assert
            log.LogLevel.Should().Be(logLevel);
            log.Message.Should().Be(message);
            log.CorrelationId.Should().Be(correlationId);
            log.Body.Should().Be(body);
            log.Error.Should().Be(exception);
        }

        [Fact]
        public void Constructor_WithLogLevelExceptionCorrelationIdAndBody_ShouldCreateLog()
        {
            //Arrange
            var logLevel = LogLevel.Error;
            var exception = new Exception("Error message");
            var correlationId = Guid.NewGuid();
            var body = new { Id = Guid.NewGuid(), Name = "log name" };

            //Act
            var log = new Log(logLevel, exception, correlationId, body);

            //Assert
            log.LogLevel.Should().Be(logLevel);
            log.Message.Should().Be(exception.Message);
            log.CorrelationId.Should().Be(correlationId);
            log.Body.Should().Be(body);
            log.Error.Should().Be(exception);
        }

        [Fact]
        public void Constructor_WithLogLevelExceptionInnerExceptionCorrelationIdAndBody_ShouldCreateLog()
        {
            //Arrange
            var logLevel = LogLevel.Error;
            var innerException = new Exception("Inner exception message");
            var exception = new Exception("Error message", innerException);
            var correlationId = Guid.NewGuid();
            var body = new { Id = Guid.NewGuid(), Name = "log name" };

            //Act
            var log = new Log(logLevel, exception, correlationId, body);

            //Assert
            log.LogLevel.Should().Be(logLevel);
            log.Message.Should().Be(exception.InnerException.Message);
            log.CorrelationId.Should().Be(correlationId);
            log.Body.Should().Be(body);
            log.Error.Should().Be(exception);
        }

        [Fact]
        public void Constructor_WithLogLevelExceptionInnerExceptionWithNoInnerMessageCorrelationIdAndBody_ShouldCreateLog()
        {
            //Arrange
            var logLevel = LogLevel.Error;
            var innerException = new Exception(string.Empty);
            var exception = new Exception("Error message", innerException);
            var correlationId = Guid.NewGuid();
            var body = new { Id = Guid.NewGuid(), Name = "log name" };

            //Act
            var log = new Log(logLevel, exception, correlationId, body);

            //Assert
            log.LogLevel.Should().Be(logLevel);
            log.Message.Should().NotBe(exception.InnerException.Message);
            log.Message.Should().Be(exception.Message);
            log.CorrelationId.Should().Be(correlationId);
            log.Body.Should().Be(body);
            log.Error.Should().Be(exception);
        }

        [Fact]
        public void Constructor_WithLogLevelExceptionAndCorrelationId_ShouldCreateLog()
        {
            //Arrange
            var logLevel = LogLevel.Error;
            var exception = new Exception("Error message");
            var correlationId = Guid.NewGuid();

            //Act
            var log = new Log(logLevel, exception, correlationId);

            //Assert
            log.LogLevel.Should().Be(logLevel);
            log.Message.Should().Be(exception.Message);
            log.CorrelationId.Should().Be(correlationId);
            log.Body.Should().BeNull();
            log.Error.Should().Be(exception);
        }

        [Fact]
        public void Constructor_WithLogLevelExceptionAndBody_ShouldCreateLog()
        {
            //Arrange
            var logLevel = LogLevel.Error;
            var exception = new Exception("Error message");
            var body = new { Id = Guid.NewGuid(), Name = "log name" };

            //Act
            var log = new Log(logLevel, exception, body: body);

            //Assert
            log.LogLevel.Should().Be(logLevel);
            log.Message.Should().Be(exception.Message);
            log.CorrelationId.Should().BeEmpty();
            log.Body.Should().Be(body);
            log.Error.Should().Be(exception);
        }

        [Fact]
        public void Constructor_WithLogLevelAndException_ShouldCreateLog()
        {
            //Arrange
            var logLevel = LogLevel.Error;
            var exception = new Exception("Error message");

            //Act
            var log = new Log(logLevel, exception);

            //Assert
            log.LogLevel.Should().Be(logLevel);
            log.Message.Should().Be(exception.Message);
            log.CorrelationId.Should().BeEmpty();
            log.Body.Should().BeNull();
            log.Error.Should().Be(exception);
        }

        [Fact]
        public void ToString_ValidLog_ShouldReturnLogString()
        {
            //Arrange
            var logLevel = LogLevel.Information;
            var message = "Log message";
            var exception = new Exception("Error message");
            var correlationId = Guid.NewGuid();
            var body = new { Id = Guid.NewGuid(), Name = "log name" };

            var logString = "{" + Environment.NewLine +
                            $"   logLevel: {Enum.GetName(logLevel)},{Environment.NewLine}" +
                            $"   message: {message},{Environment.NewLine}" +
                            $"   correlationId: {correlationId},{Environment.NewLine}" +
                            $"   body: {body},{Environment.NewLine}" +
                            $"   error: {exception},{Environment.NewLine}" +
                            "}";

            //Act
            var log = new Log(logLevel, message, exception, correlationId, body);

            //Assert
            logString.Should().Be(log.ToString());
        }
    }
}
