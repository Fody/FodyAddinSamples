using System;
using System.Diagnostics;
using Ionad;
using NUnit.Framework;

[StaticReplacement(typeof (DateTime))]
public static class DateTimeSubstitute
{
    public static DateTime Current;

    public static DateTime Now => Current;
}

[TestFixture]
public class IonadSample
{
    [Test]
    public void Run()
    {
        DateTimeSubstitute.Current = new DateTime(2000,1,1);
        var time = DateTime.Now;
        Debug.WriteLine(time);
    }

}
