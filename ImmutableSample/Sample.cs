using Xunit;

public class ImmutableSample
{
    [Fact]
    public void Run()
    {
        Assert.True(typeof(Target).GetField("Field").IsInitOnly);
    }
}

[Immutable]
public class Target
{
    public string Field;

    //uncomment this and you will get a build error
    //void BadMethodWithFieldWrite()
    //{
    //    Field = "aString";
    //}
}