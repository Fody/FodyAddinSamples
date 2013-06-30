using System;
using Anotar.Custom;
using NUnit.Framework;

[TestFixture]
public class CustomExceptionSample
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

        Assert.AreEqual("Exception occurred in 'Void MyMethod()'. ", Logger.LastMessage.Format);
    }

    [LogToDebugOnException]
    static void MyMethod()
    {
        throw new Exception("Foo");
    }

}