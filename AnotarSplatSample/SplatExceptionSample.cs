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
        Assert.AreEqual(@"SplatExceptionSample: Exception occurred in 'Void MyMethod()'. : System.Exception: Foo   at SplatExceptionSample.MyMethod()", lastMessage.Substring(0, lastMessage.LastIndexOf(" in ")));
        Assert.IsTrue(lastMessage.EndsWith(@"FodyAddinSamples\AnotarSplatSample\SplatExceptionSample.cs:line 27"));
    }

    [LogToDebugOnException]
    static void MyMethod()
    {
        throw new Exception("Foo");
    }

}