using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using log4net.Appender;
using log4net.Core;
using Tracer.Log4Net;
using TracerAttributes;

namespace TracerLog4NetSample
{
    [NoTrace]
    public class InMemoryAppender : AppenderSkeleton
    {
        private readonly List<string> _events = new List<string>();

        protected override void Append(LoggingEvent loggingEvent)
        {
            _events.Add(String.Format("{0} {1} {2}", loggingEvent.LoggerName, loggingEvent.LocationInformation.MethodName,  loggingEvent.RenderedMessage));
        }

        public void PrintToDebug()
        {
            _events.ForEach(item => Debug.Print(item));
        }

        public int EventCount
        {
            get { return _events.Count; }
        }
    }
}
