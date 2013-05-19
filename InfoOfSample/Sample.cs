using System;
using System.Diagnostics;
using System.Reflection;
using NUnit.Framework;

[TestFixture]
public class InfoOfSample
{
    [Test]
    public void Run()
    {
        Assert.IsNotNull(Info.OfMethod("InfoOfToReference", "InternalClass", "Method"));
    }

    [Test]
    public void PerfWithInfoOf()
    {
        var stopwatch = Stopwatch.StartNew();

        var methodInfo1 = Info.OfMethod("InfoOfToReference", "InternalClass", "Method");
        for (var i = 0; i < 10000; i++)
        {
            var methodInfo = Info.OfMethod("InfoOfToReference", "InternalClass", "Method");
        }
        stopwatch.Stop();
        Debug.WriteLine(stopwatch.ElapsedMilliseconds);
    }

    [Test]
    public void PerfWithReflection()
    {
        var stopwatch = Stopwatch.StartNew();

        var type1 = Type.GetType("InternalClass, InfoOfToReference");
        var methodInfo1 = type1.GetMethod("Method", BindingFlags.NonPublic | BindingFlags.Instance);
        for (var i = 0; i < 10000; i++)
        {
            var type = Type.GetType("InternalClass, InfoOfToReference");
            var methodInfo = type.GetMethod("Method",BindingFlags.NonPublic| BindingFlags.Instance);
        }
        stopwatch.Stop();
        Debug.WriteLine(stopwatch.ElapsedMilliseconds);
    }
}