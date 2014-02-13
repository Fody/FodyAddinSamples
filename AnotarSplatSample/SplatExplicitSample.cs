using Anotar.Splat;
using NUnit.Framework;

[TestFixture]
public class SplatExplicitSample
{
    [Test]
    public void Run()
    {
        MyMethod();

        Assert.AreEqual("SplatExplicitSample: Method: 'Void MyMethod()'. Line: ~17. TheMessage", LogCaptureBuilder.LastMessage);
    }

    static void MyMethod()
    {
        LogTo.Debug("TheMessage");
    }

}