using System.Threading;
using System.Threading.Tasks;
using Fody;

// the tests set a SynchronizationContext on the current thread
[NotInParallel]
[ConfigureAwait(false)]
public class ConfigureAwaitTests
{
    [Test]
    public async Task Run()
    {
        var previous = SynchronizationContext.Current;
        var context = new CountingSynchronizationContext();
        SynchronizationContext.SetSynchronizationContext(context);
        try
        {
            await Task.Delay(30);
        }
        finally
        {
            SynchronizationContext.SetSynchronizationContext(previous);
        }

        // a plain check since the weaved ConfigureAwait(false) cannot be applied to the TUnit assertion awaiter
        if (context.PostCount != 0)
        {
            throw new("Expected the continuation to not be posted back to the captured SynchronizationContext");
        }
    }

    class CountingSynchronizationContext :
        SynchronizationContext
    {
        public int PostCount { get; private set; }

        public override void Post(SendOrPostCallback callback, object state)
        {
            PostCount++;
            base.Post(callback, state);
        }
    }
}
