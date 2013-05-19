using NUnit.Framework;

[TestFixture]
public class CaselessSample
{
    [Test]
    public void Run()
    {
        var string1 = "samplestring";
        var string2 = "SampleString";
        Assert.IsTrue(string2 == string1);
    }
}