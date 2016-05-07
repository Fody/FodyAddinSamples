using NUnit.Framework;

[TestFixture]
public class WithSample
{
    [Test]
    public void Run()
    {
        var target = new Target(123, "Hello");
        Assert.AreEqual(456, target.With(456).IntValue);
        Assert.AreEqual("World", target.With("World").StringValue);
    }
}

public class Target
{
    public Target(int intValue, string stringValue)
    {
        this.IntValue = intValue;
        this.StringValue = stringValue;
    }

    public int IntValue { get; }

    public string StringValue { get; }

    // Needed for IntelliSense/Resharper support
    public Target With<T>(T value) => this;
}