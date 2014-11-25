#if (!MONO)
using System;
using System.Diagnostics;
using System.Security;
using ExtraConstraints;
using NUnit.Framework;

[TestFixture]
public class DelegateConstraintSample
{
    [Test]
    [ExpectedException(
        ExpectedException = typeof (VerificationException),
        ExpectedMessage = "Method DelegateConstraintSample.MethodWithDelegateConstraint: type argument 'System.Int32' violates the constraint of type parameter 'T'.")]
    public void InvalidDelegateConstraint()
    {
        MethodWithDelegateConstraint(10);
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
#endif