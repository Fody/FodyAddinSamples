using System;
using Xunit;

// ReSharper disable once UnusedParameter.Local
public class EmptyConstructorSample
{
    [Fact]
    public void Run()
    {
        var target = Activator.CreateInstance<Target>();
        Assert.NotNull(target);
    }

    public class Target
    {
        public Target(int foo)
        {
        }
    }
}