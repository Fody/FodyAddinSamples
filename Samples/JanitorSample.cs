using System;
// ReSharper disable NotAccessedField.Local

public class JanitorSample
{
    [Test]
    public async Task Run()
    {
        var disposable = new Disposable();
        disposable.Dispose();
        await Assert.That(DisposeTracker.HasDisposedBeenCalled).IsTrue();
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