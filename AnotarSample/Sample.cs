using Anotar;
using NUnit.Framework;

[TestFixture]
public class ExplicitSample
{
    [Test]
    public void Run()
    {
        var getLog = LogCaptureBuilder.SetupNLog();
        MyMethod();

        Assert.AreEqual("Method: 'System.Void ExplicitSample::MyMethod()'. Line: ~18. TheMessage", getLog());
    }

    static void MyMethod()
    {
        Log.Debug("TheMessage");
    }

}