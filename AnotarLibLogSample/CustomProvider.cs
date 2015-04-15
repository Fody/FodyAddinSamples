using System;
using AnotarLibLogSample.Logging;

public class CustomProvider : ILogProvider, ILog
{
    [ThreadStatic]
    public static string LastMessage;
    [ThreadStatic]
    public static Exception LastException;

    public Logger GetLogger(string name)
    {
        return Log;
    }

    public IDisposable OpenNestedContext(string message)
    {
        throw new NotImplementedException();
    }

    public IDisposable OpenMappedContext(string key, string value)
    {
        throw new NotImplementedException();
    }

    public bool Log(LogLevel logLevel, Func<string> messageFunc, Exception exception = null, params object[] formatParameters)
    {
        if (messageFunc != null)
        {
            LastMessage = messageFunc();
        }
        LastException = exception;
        return true;
    }
}