using System;
using Serilog;
using Serilog.Events;

public static class LogCaptureBuilder
{
    [ThreadStatic]
    public static string LastMessage;

    public static void Init()
    {
        var eventSink = new EventSink
            {
                Action = _ => LastMessage = _.MessageTemplate
            };
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel(LogEventLevel.Verbose)
            .WithSink(eventSink)
            .CreateLogger();
    }

}