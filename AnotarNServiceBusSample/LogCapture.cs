using System;
using NServiceBus.Logging;

public class LogCapture : ILoggerFactory, ILog
{

    Action<string> action;
    public LogCapture(Action<string> action)
    {
        this.action = action;
    }

    public ILog GetLogger(Type type)
    {
        return this;
    }

    public ILog GetLogger(string name)
    {
        return this;
    }

    public void Debug(string message)
    {
        action(message);
    }

    public void Debug(string message, Exception exception)
    {
        action(message);
    }

    public void DebugFormat(string format, params object[] args)
    {
        action(string.Format(format, args));
    }

    public void Info(string message)
    {
        action(message);
    }

    public void Info(string message, Exception exception)
    {
        action(message);
    }

    public void InfoFormat(string format, params object[] args)
    {
        action(string.Format(format, args));
    }

    public void Warn(string message)
    {
        action(message);
    }

    public void Warn(string message, Exception exception)
    {
        action(message);
    }

    public void WarnFormat(string format, params object[] args)
    {
        action(string.Format(format, args));
    }

    public void Error(string message)
    {
        action(message);
    }

    public void Error(string message, Exception exception)
    {
        action(message);
    }

    public void ErrorFormat(string format, params object[] args)
    {
        action(string.Format(format, args));
    }

    public void Fatal(string message)
    {
        action(message);
    }

    public void Fatal(string message, Exception exception)
    {
        action(message);
    }

    public void FatalFormat(string format, params object[] args)
    {
        action(string.Format(format, args));
    }

    public bool IsDebugEnabled
    {
        get { return true;}
    }

    public bool IsInfoEnabled
    {
        get { return true; }
    }

    public bool IsWarnEnabled
    {
        get { return true; }
    }

    public bool IsErrorEnabled
    {
        get { return true; }
    }

    public bool IsFatalEnabled
    {
        get { return true; }
    }
}