using System;

public class Logger
{
    public static LogEntry LastMessage;

    public void Debug(string format, params object[] args)
    {
        LastMessage = new LogEntry
        {
            Format = format,
            Params = args,
        };   
    }
    public void Debug(Exception exception, string format, params object[] args)
    {
        LastMessage = new LogEntry
        {
            Format = format,
            Params = args,
            Exception = exception
        };
    }

    public bool IsDebugEnabled { get { return true; } }

    public void Information(string format, params object[] args)
    {
        LastMessage = new LogEntry
        {
            Format = format,
            Params = args,
        };
    }
    public void Information(Exception exception, string format, params object[] args)
    {
        LastMessage = new LogEntry
        {
            Format = format,
            Params = args,
            Exception = exception
        };
    }
    public bool IsInformationEnabled { get { return true; } }

    public void Warning(string format, params object[] args)
    {
        LastMessage = new LogEntry
        {
            Format = format,
            Params = args,
        };
    }
    public void Warning(Exception exception, string format, params object[] args)
    {
       LastMessage = new LogEntry
        {
            Format = format,
            Params = args,
            Exception = exception
        };
    }
    public bool IsWarningEnabled { get { return true; } }

    public void Error(string format, params object[] args)
    {

        LastMessage = new LogEntry
        {
            Format = format,
            Params = args,
        };
    }
    public void Error(Exception exception, string format, params object[] args)
    {
        LastMessage = new LogEntry
        {
            Format = format,
            Params = args,
            Exception = exception
        };
    } 
    public bool IsErrorEnabled { get { return true; } }

    public void Fatal(string format, params object[] args)
    {
        LastMessage = new LogEntry
                   {
                       Format = format,
                       Params = args
                   };
    }
    public void Fatal(Exception exception, string format, params object[] args)
    {
        LastMessage = new LogEntry
        {
            Format = format,
            Params = args,
            Exception = exception
        };
    }
    public bool IsFatalEnabled { get { return true; } }
}