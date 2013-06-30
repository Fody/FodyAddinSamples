using System;
using Catel.Logging;

public static class LogCaptureBuilder
{
    [ThreadStatic]
    public static string LastMessage;

    public static void Init()
    {
        LogManager.AddListener(new LogListener
        {
            Action = (s, @event) => { LastMessage = s; }
        });


    }
}