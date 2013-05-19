using System;
using NUnit.Framework;

[TestFixture]
public class EmptyConstructorSample
{
    [Test]
    public void Run()
    {
        var target = Activator.CreateInstance<Target>();
        Assert.IsNotNull(target);
    }
}

public class Target
{
    public Target(int foo)
    {
        
    }
}