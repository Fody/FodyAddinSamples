using NUnit.Framework;
using Resourcer;

[TestFixture]
public class ResourcerSample
{
    [Test]
    public void Run()
    {
        var fromResource = Resource.AsString("SampleResource2.txt");
        Assert.AreEqual("Hello", fromResource);
        var fromResource2 = Resource.AsString("SampleResource4.txt");
        Assert.AreEqual("Hello", fromResource);
    }
}
