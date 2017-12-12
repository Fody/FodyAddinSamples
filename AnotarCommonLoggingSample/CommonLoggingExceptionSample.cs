using System;
using Anotar.CommonLogging;
using Xunit;

public class CommonLoggingExceptionSample
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