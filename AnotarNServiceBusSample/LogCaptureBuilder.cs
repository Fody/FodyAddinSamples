using System;
using NServiceBus.Logging;

public class LogCaptureBuilder
{
    [ThreadStatic]
    public static string LastMessage;

    public static void Init()
    {
        LogManager.UseFactory(new LogCapture(s => LastMessage = s));
    }

}