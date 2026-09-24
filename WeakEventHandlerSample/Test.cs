using System;

namespace WeakEventHandlerSample;


public class Test
{
    [Test]
    public async Task ExplicitUnsubscribe()
    {
        var lastEvent = (string)null;

        var source = new EventSource();

        var target = new EventSink(source, e => lastEvent = e);

        source.OnEvent();

        await Assert.That(lastEvent).IsNull();

        target.Subscribe();

        await Assert.That(source.HasEventHandlersAttached).IsTrue();

        source.OnEvent();

        await Assert.That(lastEvent).IsEqualTo("Event");

        lastEvent = null;

        target.Unsubscribe();

        source.OnEvent();

        await Assert.That(source.HasEventHandlersAttached).IsFalse();
        await Assert.That(lastEvent).IsNull();
    }

    [Test]
    public async Task TargetIsGarbageCollected()
    {
        var lastEvent = (string)null;

        var source = new EventSource();
        string beforeSubscribe = null;
        var attached = false;
        string afterSubscribe = null;

        void Inner()
        {
            var target = new EventSink(source, e => lastEvent = e);

            source.OnEvent();

            beforeSubscribe = lastEvent;

            target.Subscribe();

            attached = source.HasEventHandlersAttached;

            source.OnEvent();

            afterSubscribe = lastEvent;

            lastEvent = null;
        }

        Inner();

        await Assert.That(beforeSubscribe).IsNull();
        await Assert.That(attached).IsTrue();
        await Assert.That(afterSubscribe).IsEqualTo("Event");

        GCCollect();

        source.OnEvent();

        await Assert.That(source.HasEventHandlersAttached).IsFalse();
        await Assert.That(lastEvent).IsNull();
    }

    static void GCCollect()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.WaitForFullGCApproach();
    }
}