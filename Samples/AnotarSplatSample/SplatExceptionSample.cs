using Anotar.Splat;

namespace AnotarSplatSample;

// the tests in this namespace share the static last logged message
[NotInParallel]
public class SplatExceptionSample
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

        await Assert.That(LogCaptureBuilder.LastMessage).IsNotEmpty();
    }

    [LogToDebugOnException]
    static void MyMethod() =>
        throw new("Foo");
}