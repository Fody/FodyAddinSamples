using Resourcer;

public class ResourcerSample
{
    [Test]
    public async Task Run()
    {
        var fromResource = Resource.AsString("Resource.txt");
        await Assert.That(fromResource).IsEqualTo("Hello");
    }
}