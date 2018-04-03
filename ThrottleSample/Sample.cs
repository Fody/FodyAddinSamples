using System;
using System.Threading;
using System.Windows.Threading;

using Throttle;

using Xunit;

using TomsToolbox.Desktop;

public class ThrottleSample
{
    int throttledCalls;

    [Fact]
    public void Run()
    {
        var dispatcher = Dispatcher.CurrentDispatcher;

        dispatcher.BeginInvoke(() =>
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
            Assert.Equal(0, throttledCalls);
            Delay(20);
            Assert.Equal(1, throttledCalls); 

            dispatcher.BeginInvokeShutdown(DispatcherPriority.ApplicationIdle);
        });

        Dispatcher.Run();
    }

    static void Delay(int timeSpan)
    {
        var frame = new DispatcherFrame();
        var timer = new DispatcherTimer(TimeSpan.FromMilliseconds(timeSpan), DispatcherPriority.Normal, (sender, args) => frame.Continue = false, Dispatcher.CurrentDispatcher);
        timer.Start();
        Dispatcher.PushFrame(frame);
    }


    [Throttled(typeof(TomsToolbox.Desktop.Throttle), 10)]
    void ThrottledMethod()
    {
        Interlocked.Increment(ref throttledCalls);
    }
}

