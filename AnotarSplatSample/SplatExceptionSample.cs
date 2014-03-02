using System;
using Anotar.Splat;
using NUnit.Framework;

[TestFixture]
public class SplatExceptionSample
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

        var lastMessage = LogCaptureBuilder.LastMessage.Replace(Environment.NewLine, "");
        Assert.AreEqual(@"SplatExceptionSample: Exception occurred in 'Void MyMethod()'. : System.Exception: Foo   at SplatExceptionSample.MyMethod() in c:\Code\FodyAddinSamples\AnotarSplatSample\SplatExceptionSample.cs:line 26", lastMessage);
    }

    [LogToDebugOnException]
    static void MyMethod()
    {
        throw new Exception("Foo");
    }

}