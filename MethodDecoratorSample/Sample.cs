
// the tests share the static InterceptionRecorder state
[NotInParallel]
public class MethodDecoratorTests
{
    [Test]
    public async Task SimpleMethodSample()
    {
        InterceptionRecorder.Clear();
        Target.MyMethod();
        await Assert.That(InterceptionRecorder.OnEntryCalled).IsTrue();
        await Assert.That(InterceptionRecorder.OnExitCalled).IsTrue();
        await Assert.That(InterceptionRecorder.OnExceptionCalled).IsFalse();
    }

    [Test]
    public async Task ExceptionMethodSample()
    {
        InterceptionRecorder.Clear();
        try
        {
            Target.MyExceptionMethod();
        }
        catch
        {
        }
        await Assert.That(InterceptionRecorder.OnEntryCalled).IsTrue();
        await Assert.That(InterceptionRecorder.OnExitCalled).IsFalse();
        await Assert.That(InterceptionRecorder.OnExceptionCalled).IsTrue();
    }
}
