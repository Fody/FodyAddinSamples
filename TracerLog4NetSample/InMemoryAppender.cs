using System.Collections.Generic;
using System.Diagnostics;
using log4net.Appender;
using log4net.Core;
using TracerAttributes;

namespace TracerLog4NetSample
{
    [NoTrace]
    public class InMemoryAppender : AppenderSkeleton
    {
        List<string> events = new List<string>();

        protected override void Append(LoggingEvent loggingEvent)
        {
            events.Add(string.Format("{0} {1} {2}", loggingEvent.LoggerName, loggingEvent.LocationInformation.MethodName,  loggingEvent.RenderedMessage));
        }

        public void PrintToDebug()
        {
            events.ForEach(item => Debug.Print(item));
        }

        public int EventCount => events.Count;
    }
}
