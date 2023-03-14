using System;

namespace WeakEventHandlerSample;

public class EventSink
{
    EventSource source;
    Action<string> eventTracer;

    public EventSink(EventSource source, Action<string> eventTracer)
    {
        this.source = source;
        this.eventTracer = eventTracer;
    }

    public void Subscribe()
    {
        source.Event += Source_Event;
    }

    public void Unsubscribe()
    {
        source.Event -= Source_Event;
    }

    [WeakEventHandler.MakeWeak]
    void Source_Event(object sender, EventArgs e)
    {
        eventTracer("Event");
    }
}