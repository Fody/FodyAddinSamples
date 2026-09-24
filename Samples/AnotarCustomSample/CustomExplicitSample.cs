using Anotar.Custom;

namespace AnotarCustomSample;

// the tests in this namespace share the static last logged message
[NotInParallel]
public class CustomExplicitSample
{
    [Test]
    public async Task Run()
    {
        MyMethod();

        await Assert.That(Logger.LastMessage.Format).IsEqualTo("Method: 'Void MyMethod()'. Line: ~18. TheMessage");
    }

    static void MyMethod() =>
        LogTo.Debug("TheMessage");
}