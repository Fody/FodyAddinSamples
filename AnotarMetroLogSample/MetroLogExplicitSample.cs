using Anotar.MetroLog;
using NUnit.Framework;

[TestFixture]
public class MetroLogExplicitSample
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