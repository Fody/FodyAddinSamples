using Anotar.LibLog;
using NUnit.Framework;

[TestFixture]
public class NLogExplicitSample
{
    [Test]
    public void Run()
    {
        MyMethod();

        Assert.AreEqual("Method: 'Void MyMethod()'. Line: ~17. TheMessage", CustomProvider.LastMessage);
    }

    static void MyMethod()
    {
        LogTo.Debug("TheMessage");
    }

}