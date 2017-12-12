using System;
using Anotar.NServiceBus;
using Xunit;

public class NServiceBusExceptionSample
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