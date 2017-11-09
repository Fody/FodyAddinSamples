using System;
using System.Reflection;
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

        var executingAssembly = Assembly.GetExecutingAssembly();
        var repository = log4net.LogManager.GetRepository(executingAssembly);
        BasicConfigurator.Configure(repository, target);
    }
}