using Anotar.LibLog;
using Xunit;

public class LibLogExplicitSample
{
    [Fact]
    public void Run()
    {
        MyMethod();

        Assert.Equal("Method: 'Void MyMethod()'. Line: ~17. TheMessage", CustomProvider.LastMessage);
    }

    static void MyMethod()
    {
        LogTo.Debug("TheMessage");
    }
}