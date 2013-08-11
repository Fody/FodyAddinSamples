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

}