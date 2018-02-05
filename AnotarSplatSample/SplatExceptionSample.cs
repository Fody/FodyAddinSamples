using System;
using Anotar.Splat;
using Xunit;

public class SplatExceptionSample
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

        Assert.NotEmpty(LogCaptureBuilder.LastMessage);
    }

    [LogToDebugOnException]
    static void MyMethod()
    {
        throw new Exception("Foo");
    }
}