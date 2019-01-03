using System;
using Xunit;

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
// ReSharper disable once UnusedParameter.Local
        public Target(int foo)
        {
        }
    }
}