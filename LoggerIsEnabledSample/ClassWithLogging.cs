using Microsoft.Extensions.Logging;

public class ClassWithLogging
{
    ILogger<ClassWithLogging> logger;

    public ClassWithLogging(ILogger<ClassWithLogging> logger)
    {
        this.logger = logger;
    }

    public void LogTrace()
    {
        logger.LogTrace("message");
    }
}