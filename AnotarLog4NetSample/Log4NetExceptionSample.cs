using System;
using Anotar.Log4Net;
using Xunit;

public class Log4NetExceptionSample
{
    [Fact]
    public void Run()
    {
        try
        {
           MyMethod();
        }
        catch
        {
        }

        Assert.Equal("Exception occurred in 'Void MyMethod()'. ", LogCaptureBuilder.LastMessage);
    }

    [LogToDebugOnException]
    static void MyMethod()
    {
        throw new Exception("Foo");
    }
}