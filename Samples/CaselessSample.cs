using Xunit;

public class CaselessSample
{
    [Fact]
    public void Run()
    {
        var string1 = "sample_string";
        var string2 = "Sample_String";
        Assert.True(string2 == string1);
    }
}