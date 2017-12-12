using Xunit;

public class ModuleInitSample
{
    [Fact]
    public void Run()
    {
        //ModuleInitializer.Initialize will have been called when this assembly was loaded.
        Assert.True(ModuleInitializer.InitializeCalled);
    }
}