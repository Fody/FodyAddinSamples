using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Linq.Expressions;
using Xunit;

public class Sample
{
    Expression<Action<ILogger<ClassWithLogging>>> logAction = x => x.Log(It.IsAny<LogLevel>(), 0, It.IsAny<object>(), It.IsAny<Exception>(), It.IsAny<Func<object, Exception, string>>());

    [Fact]
    public void LogTrace_With_IsEnabled_True_Will_Call_Log_Method()
    {
        var mockLogger = new Mock<ILogger<ClassWithLogging>>();
        mockLogger.Setup(x => x.IsEnabled(LogLevel.Trace)).Returns(true);
        mockLogger.Setup(logAction);

        var loggingSample = new ClassWithLogging(mockLogger.Object);

        loggingSample.LogTrace();

        mockLogger.Verify(x => x.IsEnabled(LogLevel.Trace), Times.Once);
        mockLogger.Verify(logAction, Times.Once);
    }

    [Fact]
    public void LogTrace_With_IsEnabled_False_Should_Not_Call_Log_Method()
    {
        var mockLogger = new Mock<ILogger<ClassWithLogging>>();
        mockLogger.Setup(x => x.IsEnabled(LogLevel.Trace)).Returns(false);
        mockLogger.Setup(logAction);

        var loggingSample = new ClassWithLogging(mockLogger.Object);

        loggingSample.LogTrace();

        mockLogger.Verify(x => x.IsEnabled(LogLevel.Trace), Times.Once);
        mockLogger.Verify(logAction, Times.Never);
    }
}