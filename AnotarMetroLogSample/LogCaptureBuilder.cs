using System;
using MetroLog;

public static class LogCaptureBuilder
{
    [ThreadStatic] public static string LastMessage;

    public static void Init()
    {
        var target = new ActionTarget
        {
            Action = _ => LastMessage = _.Message
        };

        LogManagerFactory.DefaultConfiguration = new LoggingConfiguration
        {
            IsEnabled = true
        };
        LogManagerFactory.DefaultConfiguration.AddTarget(LogLevel.Debug, target);
    }

}