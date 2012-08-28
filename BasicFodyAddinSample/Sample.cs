using System;
using NUnit.Framework;

[TestFixture]
public class Sample
{
    [Test]
    public void Run()
    {
        var type = GetType().Assembly.GetType("Hello");
        var instance = (dynamic) Activator.CreateInstance(type);
        Assert.AreEqual("Hello World", instance.World());
    }
}