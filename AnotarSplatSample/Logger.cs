using Splat;

public class Logger : ILogger
{
    public void Write(string message, LogLevel logLevel)
    {
        LogCaptureBuilder.LastMessage = message;
    }

    public LogLevel Level { get; set; }

}