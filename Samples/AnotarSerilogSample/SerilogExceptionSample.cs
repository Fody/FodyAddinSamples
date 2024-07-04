using Anotar.Serilog;
using Xunit;

namespace AnotarSerilogSample;

public class SerilogExceptionSample
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

        var actual = LogCaptureBuilder.LastMessage.MessageTemplate.Text;
        Assert.Equal("Exception occurred in 'Void MyMethod()'. ", actual);
    }

    [LogToDebugOnException]
    static void MyMethod() =>
        throw new("Foo");
}