using System;
using Xunit;

public class BasicFodyAddinSample
{
    [Fact]
    public void Run()
    {
        var type = GetType().Assembly.GetType("Hello");
        var instance = (dynamic) Activator.CreateInstance(type);
        Assert.Equal("Hello World", instance.World());
    }
}