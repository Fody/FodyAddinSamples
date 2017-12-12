using Anotar.CommonLogging;
using Xunit;

public class CommonLoggingExplicitSample
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