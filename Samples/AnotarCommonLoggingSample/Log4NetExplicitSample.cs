using Anotar.CommonLogging;
using Xunit;

namespace AnotarCommonLoggingSample;

public class CommonLoggingExplicitSample
{
    [Fact]
    public void Run()
    {
        MyMethod();

        Assert.Equal("Method: 'Void MyMethod()'. Line: ~17. TheMessage", LogCaptureBuilder.LastMessage);
    }

    static void MyMethod() =>
        LogTo.Debug("TheMessage");
}