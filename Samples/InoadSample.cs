using System;
using System.Diagnostics;
using Ionad;
using Xunit;

public class IonadSample
{
    [Fact]
    public void Run()
    {
        DateTimeSubstitute.Current = new DateTime(2000, 1, 1);
        var time = DateTime.Now;
        Debug.WriteLine(time);
    }

    [StaticReplacement(typeof(DateTime))]
    public static class DateTimeSubstitute
    {
        public static DateTime Current;

        public static DateTime Now => Current;
    }
}