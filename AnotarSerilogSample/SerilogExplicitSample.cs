using Anotar.Serilog;
using NUnit.Framework;

[TestFixture]
public class SerilogExplicitSample
{
    [Test]
    public void Run()
    {
        MyMethod();

        var lastMessage = LogCaptureBuilder.LastMessage;
        Assert.AreEqual("Void MyMethod()", lastMessage.MethodName());
        Assert.AreEqual(20, lastMessage.LineNumber());
        Assert.AreEqual("TheMessage", lastMessage.MessageTemplate.Text);
    }

    static void MyMethod()
    {
        LogTo.Debug("TheMessage");
    }

}