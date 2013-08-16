using NUnit.Framework;

[TestFixture]
public class VirtuositySample
{
    [Test]
    public void Run()
    {
        Assert.IsTrue(GetType().GetMethod("Method").IsVirtual);
    }

    public void Method()
    {
    }

}