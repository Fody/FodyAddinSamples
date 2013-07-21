using Autofac;
using Fody.DependencyInjection;
using NUnit.Framework;

namespace AutofacFodySample
{
    [TestFixture]
    public class Sample
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Service>().As<IService>()
                .WithParameter("injectedValue", 5); 

            ConfigurableInjection.InitializeContainer(builder.Build());
        }

        [Test]
        public void AutofacServiceIsInjected()
        {
            var entity = new Entity(5);

            Assert.IsNotNull(entity.Service);
            Assert.IsInstanceOf(typeof(Service), entity.Service);

            Assert.AreEqual(25, entity.Service.MultiplyBy(5));
        }
    }

    [Configurable]
    public class Entity
    {
        int value;

        public IService Service { get; set; }

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
        int _injectedValue;

        public Service(int injectedValue)
        {
            _injectedValue = injectedValue;
        }

        public int MultiplyBy(int value)
        {
            return value * _injectedValue;
        }
    }

}
