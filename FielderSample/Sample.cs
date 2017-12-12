using Xunit;

public class FielderSample
{
    [Fact]
    public void Run()
    {
        Assert.NotNull(typeof(Target).GetProperty("MemberToConvert"));
    }
}

public class Target
{
    public string MemberToConvert;
}