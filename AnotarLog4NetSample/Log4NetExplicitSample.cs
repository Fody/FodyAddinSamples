using Anotar.Log4Net;
using Xunit;

public class Log4NetExplicitSample
{
    [Fact]
    public void Run()
    {
        MyMethod();

        Assert.Equal("Method: 'Void MyMethod()'. Line: ~16. TheMessage", LogCaptureBuilder.LastMessage);
    }

    static void MyMethod()
    {
        LogTo.Debug("TheMessage");
    }
}