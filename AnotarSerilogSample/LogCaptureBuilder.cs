using System;
using Serilog;
using Serilog.Events;

public static class LogCaptureBuilder
{
    [ThreadStatic]
    public static LogEvent LastMessage;

    public static void Init()
    {
        var eventSink = new EventSink
            {
                Action = _ => LastMessage = _
            };
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.Sink(eventSink)
            .CreateLogger();
    }

}