using System;
using NUnit.Framework;

[TestFixture]
public class Sample
{
    [Test]
    public void Run()
    {
        var targetClass = new TargetClass();
        Assert.Throws<ArgumentNullException>(() => targetClass.Method(null));
    }
}
public class TargetClass
{
    public void Method(string param)
    {
        
    }
}