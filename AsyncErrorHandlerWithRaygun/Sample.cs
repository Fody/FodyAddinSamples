using System;
using System.Threading;
using System.Threading.Tasks;
using Mindscape.Raygun4Net;
using NUnit.Framework;

[TestFixture]
public class AsyncErrorHandlerWithRaygun
{
    [Test]
    public async Task Run()
    {
        try
        {
            var instance = new Target();
            await instance.MethodWithThrow().ConfigureAwait(false);
            //run and have a look at your Raygun dashboard
            Thread.Sleep(10);
        }
        catch
        {
        }
    }
}

public class Target
{
    public async Task MethodWithThrow()
    {
        await Task.Delay(1);
        throw new Exception("MyException");
    }
}

public static class AsyncErrorHandler
{
    public static void HandleException(Exception exception)
    {
        var apiKey = "";//TODO: set your Raygun ApiKey
        var raygunClient = new RaygunClient(apiKey);
        raygunClient.Send(exception);
    }
}