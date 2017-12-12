using Xunit;

public class CaselessSample
{
    [Fact]
    public void Run()
    {
        var string1 = "samplestring";
        var string2 = "SampleString";
        Assert.True(string2 == string1);
    }
}