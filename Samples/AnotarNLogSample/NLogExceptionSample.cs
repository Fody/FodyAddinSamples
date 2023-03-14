using Anotar.NLog;
using Xunit;

namespace AnotarNLogSample;

public class NLogExceptionSample
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
        throw new("Foo");
    }
}