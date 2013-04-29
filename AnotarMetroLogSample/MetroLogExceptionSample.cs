using System;
using Anotar.MetroLog;
using NUnit.Framework;

[TestFixture]
public class MetroLogExceptionSample
{
    [Test]
    public void Run()
    {
        try
        {
           MyMethod();
        }
        catch
        {
        }

        Assert.AreEqual("Exception occurred in 'System.Void MetroLogExceptionSample::MyMethod()'. ", LogCaptureBuilder.LastMessage);
    }

    [LogToDebugOnException]
    static void MyMethod()
    {
        throw new Exception("Foo");
    }

}