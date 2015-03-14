using System;
using NUnit.Framework;

[TestFixture]
public class NameOfSample
{
    [Test]
    public void Run()
    {
		var localVariable = 42;
		Assert.IsTrue("localVariable" == Name.Of(localVariable));
		Assert.IsTrue("DoTheThing" == Name.Of(DoTheThing));
		Assert.IsTrue("Run" == Name.OfVoid(Run));
    }

	private static Boolean DoTheThing() {
		return false;
	}
}