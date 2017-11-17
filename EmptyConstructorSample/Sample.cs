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
// ReSharper disable once UnusedParameter.Local
    public Target(int foo)
    {

    }
}