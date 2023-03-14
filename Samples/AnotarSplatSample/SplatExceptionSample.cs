using Anotar.Splat;
using Xunit;

namespace AnotarSplatSample;

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
        throw new("Foo");
    }
}