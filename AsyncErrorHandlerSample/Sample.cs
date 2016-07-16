using System;
using System.Threading.Tasks;
using NUnit.Framework;

[TestFixture]
public class AsyncErrorHandlerSample
{
    [Test]
    public Task Run()
    {
        var instance = new Target();
        return instance.MethodWithThrow();
        //run and have a look at the debug window
    }
}

public class Target
{
    public async Task MethodWithThrow()
    {
        await Task.Delay(1);
        throw new Exception("MyException");
    }
}
