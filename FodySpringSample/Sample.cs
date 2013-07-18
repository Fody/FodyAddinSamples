using FodySpring;
using NUnit.Framework;

namespace FodySpringSample
{
    [TestFixture]
    public class Sample
    {
        [Test]
        public void ServiceIsInjected()
        {
            var entity = new Entity(5);

            Assert.IsNotNull(entity.Service);
            Assert.IsInstanceOf(typeof(Service), entity.Service);

            // refer to SpringObjects.xml to see Service and Entity classes configuration
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
}
