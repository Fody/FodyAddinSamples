using Anotar.Serilog;

namespace AnotarSerilogSample;

// the tests in this namespace share the static last logged message
[NotInParallel]
public class SerilogExplicitSample
{
    [Test]
    public async Task Run()
    {
        MyMethod();

        var lastMessage = LogCaptureBuilder.LastMessage;
        await Assert.That(lastMessage.MethodName()).IsEqualTo("Void MyMethod()");
        await Assert.That(lastMessage.LineNumber()).IsEqualTo(21);
        await Assert.That(lastMessage.MessageTemplate.Text).IsEqualTo("TheMessage");
    }

    static void MyMethod() =>
        LogTo.Debug("TheMessage");
}