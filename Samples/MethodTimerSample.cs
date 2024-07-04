using System.Threading;
using MethodTimer;
using Xunit;

public class MethodTimerSample
{
    [Fact]
    [Time]
    public void MyMethod() =>
        //Run and have a look in the debug window
        Thread.Sleep(1500);
}