using System;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class ObsoleteSample
{
    [Test]
    public void Run()
    {
        //ObsoleteExAttribute will have been conveted to an ObsoleteAttribute
        var obsoleteAttribute = (ObsoleteAttribute)typeof (TargetClass)
            .GetCustomAttributes(typeof (ObsoleteAttribute),false)
            .First();

        var expectedMessage = "Decided this class was a bad idea. Please use 'NewTargetClass' instead. Will be treated as an error from version '3.0.0'. Will be removed in version '4.0.0'.";
        Assert.AreEqual(expectedMessage, obsoleteAttribute.Message);
    }
}

[ObsoleteEx(
    Message = "Decided this class was a bad idea.",
    Replacement = "NewTargetClass",
    TreatAsErrorFromVersion = "3.0")]
public class TargetClass
{
}
