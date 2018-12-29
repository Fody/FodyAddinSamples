using System;

namespace WeakEventHandlerSample
{
    using Xunit;

    public class EventSource
    {
        public event EventHandler<EventArgs> Event;

        public void OnEvent()
        {
            Event?.Invoke(this, EventArgs.Empty);
        }

        public bool HasEventHandlersAttached => Event != null;
    }

    public class EventSink
    {
        readonly EventSource _source;
        readonly Action<string> _eventTracer;

        public EventSink(EventSource source, Action<string> eventTracer)
        {
            _source = source;
            _eventTracer = eventTracer;
        }

        public void Subscribe()
        {
            _source.Event += Source_Event;
        }

        public void Unsubscribe()
        {
            _source.Event -= Source_Event;
        }

        [WeakEventHandler.MakeWeak]
        void Source_Event(object sender, EventArgs e)
        {
            _eventTracer("Event");
        }
    }

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
}
