using System;
using Anotar.Log4Net;
using NUnit.Framework;

[TestFixture]
public class Log4NetExceptionSample
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

        Assert.AreEqual("Exception occurred in 'System.Void Log4NetExceptionSample::MyMethod()'. ", LogCaptureBuilder.LastMessage);
    }

    [LogToDebugOnException]
    static void MyMethod()
    {
        throw new Exception("Foo");
    }

}