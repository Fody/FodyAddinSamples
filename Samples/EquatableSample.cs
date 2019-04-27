using System;
using Equatable;
using Xunit;

public class EquatableSample
{
    [ImplementsEquatable]
    public class Target
    {
        [Equals]
        public string Property { get; set; }
    }

    [Fact]
    public void Run()
    {
        var left = new Target
        {
            Property = "Test",
        };

        Assert.True(left is IEquatable<Target>);

        var right = new Target
        {
            Property = "Test",
        };

        Assert.Equal(left, right);
        Assert.Equal(left.GetHashCode(), right.GetHashCode());
    }
}