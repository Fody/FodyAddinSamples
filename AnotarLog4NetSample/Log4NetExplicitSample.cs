using Anotar.Log4Net;
using NUnit.Framework;

[TestFixture]
public class Log4NetExplicitSample
{
    [Test]
    public void Run()
    {
        MyMethod();

        Assert.AreEqual("Method: 'Void MyMethod()'. Line: ~17. TheMessage", LogCaptureBuilder.LastMessage);
    }

    static void MyMethod()
    {
        Log.Debug("TheMessage");
    }

}