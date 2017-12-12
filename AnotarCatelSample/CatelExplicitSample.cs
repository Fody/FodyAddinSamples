using Anotar.Catel;
using Xunit;

public class CatelExplicitSample
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