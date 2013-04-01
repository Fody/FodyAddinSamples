using Anotar.Log4Net;
using NUnit.Framework;

[TestFixture]
public class ExplicitSample
{
    [Test]
    public void Run()
    {
        MyMethod();

        Assert.AreEqual("Method: 'System.Void ExplicitSample::MyMethod()'. Line: ~17. TheMessage", LogCaptureBuilder.LastMessage);
    }

    static void MyMethod()
    {
        Log.Debug("TheMessage");
    }

}