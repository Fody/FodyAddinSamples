using System;

// ReSharper disable once UnusedParameter.Local
public class EmptyConstructorSample
{
    [Test]
    public async Task Run()
    {
        var target = Activator.CreateInstance<Target>();
        await Assert.That(target).IsNotNull();
    }

    public class Target
    {
        public Target(int foo)
        {
        }
    }
}