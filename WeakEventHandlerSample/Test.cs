using System;

namespace WeakEventHandlerSample;

using Xunit;

public class Test
{
    [Fact]
    public void ExplicitUnsubscribe()
    {
        var lastEvent = (string)null;

        var source = new EventSource();

        var target = new EventSink(source, e => lastEvent = e);

        source.OnEvent();

        Assert.Null(lastEvent);

        target.Subscribe();

        Assert.True(source.HasEventHandlersAttached);

        source.OnEvent();

        Assert.Equal("Event", lastEvent);

        lastEvent = null;

        target.Unsubscribe();

        source.OnEvent();

        Assert.False(source.HasEventHandlersAttached);
        Assert.Null(lastEvent);
    }

    [Fact]
    public void TargetIsGarbageCollected()
    {
        var lastEvent = (string)null;

        var source = new EventSource();

        void Inner()
        {
            var target = new EventSink(source, e => lastEvent = e);

            source.OnEvent();

            Assert.Null(lastEvent);

            target.Subscribe();

            Assert.True(source.HasEventHandlersAttached);

            source.OnEvent();

            Assert.Equal("Event", lastEvent);

            lastEvent = null;
        }

        Inner();

        GCCollect();

        source.OnEvent();

        Assert.False(source.HasEventHandlersAttached);
        Assert.Null(lastEvent);
    }

    static void GCCollect()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.WaitForFullGCApproach();
    }
}