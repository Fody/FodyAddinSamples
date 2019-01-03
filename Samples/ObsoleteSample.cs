using System;
using System.Linq;
using Xunit;

public class ObsoleteSample
{
    [Fact]
    public void Run()
    {
        //ObsoleteExAttribute will have been converted to an ObsoleteAttribute
        var obsoleteAttribute = (ObsoleteAttribute) typeof(TargetClass)
            .GetCustomAttributes(typeof(ObsoleteAttribute), false)
            .First();

        var expectedMessage = "Decided this class was a bad idea. Use `NewTargetClass` instead. Will be treated as an error from version 3.0.0. Will be removed in version 4.0.0.";
        Assert.Equal(expectedMessage, obsoleteAttribute.Message);
    }

    [ObsoleteEx(
        Message = "Decided this class was a bad idea.",
        ReplacementTypeOrMember = "NewTargetClass",
        TreatAsErrorFromVersion = "3.0")]
    public class TargetClass
    {
    }
}