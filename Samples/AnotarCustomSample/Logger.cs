using System;

namespace AnotarCustomSample;

public class Logger
{
    [ThreadStatic]
    public static LogEntry LastMessage;

    public void Debug(string format, params object[] args) =>
        LastMessage = new()
        {
            Format = format,
            Params = args,
        };

    public void Debug(string format) =>
        LastMessage = new()
        {
            Format = format,
        };

    public void Debug(Exception exception, string format, params object[] args) =>
        LastMessage = new()
        {
            Format = format,
            Params = args,
            Exception = exception
        };

    public bool IsDebugEnabled => true;
}