using NUnit.Framework;
using Resourcer;

[TestFixture]
public class ResourcerSample
{
    [Test]
    public void Run()
    {
        var fromResource = Resource.AsString("SampleResource.txt");
        Assert.AreEqual("Hello", fromResource);
    }
}
