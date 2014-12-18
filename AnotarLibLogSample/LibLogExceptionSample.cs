using System;
using Anotar.LibLog;
using NUnit.Framework;

[TestFixture]
public class LibLogExceptionSample
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

        Assert.AreEqual("Exception occurred in 'Void MyMethod()'. ", CustomProvider.LastMessage);
        Assert.IsNotNull(CustomProvider.LastException);
    }

    [LogToDebugOnException]
    static void MyMethod()
    {
        throw new Exception("Foo");
    }

}