using System;
using NUnit.Framework;

[TestFixture]
public class EmptyStringGuardSample
{
    [Test]
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