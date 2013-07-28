using Anotar.Custom;
using NUnit.Framework;

[TestFixture]
public class CustomExplicitSample
{
    [Test]
    public void Run()
    {
        MyMethod();

        Assert.AreEqual("Method: 'Void MyMethod()'. Line: ~17. TheMessage", Logger.LastMessage.Format);
    }

    static void MyMethod()
    {
        LogTo.Debug("TheMessage");
    }

}