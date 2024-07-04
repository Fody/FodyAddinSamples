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

        public Disposable() =>
            disposeTracker = new();

        public void Dispose()
        {
            //must be empty
        }
    }

    /// <summary>
    /// A IDisposable class we will use to verify that fields in the sample have been disposed
    /// </summary>
    [Janitor.SkipWeaving]
    public class DisposeTracker : IDisposable
    {
        public static bool HasDisposedBeenCalled;

        public void Dispose() =>
            HasDisposedBeenCalled = true;
    }
}