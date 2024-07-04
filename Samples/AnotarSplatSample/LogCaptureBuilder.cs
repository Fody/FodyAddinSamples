using System;
using Splat;

namespace AnotarSplatSample;

public class LogCaptureBuilder
{
    [ThreadStatic]
    public static string LastMessage;

    static Logger currentLogger = new();

    public static void Init() =>
        Locator.CurrentMutable.Register(() => new FuncLogManager(GetLogger), typeof(ILogManager));

    static IFullLogger GetLogger(Type arg) =>
        new WrappingFullLogger(currentLogger);
}