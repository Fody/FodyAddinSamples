using Anotar.Splat;
using Xunit;

namespace AnotarSplatSample;

public class SplatExplicitSample
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