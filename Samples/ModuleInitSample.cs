using Xunit;

public class ModuleInitSample
{
    [Fact]
    public void Run() =>
        //ModuleInitializer.Initialize will have been called when this assembly was loaded.
        Assert.True(ModuleInitializer.InitializeCalled);
}

public static class ModuleInitializer
{
    public static void Initialize() =>
        InitializeCalled = true;

    public static bool InitializeCalled;
}