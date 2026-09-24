
public class ModuleInitSample
{
    [Test]
    public async Task Run() =>
        //ModuleInitializer.Initialize will have been called when this assembly was loaded.
        await Assert.That(ModuleInitializer.InitializeCalled).IsTrue();
}

public static class ModuleInitializer
{
    public static void Initialize() =>
        InitializeCalled = true;

    public static bool InitializeCalled;
}