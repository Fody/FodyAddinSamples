using System;
using log4net.Config;

public static class LogCaptureBuilder
{
    [ThreadStatic]
    public static string LastMessage;

    public static void Init()
    {

        var target = new ActionAppender
            {
                Action = _ => LastMessage = _.RenderedMessage
            };


        BasicConfigurator.Configure(target);

    }
}