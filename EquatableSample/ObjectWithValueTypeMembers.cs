using System;

using Equatable;

using Xunit;

using Target = ObjectWithValueTypeMembers;

[ImplementsEquatable]
public class ObjectWithValueTypeMembers
{
    [Equals]
    public string _field;

    [Equals]
    public int Property1 { get; set; }

    [Equals]
    public double Property2 { get; set; }

    public bool Property3 { get; set; }


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
            Property1 = 5,
            Property2 = 3.5,
            Property3 = false
        };

        var right = new Target
        {
            _field = "test",
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
            _field = "test",
            Property1 = 5,
            Property2 = 3.5,
            Property3 = true
        };

        var right = new Target
        {
            _field = "test",
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
            _field = "test",
            Property1 = 5,
            Property2 = 4.5,
            Property3 = true
        };

        var right = new Target
        {
            _field = "test",
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
            _field = "test",
            Property1 = 4,
            Property2 = 4.5,
            Property3 = true
        };

        var right = new Target
        {
            _field = "test",
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
            _field = "test",
            Property1 = 5,
            Property2 = 3.5,
            Property3 = false
        };

        var right = new Target
        {
            _field = "test1",
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
            _field = "test",
            Property1 = 5,
            Property2 = 3.5,
            Property3 = false
        };

        var right = new Target
        {
            _field = "Test",
            Property1 = 5,
            Property2 = 3.5,
            Property3 = false
        };

        Assert.NotEqual(left, right);
        Assert.NotEqual(left.GetHashCode(), right.GetHashCode());
    }

    [Fact]
    public void IsDifferentFromNull()
    {
        var left = new Target
        {
            _field = "test",
            Property1 = 5,
            Property2 = 3.5,
            Property3 = false
        };

#pragma warning disable xUnit2003 // Do not use equality check to test for null value
        Assert.NotEqual(null, left);
#pragma warning restore xUnit2003 // Do not use equality check to test for null value
    }
}
