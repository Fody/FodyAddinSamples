using System;
using Common.Logging;

namespace AnotarCommonLoggingSample;

public static class LogCaptureBuilder
{
    [ThreadStatic]
    public static string LastMessage;

    public static void Init() =>
        LogManager.Adapter = new ActionAdapter();
}