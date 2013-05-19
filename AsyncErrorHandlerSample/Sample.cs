using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

[TestFixture]
public class AsyncErrorHandlerSample
{
    [Test]
    public async void Run()
    {
        var instance = new Target();
        instance.MethodWithThrow();
        //run and have a look at the debug window
        Thread.Sleep(10);
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
