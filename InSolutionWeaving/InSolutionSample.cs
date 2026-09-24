
public class InSolutionSample
{
    [Test]
    public async Task Run()
    {
        var assembly = typeof(InSolutionSample).Assembly;
        var typeInjectedByModuleWeaver = assembly.GetType("Weavers.TypeInjectedByModuleWeaver");
        await Assert.That(typeInjectedByModuleWeaver).IsNotNull();
        var typeInjectedByNamedWeaver = assembly.GetType("Weavers.TypeInjectedByNamedWeaver");
        await Assert.That(typeInjectedByNamedWeaver).IsNotNull();
    }
}