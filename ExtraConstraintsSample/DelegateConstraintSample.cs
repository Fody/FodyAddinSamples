using System;
using System.Diagnostics;
using System.Security;
using ExtraConstraints;
using NUnit.Framework;

[TestFixture]
public class DelegateConstraintSample
{
    [Test]
    public void InvalidDelegateConstraint()
    {
        var exception = Assert.Throws<VerificationException>(() => MethodWithDelegateConstraint(10));
        Assert.AreEqual("Method DelegateConstraintSample.MethodWithDelegateConstraint: type argument 'System.Int32' violates the constraint of type parameter 'T'.", exception.Message);
    }

    [Test]
    public void ValidDelegateConstraint()
    {
        MethodWithDelegateConstraint<Action>(() => Debug.WriteLine("foo"));
    }

    public void MethodWithDelegateConstraint<[DelegateConstraint(typeof(Action))] T>(T value)
    {
    }
}
