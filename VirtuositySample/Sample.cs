using NUnit.Framework;

[TestFixture]
public class Sample
{
    [Test]
    public void Run()
    {
        Assert.IsNotNull(GetType().GetMethod("Method").IsVirtual);
    }

    public void Method()
    {
    }

}