using Anotar.NLog;

namespace AnotarNLogSample;

// the tests in this namespace share the static last logged message
[NotInParallel]
public class NLogExplicitSample
{
    [Test]
    public async Task Run()
    {
        MyMethod();

        await Assert.That(LogCaptureBuilder.LastMessage).IsEqualTo("Method: 'Void MyMethod()'. Line: ~18. TheMessage");
    }

    static void MyMethod() =>
        LogTo.Debug("TheMessage");
}