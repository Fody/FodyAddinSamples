using System;
using Anotar.LibLog;
using Xunit;

public class LibLogExceptionSample
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

        Assert.Equal("Exception occurred in 'Void MyMethod()'. ", CustomProvider.LastMessage);
        Assert.NotNull(CustomProvider.LastException);
    }

    [LogToDebugOnException]
    static void MyMethod()
    {
        throw new Exception("Foo");
    }
}