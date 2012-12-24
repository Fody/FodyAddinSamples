using System;
using Anotar;
using NUnit.Framework;

[TestFixture]
public class ExceptionSample
{
    [Test]
    public void Run()
    {
        var getLog = LogCaptureBuilder.SetupNLog();
        try
        {
           MyMethod();
        }
        catch
        {
        }

        Assert.AreEqual("Exception occurred in 'System.Void ExceptionSample::MyMethod()'. ", getLog());
    }

    [LogToDebugOnException]
    static void MyMethod()
    {
        throw new Exception("Foo");
    }

}