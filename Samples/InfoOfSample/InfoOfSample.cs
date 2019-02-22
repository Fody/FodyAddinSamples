using System;
using System.Diagnostics;
using System.Reflection;
using Xunit;
// ReSharper disable UnusedVariable

public class InfoOfSample
{
    [Fact]
    public void Run()
    {
        Assert.NotNull(Info.OfMethod("Samples", "InternalClass", "Method"));
    }

    [Fact]
    public void PerfWithInfoOf()
    {
        var stopwatch = Stopwatch.StartNew();

        var methodInfo1 = Info.OfMethod("Samples", "InternalClass", "Method");
        for (var i = 0; i < 10000; i++)
        {
            var methodInfo = Info.OfMethod("Samples", "InternalClass", "Method");
        }
        stopwatch.Stop();
        Debug.WriteLine(stopwatch.ElapsedMilliseconds);
    }

    [Fact]
    public void PerfWithReflection()
    {
        var stopwatch = Stopwatch.StartNew();

        var type1 = Type.GetType("InternalClass, Samples");
        var methodInfo1 = type1.GetMethod("Method", BindingFlags.NonPublic | BindingFlags.Instance);
        for (var i = 0; i < 10000; i++)
        {
            var type = Type.GetType("InternalClass, Samples");
            var methodInfo = type.GetMethod("Method",BindingFlags.NonPublic| BindingFlags.Instance);
        }
        stopwatch.Stop();
        Debug.WriteLine(stopwatch.ElapsedMilliseconds);
    }
}