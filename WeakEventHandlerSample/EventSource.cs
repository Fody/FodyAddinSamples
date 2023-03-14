using System;

namespace WeakEventHandlerSample;

public class EventSource
{
    public event EventHandler<EventArgs> Event;

    public void OnEvent()
    {
        Event?.Invoke(this, EventArgs.Empty);
    }

    public bool HasEventHandlersAttached => Event != null;
}