using Anotar.Serilog;
using Xunit;

public class SerilogExplicitSample
{
    [Fact]
    public void Run()
    {
        MyMethod();

        var lastMessage = LogCaptureBuilder.LastMessage;
        Assert.Equal("Void MyMethod()", lastMessage.MethodName());
        Assert.Equal(19, lastMessage.LineNumber());
        Assert.Equal("TheMessage", lastMessage.MessageTemplate.Text);
    }

    static void MyMethod()
    {
        LogTo.Debug("TheMessage");
    }

}