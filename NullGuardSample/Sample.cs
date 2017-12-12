using System;
using Xunit;

public class NullGuardSample
{
    [Fact(Skip = "Explicit")]
    public void Run()
    {
        var targetClass = new TargetClass();
        Assert.Throws<ArgumentNullException>(() => targetClass.Method(null));
    }
}

public class TargetClass
{
    public void Method(string param)
    {
    }
}