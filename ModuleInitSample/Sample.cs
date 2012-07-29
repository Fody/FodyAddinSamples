using NUnit.Framework;

[TestFixture]
public class Sample
{
    [Test]
    public void Run()
    {
        //ModuleInitializer.Initialize will have been called when this assembly was loaded. 
        Assert.IsTrue(ModuleInitializer.InitializeCalled);
    }

}
public static class ModuleInitializer
{
    public static void Initialize()
    {
        InitializeCalled = true;
    }

    public static bool InitializeCalled;
}