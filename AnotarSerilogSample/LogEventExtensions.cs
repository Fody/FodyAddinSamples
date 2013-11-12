﻿using Serilog.Events;

public static class LogEventExtensions
{
    public static string Value(this LogEvent logEvent, string property)
    {
        var logEventPropertyValue = (ScalarValue)logEvent.Properties[property];
        return (string) logEventPropertyValue.Value;
    }
}