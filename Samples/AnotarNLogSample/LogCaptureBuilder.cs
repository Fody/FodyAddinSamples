using System;
using NLog;
using NLog.Config;

namespace AnotarNLogSample;

public class LogCaptureBuilder
{
    [ThreadStatic]
    public static string LastMessage;

    public static void Init()
    {
        var actionTarget = new ActionTarget
        {
            Action = _ => LastMessage = _.Message
        };
        var config = new LoggingConfiguration();
        config.LoggingRules.Add(new("*", LogLevel.Trace, actionTarget));
        config.AddTarget("debugger", actionTarget);
        LogManager.Configuration = config;
    }
}