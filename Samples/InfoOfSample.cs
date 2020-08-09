using Xunit;
// ReSharper disable UnusedVariable

public class InfoOfSample
{
    [Fact]
    public void PerfWithInfoOf()
    {
        var methodInfo1 = Info.OfMethod("Samples", "InternalClass", "Method");
        for (var i = 0; i < 10000; i++)
        {
            Info.OfMethod("Samples", "InternalClass", "Method");
        }
    }
}