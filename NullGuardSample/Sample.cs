using System;

public class NullGuardTests
{
    [Test]
    [Skip("Explicit")]
    public async Task Run()
    {
        var targetClass = new TargetClass();
        await Assert.That(() => targetClass.Method(null)).Throws<ArgumentNullException>();
    }
}

public class TargetClass
{
    public void Method(string param)
    {
    }
}