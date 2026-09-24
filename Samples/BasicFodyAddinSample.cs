using System;

public class BasicFodyAddinSample
{
    [Test]
    public async Task Run()
    {
        var type = GetType().Assembly.GetType("Hello")!;
        var instance = (dynamic) Activator.CreateInstance(type)!;
        await Assert.That((object) instance.World()).IsEqualTo("Hello World");
    }
}