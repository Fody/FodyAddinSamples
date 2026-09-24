using Anotar.Custom;

namespace AnotarCustomSample;

// the tests in this namespace share the static last logged message
[NotInParallel]
public class CustomExceptionSample
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

        await Assert.That(Logger.LastMessage.Format).IsEqualTo("Exception occurred in 'Void MyMethod()'. ");
    }

    [LogToDebugOnException]
    static void MyMethod() =>
        throw new("Foo");
}