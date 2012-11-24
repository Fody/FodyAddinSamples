using NUnit.Framework;

[TestFixture]
public class Sample
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
    //    Field = "sdf";
    //}
}