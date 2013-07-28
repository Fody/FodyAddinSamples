using Fody.DependencyInjection;
using NUnit.Framework;
using Spring.Context.Support;

[TestFixture]
public class SpringSample
{
    [TestFixtureSetUp]
    public void Setup()
    {
        ConfigurableInjection.InitializeContainer(ContextRegistry.GetContext());
    }

    [Test]
    public void SpringServiceIsInjected()
    {
        var entity = new Entity(5);

        Assert.IsNotNull(entity.InjectedService);
        Assert.IsInstanceOf(typeof(Service), entity.InjectedService);

        // refer to springObjects.xml to see Service and Entity classes configuration
        Assert.AreEqual(25, entity.InjectedService.MultiplyBy(5));
    }
}

[Configurable]
public class Entity
{
    int value;

    public IService InjectedService { get; set; }

    public Entity(int value)
    {
        this.value = value;
    }
}

public interface IService
{
    int MultiplyBy(int value);
}

public class Service : IService
{
    int injectedValue;

    public Service(int injectedValue)
    {
        this.injectedValue = injectedValue;
    }

    public int MultiplyBy(int value)
    {
        return value * injectedValue;
    }
}