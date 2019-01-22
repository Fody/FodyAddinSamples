using Xunit;

public class InSolutionSample
{
    [Fact]
    public void Run()
    {
        var assembly = typeof(InSolutionSample).Assembly;
        var typeInjectedByModuleWeaver = assembly.GetType("Weavers.TypeInjectedByModuleWeaver");
        Assert.NotNull(typeInjectedByModuleWeaver);
        var typeInjectedByNamedWeaver = assembly.GetType("Weavers.TypeInjectedByNamedWeaver");
        Assert.NotNull(typeInjectedByNamedWeaver);
    }
}