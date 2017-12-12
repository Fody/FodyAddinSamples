using Xunit;

public class VirtuositySample
{
    [Fact]
    public void Run()
    {
        Assert.True(typeof(Target).GetMethod("Method").IsVirtual);
    }
}

public class Target
{
    public void Method()
    {
    }
}