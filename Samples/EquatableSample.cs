using System;
using Equatable;

public class EquatableSample
{
    [ImplementsEquatable]
    public class Target
    {
        [Equals]
        public string Property { get; set; }
    }

    [Test]
    public async Task Run()
    {
        var left = new Target
        {
            Property = "Test",
        };

        await Assert.That(left is IEquatable<Target>).IsTrue();

        var right = new Target
        {
            Property = "Test",
        };

        await Assert.That(right).IsEqualTo(left);
        await Assert.That(right.GetHashCode()).IsEqualTo(left.GetHashCode());
    }
}