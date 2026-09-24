using System;
using System.Diagnostics;
using System.Security;
using ExtraConstraints;
// ReSharper disable UnusedParameter.Local

public class DelegateConstraintSample
{
    [Test]
    public async Task InvalidDelegateConstraint()
    {
        var exception = await Assert.That(() => MethodWithDelegateConstraint(10)).Throws<VerificationException>();
        await Assert.That(exception!.Message).IsEqualTo("Method DelegateConstraintSample.MethodWithDelegateConstraint: type argument 'System.Int32' violates the constraint of type parameter 'T'.");
    }

    [Test]
    public void ValidDelegateConstraint() =>
        MethodWithDelegateConstraint(() => Debug.WriteLine("foo"));

    static void MethodWithDelegateConstraint<[DelegateConstraint(typeof(Action))] T>(T value)
    {
    }
}