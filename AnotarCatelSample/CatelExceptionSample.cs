using System;
using Anotar.Catel;
using Xunit;

public class CatelExceptionSample
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

        Assert.StartsWith("Exception occurred in 'Void MyMethod()'.  | [Exception] System.Exception: Foo\r\n   at CatelExceptionSample.MyMethod() in", LogCaptureBuilder.LastMessage);
    }

    [LogToDebugOnException]
    static void MyMethod()
    {
        throw new Exception("Foo");
    }
}