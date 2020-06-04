using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

public class MethodDecoratorSample
{
    [Fact]
    public void SimpleMethodSample()
    {
        InterceptionRecorder.Clear();
        Target.MyMethod();
        Assert.True(InterceptionRecorder.OnEntryCalled);
        Assert.True(InterceptionRecorder.OnExitCalled);
        Assert.False(InterceptionRecorder.OnExceptionCalled);
    }

    [Fact]
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
        Assert.True(InterceptionRecorder.OnEntryCalled);
        Assert.False(InterceptionRecorder.OnExitCalled);
        Assert.True(InterceptionRecorder.OnExceptionCalled);
    }
}
