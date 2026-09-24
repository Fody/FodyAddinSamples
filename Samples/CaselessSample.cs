
public class CaselessSample
{
    [Test]
    public async Task Run()
    {
        var string1 = "sample_string";
        var string2 = "Sample_String";
        await Assert.That(string2 == string1).IsTrue();
    }
}