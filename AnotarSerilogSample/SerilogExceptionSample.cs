using System;
using Anotar.Serilog;
using NUnit.Framework;

[TestFixture]
public class SerilogExceptionSample
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

        var actual = LogCaptureBuilder.LastMessage.MessageTemplate.Text;
        Assert.AreEqual("Exception occurred in 'System.Void SerilogExceptionSample::MyMethod()'. ", actual);
    }

    [LogToDebugOnException]
    static void MyMethod()
    {
        throw new Exception("Foo");
    }

}