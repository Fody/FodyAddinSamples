using System;
using Xunit;

public class EmptyStringGuardSample
{
    [Fact]
    public void Run()
    {
        var targetClass = new TargetClass();
        Assert.Throws<ArgumentException>(() => targetClass.Method(string.Empty));
    }
}

public class TargetClass
{
    public void Method(string param)
    {
    }
}