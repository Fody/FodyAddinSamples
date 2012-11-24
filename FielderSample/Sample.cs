using NUnit.Framework;

[TestFixture]
public class Sample
{
    [Test]
    public void Run()
    {
        Assert.IsNotNull(typeof(Target).GetProperty("MemberToConvert"));
    }
}

public class Target
{

    public string MemberToConvert;
}