using System;
using Serilog;

public static class LogCaptureBuilder
{
    [ThreadStatic]
    public static string LastMessage;

    public static void Init()
    {
        var eventSink = new EventSink
            {
                Action = _ => LastMessage = _.MessageTemplate.Text
            };
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.Sink(eventSink)
            .CreateLogger();
    }

}