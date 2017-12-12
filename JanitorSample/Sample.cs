using System;
using Xunit;
// ReSharper disable NotAccessedField.Local

public class JanitorSample
{
    [Fact]
    public void Run()
    {
        var disposable = new Disposable();
        disposable.Dispose();
        Assert.True(DisposeTracker.HasDisposedBeenCalled);
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