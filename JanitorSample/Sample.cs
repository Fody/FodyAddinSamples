using System;
using NUnit.Framework;
// ReSharper disable NotAccessedField.Local

[TestFixture]
public class JanitorSample
{
    [Test]
    public void Run()
    {
        var disposable = new Disposable();
        disposable.Dispose();
        Assert.IsTrue(DisposeTracker.HasDisposedBeenCalled);
    }

    public class Disposable : IDisposable
    {
        DisposeTracker disposeTracker;

        public Disposable()
        {
            disposeTracker = new DisposeTracker();
        }

        public void Dispose()
        {
            //must be empty
        }
    }

}