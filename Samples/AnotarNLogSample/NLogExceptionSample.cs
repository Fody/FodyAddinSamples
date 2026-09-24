using Anotar.NLog;

namespace AnotarNLogSample;

// the tests in this namespace share the static last logged message
[NotInParallel]
public class NLogExceptionSample
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

        await Assert.That(LogCaptureBuilder.LastMessage).IsEqualTo("Exception occurred in 'Void MyMethod()'. ");
    }

    [LogToDebugOnException]
    static void MyMethod() =>
        throw new("Foo");
}