using System;

/// <summary>
/// A IDisposable class we will use to verify that fields in the sample have been disposed
/// </summary>
[Janitor.SkipWeaving]
public class DisposeTracker : IDisposable
{
    public static bool HasDisposedBeenCalled;

    public void Dispose()
    {
        HasDisposedBeenCalled = true;
    }
}