using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            // refer to springobjects.xml to see Service and Entity classes configuration
            Assert.AreEqual(25, entity.Service.MultiplyBy(5));
        }
    }

    [Configurable]
    public class Entity
    {
        private readonly int _value;

        public IService Service { get; set; }

        public Entity(int value)
        {
            _value = value;
        }
    }

    public interface IService
    {
        int MultiplyBy(int value);
    }

    public class Service : IService
    {
        private readonly int _injectedValue;

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
