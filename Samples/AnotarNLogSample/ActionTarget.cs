using System;
using NLog;
using NLog.Targets;

namespace AnotarNLogSample;

public sealed class ActionTarget : Target
{
    public Action<LogEventInfo> Action;

    protected override void Write(LogEventInfo logEvent) =>
        Action(logEvent);
}