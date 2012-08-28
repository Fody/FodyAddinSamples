public static class ModuleInitializer
{
    public static void Initialize()
    {
        InitializeCalled = true;
    }

    public static bool InitializeCalled;
}