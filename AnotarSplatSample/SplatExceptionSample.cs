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

        var lastMessage = LogCaptureBuilder.LastMessage.Replace(Environment.NewLine, "");
        Assert.Equal(@"SplatExceptionSample: Exception occurred in 'Void MyMethod()'. : System.Exception: Foo   at SplatExceptionSample.MyMethod()", lastMessage.Substring(0, lastMessage.LastIndexOf(" in ")));
    }

    [LogToDebugOnException]
    static void MyMethod()
    {
        throw new Exception("Foo");
    }

}