using AnotarLibLogSample.Logging;

public class LogCaptureBuilder
{

    public static void Init()
    {
        LogProvider.SetCurrentLogProvider(new CustomProvider());
    }

}