using System.Threading;
using System.Threading.Tasks;
using Fody;
using NUnit.Framework;

[TestFixture]
[ConfigureAwait(false)]
public class ConfigureAwaitSample
{
    [Test]
    public async void Run()
    {
        var beforeAwaitId = Thread.CurrentThread.ManagedThreadId;
        await Task.Delay(30);
        Assert.AreNotEqual(Thread.CurrentThread.ManagedThreadId,beforeAwaitId);
    }
}

