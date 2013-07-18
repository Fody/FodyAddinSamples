using NUnit.Framework;

[TestFixture]
public class ImmutableSample
{
    [Test]
    public void Run()
    {
        Assert.IsTrue(typeof(Target).GetField("Field").IsInitOnly);
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