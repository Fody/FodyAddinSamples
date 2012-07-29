using NUnit.Framework;

[TestFixture]
public class Sample
{
    [Test]
    public void Run()
    {
        Assert.IsNotNull(GetType().GetProperty("MemberToConvert"));
    }

    public string MemberToConvert;
}