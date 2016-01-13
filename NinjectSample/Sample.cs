using Fody.DependencyInjection;
using Ninject;
using Ninject.Selection.Heuristics;
using NUnit.Framework;
// ReSharper disable NotAccessedField.Local

[TestFixture]
public class NinjectSample
{

    [Test]
    public void SpringServiceIsInjected()
    {
        IKernel kernel = new StandardKernel();
        kernel.Components.Add<IInjectionHeuristic, PropertyInjectionHeuristic>();
        kernel.Bind<IService>().To<Service>().WithConstructorArgument("injectedValue", 5);

        ConfigurableInjection.InitializeContainer(kernel);
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
