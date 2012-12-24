using System;
using System.Linq;
using NLog;
using NLog.Config;
using NLog.Targets;

public class LogCaptureBuilder{

    public static Func<string> SetupNLog()
    {
        var target = new MemoryTarget
            {
                Layout = "${message}"
            };
        var config = new LoggingConfiguration();
        config.AddTarget("trace", target);

        config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));

        LogManager.Configuration = config;

        return ()=> target.Logs.First();
    }

}