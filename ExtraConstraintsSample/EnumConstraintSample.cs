using System.Security;
using ExtraConstraints;
using NUnit.Framework;

[TestFixture]
public class EnumConstraintSample
{
    [Test]
    public void InvalidEnumConstraint()
    {
        var exception = Assert.Throws<VerificationException>(() => MethodWithEnumConstraint(10));
        Assert.AreEqual("Method EnumConstraintSample.MethodWithEnumConstraint: type argument 'System.Int32' violates the constraint of type parameter 'T'.", exception.Message);
    }

    [Test]
    public void ValidEnumConstraint()
    {
        MethodWithEnumConstraint(MyEnum.Value);
    }

    public void MethodWithEnumConstraint<[EnumConstraint(typeof(MyEnum))] T>(T value)
    {
    }
}

