using System.Threading;
using System.Threading.Tasks;
using Fody;
using Xunit;

[ConfigureAwait(false)]
public class ConfigureAwaitSample
{
    [Fact]
    public async Task Run()
    {
        var beforeAwaitId = Thread.CurrentThread.ManagedThreadId;
        await Task.Delay(30);
        Assert.NotEqual(Thread.CurrentThread.ManagedThreadId, beforeAwaitId);
    }
}