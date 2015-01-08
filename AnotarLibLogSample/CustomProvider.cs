using System;
using AnotarLibLogSample.Logging;

public class CustomProvider : ILogProvider, ILog
{
    [ThreadStatic]
    public static string LastMessage;
    [ThreadStatic]
    public static Exception LastException;

    public ILog GetLogger(string name)
    {
        return this;
    }

    public bool Log(LogLevel logLevel, Func<string> messageFunc)
    {
        if (messageFunc != null)
        {
            LastMessage = messageFunc();
        }
        return true;
    }

    public bool Log(LogLevel logLevel, Func<string> messageFunc, Exception exception) 
    {
        if (messageFunc != null)
        {
            LastMessage = messageFunc();
        }
        LastException = exception;
        return true;
    }
}