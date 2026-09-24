using System;
using System.Threading;
using System.Windows.Threading;
using Throttle;

public class ThrottleTests
{
    int throttledCalls;

    [Test]
    public async Task Run()
    {
        var dispatcher = Dispatcher.CurrentDispatcher;
        var callsBeforeDelay = -1;
        var callsAfterDelay = -1;

        _ = dispatcher.BeginInvoke(() =>
        {
            ThrottledMethod();
            Delay(5);
            ThrottledMethod();
            Delay(5);
            ThrottledMethod();
            Delay(5);
            ThrottledMethod();
            Delay(5);
            ThrottledMethod();
            Delay(5);
            callsBeforeDelay = throttledCalls;
            Delay(200);
            callsAfterDelay = throttledCalls;

            dispatcher.BeginInvokeShutdown(DispatcherPriority.ApplicationIdle);
        });

        Dispatcher.Run();

        await Assert.That(callsBeforeDelay).IsEqualTo(0);
        await Assert.That(callsAfterDelay).IsEqualTo(1);
    }

    static void Delay(int timeSpan)
    {
        var frame = new DispatcherFrame();
        var timer = new DispatcherTimer(TimeSpan.FromMilliseconds(timeSpan), DispatcherPriority.Normal, (_, _) => frame.Continue = false, Dispatcher.CurrentDispatcher);
        timer.Start();
        Dispatcher.PushFrame(frame);
    }

    [Throttled(typeof(TomsToolbox.Wpf.Throttle), 100)]
    void ThrottledMethod() =>
        Interlocked.Increment(ref throttledCalls);
}

