using Samples.Logging;

namespace AnotarLibLogSample
{
    public class LogCaptureBuilder
    {
        public static void Init()
        {
            LogProvider.SetCurrentLogProvider(new CustomProvider());
        }
    }
}