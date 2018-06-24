using System;
using Xunit;
using Xunit.Abstractions;

public class AssertMessageSample
{
    public AssertMessageSample(ITestOutputHelper output)
    {
        this.output = output;
    }

    ITestOutputHelper output;

    [Fact]
    public void Run()
    {
        var string1 = "sample_string";
        var string2 = "Sample_String";

        try
        {
            Assert.True(string2 == string1);
        }
        catch (Exception e)
        {
            output.WriteLine(e.Message);
        }
    }
}