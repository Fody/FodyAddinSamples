using System;
using System.Threading.Tasks;

public class Target
{
    public async Task MethodWithThrow()
    {
        await Task.Delay(1);
        throw new Exception("MyExcpetion");
    }
}