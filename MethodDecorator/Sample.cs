using NUnit.Framework;

[TestFixture]
public class Sample
{

    [Test]
    public void SimpleMethodSample()
    {
        InterceptionRecorder.Clear();
        Target.MyMethod();
        Assert.IsTrue(InterceptionRecorder.OnEntryCalled);
        Assert.IsTrue(InterceptionRecorder.OnExitCalled);
        Assert.IsFalse(InterceptionRecorder.OnExceptionCalled);
    }

    [Test]
    public void ExceptionMethodSample()
    {
        InterceptionRecorder.Clear();
        try
        {
            Target.MyExceptionMethod();
        }
        catch
        {
        }
        Assert.IsTrue(InterceptionRecorder.OnEntryCalled);
        Assert.IsFalse(InterceptionRecorder.OnExitCalled);
        Assert.IsTrue(InterceptionRecorder.OnExceptionCalled);
    }
}