using Anotar.Serilog;

namespace AnotarSerilogSample;

// the tests in this namespace share the static last logged message
[NotInParallel]
public class SerilogExceptionSample
{
    [Test]
    public async Task Run()
    {
        try
        {
            MyMethod();
        }
        catch
        {
        }

        var actual = LogCaptureBuilder.LastMessage.MessageTemplate.Text;
        await Assert.That(actual).IsEqualTo("Exception occurred in 'Void MyMethod()'. ");
    }

    [LogToDebugOnException]
    static void MyMethod() =>
        throw new("Foo");
}