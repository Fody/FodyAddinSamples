using System;
using System.Threading.Tasks;
using Xunit;

public class AsyncErrorHandlerSample
{
    [Fact]
    public async Task Run()
    {
        try
        {

        var instance = new Target();
        await instance.MethodWithThrow().ConfigureAwait(false);
        //run and have a look at the debug window
        }
        catch
        {
        }
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