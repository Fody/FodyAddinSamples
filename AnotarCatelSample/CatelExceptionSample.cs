using System;
using Anotar.Catel;
using NUnit.Framework;

[TestFixture]
public class CatelExceptionSample
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

        Assert.IsTrue( LogCaptureBuilder.LastMessage.StartsWith("Exception occurred in 'Void MyMethod()'.  | [Exception] System.Exception: Foo\r\n   at CatelExceptionSample.MyMethod() in") );
    }

    [LogToDebugOnException]
    static void MyMethod()
    {
        throw new Exception("Foo");
    }

}