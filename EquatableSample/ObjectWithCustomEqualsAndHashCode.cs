using System;
using Equatable;
using Xunit;
using Target = ObjectWithCustomEqualsAndHashCode;

[ImplementsEquatable]
public class ObjectWithCustomEqualsAndHashCode
{
    [Equals]
    public string field;

    [Equals]
    public int Property1 { get; set; }

    public double Property2 { get; set; }

    public bool Property3 { get; set; }

    [CustomEquals]
    bool CustomEquals(ObjectWithCustomEqualsAndHashCode other)
    {
        return Equals(Property2, other.Property2);
    }

    [CustomGetHashCode]
    int CustomGetHashCode()
    {
        return Property2.GetHashCode();
    }

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
            field = "test",
            Property1 = 5,
            Property2 = 3.5,
            Property3 = false
        };

        var right = new Target
        {
            field = "test",
            Property1 = 5,
            Property2 = 3.5,
            Property3 = false
        };

        Assert.Equal(left, right);
        Assert.Equal(left.GetHashCode(), right.GetHashCode());
    }

    [Fact]
    public void AreEqualWhenAttributedPropertiesAreEqual()
    {
        var left = new Target
        {
            field = "test",
            Property1 = 5,
            Property2 = 3.5,
            Property3 = true
        };

        var right = new Target
        {
            field = "test",
            Property1 = 5,
            Property2 = 3.5,
            Property3 = false
        };

        Assert.Equal(left, right);
        Assert.Equal(left.GetHashCode(), right.GetHashCode());
    }

    [Fact]
    public void AreDifferentWhenOneAttributedPropertyIsDifferent()
    {
        var left = new Target
        {
            field = "test",
            Property1 = 5,
            Property2 = 4.5,
            Property3 = true
        };

        var right = new Target
        {
            field = "test",
            Property1 = 5,
            Property2 = 3.5,
            Property3 = false
        };

        Assert.NotEqual(left, right);
        Assert.NotEqual(left.GetHashCode(), right.GetHashCode());
    }

    [Fact]
    public void AreDifferentWhenAllAttributedPropertiesAreDifferent()
    {
        var left = new Target
        {
            field = "test",
            Property1 = 4,
            Property2 = 4.5,
            Property3 = true
        };

        var right = new Target
        {
            field = "test",
            Property1 = 5,
            Property2 = 3.5,
            Property3 = false
        };

        Assert.NotEqual(left, right);
        Assert.NotEqual(left.GetHashCode(), right.GetHashCode());
    }

    [Fact]
    public void AreDifferentWhenTheFieldIsDifferent()
    {
        var left = new Target
        {
            field = "test",
            Property1 = 5,
            Property2 = 3.5,
            Property3 = false
        };

        var right = new Target
        {
            field = "test1",
            Property1 = 5,
            Property2 = 3.5,
            Property3 = false
        };

        Assert.NotEqual(left, right);
        Assert.NotEqual(left.GetHashCode(), right.GetHashCode());
    }

    [Fact]
    public void AreDifferentWhenTheFieldIsDifferentInCase()
    {
        var left = new Target
        {
            field = "test",
            Property1 = 5,
            Property2 = 3.5,
            Property3 = false
        };

        var right = new Target
        {
            field = "Test",
            Property1 = 5,
            Property2 = 3.5,
            Property3 = false
        };

        Assert.NotEqual(left, right);
        Assert.NotEqual(left.GetHashCode(), right.GetHashCode());
    }
}