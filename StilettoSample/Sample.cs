using System.Reflection;
using NUnit.Framework;
using Stiletto;
using Stiletto.Internal.Loaders.Codegen;

namespace StilettoSample
{
    [TestFixture]
    public class Sample
    {
        [Inject]
        public CoffeeMaker CoffeeMaker { get; set; }

        [Test]
        public void InjectYourStuff()
        {
            var container = Container.Create(typeof (DripCoffeeModule));
            container.Inject(this);
            Assert.IsNotNull(CoffeeMaker);
            CoffeeMaker.Brew();
        }

        [Test]
        public void InjectionCodeIsGeneratedByFody()
        {
            // Modules that have been woven by Stiletto have a [ProcessedAssembly] attribute.
            // Other code that minimizes reflection at runtime is also generated.

            var tAttr = typeof (ProcessedAssemblyAttribute);
            var assembly = Assembly.GetExecutingAssembly();
            var modules = assembly.GetModules();
            Assert.AreEqual(1, modules.Length);

            var module = modules[0];
            var attributes = module.GetCustomAttributes(tAttr, false);

            Assert.IsNotEmpty(attributes);
        }
    }
}
