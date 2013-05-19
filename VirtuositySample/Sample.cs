using NUnit.Framework;

[TestFixture]
public class VirtuositySample
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