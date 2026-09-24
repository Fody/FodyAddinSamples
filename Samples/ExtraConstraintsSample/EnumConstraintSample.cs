using System.Security;
using ExtraConstraints;
// ReSharper disable UnusedParameter.Local

public class EnumConstraintSample
{
    [Test]
    public async Task InvalidEnumConstraint()
    {
        var exception = await Assert.That(() => MethodWithEnumConstraint(10)).Throws<VerificationException>();
        await Assert.That(exception!.Message).IsEqualTo("Method EnumConstraintSample.MethodWithEnumConstraint: type argument 'System.Int32' violates the constraint of type parameter 'T'.");
    }

    [Test]
    public void ValidEnumConstraint() =>
        MethodWithEnumConstraint(MyEnum.Value);

    // ReSharper disable once MemberCanBeMadeStatic.Local
    void MethodWithEnumConstraint<[EnumConstraint(typeof(MyEnum))] T>(T value)
    {
    }

    public enum MyEnum
    {
        Value
    }
}