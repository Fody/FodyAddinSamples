#if (!MONO)
using System.Security;
using NUnit.Framework;

[TestFixture]
public class EnumConstraintSample
{
    [Test]
    [ExpectedException(
        ExpectedException = typeof (VerificationException),
        ExpectedMessage = "Method EnumConstraintSample.MethodWithEnumConstraint: type argument 'System.Int32' violates the constraint of type parameter 'T'.")]
    public void InvalidEnumConstraint()
    {
        MethodWithEnumConstraint(10);
    }

    [Test]
    public void ValidEnumConstraint()
    {
        MethodWithEnumConstraint(MyEnum.Value);
    }

    public void MethodWithEnumConstraint<[EnumConstraint] T>(T value)
    {
    }
}

#endif