using System;

using Equatable;

using Xunit;

using Target = ObjectWithGenericTypeMembers;

// [ImplementsEquatable] => show a warning, if not annotated.
public class ObjectWithGenericTypeMembers
{
    [Equals]
    public string _field;

    [Equals]
    public Tuple<int, string> Property1 { get; set; }

    [Fact]
    public void ImplementsIEquatable()
    {
        var target = new Target();

        Assert.True(target is IEquatable<Target>);
    }

    [Fact]
    public void AreEqualWhenAllPropertiesAreEqual()
    {
        var left = new Target
        {
            _field = "test",
            Property1 = new Tuple<int, string>(5, "test"),
        };

        var right = new Target
        {
            _field = "test",
            Property1 = new Tuple<int, string>(5, "test"),
        };

        Assert.Equal(left, right);
        Assert.Equal(left.GetHashCode(), right.GetHashCode());
    }

    [Fact]
    public void AreDifferentWhenFirstTupleItemIsDifferent()
    {
        var left = new Target
        {
            _field = "test",
            Property1 = new Tuple<int, string>(5, "test"),
        };

        var right = new Target
        {
            _field = "test",
            Property1 = new Tuple<int, string>(6, "test"),
        };

        Assert.NotEqual(left, right);
        Assert.NotEqual(left.GetHashCode(), right.GetHashCode());
    }

    [Fact]
    public void AreDifferentWhenSecondTupleItemIsDifferent()
    {
        var left = new Target
        {
            _field = "test",
            Property1 = new Tuple<int, string>(5, "test"),
        };

        var right = new Target
        {
            _field = "test",
            Property1 = new Tuple<int, string>(5, "Test"),
        };

        Assert.NotEqual(left, right);
        Assert.NotEqual(left.GetHashCode(), right.GetHashCode());
    }
}

