using System;
using NServiceBus.Logging;

namespace AnotarNServiceBusSample
{
    public class LogCaptureBuilder
    {
        [ThreadStatic]
        public static string LastMessage;

        public static void Init()
        {
            LogManager.UseFactory(new LogCapture(s => LastMessage = s));
        }

    }
}