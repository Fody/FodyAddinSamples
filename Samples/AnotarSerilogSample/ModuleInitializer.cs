﻿namespace AnotarSerilogSample;

public static class ModuleInitializer
{
    public static void Initialize() =>
        LogCaptureBuilder.Init();
}