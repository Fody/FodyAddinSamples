using System;
using Common.Logging;

public static class LogCaptureBuilder
{
    [ThreadStatic]
    public static string LastMessage;

    public static void Init()
    {
        LogManager.Adapter = new ActionAdapter();

    }
}