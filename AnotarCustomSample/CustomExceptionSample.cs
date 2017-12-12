using System;
using Anotar.Custom;
using Xunit;

public class CustomExceptionSample
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

        Assert.Equal("Exception occurred in 'Void MyMethod()'. ", Logger.LastMessage.Format);
    }

    [LogToDebugOnException]
    static void MyMethod()
    {
        throw new Exception("Foo");
    }
}