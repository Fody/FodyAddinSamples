
using NUnit.Framework;
using Resourcer;

[TestFixture]
public class Sample
{
    [Test]
    public void Run()
    {
        var fromResource = Resource.AsString("SampleResource.txt");
        Assert.AreEqual("Hello", fromResource);
    }
}
