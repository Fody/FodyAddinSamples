using System;
using Splat;

public class LogCaptureBuilder
{
    [ThreadStatic]
    public static string LastMessage;

    static Logger currentLogger = new Logger();

    public static void Init()
    {
        Locator.CurrentMutable.Register(() => new FuncLogManager(GetLogger), typeof(ILogManager));
    }

    static IFullLogger GetLogger(Type arg)
    {
        return new WrappingFullLogger(currentLogger, arg);
    }

}