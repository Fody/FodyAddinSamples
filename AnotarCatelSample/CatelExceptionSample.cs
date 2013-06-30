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

        Assert.AreEqual("[CatelExceptionSample] Exception occurred in 'Void MyMethod()'.  | [Exception] System.Exception: Foo\r\n   at CatelExceptionSample.MyMethod() in c:\\Code\\FodyAddinSamples\\AnotarCatelSample\\CatelExceptionSample.cs:line 25", LogCaptureBuilder.LastMessage);
    }

    [LogToDebugOnException]
    static void MyMethod()
    {
        throw new Exception("Foo");
    }

}