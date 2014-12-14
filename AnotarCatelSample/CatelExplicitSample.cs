using Anotar.Catel;
using NUnit.Framework;

[TestFixture]
public class CatelExplicitSample
{
    [Test]
    public void Run()
    {
        MyMethod();

        Assert.AreEqual("Method: 'Void MyMethod()'. Line: ~17. TheMessage", LogCaptureBuilder.LastMessage);
    }

    static void MyMethod()
    {
        LogTo.Debug("TheMessage");
    }

}