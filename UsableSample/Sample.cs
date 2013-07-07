using System;
using NUnit.Framework;

[TestFixture]
public class UsableSample
{
    [Test]
    public void Run()
    {
        MethodWithDisposableVariable();
        Assert.IsTrue(Disposable.Disposed);
    }
    public static void MethodWithDisposableVariable()
    {
        var disposable = new Disposable();
        disposable.Method();
    }
}


public class Disposable : IDisposable
{
    public void Dispose()
    {
        Disposed = true;
    }

    public void Method()
    {
        
    }

    public static bool Disposed;
}
