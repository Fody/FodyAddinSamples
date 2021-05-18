using Xunit;

public class VirtuositySample
{
    [Fact]
    public void Run()
    {
        Assert.True(typeof(Target).GetProperty("Property")!.GetMethod.IsVirtual);
    }

    public class Target
    {
        public string Property { get; set; }
    }
}