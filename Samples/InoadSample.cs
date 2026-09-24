using System;
using System.Diagnostics;
using Ionad;

public class IonadSample
{
    [Test]
    public void Run()
    {
        DateTimeSubstitute.Current = new(2000, 1, 1);
        var time = DateTime.Now;
        Trace.WriteLine(time);
    }

    [StaticReplacement(typeof(DateTime))]
    public static class DateTimeSubstitute
    {
        public static DateTime Current;

        public static DateTime Now => Current;
    }
}