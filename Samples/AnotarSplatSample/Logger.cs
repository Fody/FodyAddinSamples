using System;
using Splat;

namespace AnotarSplatSample;

public class Logger : ILogger
{
    public void Write(string message, LogLevel logLevel)
    {
        LogCaptureBuilder.LastMessage = message;
    }

    public void Write(Exception exception, string message, LogLevel logLevel)
    {
        LogCaptureBuilder.LastMessage = message;
    }

    public void Write(string message, Type type, LogLevel logLevel)
    {
        LogCaptureBuilder.LastMessage = message;
    }

    public void Write(Exception exception, string message, Type type, LogLevel logLevel)
    {
        LogCaptureBuilder.LastMessage = message;
    }

    public LogLevel Level { get; set; }
}